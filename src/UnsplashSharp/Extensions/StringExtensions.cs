namespace UnsplashSharp.Extensions
{
    internal static class StringExtensions
    {
        internal static bool IsNeitherNullNorEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str)
                && !string.IsNullOrWhiteSpace(str);
        }
    }
}
