using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDemo_CodeSample.Commands;
using WPFDemo_CodeSample.Models;

namespace WPFDemo_CodeSample.ViewModels
{
    public class CustomerViewModel
    {
        private Customer _customer;

        private ICommand _updateCommand;

        public CustomerViewModel()
        {
            this.Customer = new Customer("Steven");
            this.UpdateCommand = new CustomerUpdateCommand(this);
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
            set { _updateCommand = value; }
        }

        public bool CanUpdate
        {
            get
            {
                if (Customer == null)
                {
                    return false;
                }
                return !String.IsNullOrWhiteSpace(Customer.Name);
            }
        }

        public void SaveChanges()
        {
            MessageBox.Show(String.Format("Updated name to be {0}.", Customer.Name));
        }
    }
}
