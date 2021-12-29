using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LegoStore.Models
{
    public class Box
    {
        // ID коробки
        public int Id { get; set; }
        // название коробки
        public string Name { get; set; }
        // серия
        public string Series { get; set; }
        // цена
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}