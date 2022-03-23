using System;
using System.Collections.Generic;

#nullable disable

namespace WpfDbApplication.DTOs
{
    public partial class CardDto
    {
        public int id { get; set; }
        public string cardNum { get; set; }
        public int cvv { get; set; }
        public string expDate { get; set; }
    }
}
