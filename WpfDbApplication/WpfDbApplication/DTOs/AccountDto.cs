using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WpfDbApplication.Repository;

#nullable disable

namespace WpfDbApplication.DTOs
{
    public class AccountDto : Entity
    {
        public int id { get; set; }
        public string Uuid { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public decimal? Money { get; set; }
        public int? CardId { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
