using System;
using System.Text;

namespace StringCalculatorNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var cal = new StringCalculator();

            Console.WriteLine(cal.Addition("5,10"));
            Console.WriteLine(cal.Addition("999,9"));
            Console.WriteLine(cal.Addition(",10,cccc"));
            Console.ReadLine();
        }
    }


    public class StringCalculator
    {
        private readonly char[] delimiter = { ',' };
        public const string MaximumTwoNumberMessage = "Should provide no more than 2 numbers";
        public StringCalculator()
        {
        }

        public string Addition(string st)
        {
            string[] nums = ParseString(st, delimiter);
            checkCountOfNums(nums);
            string temp = string.Empty;
            foreach (string s in nums)
            {

                temp = PerformAddition(temp, VerifyNumber(s));
            }

            int count = 0;
            //remove leading 0
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '0') count++;
                else break;
            }
            return temp.Substring(count);
        }

        public string[] ParseString(string st, char[] delimiter)
        {
            return st.Split(delimiter);
        }

        private void checkCountOfNums(string[] st)
        {
            if (st.Length > 2)
            {
                throw new ArgumentException(MaximumTwoNumberMessage);
            }
        }
       

        private string PerformAddition(string s1, string s2)
        {
            char[] result = new char[Math.Max(s1.Length, s2.Length) + 1];

            int temp = 0;
            int i = s1.Length - 1;
            int j = s2.Length - 1;
            int k = result.Length - 1;
            while (k >= 0)
            {
                if (i >= 0) temp += s1[i--] - '0';
                if (j >= 0) temp += s2[j--] - '0';
                result[k--] = Convert.ToChar(temp % 10 + '0');
                temp = temp / 10;
            }

            return new string(result);

        }

        private string VerifyNumber(string st)
        {
            if (String.IsNullOrWhiteSpace(st)) return string.Empty;

            foreach (char c in st)
            {
                if (c - '0' > 9 || c - '0' < 0)
                    return string.Empty;
            }
            return st;
        }
    }
}
