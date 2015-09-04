using System;
using System.Collections.Generic;
using System.Text;

namespace nTools.Utilities.Ranges
{
    /// <summary>
    /// RangeArray&lt;T, U&gt; overlaps the Dictionary&lt;Range&lt;T&gt;,U&gt; allowing for extra functionality
    /// <para>One of the things it adds is the ability to supply a param of type T, and it will lookup all ranges to find the key</para>
    /// <para>that contains the param, returning the Value stored at that location.</para>
    /// <para>Also, there is an optimized search available in case this houses many Key/Value pairs and needs to be looped through</para>
    /// <para>many times.</para>
    /// <para>It will only accept type T where T : IComparable&lt;T&gt; and also accepts a value of type U.</para>
    /// <para>There are no restrictions on type U</para>
    /// </summary>
    /// <typeparam name="T">the type of item that will make up the lower and upper bounds of a range for the key (T:IComparable&lt;T&gt;</typeparam>
    /// <typeparam name="U">the type of item that will be stored as the value. no restrictions on type</typeparam>
    public class RangeArray<T, U> : Dictionary<Range<T>,U> where T : IComparable<T>
    {
        #region Fields
        List<RangeError> _errors = new List<RangeError>();
        List<Range<T>> _rangeKeys = new List<Range<T>>();
        bool _isOptimized;

        #endregion

        #region Properties
        /// <summary>
        /// gets a readonly List of errors
        /// </summary>
        public IList<RangeError> Errors { get { return _errors.AsReadOnly(); } }
        /// <summary>
        /// gets a readonly list of Keys
        /// </summary>
        public IList<Range<T>> RangeKeys { get { return _rangeKeys.AsReadOnly(); } }
        /// <summary>
        /// returns whether the RangeArray has been optimized since the last time something was added to it
        /// </summary>
        public bool IsOptimized { get { return _isOptimized; } }

        #endregion

        #region Indexes
        /// <summary>
        /// get the stored value if the index is within a stored range, 
        /// <para>else, return newly constructed value and store the error to Errors</para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public U this[T index]
        {
            get
            {
                return FindValue(index);
            }
        }

        #endregion


        #region Cstrs
        public RangeArray()
            : base()
        {

        }

        #endregion

        /******
         * Methods:
         * 
         * U FindValue(T)
         * bool ContainsIndex(T)
         * void Optimize()
         * new void Add(Range<T>,U)
         * new bool Remove(Range<T>)
         * new void Clear()
         * 
         */
        #region Methods
        /// <summary>
        /// get the stored value if the index is within a stored range
        /// <para>else, return thows an exception </para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public U FindValue(T index)
        {
            if (_isOptimized)
            {
                int compResult;

                for (int x = 0; x < _rangeKeys.Count; x++)
                {
                    compResult = _rangeKeys[x].Lower.CompareTo(index);

                    //if range.Lower < index, checks if index <= range.Upper, if not, then keeps going, else returns true
                    //if range.Lower == index, then it returns true
                    //if range.Lower > index, it returns false, instead of searching through rest of ranges
                    switch (compResult)
                    {
                        case -1:
                            if (index.CompareTo(_rangeKeys[x].Upper) <= 0)
                            {
                                return base[_rangeKeys[x]]; //returns true iff the index is w/i bounds, else, continues til found or value < range.Lower
                            }
                            break;
                        case 0:
                            return base[_rangeKeys[x]];
                        case 1:
                            _errors.Add(new RangeError(index, "No ranges contained the index: " + index.ToString()));
                            throw new Exception(_errors[_errors.Count - 1].Msg);
                    }
                }
            }
            else
            {
                foreach (Range<T> tmpRange in base.Keys)
                {
                    if (tmpRange.Contains(index))
                    {
                        return base[tmpRange];
                    }
                }
            }
            _errors.Add(new RangeArray<T,U>.RangeError(index, "None of the ranges stored contain the index: " + index.ToString()));

            throw new Exception(_errors[_errors.Count - 1].Msg);

        }//end FindValue(T)

        /// <summary>
        /// looks for any possible ranges that contain the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ContainsIndex(T index)
        {
            //if optimized, then will search through
            if (_isOptimized)
            {
                int compResult;

                for (int x = 0; x < _rangeKeys.Count; x++)
                {
                    compResult = _rangeKeys[x].Lower.CompareTo(index);
                    
                    //if range.Lower < index, checks if index <= range.Upper, if not, then keeps going, else returns true
                    //if range.Lower == index, then it returns true
                    //if range.Lower > index, it returns false, instead of searching through rest of ranges
                    switch (compResult)
                    {
                        case -1:
                            if (index.CompareTo(_rangeKeys[x].Upper) <= 0)
                            {
                                return true; //returns true iff the index is w/i bounds, else, continues til found or value < range.Lower
                            }
                            break;
                        case 0:
                            return true;
                        case 1:
                            return false;
                    }
                }
            }
            else
            {
                foreach (Range<T> tmpRange in base.Keys)
                {
                    if (tmpRange.Contains(index))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// optimizes the indexing and search features for looking for indexes in multiple ranges
        /// <para>depending on number of ranges stored, might take a bit of time</para>
        /// <para>NOTE: it is important to optimize after entering in all key-value pairs if you plan on doing alot of searching/indexing</para>
        /// <para>because this will save time and make things more efficient in the long run</para>
        /// </summary>
        public void Optimize()
        {
            _rangeKeys.Sort(Range<T>.Compare);
            _isOptimized = true;
        }

        /// <summary>
        /// Adds the new range key and value pair
        /// <para>make sure to optimize before runing any full scale index based operations</para>
        /// </summary>
        /// <param name="newRange"></param>
        /// <param name="newValue"></param>
        new public void Add(Range<T> newRange, U newValue)
        {
            base.Add(newRange, newValue);
            _rangeKeys.Add(newRange);
            _isOptimized = false;
        }

        /// <summary>
        /// attempts to remove the key/value pair based on supplied key
        /// </summary>
        /// <param name="oldRange"></param>
        /// <returns></returns>
        new public bool Remove(Range<T> oldRange)
        {
            if (base.Remove(oldRange))
            {
                _rangeKeys.Remove(oldRange);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// clears all entries into the RangeArray
        /// </summary>
        new public void Clear()
        {
            _rangeKeys.Clear();
            base.Clear();
        }

        #endregion

        #region Dependant Classes
        /// <summary>
        /// RangeError for type RangeArray&lt;T,U&gt;
        /// </summary>
        public sealed class RangeError
        {
            #region Fields
            T _index;
            string _msg = "";
            #endregion

            #region Properties
            /// <summary>
            /// the index that was attempted to access
            /// </summary>
            public T Index { get{ return _index; } }
            /// <summary>
            /// the error message
            /// </summary>
            public string Msg { get { return _msg; } }
            #endregion

            #region Cstr
            /// <summary>
            /// constructor for setting up the RangeError. Note that no other methods are 
            /// <para>available, so set the error fields here and now</para>
            /// </summary>
            /// <param name="index"></param>
            /// <param name="value"></param>
            /// <param name="msg"></param>
            public RangeError(T index, string msg)
            {
                _index = index;
                _msg = msg;
            }//end cstr(T,U,string)
            #endregion

        }
        #endregion

    }



}
