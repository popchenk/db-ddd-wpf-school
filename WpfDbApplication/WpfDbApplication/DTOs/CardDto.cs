using System;
using System.Collections.Generic;
using WpfDbApplication.Repository;
using WpfDbApplication.Services.Helpers;

#nullable disable

namespace WpfDbApplication.DTOs
{
    public class CardDto : Entity, IAggregateRoot
    {
        public int id { get; set; }
        public string cardNum { get; set; }
        public int cvv { get; set; }
        public string expDate { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
