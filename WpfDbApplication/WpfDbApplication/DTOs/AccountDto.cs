using System;
using System.Collections.Generic;

#nullable disable

namespace WpfDbApplication.DTOs
{
    public partial class AccountDto
    {
        public string Uuid { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public decimal? Money { get; set; }
    }
}
