using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PubMVVM.Models
{
    public class Printer:Entity
    {
        public string ImageP { get; set; }
        public string BeerName { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string CountOfBeer { get; set; }
    }
}
