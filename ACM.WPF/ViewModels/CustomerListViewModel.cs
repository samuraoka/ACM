using ACM.BL;
using ACM.Data;
using System.Collections.ObjectModel;

namespace ACM.WPF.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> customers;

        public ObservableCollection<Customer> Customers
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

        CustomerRepository customerRepository = new ACMCustomerRepository();

        public CustomerListViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            var customerList = customerRepository.Retrieve();
            var sortedList = customerRepository.SortByName(customerList);
            customers = new ObservableCollection<Customer>(customerList);

        }
    }
}
