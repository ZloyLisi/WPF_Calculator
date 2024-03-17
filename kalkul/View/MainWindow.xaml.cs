using System;
using System.Collections.Generic;
using System.Globalization;
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
using WPFCalc;


namespace kalkul.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string DecimalSeparator => CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
        decimal FirstValue { get; set; }
        decimal? SecondValue { get; set; }

        IOperation CurrentOperation;
        public MainWindow()
        {
            InitializeComponent();
            btnPoint.Content = DecimalSeparator;
            
            btnSum.Tag = new Sum();
            btnSubtraction.Tag = new Subtraction();
            btnDivision.Tag = new Division();
            btnMultiplication.Tag = new Multiplication();
        }

        public double i;
        public double num1, num2, num3, num4;
        public double memory = 0;
        public double memory2 = 0;
        public bool enter = false;







        private void regularButtonClick(object sender, RoutedEventArgs e)
           => SendToInput(((Button)sender).Content.ToString());

        private void SendToInput(string content)
        {
            //Prevent 0 from appearing on the left of new numbers
            if (txtInput.Text == "0")
                txtInput.Text = "";

            txtInput.Text = $"{txtInput.Text}{content}";
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Contains(this.DecimalSeparator))
                return;

            regularButtonClick(sender, e);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //Prevent from clearing zero
            if (txtInput.Text == "0")
                return;

            txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            if (txtInput.Text == "")
                txtInput.Text = "0";
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            //if current operation is not null then we already have the FirstValue
            if (CurrentOperation == null)
                FirstValue = Convert.ToDecimal(txtInput.Text);

            CurrentOperation = (IOperation)((Button)sender).Tag;
            SecondValue = null;
            txtInput.Text = "";
        }

        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            switch (e.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    SendToInput(e.Text);
                    break;

                case "*":
                    btnMultiplication.PerformClick();
                    break;

                case "-":
                    btnSubtraction.PerformClick();
                    break;

                case "+":
                    btnSum.PerformClick();
                    break;

                case "/":
                    btnDivision.PerformClick();
                    break;

                case "=":
                    btnEquals.PerformClick();
                    break;

                default:
                    
                    if (e.Text == DecimalSeparator)
                        btnPoint.PerformClick();
                   
                    else if (e.Text[0] == (char)13)
                        btnEquals.PerformClick();

                    break;
            }

            
            btnEquals.Focus();
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperation == null)
                return;

            if (txtInput.Text == "")
                return;

          
            decimal val2 = SecondValue ?? Convert.ToDecimal(txtInput.Text);
            try
            {
                txtInput.Text = (FirstValue = CurrentOperation.DoOperation(FirstValue, (decimal)(SecondValue = val2))).ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Делить на 0 нельзя", "Деление на 0", MessageBoxButton.OK, MessageBoxImage.Error);
                btnClearAll.PerformClick();
            }
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
            => txtInput.Text = "0";

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            FirstValue = 0;
            CurrentOperation = null;
            txtInput.Text = "0";
        }
   

    private void koren_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enter = false; num2 = Convert.ToDouble(txtInput.Text);
                if (num2 < 0) throw new Exception("Ошибка: отрицательное число"); num2 = Convert.ToDouble(Math.Sqrt((double)num2));
                txtInput.Text = Convert.ToString(num2);
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
                num1 = Convert.ToDouble(txtInput.Text);
                num2 = num1 / 100;
                txtInput.Text = num2.ToString();
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


        //память
        private void mplus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(txtInput.Text, out double currentValue))
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
                if (double.TryParse(txtInput.Text, out double currentValue))
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
            txtInput.Text = memory2.ToString();
        }

        private void MC_Click(object sender, RoutedEventArgs e)
        {
            memory2 = 0;
        }       
    }
}
