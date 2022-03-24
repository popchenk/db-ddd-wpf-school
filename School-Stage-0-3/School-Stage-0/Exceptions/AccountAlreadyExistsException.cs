using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using School_Stage_0.Models;

namespace School_Stage_0.Exceptions
{
    public class AccountAlreadyExistsException : Exception
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
