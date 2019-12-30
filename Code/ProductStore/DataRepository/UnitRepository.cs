using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataRepository
{
    public class UnitRepository : IRepository
    {
        public dynamic Delete(dynamic data)
        {
            throw new NotImplementedException();
        }

        public dynamic GetData(dynamic data)
        {
            List<UnitModel> unitList = null;
            UnitModel jsonResult = JsonConvert.DeserializeObject<UnitModel>(data);
            if (jsonResult != null)
            {
                using (var dbContex = new ProductStoreEntities())
                {
                    if (jsonResult.UnitId.Equals(0) && string.IsNullOrWhiteSpace(jsonResult.UnitCode))
                    {
                        unitList = dbContex.Units.Select(c =>
                           new UnitModel
                           {
                               UnitId = c.UnitId,
                               Description = c.Description,
                               UnitCode = c.UnitCode
                           }
                        ).ToList<UnitModel>();
                    }
                    if (jsonResult.UnitId > 0)
                    {
                        unitList = dbContex.Units.Where(c => c.UnitId.Equals(jsonResult.UnitId)).Select(c =>
                           new UnitModel
                           {
                               UnitId = c.UnitId,
                               Description = c.Description,
                               UnitCode = c.UnitCode
                           }
                        ).ToList<UnitModel>();
                    }
                    if (!string.IsNullOrWhiteSpace(jsonResult.UnitCode))
                    {
                        if (unitList != null && unitList.Count > 0)
                        {
                            unitList.AddRange(
                                dbContex.Units.Where(c => c.UnitCode.Equals(jsonResult.UnitCode)).Select(c =>
                                                             new UnitModel
                                                             {
                                                                 UnitId = c.UnitId,
                                                                 Description = c.Description,
                                                                 UnitCode = c.UnitCode
                                                             }
                                                          ).ToList<UnitModel>()
                          );

                        }
                        else
                        {
                            unitList = dbContex.Units.Where(c => c.UnitCode.Equals(jsonResult.UnitCode)).Select(c =>
                                                             new UnitModel
                                                             {
                                                                 UnitId = c.UnitId,
                                                                 Description = c.Description,
                                                                 UnitCode = c.UnitCode
                                                             }
                                                          ).ToList<UnitModel>();
                        }
                    }
                }
            }
            return unitList;
        }

        public dynamic Insert(dynamic data)
        {
            throw new NotImplementedException();
        }

        public dynamic Update(dynamic data)
        {
            throw new NotImplementedException();
        }
    }
}
