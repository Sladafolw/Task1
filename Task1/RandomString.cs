using System.Text;

namespace Task1
{
    internal class RandomStrings
    {
        private readonly string lettersEng = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string lettersRu = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮеЕеЕ";
        private readonly Random random = new ();

        // getting a string according to the assignment
        public string RandomString()
        {
            StringBuilder myRandomS = new (58);
            this.RandomDate(ref myRandomS);
            this.RandomLetters(this.lettersEng, ref myRandomS);
            this.RandomLetters(this.lettersRu, ref myRandomS);
            this.RandomNumberRange(ref myRandomS);
            this.RandomNumberRange1_20(ref myRandomS);
            return myRandomS.ToString();
        }

        // getting a random date
        private void RandomDate(ref StringBuilder myRandomS)
        {
            int randomYear = this.random.Next(DateTime.Now.Year - 5, DateTime.Now.Year);
            int randomMonth = this.random.Next(1, 12);
            int randomDay = this.random.Next(1, DateTime.DaysInMonth(randomYear, randomMonth));
            DateTime date = new(randomYear, randomMonth, randomDay);
            myRandomS.Append(date.ToShortDateString());
        }

        // getting a random integer
        private void RandomNumberRange(ref StringBuilder myRandomS)
        {
            int number;
            do
            {
                number = this.random.Next(1, 100000000);
            }
            while (number % 2 == 0);
            myRandomS.Append("||" + number);
        }

        // getting a random fractional
        private void RandomNumberRange1_20(ref StringBuilder myRandomS)
        {
            float number = (float)this.random.Next(100000000, 2000000000) / 100000000;
            myRandomS.Append("||" + number + "||");
        }

        // getting random 10 letters
        private void RandomLetters(string myString, ref StringBuilder myRandomS)
        {
            int index;
            myRandomS.Append("||");
            for (int i = 0; i < 10; i++)
            {
                index = this.random.Next(0, myString.Length - 1);
                myRandomS.Append(myString[index]);
            }
        }
    }
}
