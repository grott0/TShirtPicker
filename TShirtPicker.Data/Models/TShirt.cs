using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShirtPicker.Data.Models
{
    public class TShirt
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
    }
}
