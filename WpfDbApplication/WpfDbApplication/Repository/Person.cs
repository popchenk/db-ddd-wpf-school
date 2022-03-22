using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.Repository
{
    public class Person : Entity, IAggregateRoot
    {
        /// <summary>
        /// Last Name of a person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// First Name of a person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Age of a person
        /// </summary>
        public int Age { get; set; }


        /// <summary>
        /// Validation Check
        /// </summary>
        protected override void Validate()
        {
            throw new NotImplementedException();

        }
    }
}
