using System.Linq;

namespace CompleteApp.Business.Utils
{
    public class StringUtils
    {
        public static string OnlyNumbers(string value)
        {
            return value.Where(char.IsDigit).Aggregate(string.Empty, (current, c) => current + c);
        }

        public static bool HasLength(string value, int size)
        {
            return value.Length == size;
        }

        public static bool IsInBlackList(string value, string[] blackList)
        {
            return blackList.Contains(value);
        }
    }
}
