using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using DataLayer.Entities;

namespace ServiceLayer
{
    public class EShopService : IEShopService
    {
        private readonly EShopContext _context;

        public EShopService(EShopContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public IQueryable<Customer> GetCustomerByFirstname(string customerFirstname)
        {
            var query = _context.Customers
                .Where(c => string.IsNullOrEmpty(customerFirstname) || c.Firstname.StartsWith(customerFirstname))
                .OrderBy(f => f.Firstname);

            return query;
        }

        public IQueryable<Customer> GetCustomerByLastname(string customerLastname)
        {
            var query = _context.Customers
                .Where(c => string.IsNullOrEmpty(customerLastname) || c.Lastname.StartsWith(customerLastname))
                .OrderBy(f => f.Lastname);

            return query;
        }

        public Order GetOrderByID(int orderID)
        {
            return _context.Orders.Find(orderID);
        }

        public Customer GetCustomerByID(int customerID)
        {
            return _context.Customers.Find(customerID);
        }

        public Product GetProductByID(int productID)
        {
            return _context.Products.Find(productID);
        }

        public Product UpdateProduct(Product productUpdate)
        {
            _context.Products.Update(productUpdate);
            return productUpdate;
        }

        public Product AddProduct(Product productNew)
        {
            _context.Products.Add(productNew);
            return productNew;
        }

        public Product DeleteProduct(int productID)
        {
            var product = GetProductByID(productID);
            if (product != null) _context.Products.Remove(product);
            return product;
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            _context.Customers.Update(customerUpdate);
            return customerUpdate;
        }

        public Customer AddCustomer(Customer customerNew)
        {
            _context.Customers.Add(customerNew);
            return customerNew;
        }

        public Customer DeleteCustomer(int customerID)
        {
            var customer = GetCustomerByID(customerID);
            if (customer != null) _context.Customers.Remove(customer);
            return customer;
        }

        public int GetCountOfProducts()
        {
            return _context.Products.Count();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
