using ACM.BL;
using ACM.Win.Data;
using System;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class CustomerWin : Form
    {
        private readonly CustomerRepository customers
            = new WinFormCustomerRepository();

        public CustomerWin()
        {
            InitializeComponent();
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            CustomerGridView.DataSource = customers.Retrieve();
        }
    }
}
