using System.Text;

namespace Task1
{
    internal class RandomStrings
    {
        private readonly string lettersEng = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string lettersRu = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮеЕеЕ";
        private readonly Random random = new();
        // получение строки согласно заданию
        public string RandomString()
        {
            StringBuilder myRandomS = new(58);
            RandomDate(ref myRandomS);
            RandomLetters(lettersEng, ref myRandomS);
            RandomLetters(lettersRu, ref myRandomS);
            RandomNumberRange(ref myRandomS);
            RandomNumberRange1_20(ref myRandomS);


            return myRandomS.ToString();
        }

        // получение рандомной даты 
        private void RandomDate(ref StringBuilder myRandomS)
        {
            int randomYear = random.Next(DateTime.Now.Year - 5, DateTime.Now.Year);
            int randomMonth = random.Next(1, 12);
            int randomDay = random.Next(1, DateTime.DaysInMonth(randomYear, randomMonth));
            DateTime date = new(randomYear, randomMonth, randomDay);
            _ = myRandomS.Append(date.ToShortDateString());
        }

        // получение рандомной целого 
        private void RandomNumberRange(ref StringBuilder myRandomS)
        {
            int number;
            do
            {
                number = random.Next(1, 100000000);
            }
            while (number % 2 == 0);
            _ = myRandomS.Append("||" + number);
        }

        // получение рандомного дробного
        private void RandomNumberRange1_20(ref StringBuilder myRandomS)
        {
            float number = (float)random.Next(100000000, 2000000000) / 100000000;
            _ = myRandomS.Append("||" + number + "||");
        }

        // получение рандомных 10 букв 
        private void RandomLetters(string myString, ref StringBuilder myRandomS)
        {
            int index;
            _ = myRandomS.Append("||");
            for (int i = 0; i < 10; i++)
            {
                index = random.Next(0, myString.Length - 1);
                _ = myRandomS.Append(myString[index]);
            }
        }
    }
}
