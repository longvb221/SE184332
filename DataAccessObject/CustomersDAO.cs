using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CustomersDAO
    {
        private static CustomersDAO instance;
        private static readonly object instanceLock = new object();
        private List<Customers> customers;

        private CustomersDAO()
        {
            customers = new List<Customers>
            {
              
                new Customers { CustomerID = 1, CompanyName = "Company A", ContactName = "Long", ContactTitle = "Sales", Address = "789 Oak St", Phone = "555-123-4567" },
                new Customers { CustomerID = 2, CompanyName = "Company B", ContactName = "David", ContactTitle = "Support", Address = "321 Pine St", Phone = "444-987-6543" },
                new Customers { CustomerID = 3, CompanyName = "Company C", ContactName = "Eve", ContactTitle = "Marketing", Address = "654 Maple St", Phone = "222-333-4444" },
                new Customers { CustomerID = 4, CompanyName = "Company D", ContactName = "Frank", ContactTitle = "HR", Address = "111 Cedar St", Phone = "111-222-3333" },
                new Customers { CustomerID = 5, CompanyName = "Company E", ContactName = "Grace", ContactTitle = "IT", Address = "222 Birch St", Phone = "333-444-5555" },
            };
        }

        public static CustomersDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomersDAO();
                    }
                    return instance;
                }
            }
        }
        // Get all customers
        public List<Customers> GetAll() => customers;

        // Get customer by ID
        public Customers GetById(int id) =>
            customers.FirstOrDefault(c => c.CustomerID == id);

        // Add new customer
        public void Add(Customers customer)
        {
            if (customers.Any(c => c.CustomerID == customer.CustomerID))
                throw new Exception("CustomerID already exists.");
            customers.Add(customer);
        }

        // Update existing customer
        public void Update(Customers updatedCustomer)
        {
            var existing = GetById(updatedCustomer.CustomerID);
            if (existing != null)
            {
                existing.CompanyName = updatedCustomer.CompanyName;
                existing.ContactName = updatedCustomer.ContactName;
                existing.ContactTitle = updatedCustomer.ContactTitle;
                existing.Address = updatedCustomer.Address;
                existing.Phone = updatedCustomer.Phone;
            }
            else
            {
                throw new Exception("Customer not found.");
            }
        }

        // Delete customer by ID
        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
            else
            {
                throw new Exception("Customer not found.");
            }
        }

        // Search customers by name or company
        public List<Customers> Search(string keyword)
        {
            return customers
                .Where(c =>
                    (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.ToLower().Contains(keyword.ToLower())) ||
                    (!string.IsNullOrEmpty(c.ContactName) && c.ContactName.ToLower().Contains(keyword.ToLower()))
                )
                .ToList();
        }
    }
}
