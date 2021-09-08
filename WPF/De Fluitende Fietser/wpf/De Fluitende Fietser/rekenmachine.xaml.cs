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

namespace De_Fluitende_Fietser
{
    /// <summary>
    /// Interaction logic for rekenmachine.xaml
    /// </summary>
    public partial class rekenmachine : Window
    {
        private const double pI = Math.PI;
        int number1 = 0;
        int number2 = 0;
        string Operation = "";
        public rekenmachine()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {



        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (Operation =="")
            {
                number1 += 9;
                txtdisplay.Text = number1.ToString();
            }
            else
            {
                number2 += 9;
                txtDisplay.Text = number2.ToString();
            }
         

        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnplus_Click(object sender, RoutedEventArgs e)
        {

            //Operation = "+";
            //txtDisplay.Text = number2.ToString();

        }

        private void btndeel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnkeer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnenter_Click(object sender, RoutedEventArgs e)
        {
            switch (Operation)
            {
                case "+":
                    txtdisplay.Text = (number1 + number2).ToString();
                    break;
            }

        }

        private void btnc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnenter_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Operation == "")
            {
                number1 = (number1 * 10) *0;
                txtDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) *0;
                txtDisplay.Text = number2.ToString();
            }

        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
