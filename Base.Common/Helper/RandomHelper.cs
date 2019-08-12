using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Common.Helper
{
    public sealed class RandomHelper
    {
        private static readonly Random randomSeed = new Random();

        public static bool GetRandomBool()
        {
            return (randomSeed.NextDouble() > 0.5);
        }

        public static DateTime GetRandomDateTime(DateTime min, DateTime max)
        {
            if (max <= min)
            {
                throw new ArgumentException("开始时间必须小于结束时间");
            }
            long ticks = min.Ticks;
            double num3 = ((Convert.ToDouble(max.Ticks) - Convert.ToDouble(ticks)) * randomSeed.NextDouble()) + Convert.ToDouble(ticks);
            return new DateTime(Convert.ToInt64(num3));
        }

        public static string GetRandomNum(int len)
        {
            StringBuilder builder = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                builder.Append(randomSeed.Next(9));
            }
            return builder.ToString();
        }

        public static int GetRandomNumber(int minimal, int maximal)
        {
            return randomSeed.Next(minimal, maximal);
        }

        public static string GetRandomString(string pwdchars, int len)
        {
            StringBuilder builder = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                builder.Append(pwdchars[randomSeed.Next(pwdchars.Length)]);
            }
            return builder.ToString();
        }

        public static string GetRandomStringByTime()
        {
            return (DateTime.Now.ToString("yyyyMMddHHmmssfff") + GetRandomNum(4));
        }

        public static string GetRandWord(int len, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder(len);
            int num = lowerCase ? 0x61 : 0x41;
            for (int i = 0; i < len; i++)
            {
                builder.Append((char)((ushort)((26.0 * randomSeed.NextDouble()) + num)));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 根据26个字母（大小写）和1~9数字组成的字符串中随机生成一定长度的字符串
        /// </summary>
        /// <param name="len">长度</param>
        /// <returns>返回字符串</returns>
        public static string CreateRandomStr(int len)
        {
            return GetRandomString("123456789abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ", len);
        }
        /// <summary>
        /// 生成随机字母
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        public static string RandNum(int Length, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(3);
            char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string result = "";
            int n = Pattern.Length;
            Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int rnd = random.Next(0, n);
                result += Pattern[rnd];
            }
            return result;
        }
    }
}
