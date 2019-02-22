using Assignment1_Api.Models;
using Assignment1_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Assignment1_Client.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            PurchaseOrder po = new PurchaseOrder();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/WebApi/");
            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync("api/values/suppliers");

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var supplierRes = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                po.suppliers = JsonConvert.DeserializeObject<List<Supplier>>(supplierRes);
                Session["Suppliers"] = po.suppliers;
            }


            Res = await client.GetAsync("api/values/pomaster");

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var masterRes = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                po.POMaster = JsonConvert.DeserializeObject<List<POMaster>>(masterRes);
            }


            return View(po);
        }

        public async Task<ActionResult> Delete(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/WebApi/");

            var Res = await client.PostAsJsonAsync<string>("api/values/deletepomaster", id);

            return RedirectToAction("Index");

        }
        public ActionResult Create()
        {
            ViewBag.Suppliers = Session["Suppliers"];
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            POMaster master = new POMaster();
            master.PONO = collection["PONO"].ToString();
            master.PODATE = Convert.ToDateTime(collection["PODATE"].ToString());
            master.SUPLNO = collection["Suppliers"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/WebApi/");

            var Res = await client.PostAsJsonAsync<POMaster>("api/values/addpomaster", master);

            return RedirectToAction("Index");
        }
    }
}