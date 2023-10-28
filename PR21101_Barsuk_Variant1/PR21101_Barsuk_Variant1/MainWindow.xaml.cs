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
using System.Numerics;

namespace PR21101_Barsuk_Variant1
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

        static int[] GetDigits(long number)
        {
            string numberString = number.ToString();
            int[] digits = new int[numberString.Length];

            for (int i = 0; i < numberString.Length; i++)
            {
                digits[i] = int.Parse(numberString[i].ToString());
            }

            return digits;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputText = IntBox.Text;

            if (inputText.Length != 12)
            {
                MessageBox.Show("Введено не двенадцати значное число");
                return;
            }

            if (long.TryParse(inputText, out long number))
            {
                int[] digits = GetDigits(number);

                // Перемножаем первые три цифры
                int product = digits[0] * digits[1] * digits[2];

                // Суммируем последние девять цифр
                int sum = 0;
                for (int i = 3; i < digits.Length; i++)
                {
                    sum += digits[i];
                }

                if (product == sum)
                {
                    OutBox.Text = ("Произведение первых 3 цифр равно сумме 9 последних цифр.");
                }
                else
                {
                    OutBox.Text = ("Произведение первых 3 цифр НЕ равно сумме 9 последних цифр.");
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Введите корректное двенадцатизначное число.");
            }

            // Проверяем равенство произведения и суммы
            
 
        }
    }
}
