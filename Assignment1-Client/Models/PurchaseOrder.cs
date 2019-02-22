using Assignment1_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1_Client.Models
{
    public class PurchaseOrder
    {
        public List<Supplier> suppliers { get; set; }
        public List<Item> items { get; set; }
        public List<POMaster> POMaster { get; set; }
        public List<PODetail> PODetail { get; set; }
    }
}