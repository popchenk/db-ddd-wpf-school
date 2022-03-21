using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Model
{
    public class Card
    {
        public string cardNum { get; }
        public int cvv { get; }
        public string expiration { get; }


        public Card(string cardNum, int cvv, string expiration)
        {
            if (String.IsNullOrEmpty(cardNum)) this.cardNum = GenerateCardNum();
            else this.cardNum = cardNum;
            this.cvv = cvv;
            this.expiration = expiration;
        }

        private string GenerateCardNum()
        {
            Random rnd = new Random();
            
                string cardNumber = string.Empty;

                for (int i = 0; i < 16; i++)
                {
                    cardNumber += rnd.Next(0, 9).ToString();
                }
                if (Int32.Parse(GenerateLuhnNumber(cardNumber)) > 9)
                    throw new Exception("Invalid card Number");

            return cardNumber;

        }

        public string GenerateLuhnNumber(string baseNumber)
        {
            if (!double.TryParse(baseNumber, out double baseNumberInt))
                throw new Exception($"Field contains non-numeric character(s) : {baseNumber}");

            var step2 = string.Empty;
            for (var index = baseNumber.Length - 1; index >= 0; index -= 2)
            {
                var doubleTheValue = (int.Parse(baseNumber[index].ToString())) * 2;

                if (doubleTheValue > 9)
                    doubleTheValue = Math.Abs(doubleTheValue).ToString().Sum(c => Convert.ToInt32(c.ToString()));

                step2 = step2.Insert(0, (index != 0 ? baseNumber[index - 1].ToString() : "") + doubleTheValue);
            }
            var step3 = Math.Abs(Convert.ToDouble(step2)).ToString(CultureInfo.InvariantCulture).Sum(c => Convert.ToDouble(c.ToString())).ToString(CultureInfo.InvariantCulture);

            var lastDigitStep3 = Convert.ToInt32(step3[step3.Length - 1].ToString());
            string checkDigit = "0";

            if (lastDigitStep3 != 0)
                checkDigit = (10 - lastDigitStep3).ToString();

            return checkDigit;
        }

    }
}
