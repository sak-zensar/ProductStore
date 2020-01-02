using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DataRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public dynamic GetData(dynamic data)
        {
            List<CategoryModel> categories = null;

            var jsonResult = JsonConvert.DeserializeObject(data);
            if (jsonResult != null)
            {
                int CategoryId = jsonResult.CategoryId != null && jsonResult.CategoryId > 0 ? jsonResult.CategoryId : -1;
                string CategoryName = jsonResult.CategoryName != null ? jsonResult.CategoryName : string.Empty;

                using (var dbContex = new ProductStoreEntities())
                {
                    if (CategoryId.Equals(-1) && string.IsNullOrWhiteSpace(CategoryName))
                    {
                        categories = dbContex.Categories.Select(c =>
                           new CategoryModel
                           {
                               CategoryId = c.CategoryId,
                               Description = c.Description,
                               Name = c.Name
                           }
                        ).ToList<CategoryModel>();
                    }
                    if (CategoryId > 0)
                    {
                        categories = dbContex.Categories.Where(c => c.CategoryId.Equals(CategoryId)).Select(c =>
                           new CategoryModel
                           {
                               CategoryId = c.CategoryId,
                               Description = c.Description,
                               Name = c.Name
                           }
                        ).ToList<CategoryModel>();
                    }
                    if (!string.IsNullOrWhiteSpace(CategoryName))
                    {
                        if (categories != null && categories.Count > 0)
                        {
                            categories.AddRange(
                                dbContex.Categories.Where(c => c.Name.Equals(CategoryName)).Select(c =>
                                                             new CategoryModel
                                                             {
                                                                 CategoryId = c.CategoryId,
                                                                 Description = c.Description,
                                                                 Name = c.Name
                                                             }
                                                          ).ToList<CategoryModel>()
                          );

                        }
                        else
                        {
                            categories = dbContex.Categories.Where(c => c.Name.Equals(CategoryName)).Select(c =>
                                                             new CategoryModel
                                                             {
                                                                 CategoryId = c.CategoryId,
                                                                 Description = c.Description,
                                                                 Name = c.Name
                                                             }
                                                          ).ToList<CategoryModel>();
                        }
                    }
                }
            }

            return categories;
        }

        public dynamic Insert(dynamic data)
        {
            CategoryModel categoryModel = JsonConvert.DeserializeObject<CategoryModel>(data);
            if (categoryModel != null)
            {
                using (var dbContex = new ProductStoreEntities())
                {
                    dbContex.SaveCategory(categoryModel.CategoryId, categoryModel.Name, categoryModel.Description);
                    dbContex.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public dynamic Update(dynamic data)
        {
            CategoryModel categoryModel = JsonConvert.DeserializeObject<CategoryModel>(data);
            if (categoryModel != null)
            {
                using (var dbContex = new ProductStoreEntities())
                {
                    dbContex.SaveCategory(categoryModel.CategoryId, categoryModel.Name, categoryModel.Description);
                    dbContex.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public dynamic Delete(dynamic data)
        {
            int Categoryid = (int)data;
            using (var dbContex = new ProductStoreEntities())
            {
                Category removeCagtegory = dbContex.Categories.Where(c => c.CategoryId.Equals(Categoryid)).FirstOrDefault(); ;
                if (removeCagtegory != null)
                {
                    dbContex.Categories.Remove(removeCagtegory);
                    dbContex.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
