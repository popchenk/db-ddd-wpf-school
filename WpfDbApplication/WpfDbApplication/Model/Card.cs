using System;
using System.Collections.Generic;
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
            this.cardNum = cardNum;
            this.cvv = cvv;
            this.expiration = expiration;
        }


    }
}
