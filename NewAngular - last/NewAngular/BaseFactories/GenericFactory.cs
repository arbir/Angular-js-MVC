using NewAngular.BaseInterfaces;
using NewAngular.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace NewAngular.BaseFactories
{
    public class GenericFactory<C, T> : iGenericFactory<T>
        where T : class
        where C : AngularUnitEntities, new()
    {
        private C _dbctx = new C();
        protected C Context
        {
            get { return _dbctx; }
            set { _dbctx = value; }
        }

        /// <summary>
        /// Insert/Update/Delete Data To Database
        /// Get int Data after CRUD
        /// <para>Use it when to Insert/Update/Delete data through a stored procedure</para>
        /// </summary>
        
        public virtual string ExecuteCommandString(string spQuery, Hashtable ht)
        {
            string result = "successfull";
            var temp = false;
            try
            {
                using (_dbctx.Database.Connection)
                {
                    _dbctx.Database.Connection.Open();
                    DbCommand cmd = _dbctx.Database.Connection.CreateCommand();
                    cmd.CommandText = spQuery;
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (object obj in ht.Keys)
                    {
                        string str = Convert.ToString(obj);
                        SqlParameter parameter = new SqlParameter("@" + str, ht[obj]);
                        cmd.Parameters.Add(parameter);
                    }
/*
                    IDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        result = Convert.ToString(dr.GetString(0));
                    }
                    
                    //cmd.Parameters.Clear();*/
                    cmd.ExecuteNonQuery();
                    temp = true;
                }
            }
            catch (Exception e)
            {
                throw e;
                //e.Message.ToString();
                //e.StackTrace.ToString();
            }
            if(temp)
            {
                return result;
            }
            return "Fuck you!!, It didn't work";
            
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    _dbctx.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get Data From Database
        /// <para>Use it when to retive data through a stored procedure</para>
        /// </summary>
        public List<Item> ExecuteQuery()
        {
           /* var db = new AngularUnitEntities();
            var data = db.ShowData();
            return data.ToList();*/
            
            List<Item> lst = new List<Item>();
            using (_dbctx.Database.Connection)
            {

                _dbctx.Database.Connection.Open();
                DbCommand cmd = _dbctx.Database.Connection.CreateCommand();
                cmd.CommandText = "ShowData";
                cmd.CommandType = CommandType.StoredProcedure;

              
                /*
                                    IDataReader dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        result = Convert.ToString(dr.GetString(0));
                                    }
                    
                                    //cmd.Parameters.Clear();*/
                
                IDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    lst.Add(new Item
                    {
                        Id=Convert.ToInt32(dr["Id"]),
                        Csgroup = dr["Csgroup"].ToString(),
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                        Qty = Convert.ToInt32(dr["Qty"]),
                        Price = Convert.ToInt32(dr["Price"])
                    });
                }
            
            }
            return lst;
        }
      
    }

}
