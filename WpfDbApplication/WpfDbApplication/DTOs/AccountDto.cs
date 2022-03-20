using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WpfDbApplication.DTOs
{
    public partial class AccountDto
    {
        [Key]
        public string Uuid { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public decimal? Money { get; set; }
        public int? CardId { get; set; }
    }
}
