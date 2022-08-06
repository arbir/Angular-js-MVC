using NewAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAngular.Interfaces
{
    public interface iItemUnit
    {
        string saveItemUnit(Item it);
        List<Item> GetItem();
    }
}
