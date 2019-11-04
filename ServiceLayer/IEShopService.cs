using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer
{
    public interface IEShopService
    {
        IQueryable<Order> GetOrders();
        IQueryable<Customer> GetCustomers();
        IQueryable<Product> GetProducts();
        IQueryable<Customer> GetCustomerByFirstname(string customerFirstname);
        IQueryable<Customer> GetCustomerByLastname(string customerLastname);
        Order GetOrderByID(int orderID);
        Customer GetCustomerByID(int customerID);
        Product GetProductByID(int productID);
        Product UpdateProduct(Product productUpdate);
        Product AddProduct(Product productNew);
        Product DeleteProduct(int productID);
        Customer UpdateCustomer(Customer customerUpdate);
        Customer AddCustomer(Customer customerNew);
        Customer DeleteCustomer(int customerID);
        int GetCountOfProducts();
        void SaveChanges();
    }
}
