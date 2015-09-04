using System;
using System.Collections.Generic;
using System.Text;

namespace nTools.Utilities.Ranges
{
    public class Range<T> : IRange<T>, IComparable<Range<T>>, IComparable<T> 
           where T : IComparable<T>
    {
        #region Fields
        T _lower;
        T _upper;
        #endregion

        #region Properties
        /// <summary>
        /// get the lower bound of the range
        /// </summary>
        public T Lower { get { return _lower; } }
        /// <summary>
        /// get the upper bound of the range
        /// </summary>
        public T Upper { get { return _upper; } }
        #endregion

        #region Cstr
        /// <summary>
        /// constructor handling type T. if your lower is greater than your upper, then they will be swapped for you
        /// </summary>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        public Range(T lower, T upper)
        {
            if (lower.CompareTo(upper) > 0)
            {
                _lower = upper;
                _upper = lower;
            }
            else
            {
                _lower = lower;
                _upper = upper;
            }
        }//end cstr(T,T)
        #endregion

        #region Methods

        #region Contains
        /// <summary>
        /// returns bool whether the element fits within the bounds of the range
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            return element.CompareTo(_lower) >= 0 && element.CompareTo(_upper) <= 0;
        }//end Contains(T)

        /// <summary>
        /// returns bool whether the supplied range fits within the bounds of the range
        /// </summary>
        /// <param name="otherRange"></param>
        /// <returns></returns>
        public bool Contains(Range<T> otherRange)
        {
            return _lower.CompareTo(otherRange.Lower) <=0 && _upper.CompareTo(otherRange.Upper) >=0;
        }//end Contains(IRange<T>)
        #endregion

        #region CompareTo
        /// <summary>
        /// <para>compares this range to another</para>
        /// <para>if this one contains the all of the other or the other contains all of this one, then it returns 0</para>
        /// <para>if the lower bound of this one is larger than the upper bound of the other one, it returns 1</para>
        /// <para>if the upper bound of this one is smaller than the lower bound of the other one, it returns -1</para>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Range<T> other)
        {
            if (Equals(other))
            {
                return 0;
            }
            else if (_lower.CompareTo(other._upper) >= 0) 
            { 
                return 1; 
            }
            else 
            { 
                return -1; 
            }
        }//end CompareTo(Range<T>)

        /// <summary>
        /// <para>compares this range to an element</para>
        /// <para>if this range contains the element, it returns 0</para>
        /// <para>if the lower bound is larger than the element, it returns 1</para>
        /// <para>if the upper bound is smaller than the element, it returns -1</para>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(T other)
        {
            if (Equals(other))
            {
                return 0;
            }
            else if (_lower.CompareTo(other) >= 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }//end CompareTo(T)

        /// <summary>
        /// compares two ranges, returning left.CompareTo(right)
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int Compare(Range<T> left, Range<T> right)
        {
            return left.CompareTo(right);
        }//end Compare(Range<T>,Range<T>)

        #endregion //CompareTo

        #region Equals
        /// <summary>
        /// if this range contains all of other or other contains this whole range, it returns true, else false
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Range<T> other)
        {
            return Contains(other) || other.Contains(this);
        }//end Equals(Range<T>)

        /// <summary>
        /// if this range contains T other, then it returns true, else false
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(T other)
        {
            return Contains(other);
        }//end Equals(T)

        #endregion

        #region OutsideOf
        /// <summary>
        /// returns true if other does not contain this whole range
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool OutsideOf(Range<T> other)
        {
            return !other.Contains(this);
        }//end OutsideOf
        #endregion

        #region Intersects
        /// <summary>
        /// returns whether or not both ranges intersect at least at one point
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Intersects(Range<T> other)
        {
            return Contains(other.Lower) || Contains(other.Upper) || other.Contains(_lower) || other.Contains(_upper);
        }//end Intersects(Range<T>)
        #endregion

        #region OperatorOverloads

        #region Operator==
        /// <summary>
        /// if this range contains all of other range or other contains this whole range, it returns true, else false
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Range<T> left, Range<T> right)
        {
            return left.Equals(right);
        }//end operator==(Range<T>,Range<T>)

        /// <summary>
        /// if this range contains T other, then it returns true, else false
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Range<T> left, T right)
        {
            return left.Contains(right);
        }//end operator==(Range<T>,T)
        #endregion //operator==

        #region Operator!=
        /// <summary>
        /// returns true if right is completely contained by left or left is completely contained by right, else false
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Range<T> left, Range<T> right)
        {
            return !(left == right);
        }//end operator!=(Range<T>,Range<T>)

        /// <summary>
        /// returns true if right is not contained by left, else false
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Range<T> left, T right)
        {
            return !(left == right);
        }//end operator!=(Range<T>,T)
        #endregion

        #endregion

        /// <summary>
        /// returns the string.Format of the type, lower bound and upper bound
        /// <para>Exa:</para>
        /// <para>Range&lt;int&gt;[2 -> 8]</para>
        /// </summary>
        /// <returns></returns>
        public override string  ToString()
        {
            return string.Format("Range<{0}>[{1} -> {2}]", typeof(T), _lower, _upper);
        }

        #endregion
    }
}
