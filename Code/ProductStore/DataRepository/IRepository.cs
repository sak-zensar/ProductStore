using Models;
using System.Collections.Generic;

namespace DataRepository
{
    public interface IRepository
    {
        dynamic Insert(dynamic data);
        dynamic Update(dynamic data);
        dynamic Delete(dynamic data);
        dynamic GetData(dynamic data);
    }
}
