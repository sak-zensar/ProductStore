using DataRepository;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Service.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IProductRepositoryInteface _productorRepository = null;
        public ProductController(IProductRepositoryInteface productorRepository)
        {
            _productorRepository = productorRepository;
        }
        [AcceptVerbs("Get")]
        [Route("ProductSearch")]
        public dynamic ProductSearch([FromUri] string ProductName, [FromUri]int CategoryId, [FromUri]string CategoryName, [FromUri]int UnitId)
        {
            JsonResponse jsonResponse = new JsonResponse();
            string resJson = string.Empty;
            try
            {
                string functionParameters = JsonConvert.SerializeObject(new { ProductName = ProductName, CategoryId = CategoryId, CategoryName = CategoryName, UnitId = UnitId });
                if (!string.IsNullOrWhiteSpace(functionParameters))
                {
                    var result = _productorRepository.GetData(functionParameters);
                    if (result != null)
                    {
                        List<ProductDetails> products = (List<ProductDetails>)result;
                        jsonResponse.StatusCode = (int)HttpStatusCode.OK;
                        jsonResponse.ResultData = products;
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

        [AcceptVerbs("Post")]
        [Route("InsertProduct")]
        public dynamic InsertProduct([FromBody] ProductDetails product)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                _productorRepository.Insert(JsonConvert.SerializeObject(product));
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

        [AcceptVerbs("Put")]
        [Route("UpdateProduct")]
        public dynamic UpdateProduct([FromBody] ProductDetails product)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                _productorRepository.Update(JsonConvert.SerializeObject(product));
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

        [AcceptVerbs("Delete")]
        [Route("DeleteProduct")]
        public dynamic DeleteProduct([FromUri] int ProductId)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                _productorRepository.Delete(ProductId);
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
