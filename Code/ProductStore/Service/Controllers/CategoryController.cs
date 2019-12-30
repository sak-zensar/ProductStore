using DataRepository;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Service.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        //private ProductStoreEntities db = new ProductStoreEntities();
        private IRepository _repository = null;
        public CategoryController()
        {
            _repository = new CategoryRepository();
        }

        // GET: api/Category
        [AcceptVerbs("Get")]
        public dynamic GetCategories()
        {
            JsonResponse jsonResponse = new JsonResponse();
            string resJson = string.Empty;
            try
            {
                string functionParameters = JsonConvert.SerializeObject(new CategoryModel());
                if (!string.IsNullOrWhiteSpace(functionParameters))
                {
                    var result = _repository.GetData(functionParameters);
                    if (result != null)
                    {
                        List<CategoryModel> categoryList = (List<CategoryModel>)result;
                        jsonResponse.StatusCode = (int)HttpStatusCode.OK;
                        jsonResponse.ResultData = categoryList;
                    }
                    else
                    {
                        jsonResponse.StatusCode = (int)HttpStatusCode.NotFound;
                        jsonResponse.ErrorMessage = string.Format("No result found.");
                    }
                }
                else
                {
                    jsonResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    jsonResponse.ErrorMessage = string.Format("Error occured while creating function parameters.");
                }
            }
            catch (System.Exception ex)
            {
                jsonResponse.StatusCode = (int)HttpStatusCode.NotFound;
                jsonResponse.ErrorMessage = ex.InnerException != null ? string.Format("Exception Message: {0}, Inner Message: {1}.", ex.Message, ex.InnerException.Message) : string.Format("Exception Message: {0}.", ex.Message);
            }
            jsonResponse.IsValid = jsonResponse.ResultData != null;
            return JsonConvert.SerializeObject(jsonResponse);
        }

        // PUT: api/Category/5
        [AcceptVerbs("Put")]
        public dynamic Put([FromUri] int id, [FromBody] CategoryModel categoryModel)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                _repository.Update(JsonConvert.SerializeObject(categoryModel));
                jsonResponse.StatusCode = (int)HttpStatusCode.OK;
                jsonResponse.ResultData = string.Empty;
                jsonResponse.IsValid = true;
            }
            catch (System.Exception ex)
            {
                jsonResponse.StatusCode = (int)HttpStatusCode.NotFound;
                jsonResponse.ErrorMessage = ex.InnerException != null ? string.Format("Exception Message: {0}, Inner Message: {1}.", ex.Message, ex.InnerException.Message) : string.Format("Exception Message: {0}.", ex.Message);
                jsonResponse.IsValid = false;
            }
            return JsonConvert.SerializeObject(jsonResponse);
        }

        // POST: api/Category
        [AcceptVerbs("Post")]
        [ResponseType(typeof(Category))]
        public dynamic PostCategory([FromBody]CategoryModel categoryModel)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                _repository.Insert(JsonConvert.SerializeObject(categoryModel));
                jsonResponse.StatusCode = (int)HttpStatusCode.Created;
                jsonResponse.ResultData = string.Empty;
                jsonResponse.IsValid = true;
            }
            catch (System.Exception ex)
            {
                jsonResponse.StatusCode = (int)HttpStatusCode.NotFound;
                jsonResponse.ErrorMessage = ex.InnerException != null ? string.Format("Exception Message: {0}, Inner Message: {1}.", ex.Message, ex.InnerException.Message) : string.Format("Exception Message: {0}.", ex.Message);
                jsonResponse.IsValid = false;
            }
            return JsonConvert.SerializeObject(jsonResponse);
        }

        // DELETE: api/Category/5
        [AcceptVerbs("Delete")]
        public dynamic Delete([FromUri] int id)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                _repository.Delete(id);
                jsonResponse.StatusCode = (int)HttpStatusCode.OK;
                jsonResponse.ResultData = string.Empty;
                jsonResponse.IsValid = true;
            }
            catch (System.Exception ex)
            {
                jsonResponse.StatusCode = (int)HttpStatusCode.NotFound;
                jsonResponse.ErrorMessage = ex.InnerException != null ? string.Format("Exception Message: {0}, Inner Message: {1}.", ex.Message, ex.InnerException.Message) : string.Format("Exception Message: {0}.", ex.Message);
                jsonResponse.IsValid = false;
            }
            return JsonConvert.SerializeObject(jsonResponse);
        }

    }
}