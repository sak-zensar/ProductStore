using DataRepository;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Service.Controllers
{
    public class UnitController : ApiController
    {
        private ProductStoreEntities db = new ProductStoreEntities();
        private IUnitRepositoryInterface _repository = null;
        public UnitController(IUnitRepositoryInterface unitRepository)
        {
            _repository = unitRepository;
        }
        // GET: api/Unit
        [AcceptVerbs("Get")]
        public dynamic GetUnits()
        {
            JsonResponse jsonResponse = new JsonResponse();
            string resJson = string.Empty;
            try
            {
                string functionParameters = JsonConvert.SerializeObject(new UnitModel());
                if (!string.IsNullOrWhiteSpace(functionParameters))
                {
                    var result = _repository.GetData(functionParameters);
                    if (result != null)
                    {
                        jsonResponse.StatusCode = (int)HttpStatusCode.OK;
                        jsonResponse.ResultData = (List<UnitModel>)result;
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

    }
}