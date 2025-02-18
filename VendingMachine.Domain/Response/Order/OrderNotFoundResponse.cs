using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Domain.Response.Order
{
    public class OrderNotFoundResponse : ApiNotFoundResponse
    {
        public OrderNotFoundResponse(int id) : base($"An order with Id {id} was not found.")
        {
        }
    }
}
