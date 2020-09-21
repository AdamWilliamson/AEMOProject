using System.Collections.Generic;

namespace System
{
    public static class StringExtensions
    {
        // https://stackoverflow.com/questions/2641326/finding-all-positions-of-substring-in-a-larger-string-in-c-sharp
        public static IEnumerable<int> AllIndexesOf(this string source, string subString)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentException("The source string should not be empty", "source");
            if (string.IsNullOrEmpty(subString)) throw new ArgumentException("The substring should not be empty", "subString");

            for (int index = 0; ; index += subString.Length)
            {
                index = source.IndexOf(subString, index);

                if (index != -1)
                {
                    yield return index;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
