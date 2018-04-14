using ACM.BL;
using ACM.Win.Data;
using System;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class CustomerWin : Form
    {
        private readonly CustomerRepository customers;

        public CustomerWin()
        {
            InitializeComponent();
            customers = new WinFormCustomerRepository();
        }

        private void CustomerWin_Load(object sender, EventArgs e)
        {
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {

        }
    }
}
