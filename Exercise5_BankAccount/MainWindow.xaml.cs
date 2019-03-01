using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Exercise5_BankAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BankAccount> bankAccounts = new ObservableCollection<BankAccount>();

        public BankAccount selectedBankAccount = new BankAccount();

        public MainWindow()
        {
            InitializeComponent();

            bankAccounts.Add(new BankAccount(7654321, 124390, "John", 2011.11m));
            bankAccounts.Add(new BankAccount(1255322, 124390, "Sally", 532.45m));
            bankAccounts.Add(new BankAccount(4653536, 124390, "Mike", 232.11m));
            bankAccounts.Add(new BankAccount(3242354, 124390, "Don", 7821.91m));
            bankAccounts.Add(new SavingsAccount(3653242, 124390, "Larry", 10000m, 0.01m));

            listBoxBankAccounts.ItemsSource = bankAccounts;

        }

        private void ListBoxBankAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBankAccount = listBoxBankAccounts.SelectedItem as BankAccount;

            textBlockShowAccount.Text = selectedBankAccount.DisplayAccount();
        }

        private void ButtonAddInterest_Click(object sender, RoutedEventArgs e)
        {
            selectedBankAccount.AddInterest();
            listBoxBankAccounts.SelectedItem = selectedBankAccount;
            textBlockShowAccount.Text = selectedBankAccount.DisplayAccount();
        }

        private void ButtonWithdraw_Click(object sender, RoutedEventArgs e)
        {

            if (decimal.TryParse(textBoxAmount.Text, out decimal amount))
            {
                foreach (var account in bankAccounts)
                {
                    if (account == selectedBankAccount)
                    {
                        account.Withdraw(amount);
                    }
                }
                textBlockShowAccount.Text = selectedBankAccount.DisplayAccount();
            }
        }

        private void ButtonDeposit_Click(object sender, RoutedEventArgs e)
        {

            if (decimal.TryParse(textBoxAmount.Text, out decimal amount))
            {
                selectedBankAccount.Deposit(amount);
                listBoxBankAccounts.SelectedItem = selectedBankAccount;
                textBlockShowAccount.Text = selectedBankAccount.DisplayAccount();
            }
        }

        private void WriteToFile(ObservableCollection<BankAccount> bank_accounts)
        {
            string[] account_strings = new string[bankAccounts.Count];

            BankAccount ba;

            for (int i = 0; i < account_strings.Length; i++)
            {
                ba = bank_accounts.ElementAt(i);
                account_strings[i] = ba.DisplayAccount();
            }

            File.WriteAllLines(@"D:\temp\BankAccounts.txt", account_strings);
        }

        private void ButtonSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile(bankAccounts);
        }
    }
}
