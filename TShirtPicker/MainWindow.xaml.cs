using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TShirtPicker.Data;
using TShirtPicker.Data.Models;

namespace TShirtPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TShirtRepository repository = new TShirtRepository();

        public MainWindow()
        {
            InitializeComponent();

            this.GetRandomTShirt();
        }

        public void GetRandomTShirt()
        {
            Random rnd = new Random();
            List<TShirt> tShirts = this.repository.GetAll().ToList();

            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday || tShirts.All(x => x.Quantity <= 0))
            {
                this.RestockTShirts(tShirts);
            }

            int loopCounter = 0;

            while (true)
            {
                loopCounter++;
                int index = rnd.Next(0, tShirts.Count);

                if (tShirts[index].Quantity > 0)
                {
                    ImageSource imageSource = new BitmapImage(
                        new Uri($@"../../Resources/{tShirts[index].Color}.jpg", UriKind.Relative));
                    this.Image.Source = imageSource;
                    this.repository.DecreaseQuantity(tShirts[index].Id, tShirts[index].Quantity - 1);
                    break;
                }
            }
        }

        private void RestockTShirts(List<TShirt> tShirts)
        {
            foreach (var tShirt in tShirts)
            {
                if (tShirt.Color == "61422-30 White")
                {
                    this.repository.Restock(1, tShirt.Color);
                    tShirt.Quantity = 1;
                }
                else if (tShirt.Color == "61422-32 Navy")
                {
                    this.repository.Restock(4, tShirt.Color);
                    tShirt.Quantity = 4;
                }
                else if (tShirt.Color == "61422-36 Black")
                {
                    this.repository.Restock(1, tShirt.Color);
                    tShirt.Quantity = 1;
                }
                else if (tShirt.Color == "61422-94 Heather Grey")
                {
                    this.repository.Restock(1, tShirt.Color);
                    tShirt.Quantity = 1;
                }
            }
        }
    }
}
