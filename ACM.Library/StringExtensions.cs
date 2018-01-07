using System.Threading;

namespace ACM.Library
{
    public static class StringExtensions
    {
        public static string ConvertToTitleCase(this string source)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(source);
        }
    }
}
