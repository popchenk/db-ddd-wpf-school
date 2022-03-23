using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Model
{
    public class AccountID
    {

        public string state;

        public string uuid;

        // example : CZ057A98777bD9820
        public AccountID(string state, string uuid = null)
        {
            this.state = state;
            this.uuid = !String.IsNullOrEmpty(uuid) ? uuid : Guid.NewGuid().ToString();
        }

        public AccountID()
        {
        }

        public override string ToString()
        {
            return $"{state}{uuid}";
        }

        // need to override the dictionary functions so it looks up the accountID how we want to
        public override bool Equals(object obj)
        {
            return obj is AccountID accountID && state == accountID.state && uuid == accountID.uuid;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(state, uuid);
        }


    }
}
