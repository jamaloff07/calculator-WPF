using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string currentNumber = string.Empty;
        private string operation = string.Empty;
        private double result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();

            if (buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/")
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    operation = buttonText;
                    result = double.Parse(currentNumber);
                    currentNumber = string.Empty;
                }
            }
            else if (buttonText == "=")
            {
                if (!string.IsNullOrEmpty(currentNumber) && !string.IsNullOrEmpty(operation))
                {
                    double secondNumber = double.Parse(currentNumber);
                    currentNumber = string.Empty;

                    switch (operation)
                    {
                        case "+":
                            result += secondNumber;
                            break;
                        case "-":
                            result -= secondNumber;
                            break;
                        case "*":
                            result *= secondNumber;
                            break;
                        case "/":
                            if (secondNumber != 0)
                                result /= secondNumber;
                            else
                            {
                                MessageBox.Show("Cannot divide by zero!");
                                return;
                            }
                            break;
                    }

                    txtDisplay.Text = result.ToString();
                    operation = string.Empty;
                }
            }
            else
            {
                currentNumber += buttonText;
                txtDisplay.Text += buttonText;
            }
        }
    }
}
