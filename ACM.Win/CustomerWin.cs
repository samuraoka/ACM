using ACM.BL;
using ACM.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ACM.Win
{
    public partial class CustomerWin : Form
    {
        private readonly CustomerRepository customerRepository
            = new ACMCustomerRepository();
        private readonly CustomerTypeRepository customerTypeRepository
            = new ACMCustomerTypeRepository();

        public CustomerWin()
        {
            InitializeComponent();
        }

        private void CustomerWin_Load(object sender, EventArgs e)
        {
            var customerList = customerRepository.Retrieve();
            CustomerComboBox.DataSource = customerRepository.GetNamesAndId(customerList);
        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            var customerList = customerRepository.Retrieve();
            var customerTypeList = customerTypeRepository.Retrieve();
            CustomerGridView.DataSource =
                customerRepository.GetNameAndTypes(customerList, customerTypeList).ToList();
        }

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = sender as ComboBox;
            if (box?.SelectedValue != null)
            {
                int customerId;
                if (int.TryParse(box.SelectedValue.ToString(), out customerId))
                {
                    var customerList = customerRepository.Retrieve();
                    CustomerGridView.DataSource = customerRepository.Find(customerList, customerId).ToList();
                }
            }
        }
    }
}
