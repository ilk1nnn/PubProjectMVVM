using iTextSharp.text.pdf;
using PubMVVM.Commands;
using PubMVVM.Models;
using PubMVVM.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;
using PubMVVM.Views;
using System.Reflection.Emit;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PubMVVM.ViewModels
{
    public class AppViewModel : BaseViewModel
    {

        public FakeRepo PrinterRepository { get; set; }
        public ObservableCollection<Printer> Printers { get; set; }
        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand PlusCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand MinusCommand { get; set; }
        public string Count { get; set; }

        private Printer printer;

        public Printer Printer
        {
            get { return printer; }
            set { printer = value; OnPropertyChanged(); }
        }


        private Printer buyPrinter;

        public Printer BuyPrinter
        {
            get { return printer; }
            set { printer = value; OnPropertyChanged(); }
        }


        public AppViewModel()
        {
            PrinterRepository = new FakeRepo();
            Printers = PrinterRepository.GetAll();


            ResetCommand = new RelayCommand((a) =>
            {
                var printer = a as Printer;
                printer = Printer;
                printer.CountOfBeer = "0";
                printer = null;
                Printer = printer;

            });

            SelectedCommand = new RelayCommand((o) =>
            {
                var printer = o as Printer;
                Printer = printer;
            });

            PlusCommand = new RelayCommand((b) =>
            {
                var printer =b as Printer;
                printer = Printer;
                var x = int.Parse(printer.CountOfBeer);
                x++;
                string a = x.ToString();
                printer.CountOfBeer = a;
                Printer = printer;
            });


            MinusCommand = new RelayCommand((b) =>
            {
                var printer = b as Printer;
                printer = Printer;
                var x = int.Parse(printer.CountOfBeer);
                x--;
                if(x<0)
                {
                    Printer.CountOfBeer = "0";
                    x++;
                    
                }
                string a = x.ToString();
                printer.CountOfBeer = a;
                Printer = printer;
            });


            BuyCommand = new RelayCommand((c) =>
            {

                var printer = c as Printer;
                printer = Printer;
                var buywindow = new BuyWindow();
                Uri imageUri = new Uri(printer.ImageP, UriKind.Relative);
                BitmapImage bitmapImage = new BitmapImage(imageUri);
                buywindow.beerimage.Source = bitmapImage;
                double price = double.Parse(printer.Price);
                int count = int.Parse(printer.CountOfBeer);
                double total = price * count;
                string totalprice = total.ToString();
                buywindow.beername.Content = $"Name : {printer.BeerName}" + $" \nVolume : {printer.Volume}";
                buywindow.totallbl.Content = totalprice+" AZN";
                buywindow.ShowDialog();

            }, (c) =>
            {
                if (Printer == null) return false;
                return true;
            });


        }

    }
}
