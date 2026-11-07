using System;
using System.Collections;
namespace PlacesLib
{
    public class NameLengthComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Place a = (Place)x;
            Place b = (Place)y;
            int r = a.Name.Length.CompareTo(b.Name.Length);
            if (r != 0) return r;
            return string.Compare(a.Name, b.Name, StringComparison.CurrentCulture);
        }
    }
}