using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace De_Fluitende_Fietser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //create variables that we'll need
        string selectedcombobox = "0";
        double totaalbedrag = 0;
        DispatcherTimer timer = new DispatcherTimer();
        int num = 60;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            num--;
            tbTime.Text = num.ToString();

        }

        //when one combobox is selected u can't select more
        private void cmbFietsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcombobox = "1";

            cmbVerzekeringen.IsHitTestVisible = false;
            cmbServices.IsHitTestVisible = false;
            num = 60;
        }

        //when one combobox is selected u can't select more
        private void cmbVerzekeringen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcombobox = "2";

            cmbFietsen.IsHitTestVisible = false;
            cmbServices.IsHitTestVisible = false;
            num = 60;

        }
        //when one combobox is selected u can't select more
        private void cmbServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcombobox = "3";

            cmbFietsen.IsHitTestVisible = false;
            cmbVerzekeringen.IsHitTestVisible = false;
            num = 60;

        }

        private void btBestellen_Click(object sender, RoutedEventArgs e)
        {
            //to insure that "Days" is numeric and Days > 0
            string dagencheck = tbDagen.Text;


            if (System.Text.RegularExpressions.Regex.IsMatch(dagencheck, @"^[0-9]+$"))
            {
                double dagencheck2 = Convert.ToDouble(dagencheck);
                if (dagencheck2 == 0)
                {
                    MessageBox.Show("Voer aantal dagen in a.u.b!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Voer aantal dagen in a.u.b!");
                return;
            }
            //if nothing is selected
            if (cmbFietsen.SelectedItem == null && cmbVerzekeringen.SelectedItem == null && cmbServices.SelectedItem == null)
            {
                if (MessageBox.Show("Geen geselecteerde producten! Wilt u toch doorgaan?", "Error404", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else if (tbDagen != null)
            {
                switch (selectedcombobox)
                {
                    case "0":
                        MessageBox.Show("Kies een product!");
                        break;

                    case "1":

                        var tbSelectedFiets = cmbFietsen.Text;
                        var tbAantalDagen = tbDagen.Text;

                        var prijs = cmbFietsen.SelectedItem.ToString();
                        double prijss = double.Parse(prijs.Split('€')[1]);


                        double dagen = double.Parse(tbDagen.Text);

                        totaalbedrag += prijss * dagen;
                        tbBetalen.Text = totaalbedrag.ToString("0.00");

                        var box = tbSelectedFiets + " /dag. " + " Aantal dagen is/zijn:" + tbAantalDagen;

                        lbOverzicht.Items.Add(box);


                        break;

                    case "2":

                        var tbSelectedVerzekering = cmbVerzekeringen.Text + " /dag. ";
                        var tbAantalDagen2 = " Aantal dagen is/zijn: " + tbDagen.Text;

                        var prijs2 = cmbVerzekeringen.SelectedItem.ToString();
                        double prijss2 = double.Parse(prijs2.Split('€')[1]);

                        double dagen2 = double.Parse(tbDagen.Text);

                        totaalbedrag += prijss2 * dagen2;
                        tbBetalen.Text = totaalbedrag.ToString("0.00");

                        var box2 = tbSelectedVerzekering + tbAantalDagen2;

                        lbOverzicht.Items.Add(box2);

                        break;

                    case "3":

                        var tbSelectedService = cmbServices.Text + " /dag. ";
                        var tbAantalDagen3 = " Aantal dagen is/zijn: " + tbDagen.Text;

                        var prijs3 = cmbServices.SelectedItem.ToString();
                        double prijss3 = double.Parse(prijs3.Split('€')[1]);

                        double dagen3 = double.Parse(tbDagen.Text);

                        totaalbedrag += prijss3 * dagen3;
                        tbBetalen.Text = totaalbedrag.ToString("0.00");

                        var box3 = tbSelectedService + tbAantalDagen3;

                        lbOverzicht.Items.Add(box3);

                        break;

                    default:
                        tbBetalen.Text = "Error404";
                        break;

                }

                cmbFietsen.SelectedIndex = -1;
                cmbVerzekeringen.SelectedIndex = -1;
                cmbServices.SelectedIndex = -1;

                cmbFietsen.IsHitTestVisible = true;
                cmbServices.IsHitTestVisible = true;
                cmbVerzekeringen.IsHitTestVisible = true;

                tbDagen.Text = "1";

            }
        }

        private void lbOverzicht_verwijderen(object sender, MouseButtonEventArgs e)
        {
            if (lbOverzicht.Items.Count == 0)
            {
                MessageBox.Show("Er is geen product om te verwijderen");
            }
            else
            {


                if (MessageBox.Show("Weet u zeker dat u dit item wil verwijderen?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var prijsaf = lbOverzicht.SelectedItem.ToString();

                    string prijsaf1 = prijsaf.Split('€')[1];
                    string prijsaf2 = prijsaf1.Substring(0, 6);

                    string dagenaf1 = prijsaf.Split(':')[1];
                    string dagenaf2 = dagenaf1.Substring(0);

                    double prijs = Convert.ToDouble(prijsaf2);
                    double dagen = Convert.ToDouble(dagenaf2);


                    lbOverzicht.Items.Remove(lbOverzicht.SelectedItem);
                    totaalbedrag -= prijs * dagen;
                    tbBetalen.Text = totaalbedrag.ToString("0.00");
                }
                else
                {
                    return;
                }

            }
        }


        private void btBetalen_Click(object sender, RoutedEventArgs e)
        {
            double tebetalen = Double.Parse(tbBetalen.Text);
            if (tebetalen <= 0)
            {
                MessageBox.Show("Add an item first");
            }
            else
            {
                if (MessageBox.Show("Bestelling betaald?", "Betaald?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    cmbFietsen.SelectedIndex = -1;
                    cmbVerzekeringen.SelectedIndex = -1;
                    cmbServices.SelectedIndex = -1;

                    cmbFietsen.IsHitTestVisible = true;
                    cmbServices.IsHitTestVisible = true;
                    cmbVerzekeringen.IsHitTestVisible = true;

                    tbDagen.Text = "1";

                    lbOverzicht.Items.Clear();

                    tbBetalen.Text = "0.00";
                    totaalbedrag = 0.00;


                }
            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    
    }
}
