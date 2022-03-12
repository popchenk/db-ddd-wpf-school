using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;

namespace WpfDbApplication.Exceptions
{
    class AccountAlreadyExistsException : Exception
    {

        public Account existingAccount { get; }
        public Account incomingAccount { get; }

        public AccountAlreadyExistsException(Account existingAccount, Account incomingAccount)
        {
            this.existingAccount = existingAccount;
            this.incomingAccount = incomingAccount;
        }

        public AccountAlreadyExistsException(string message) : base(message)
        {
        }

        public AccountAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


    }
}
