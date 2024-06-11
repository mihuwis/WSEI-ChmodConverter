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

namespace WpfInterface
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

        private void NumericPermissionsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NumericPermissionsTextBox.Text.Length == 3 && int.TryParse(NumericPermissionsTextBox.Text, out int numericPermissions))
            {
                SymbolicPermissionsTextBox.Text = NumericToSymbolic(numericPermissions);
                UpdateCheckBoxes(numericPermissions);
            }
        }

        private void SymbolicPermissionsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SymbolicPermissionsTextBox.Text.Length == 9)
            {
                var symbolicPermissions = SymbolicPermissionsTextBox.Text;
                NumericPermissionsTextBox.Text = SymbolicToNumeric(symbolicPermissions).ToString();
                UpdateCheckBoxes(symbolicPermissions);
            }
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            int numericPermissions = CalculateNumericPermissions();
            NumericPermissionsTextBox.Text = numericPermissions.ToString();
            SymbolicPermissionsTextBox.Text = NumericToSymbolic(numericPermissions);
        }

        private int CalculateNumericPermissions()
        {
            int owner = (OwnerReadCheckBox.IsChecked == true ? 4 : 0) +
                        (OwnerWriteCheckBox.IsChecked == true ? 2 : 0) +
                        (OwnerExecuteCheckBox.IsChecked == true ? 1 : 0);

            int group = (GroupReadCheckBox.IsChecked == true ? 4 : 0) +
                        (GroupWriteCheckBox.IsChecked == true ? 2 : 0) +
                        (GroupExecuteCheckBox.IsChecked == true ? 1 : 0);

            int other = (OtherReadCheckBox.IsChecked == true ? 4 : 0) +
                        (OtherWriteCheckBox.IsChecked == true ? 2 : 0) +
                        (OtherExecuteCheckBox.IsChecked == true ? 1 : 0);

            return owner * 100 + group * 10 + other;
        }

        private string NumericToSymbolic(int numericPermissions)
        {
            char[] symbolic = new char[9];
            int owner = numericPermissions / 100;
            int group = (numericPermissions / 10) % 10;
            int other = numericPermissions % 10;

            FillSymbolicPermissions(symbolic, owner, 0);
            FillSymbolicPermissions(symbolic, group, 3);
            FillSymbolicPermissions(symbolic, other, 6);

            return new string(symbolic);
        }

        private void FillSymbolicPermissions(char[] symbolic, int permissions, int offset)
        {
            symbolic[offset] = (permissions & 4) != 0 ? 'r' : '-';
            symbolic[offset + 1] = (permissions & 2) != 0 ? 'w' : '-';
            symbolic[offset + 2] = (permissions & 1) != 0 ? 'x' : '-';
        }

        private int SymbolicToNumeric(string symbolicPermissions)
        {
            int numericPermissions = 0;
            numericPermissions += SymbolicToDigit(symbolicPermissions.Substring(0, 3)) * 100;
            numericPermissions += SymbolicToDigit(symbolicPermissions.Substring(3, 3)) * 10;
            numericPermissions += SymbolicToDigit(symbolicPermissions.Substring(6, 3));
            return numericPermissions;
        }

        private int SymbolicToDigit(string symbolic)
        {
            int digit = 0;
            digit += symbolic[0] == 'r' ? 4 : 0;
            digit += symbolic[1] == 'w' ? 2 : 0;
            digit += symbolic[2] == 'x' ? 1 : 0;
            return digit;
        }

        private void UpdateCheckBoxes(int numericPermissions)
        {
            int owner = numericPermissions / 100;
            int group = (numericPermissions / 10) % 10;
            int other = numericPermissions % 10;

            OwnerReadCheckBox.IsChecked = (owner & 4) != 0;
            OwnerWriteCheckBox.IsChecked = (owner & 2) != 0;
            OwnerExecuteCheckBox.IsChecked = (owner & 1) != 0;

            GroupReadCheckBox.IsChecked = (group & 4) != 0;
            GroupWriteCheckBox.IsChecked = (group & 2) != 0;
            GroupExecuteCheckBox.IsChecked = (group & 1) != 0;

            OtherReadCheckBox.IsChecked = (other & 4) != 0;
            OtherWriteCheckBox.IsChecked = (other & 2) != 0;
            OtherExecuteCheckBox.IsChecked = (other & 1) != 0;
        }

        private void UpdateCheckBoxes(string symbolicPermissions)
        {
            OwnerReadCheckBox.IsChecked = symbolicPermissions[0] == 'r';
            OwnerWriteCheckBox.IsChecked = symbolicPermissions[1] == 'w';
            OwnerExecuteCheckBox.IsChecked = symbolicPermissions[2] == 'x';

            GroupReadCheckBox.IsChecked = symbolicPermissions[3] == 'r';
            GroupWriteCheckBox.IsChecked = symbolicPermissions[4] == 'w';
            GroupExecuteCheckBox.IsChecked = symbolicPermissions[5] == 'x';

            OtherReadCheckBox.IsChecked = symbolicPermissions[6] == 'r';
            OtherWriteCheckBox.IsChecked = symbolicPermissions[7] == 'w';
            OtherExecuteCheckBox.IsChecked = symbolicPermissions[8] == 'x';
        }
    }
}
