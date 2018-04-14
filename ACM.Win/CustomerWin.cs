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
        private readonly CustomerTypeRepository customerTypeRepository
            = new WinFormCustomerTypeRepository();

        public CustomerWin()
        {
            InitializeComponent();
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            var customerList = customerRepository.Retrieve();
            var customerTypeList = customerTypeRepository.Retrieve();
            CustomerGridView.DataSource =
                customerRepository.GetNameAndTypes(customerList, customerTypeList).ToList();
        }
    }
}
