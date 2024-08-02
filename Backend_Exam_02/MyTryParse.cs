using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02
{
    internal class MyTryParse
    {
        public delegate bool TryParseDelegate<T>(string input, out T result);

        public static T loopUntilParsed<T>(Action printStatement, TryParseDelegate<T> parse)
        {
            T res;
            bool isParsed = false;
            do
            {
                printStatement();
                isParsed = parse(Console.ReadLine(), out res);
            } while (!isParsed);

            return res;
        }

        public static T loopUntilParsed<T>(Action printStatement, TryParseDelegate<T> parse, Predicate<T> pred)
        {
            T res;
            do
            {
                res = loopUntilParsed(printStatement, parse);
            } while (!pred(res));

            return res;
        }

        public static string loopUntilNotEmptyString(string request)
        {
            string res;
            do
            {
                Console.WriteLine(request);
                res = Console.ReadLine() ?? "";
            } while (res.Equals(""));

            return res;
        }
    }
}
