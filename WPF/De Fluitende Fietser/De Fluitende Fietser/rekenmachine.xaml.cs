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
    /// Interaction logic for rekenmachine.xaml
    /// </summary>
    public partial class rekenmachine : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private const double pI = Math.PI; //calculate pi=3.14
        int number1 = 0;
        int number2 = 0;
        string Operation = "";
        string operation = "";
        public rekenmachine()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0); // how the timer works
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int num = int.Parse(tbTime.Text); 
            int nums = int.Parse(tbTimely.Text);
            int numsy = int.Parse(tbTimey.Text);
            num--;
            nums--;
            numsy--;
            tbTime.Text = num.ToString();
            tbTimely.Text = nums.ToString();
            tbTimey.Text = numsy.ToString();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 1; //number1 == 0 ( 0*10 +1 =1)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 1
            }
            else
            {
                number2 = (number2 * 10) + 1;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 1
            }

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 2; //number1 == 0 ( 0*10 +2 =2)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 2
            }
            else
            {
                number2 = (number2 * 10) + 2;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 2
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (operation == "")
                {
                    number1 = (number1 * 10) + 3;//number1== 0 ( 0*10 +3 =3)
                    txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 3
                }
                else
                {
                    number2 = (number2 * 10) + 3;
                    txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 3
                }
            }
            catch
            {
                if (operation == "")
                {
                    number2 = (number2 * 10) + 3;
                    txtDisplay.Text = number2.ToString();
                }
                else
                {
                    number1 = (number1 * 10) + 3;
                    txtdisplay.Text = number1.ToString();

                }
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 4; //number1 == 0 ( 0*10 +4 =4)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 4
            }
            else
            {
                number2 = (number2 * 10) + 4;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 4
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 5; //number1 == 0 ( 0*10 +5 =5)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 5
            }
            else
            {
                number2 = (number2 * 10) + 5;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 5
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 6; //number1 == 0 ( 0*10 +6 =6)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 6
            }
            else
            {
                number2 = (number2 * 10) + 6;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 6
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 7; //number1 = 0 ( 0*10 +7 =7)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 7
            }
            else
            {
                number2 = (number2 * 10) + 7;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 7
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 8; //number1 = 0 ( 0*10 +8 =8)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 8
            }
            else
            {
                number2 = (number2 * 10) + 8;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 8
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (Operation == "")
            {
                number1 += 9; 
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 9
            }
            else
            {
                number2 += 9;
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 9
            }


        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10); //number1 = 0 ( 0*10 +10)
                txtdisplay.Text = number1.ToString(); /// if number 1 is clicked shows up in txtdisplay as 0
            }
            else
            {
                number2 = (number2 * 10);
                txtDisplay.Text = number2.ToString(); /// if number 2 is clicked shows up in txtdisplay as 0
            }
        }

        private void btnplus_Click(object sender, RoutedEventArgs e) // this is here so that it shows what the operation is
        {
            operation = "+";
            txtDisplay.Text = "";
        }

        private void btndeel_Click(object sender, RoutedEventArgs e) // this is here so that it shows what the operation is
        {
            operation = "/";
            txtDisplay.Text = "";
        }

        private void btnmin_Click(object sender, RoutedEventArgs e) // this is here so that it shows what the operation is
        {
            operation = "-";
            txtDisplay.Text = "";
        }

        private void btnkeer_Click(object sender, RoutedEventArgs e) // this is here so that it shows what the operation is
        {
            operation = "*";
            txtDisplay.Text = number2.ToString();
        }

        private void btnenter_Click(object sender, RoutedEventArgs e) // the enter button now checks wether its a + - * /  
        {
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (number1 + number2).ToString(); //if clicked on this then it adds up (plus
                    break;
                case "/":
                    txtDisplay.Text = (number1 / number2).ToString();  //if clicked on this then it divide (deel
                    break;
                case "-":
                    txtDisplay.Text = (number1 - number2).ToString();  //if clicked on this then it minus( -
                    break;
                case "*":
                    txtDisplay.Text = (number1 * number2).ToString();  //if clicked on this then it multiply ( keer
                    break;
                case "π":
                    txtDisplay.Text = (Math.PI * number1).ToString();  //if clicked on this then it takes number1 * 3.14.............
                    break;
                default:
                    MessageBox.Show("invalid"); //else invalid
                    break;
            }
            number1 = 0;
            number2 = 0;
            txtdisplay.Text = "0"; 
            Operation = "";
            operation = "";

        }



        private void btnr_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 *= -1;
                txtdisplay.Text = number1.ToString(); //plus /min
            }
            else
            {
                number2 *= -1;
                txtDisplay.Text = number2.ToString();
            }

        }

        private void btnPi_Click(object sender, RoutedEventArgs e)
        {
            double NUM = 0;
            if (operation == "")
            {
                number1 = ((int)(NUM * pI));
                txtDisplay.Text = pI.ToString();
            }
            else MessageBox.Show("invalid");
        }

        

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 / 10);
                txtdisplay.Text = number1.ToString(); //divide  10 so that it move back one space
            }
            else
            {
                number2 = (number2 / 10);
                txtDisplay.Text = number2.ToString();
            }

        }
        bool btn = true;
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(tbTime.Text);
            int nums = int.Parse(tbTimely.Text);
            int numsy = int.Parse(tbTimey.Text);  // num.. for each textbox indiviually
            if (btn)
            {
                timer.Start();
                btnReset.Content = "Stop";

            }
            if (num <= 0)  // if num is less than or equal to 0 timer stops and return 60
            {
                timer.Stop();
                tbTime.Text = "60"; 
                num = 60;
            }
            if (nums <= 0)
            {
                timer.Stop();
                tbTimely.Text = "60";
                nums = 60;
            }
            if(numsy<=0)
            {
                timer.Stop();
                tbTimey.Text = "60";
                numsy = 60;

            }
            else if (num > 0)
            {
                timer.Start(); // if btn is true and higher than 0 timer starts
            }
            else
            {
                timer.Stop();
                btnReset.Content = "(Re) set tijd"; // else timer stops  and show on button reset tijd

            }
            btn = !btn;
        }

        private void btnc_Click(object sender, RoutedEventArgs e) // if clicked it resets all of the initial values back to 0 
        {
            number1 = 0;
            number2 = 0;
            txtdisplay.Text = "0";
            Operation = "";
            operation = "";
        }
    }
}
