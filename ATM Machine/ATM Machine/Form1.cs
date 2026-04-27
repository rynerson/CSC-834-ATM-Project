using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Machine
{
    public partial class Form1 : Form
    {
        Customer currentCustomer;
        ArrayList accountList = new ArrayList();
        Account selectedAccount;
        ArrayList accountsFilter = new ArrayList();
        Account selectedAccount2;
        double machineCash = 100000;
        //codes to handle errors for the different features
        int withdrawCode = -1;
        int depositCode = -1;
        int transferCode = -1;
        //set this to whatever type of transaction we are dealing with
        string type = "";
        public Form1()
        {
            InitializeComponent();
            

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        //exit button
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        //withdraw button
        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            type = "withdraw";
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add("                            " + tempAccount.getAccountNum());
            }
        }

        

        private void button6_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel1.Visible = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel2.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAccount = (Account)accountList[listBox1.SelectedIndex];
            if (selectedAccount.checkDailyTransaction() == false)
            {
                withdrawCode = 1;
                label4.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                     + "Please select another account.";
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel9.Visible = true;
            }
            else if (type == "checkBalance")
            {
                label4.Text = "Current Balance: " + selectedAccount.checkBalance();

                tableLayoutPanel2.Visible = false;
                tableLayoutPanel9.Visible = true;

            }
            else if (type == "transfer")
            {
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel17.Visible = true;

                accountsFilter.Clear();
                listBox2.Items.Clear();
                Account tempAccount;
                Console.WriteLine("number of account: " + accountList.Count);
                
                for (int i = 0; i < accountList.Count; i++)
                {
                    tempAccount = (Account)accountList[i];
                    if(tempAccount.getAccountNum() != selectedAccount.getAccountNum())
                    {
                        accountsFilter.Add(tempAccount);
                        listBox2.Items.Add("                            " + tempAccount.getAccountNum());
                    }
                    
                }
                
            }
            else
            {
                textBox1.Text = "0";
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel3.Visible = true;
            }
        }
       


        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "1";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "2";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "2";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "3";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "4";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "4";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "5";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "5";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "6";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "6";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "7";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "7";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "8";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "8";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "9";
            else if (textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "9";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "0" && textBox1.TextLength <= 3)
                textBox1.Text = textBox1.Text + "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 1)
                textBox1.Text = "0";
            else
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            tableLayoutPanel9.Visible = false;
            if (type == "withdraw")
            {
                
                //Transactions from the account have exceeded the maximum of $3000
                if (withdrawCode == 1)
                {
                    tableLayoutPanel2.Visible = true;
                }
                //Amount will make the transactions of this account exceed max limit.
                else if (withdrawCode == 2)
                {
                    
                    tableLayoutPanel3.Visible = true;
                }
                //Amount is greater than balance
                else if (withdrawCode == 3)
                {
                    
                    tableLayoutPanel3.Visible = true;

                }
                //Machine doesn't have enough cash for withdrawal.
                else if (withdrawCode == 4)
                {

                    tableLayoutPanel3.Visible = true;
                }
                else
                    tableLayoutPanel1.Visible = true;
                withdrawCode = -1;
            }
            else if(type == "deposit")
            {
                
                if (depositCode == 1)
                {
                    tableLayoutPanel2.Visible = true;
                }
                //Amount will make the transactions of this account exceed max limit.
                else if (depositCode == 2)
                {
                    tableLayoutPanel3.Visible = true;
                }
                else
                    tableLayoutPanel1.Visible = true;
                depositCode = -1;
                

            }
            else if(type == "checkBalance")
            {
                tableLayoutPanel1.Visible = true;
                
            }
            else if(type == "transfer")
            {
                
                //Transactions from the account have exceeded the maximum of $3000
                if (transferCode == 1)
                {
                    tableLayoutPanel2.Visible = true;
                }
                //Amount will make the transactions of this account exceed max limit.
                else if (transferCode == 2)
                {
                    tableLayoutPanel3.Visible = true;
                }
                //Amount is greater than balance
                else if (transferCode == 3)
                {
                    tableLayoutPanel3.Visible = true;

                }
                //Machine doesn't have enough cash for withdrawal.
                else if (transferCode == 4)
                {
                    tableLayoutPanel3.Visible = true;
                }
                else
                    tableLayoutPanel1.Visible = true;
                transferCode = -1;
            }
                type = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double amount = Double.Parse(textBox1.Text);
            if (type == "withdraw")
            {
                

                withdrawCode = selectedAccount.withdrawMoney(amount, machineCash);
                if (withdrawCode == 0)
                {
                    label4.Text = "Please take the money.\n Transaction number: "
                        + selectedAccount.getNewTransaction().getTransNum() + "\n" + "Withdrawal amount: $"
                        + selectedAccount.getNewTransaction().getAmount() + "\n" + "From account: "
                        + selectedAccount.getAccountNum();
                }
                else if (withdrawCode == 1)
                {
                    label4.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                        + "Please select another account.";
                }
                else if (withdrawCode == 2)
                {
                    label4.Text = "The amount will make the transactions of this account exceed the max limit $3000 for today.\n"
                        + "Please enter a smaller amount.";
                }
                else if (withdrawCode == 3)
                {
                    label4.Text = "The amount you entered is greater than the balance of the selected account.\n"
                        + "Please enter a smaller amount.";
                }
                else if (withdrawCode == 4)
                {
                    label4.Text = "The machine doesn't have enough cash for your withdrawal.\n"
                        + "Please enter a smaller amount.";
                }
               
            }
            else if (type == "deposit")
            {
                depositCode = selectedAccount.depositMoney(amount);
                if (depositCode == 0)
                {
                    label4.Text = "The Machine has accepted your cash.\n Transaction number: "
                        + selectedAccount.getNewTransaction().getTransNum() + "\n" + "Deposit amount: $"
                        + selectedAccount.getNewTransaction().getAmount() + "\n" + "From account: "
                        + selectedAccount.getAccountNum();
                }
                else if(depositCode == 1)
                {
                    label4.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                       + "Please select another account.";
                }
                else if (depositCode == 2)
                {
                    label4.Text = "The amount will make the transactions of this account exceed the max limit $3000 for today.\n"
                        + "Please enter a smaller amount.";
                }

            }
            else if (type == "transfer")
            {
                transferCode = selectedAccount.transferMoney(selectedAccount2, amount, machineCash);
                if (transferCode == 0)
                {
                    label4.Text = "Transfer Successful.\n Transaction number: "
                        + selectedAccount.getNewTransaction().getTransNum() + "\n" + "Transfer amount: $"
                        + selectedAccount.getNewTransaction().getAmount() + "\n" + "From account: "
                        + selectedAccount.getAccountNum();
                }
                else if (transferCode == 1)
                {
                    label4.Text = "The transactions of this account have exceeded the max limit $3000 for today.\n"
                        + "Please select another account.";
                }
                else if (transferCode == 2)
                {
                    label4.Text = "The amount will make the transactions of this account exceed the max limit $3000 for today.\n"
                        + "Please enter a smaller amount.";
                }
                else if (transferCode == 3)
                {
                    label4.Text = "The amount you entered is greater than the balance of the selected account.\n"
                        + "Please enter a smaller amount.";
                }
                else if (transferCode == 4)
                {
                    label4.Text = "The machine doesn't have enough cash for your transfer.\n"
                        + "Please enter a smaller amount.";
                }


            }
                tableLayoutPanel3.Visible = false;
            tableLayoutPanel9.Visible = true;
            
        }

       private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add("                            " + tempAccount.getAccountNum());
            }
            type = "deposit";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            
            listBox1.Items.Clear();
            Account tempAccount;
            Console.WriteLine("number of account: " + accountList.Count);
            for (int i = 0; i < accountList.Count; i++)
            {
                tempAccount = (Account)accountList[i];
                listBox1.Items.Add("                            " + tempAccount.getAccountNum());
            }
            type = "checkBalance";
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
            type = "transfer";

            if (accountList.Count < 2)
            {
                label4.Text = "There are not enough Accounts for transfer";
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel9.Visible = true;
            }
            else
            {
                listBox1.Items.Clear();
                Account tempAccount;
                Console.WriteLine("number of account: " + accountList.Count);
                for (int i = 0; i < accountList.Count; i++)
                {
                    tempAccount = (Account)accountList[i];
                    listBox1.Items.Add("                            " + tempAccount.getAccountNum());
                }
            }

            


        }

       

       

        private void button29_Click(object sender, EventArgs e)
        {
            tableLayoutPanel17.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

      
        //account selection for the account for the money to be transferred to
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAccount2 = (Account)accountsFilter[listBox2.SelectedIndex];
            tableLayoutPanel17.Visible = false;
            tableLayoutPanel3.Visible = true;
            
        }

        private void button31_Click(object sender, EventArgs e)
        {
            tableLayoutPanel19.Visible = false;
            tableLayoutPanel21.Visible = true;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "1";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "1";
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "2";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "2";
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "3";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "3";
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "4";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "4";
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "5";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "5";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "6";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "6";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "7";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "7";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "8";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "8";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
                textBox2.Text = "9";
            else if (textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "9";
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "0" && textBox2.TextLength <= 3)
                textBox2.Text = textBox2.Text + "0";
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 1)
                textBox2.Text = "0";
            else
                textBox2.Text = textBox2.Text.Substring(0, textBox2.TextLength - 1);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            textBox2.Text = "0";
        }

        private void button34_Click(object sender, EventArgs e)
        {

            if(verifyPin() == 0)
            {
                tableLayoutPanel21.Visible = false;
                tableLayoutPanel1.Visible = true;
                currentCustomer = new Customer(1);
                accountList = Account.retrieveAccounts(currentCustomer.getID());

            }
            else
            {
                tableLayoutPanel21.Visible = false;
                tableLayoutPanel27.Visible = true;
            }

        }
        //verify that the pin is correct
        private int verifyPin()
        {
            string password = "1234";
            if(textBox2.Text == password)
            {
                return 0;
            }
            return 1;
            
        }

        private void button47_Click(object sender, EventArgs e)
        {
            tableLayoutPanel27.Visible = false;
            tableLayoutPanel19.Visible = true;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            tableLayoutPanel21.Visible = false;
            tableLayoutPanel19.Visible = true;
        }

    }
}
