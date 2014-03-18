using System;
using System.Text;

namespace JSTC.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder CompactWhiteSpaces(this StringBuilder sb)
        {
            if (sb.Length == 0) return sb;

            var start = 0;

            while (start < sb.Length)
            {
                if (Char.IsWhiteSpace(sb[start]))
                    start += 1;
                else break;
            }

            if (start == sb.Length)
            {
                sb.Length = 0;
                return sb;
            }

            var end = sb.Length - 1;

            while (end >= 0)
            {
                if (Char.IsWhiteSpace(sb[end]))
                    end -= 1;
                else break;
            }

            var dest = 0;
            var prevIsNotWhiteSpace = true;

            for (var i = start; i <= end; i += 1)
            {
                if (Char.IsWhiteSpace(sb[i]))
                {
                    if (prevIsNotWhiteSpace && (sb[i - 1] != '>' && sb[i + 1] != '<'))
                    {
                        prevIsNotWhiteSpace = false;
                        sb[dest] = ' ';
                        dest += 1;
                    }
                }
                else
                {
                    prevIsNotWhiteSpace = true;
                    sb[dest] = sb[i];
                    dest += 1;
                }
            }

            sb.Length = dest;

            return sb;
        }

        public static StringBuilder EscapeQuotes(this StringBuilder sb)
        {
            if (sb.Length == 0) return sb;
            sb.Replace("\"", "\\\"");
            return sb;
        }

        public static StringBuilder ClearTagWhiteSpace(this StringBuilder sb)
        {
            if (sb.Length == 0) return sb;

            //var start = sb.Length - 1;

            //for (var i = start; i >= 2; i -= 1)
            //{
            //    if (sb[i] == '<' && sb[i - 1] == ' ' && sb[i - 2] == '>')
            //    {
            //        sb.Remove(i - 1, 1);
            //        i -= 2;
            //    }
            //}

            return sb;
        }
    }
}
