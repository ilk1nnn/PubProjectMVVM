using PubMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PubMVVM.Repositories
{
    public class FakeRepo
    {

        public ObservableCollection<Printer>GetAll()
        {

       
            return new ObservableCollection<Printer>()
            {
                new Printer {BeerName="Xirdalan", Price="3.5",Volume="0.5 L",ImageP = "images/xirdalan.png",CountOfBeer="0"},
                new Printer {BeerName="NZS", Price="2",Volume="0.5 L",ImageP = "images/nzsimg.png",CountOfBeer="0"},
                new Printer {BeerName="Efsane", Price="2.5",Volume="10 L",ImageP = "images/efsane.png",CountOfBeer="0"},
            };
        }

    }
}
