using ACM.BL;
using ACM.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        private List<KeyValuePair<string, decimal>> chartData;
        public List<KeyValuePair<string, decimal>> ChartData
        {
            get { return chartData; }
            set
            {
                if (chartData != value)
                {
                    chartData = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public CustomerListViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            IEnumerable<Customer> customerList = customerRepository.Retrieve();
            customerList = customerRepository.SortByName(customerRepository.Retrieve());
            var customerTypeList = customerTypeRepository.Retrieve();
            customers = new ObservableCollection<CustomerNameAndType>(
                customerRepository.GetNameAndTypes(customerList, customerTypeList));

            ChartData = customerRepository.GetInvoiceTotalByCustomerTypeInKeyValuePair(
                customerList, customerTypeList).ToList();
        }
    }
}
