using NewAngular.BaseFactories;
using NewAngular.BaseInterfaces;
using NewAngular.Interfaces;
using NewAngular.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewAngular.Factories
{
    public class fItemUnit : iItemUnit
    {
        private iGenericFactory<Item> genericobj = null;
        
        public string saveItemUnit(Item it)
        {
            genericobj = new GenericFactory<AngularUnitEntities, Item>();
            string spQuery = "";
            string result = "";
            try
            {
                Hashtable ht =new Hashtable();
                ht.Add("Csgroup",it.Csgroup);
                ht.Add("Code",it.Code);
                ht.Add("Name",it.Name);
                ht.Add("Qty",it.Qty);
                ht.Add("Price",it.Price);

                spQuery = "[InsertData]";
                result = genericobj.ExecuteCommandString(spQuery, ht);
            }
            catch(Exception e)
            {
                e.ToString();
            }
            return result;
        }
     public   List<Item>GetItem()
        {
            genericobj = new GenericFactory<AngularUnitEntities, Item>();
            List<Item> lst = genericobj.ExecuteQuery();
            return lst;
        }
    }
}