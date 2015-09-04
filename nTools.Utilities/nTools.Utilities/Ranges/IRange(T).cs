using System;
using System.Collections.Generic;
using System.Text;

namespace nTools.Utilities.Ranges
{
    interface IRange<T> : IComparable<Range<T>>, IComparable<T> where T : IComparable<T>
    {
        #region Properties
        T Lower { get; }
        T Upper { get; }
        #endregion

        #region Methods
        bool Contains(T val);
        bool OutsideOf(Range<T> other);
        int CompareTo(T other);
        int CompareTo(Range<T> other);
        bool Equals(object other);
        bool Equals(Range<T> other);
        bool Equals(T other);
        #endregion

    }
}
