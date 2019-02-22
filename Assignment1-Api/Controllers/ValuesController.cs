using Assignment1_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1_Api.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/values/suppliers")]
        public List<Supplier> GetSuppliers()
        {
            DALLayer dalObj = new DALLayer();
            return dalObj.GetSuppliers();
        }

        [HttpGet]
        [Route("api/values/items")]
        public List<Item> GetItems()
        {
            DALLayer dalObj = new DALLayer();
            return dalObj.GetItems();
        }

        [HttpGet]
        [Route("api/values/pomaster")]
        public List<POMaster> GetPOMaster()
        {
            DALLayer dalObj = new DALLayer();
            return dalObj.GetPOMaster();
        }

        [HttpGet]
        [Route("api/values/podetail")]
        public List<PODetail> GetPODetails()
        {
            DALLayer dalObj = new DALLayer();
            return dalObj.GetPODetails();
        }

        [HttpPost]
        [Route("api/values/addpomaster")]
        public void AddPOMaster([FromBody]POMaster value)
        {
            DALLayer dalObj = new DALLayer();
            dalObj.AddPOMaster(value);
        }


        [HttpPost]
        [Route("api/values/deletepomaster")]
        public void DeletePOMaster([FromBody]string id)
        {
            DALLayer dalObj = new DALLayer();
            dalObj.DeletePOMaster(id);
        }
    }
}
