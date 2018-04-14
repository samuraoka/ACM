using ACM.BL;
using ACM.Win.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class CustomerWin : Form
    {
        private readonly CustomerRepository customerRepository
            = new WinFormCustomerRepository();

        public CustomerWin()
        {
            InitializeComponent();
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            var customerList = customerRepository.Retrieve();
            var unpaidCustomerList = customerRepository.GetOverdueCustomers(customerList);
            CustomerGridView.DataSource =
                customerRepository.SortByName(unpaidCustomerList).ToList();
        }
    }
}
