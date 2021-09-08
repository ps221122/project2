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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace De_Fluitende_Fietser
{
    /// <summary>
    /// Interaction logic for extra_s.xaml
    /// </summary>
    public partial class extra_s : Window
    {
        //create variables that we'll need
        string selectedcombobox = "0";
        double totaalbedrag = 0;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer Timer = new DispatcherTimer();
        int num = 60;
        double number1 = 0;
        int A = 0;
        int B = 0;
        int C = 0;
        int D = 0;
        int E = 0;
        int F = 0;
        int G = 0;
        int H = 0;
        int I = 0;
        int J = 0;
        int K = 0;
        int L = 0;
        public extra_s()
        {
            InitializeComponent();
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 550);  // timer for the progressbar
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0); // timer that ensure that the progressbar goes down every second
            timer.Tick += Timer_Tick;
            Timer.Tick += Timer_Tick1;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            pbBar.Value--;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            num--;

        }

        //when one combobox is selected u can't select  the other combobox's while this has been selected
        private void cmbFietsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcombobox = "1";

            cmbVerzekeringen.IsHitTestVisible = false;
            cmbServices.IsHitTestVisible = false;
            num = 60;
            pbBar.Value = 100; // evreythime combobox item has been selected timer and the progressbar resets to initial value 
        }

        //when one combobox is selected u can't select  the other combobox's while this has been selected
        private void cmbVerzekeringen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcombobox = "2";

            cmbFietsen.IsHitTestVisible = false;
            cmbServices.IsHitTestVisible = false;
            num = 60;
            pbBar.Value = 100; // evreythime combobox item has been selected timer and the progressbar resets to initial value 
        }
        //when one combobox is selected u can't select  the other combobox's while this has been selected
        private void cmbServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcombobox = "3";
            cmbFietsen.IsHitTestVisible = false;
            cmbVerzekeringen.IsHitTestVisible = false;
            num = 60;
            pbBar.Value = 100; // evreythime combobox item has been selected timer and the progressbar resets to initial value 
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
                        //we put all the info into variables, then multiply days and the product selected and update the info and add it to the listbox
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
                        //we put all the info into variables, then multiply days and the product selected and update the info and add it to the listbox
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
                        //we put all the info into variables, then multiply days and the product selected and update the info and add it to the listbox
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
                //resets after the purchase
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
            //error fix
            if (lbOverzicht.Items.Count == 0)
            {
                MessageBox.Show("Er is geen product om te verwijderen");
            }
            else
            {
                //to delete the row and update the total when double clicked
                if (MessageBox.Show("Weet u zeker dat u dit item wil verwijderen?", "Error", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var prijsaf = lbOverzicht.SelectedItem.ToString();

                    string prijsaf1 = prijsaf.Split('€')[1];
                    string prijsaf2 = prijsaf1.Substring(0, 6);

                    string dagenaf1 = prijsaf.Split(':')[1]; // checks for each item indiviually and remove the item price from the totaal
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
                //if paid it resets the whole page
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
                    tbBedrag.Text = "0.00"; // returns all of the values to  0 or as for tthe timer it returns it back to 60
                    num = 60;
                    pbBar.Value = 100;
                    tbAf.Text = " 0.00";
                    tbBedrag.Text = "0.00";


                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e) //// grid loads and ime starts counting down
        {
            timer.Start();
            Timer.Start();

        }
        private void time()
        {
            if (num == 0)
            {
                timer.Stop();
                rekenmachine extra = new rekenmachine(); //// if timer reach 0 it close the window and opens the next page 
                extra.Show();
                this.Close();

            }
        }


        private void btn5_Click(object sender, RoutedEventArgs e) /////////// if 5 cent button is clicked it use number1 which is 0 plus the value and shows this in the textblock bedrag
        {
            number1 = (number1 + 0.05); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
        
            A++;
            lb1.Content = A.ToString() + "keer";

            //necessary to update the total At the end
            UpdateAf();

        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 0.10); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
        
            B++;
            lb2.Content = B.ToString() + "keer";
            UpdateAf();
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 0.20); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
           
            C++;
            lb3.Content = C.ToString() + "keer";
            UpdateAf();
        }

        private void btn50_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 0.50); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
        
            D++;
            lb4.Content = D.ToString() + "keer";
            UpdateAf();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 1.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
         
            E++;
            lb5.Content = E.ToString() + "keer";
            UpdateAf();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 2.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
           
            F++;
            lb6.Content = F.ToString() + "keer";
            UpdateAf();
        }

        private void Btn5_Click_1(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 5.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
      
            G++;
            lb7.Content = G.ToString() + "keer";
            UpdateAf();
        }

        private void Btn10_Click_1(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 10.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
         
            H++;
            lb8.Content = H.ToString() + "keer";
            UpdateAf();
        }

        private void Btn20_Click_1(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 20.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;

            I++;
            lb9.Content = I.ToString() + "keer";
            UpdateAf();
        }

        private void Btn50_Click_1(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 50.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
         
            J++;
            lb10.Content = J.ToString() + "keer";
            UpdateAf();
        }

        private void btn100_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 100.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
         
            K++;
            lb11.Content = K.ToString() + "keer";
            UpdateAf();
        }

        private void btn200_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 + 200.00); // number 1 = 0 + value 
            tbBedrag.Text = "€" + number1.ToString();
            num = 60;
            pbBar.Value = 100;
       
            L++;
            lb12.Content = L.ToString() + "keer";
            UpdateAf();
        }

        private void btnV_Click(object sender, RoutedEventArgs e)
        {
            var overzicht = MessageBox.Show("Weet u zeker dat u  klaar bent met deze scherm?", "Klaar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (overzicht == MessageBoxResult.Yes)
            {
                timer.Stop();
                rekenmachine extra = new rekenmachine(); //// if yes opens calculator window else if not, clears everthing
                extra.Show();
                this.Close();
            }
            else if (overzicht == MessageBoxResult.No)
            {
                return;
            }
        }
        private void UpdateAf()
        {
            //the amount the client paid-the expenses = the money we have to give back.
            double teBetalen = Convert.ToDouble(tbBetalen.Text);
            double totaal = Convert.ToDouble(tbBedrag.Text.Substring(1)); // substring removes the euro sign
            double af = totaal - teBetalen;
            tbAf.Text = Convert.ToString(af)+ "€";
        }



    }
}