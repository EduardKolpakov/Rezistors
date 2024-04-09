using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string messageBoxText = "";
        string caption = "Ошибка!";
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage icon = MessageBoxImage.Warning;
        MessageBoxResult result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            while (true) 
            {
                double res = 0;
                string res1 = "";
                if (text1.Text == "")
                {
                    messageBoxText = "Введите сопротивление 1-го резистора!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    break;
                }
                if (text2.Text == "")
                {
                    messageBoxText = "Введите сопротивление 2-го резистора!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    break;
                }
                if (rb1.IsChecked == false & rb2.IsChecked == false)
                {
                    messageBoxText = "Выберите тип соединения!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    break;
                }
                if (text1.Text.Contains(" ") || text2.Text.Contains(" "))
                {
                    messageBoxText = "Введите сопротивление без пробелов!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    break;
                }
                if (text1.Text == "0" || text2.Text == "0")
                {
                    messageBoxText = "Сопротивление не может равняться 0!";
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    break;
                }
                double num1 = Convert.ToDouble(text1.Text);
                double num2 = Convert.ToDouble(text2.Text);
                if (rb1.IsChecked == true)
                {
                    res = (num1 * num2) / (num1 + num2);
                }
                else if (rb2.IsChecked == true)
                {
                    res = num1 + num2;
                }
                res1 = $"{res} Ом";
                if (res >= 1000)
                {
                    res /= 1000;
                    res1 = $"{res} КилоОм";
                }
                resultText.Text = res1;
                break;
            }

        }

        private void text1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!text1.Text.Contains(".") && text1.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void text2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!text2.Text.Contains(".") && text2.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            text1.Text = "";
            text2.Text = "";
            resultText.Text = "Результат:";

        }
    }
}