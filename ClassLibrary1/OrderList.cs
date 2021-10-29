using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    class OrderList : IEnumerable<Order>
    {
        public IList<Order> orders { get; private set; }

        public OrderList()
        {
            
            orders = new List<Order>
            {
                new Order("firstName1",  "lastName1", "New", DateTime.Now, "pName1", 100,1),
                new Order("firstName2",  "lastName2", "Received", DateTime.Now, "pName2", 100,2),
                new Order("firstName3",  "lastName3", "New", DateTime.Now, "pName3", 100,3),
                new Order("firstName4",  "lastName4", "Canceled", DateTime.Now, "pName4", 100,4),
                new Order("firstName5",  "lastName5", "New", DateTime.Now, "pName5", 100,5)
            };
        }
        internal void AddOrder(Order order)
        {
            orders.Add(order);
        }
        internal void RemoveOrder(Order order)
        {
            orders.Remove(order);
        }

        internal Order FindOrder(string fn, string ln, string pn)
        {
            Order order = null;
            var orderList = new OrderList();
            foreach (var o in orderList)
            {
                if (o.FirstName == fn && o.LastName == ln && o.PName == pn)
                    order = o;
            }
            return order;
        }


        public IEnumerator<Order> GetEnumerator()
        {
            return orders.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return orders.GetEnumerator();
        }


    }
}
