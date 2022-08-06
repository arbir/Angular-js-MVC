using NewAngular.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAngular.BaseInterfaces
{
    interface iGenericFactory<T> : IDisposable where T : class
    {
        string ExecuteCommandString(string spQuery, Hashtable ht);
        List<Item> ExecuteQuery();

    }
}
