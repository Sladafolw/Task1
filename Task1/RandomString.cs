using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class RandomStrings
    {
        readonly string lettersEng = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string lettersRu = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮеЕеЕ";
        Random random = new Random();
        // получение строки согласно заданию
        public string RandomString()
        {
            StringBuilder myRandomS = new StringBuilder(58);
            RandomDate(ref myRandomS);
            RandomLetters(lettersEng, ref myRandomS);
            RandomLetters(lettersRu, ref myRandomS);
            RandomNumberRange(ref myRandomS);
            RandomNumberRange1_20(ref myRandomS);
            return myRandomS.ToString();
        } // получение рандомной даты 
        void RandomDate(ref StringBuilder myRandomS)
        {
            var randomYear = random.Next(DateTime.Now.Year - 5, DateTime.Now.Year);
            var randomMonth = random.Next(1, 12);
            var randomDay = random.Next(1, DateTime.DaysInMonth(randomYear, randomMonth));
            DateTime date = new DateTime(randomYear, randomMonth, randomDay);
            myRandomS.Append(date.ToShortDateString());
        }// получение рандомной целого 
        void RandomNumberRange(ref StringBuilder myRandomS)
        {
            int number;
            do
                number = random.Next(1, 100000000);
            while (number % 2 == 0);
            myRandomS.Append("||" + number);
        }// получение рандомного дробного
        void RandomNumberRange1_20(ref StringBuilder myRandomS)
        {
            float number = (float)random.Next(100000000, 2000000000) / 100000000;
            myRandomS.Append("||" + number + "||");
        }// получение рандомных 10 букв 
        void RandomLetters(string myString, ref StringBuilder myRandomS)
        {
            int index;
            myRandomS.Append("||");
            for (int i = 0; i < 10; i++)
            {
                index = random.Next(0, myString.Length - 1);
                myRandomS.Append(myString[index]);
            }
        }
    }
}
