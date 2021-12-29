using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LegoStore.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
    }
}