using ACM.BL;
using ACM.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ACM.WPF.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerNameAndType> customers;

        public ObservableCollection<CustomerNameAndType> Customers
        {
            get { return customers; }
            set
            {
                if (customers != value)
                {
                    customers = value;
                    NotifyPropertyChanged();
                }
            }
        }

        CustomerRepository customerRepository = new ACMCustomerRepository(new ACMInvoiceRepository());
        CustomerTypeRepository customerTypeRepository = new ACMCustomerTypeRepository();

        public CustomerListViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            IEnumerable<Customer> customerList = customerRepository.Retrieve();
            customerList = customerRepository.SortByName(customerList);
            var customerTypeList = customerTypeRepository.Retrieve();
            customers = new ObservableCollection<CustomerNameAndType>(
                customerRepository.GetNameAndTypes(customerList, customerTypeList));

        }
    }
}
