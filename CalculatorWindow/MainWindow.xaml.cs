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

namespace CalculatorWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Number1.Text, out double num1) && double.TryParse(Number2.Text, out double num2))
            {
                // string operation = (OperationComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                //Behöver konvertera selecteditem som ett comboboxitem först för att sedan göra om till string
                ComboBoxItem selectedItem = OperationComboBox.SelectedItem as ComboBoxItem; 
                string operation = selectedItem.Content.ToString();

                double result = 0;

                switch (operation)
                {
                    case "Add":
                        result = num1 + num2;
                        break;
                    case "Subtract":
                        result = num1 - num2;
                        break;
                    case "Multiply":
                        result = num1 * num2;
                        break;
                    case "Divide":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            MessageBox.Show("Cannot divide by zero.");
                        break;
                }

                ResultLabel.Content = $"Result: {result}";
            }
            else
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }

    }
}