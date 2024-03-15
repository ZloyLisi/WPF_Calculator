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

namespace kalkul.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public double i;
        public double num1, num2, num3;
        public double memory = 0;
        public double memory2 = 0;
        public bool enter = false;
        

        private void steretall_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            memory = 0;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "0";
            else
                textBox1.Text += 0;
        }

        

        private void one_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "1";
            else
                textBox1.Text += 1;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "3";
            else
                textBox1.Text += 3;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "4";
            else
                textBox1.Text += 4;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "5";
            else
                textBox1.Text += 5;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "6";
            else
                textBox1.Text += 6;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "7";
            else
                textBox1.Text += 7;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "8";
            else
                textBox1.Text += 8;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "9";
            else
                textBox1.Text += 9;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i = 1;
                num1 = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (FormatException)
            {
                this.Topmost = true;
            }
            catch (Exception)
            {
                this.Topmost = true;
            }
        }

      

        private void ravno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (i == 1)
                {
                    num2 = Double.Parse(textBox1.Text);
                    num3 = num1 + num2;
                    textBox1.Text = num3.ToString();
                }
                if (i == 2)
                {
                    num2 = Double.Parse(textBox1.Text);
                    num3 = num1 / num2;
                    textBox1.Text = num3.ToString();
                }
                if (i == 3)
                {
                    num2 = Double.Parse(textBox1.Text);
                    num3 = num1 * num2;
                    textBox1.Text = num3.ToString();
                }
                if (i == 4)
                {
                    num2 = Double.Parse(textBox1.Text);
                    num3 = num1 - num2;
                    textBox1.Text = num3.ToString();
                }
                if (i == 5)
                {
                    num2 = Double.Parse(textBox1.Text);
                    num3 = Math.Pow(num1, num2);
                    textBox1.Text = num3.ToString();
                }
                if (i == 6)
                {
                    num2 = Double.Parse(textBox1.Text);
                    num3 = Math.Pow(num1, (double)1 / num2);
                    textBox1.Text = num3.ToString();
                }
            }
            catch (FormatException)
            {

                this.Topmost = true;
            }
            catch (Exception)
            {

                this.Topmost = true;
            }
        }

        private void tochka_Click(object sender, RoutedEventArgs e)
        {
            {
                if (textBox1.Text == "") textBox1.Text += "0,";
                if (!textBox1.Text.Contains(","))
                    textBox1.Text = textBox1.Text + ",";
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox1.Text == "0" || textBox1.Text == " ")
                    textBox1.Text = "";
                else
                {
                    i = 4;
                    num1 = Convert.ToDouble(textBox1.Text);
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
            catch (FormatException)
            {
                this.Topmost = true;
            }
            catch (Exception)
            {
                this.Topmost = true;
            }
        }

        private void umnozhit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i = 3;
                num1 = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (FormatException)
            {
                this.Topmost = true;
            }
            catch (Exception)
            {
                this.Topmost = true;
            }
        }

        private void delit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                i = 2;
                num1 = Convert.ToDouble(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
            catch (FormatException)
            {
                this.Topmost = true;
            }
            catch (Exception)
            {
                this.Topmost = true;
            }
        }

        private void off_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void koren_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enter = false; num2 = Convert.ToDouble(textBox1.Text);
                if (num2 < 0) throw new Exception("Ошибка: отрицательное число"); num2 = Convert.ToDouble(Math.Sqrt((double)num2));
                textBox1.Text = Convert.ToString(num2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                Application.Current.MainWindow.Topmost = true;
            }
        }

        private void percent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                num1 = Convert.ToDouble(textBox1.Text);
                num2 = num1 / 100;
                textBox1.Text = num2.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите числа", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.MainWindow.Topmost = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.MainWindow.Topmost = true;
            }
        }

        private void mplus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(textBox1.Text, out double currentValue))
                {
                    memory2 += currentValue;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Введите числа", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.MainWindow.Topmost = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.MainWindow.Topmost = true;
            }
        }

        private void mminus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(textBox1.Text, out double currentValue))
                {
                    memory2 -= currentValue;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите числа", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.MainWindow.Topmost = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.MainWindow.Topmost = true;
            }
        }

        private void mr_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = memory2.ToString();
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            memory2 = 0;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "2";
            else
                textBox1.Text += 2;
        }




        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

       
    }
}
