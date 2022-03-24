using School_Stage_0.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.DTOs
{
    public class AccountDto : Entity
    {
        public int id { get; set; }
        public string Uuid { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public decimal? Money { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
