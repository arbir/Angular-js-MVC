using NewAngular.Factories;
using NewAngular.Interfaces;
using NewAngular.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewAngular.api
{
    [RoutePrefix("api")]
    public class apItemController : ApiController
    {

        // GET api/<controller>
        private iItemUnit objUnit = null;
        public apItemController()
        {
            objUnit = new fItemUnit();
        }
      //  [Route("apItem")]
        [HttpPost]
        public HttpResponseMessage temp(object[] data)
        {
            string result = "";
            try
            {
                Item cmnParam = JsonConvert.DeserializeObject<Item>(data[0].ToString());
                
                if(cmnParam!= null)
                {
                    result=objUnit.saveItemUnit(cmnParam);
                }
                else
                {
                    result = "";
                }
            }
            catch(Exception e)
            {
                e.ToString();
                result = "";
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpGet]
        public List<Item>GetAllData()
        {
            List<Item>lst=new List<Item>();
            lst = objUnit.GetItem();
            return lst;
        }

    }
}