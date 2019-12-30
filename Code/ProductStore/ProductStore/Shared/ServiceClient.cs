using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ProductStore.Shared
{
    public class ServiceClient
    {
        public static dynamic GetServiceClient(string methodNameWithQueryParameter)
        {
            try
            {
                string serviceClientBaseUri = ConfigurationManager.AppSettings["WebApiBaseUrl"];
                if (!string.IsNullOrWhiteSpace(serviceClientBaseUri))
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(serviceClientBaseUri);
                        //HTTP GET
                        var responseTask = client.GetAsync(methodNameWithQueryParameter);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            return readTask.Result;
                        }
                        else
                        {
                            throw new Exception(string.Format("Status Code: {0}, Message: {1}.", result.StatusCode, result.RequestMessage));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static dynamic PostServiceClient(string methodPath, dynamic jsonStringData)
        {
            try
            {
                string serviceClientBaseUri = ConfigurationManager.AppSettings["WebApiBaseUrl"];
                if (!string.IsNullOrWhiteSpace(serviceClientBaseUri))
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(serviceClientBaseUri);

                        var stringContent = new StringContent(jsonStringData, UnicodeEncoding.UTF8, "application/json");

                        var postTask = client.PostAsync(methodPath, stringContent);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            return readTask.Result;
                        }
                        else
                        {
                            throw new Exception(string.Format("Status Code: {0}, Message: {1}.", result.StatusCode, result.RequestMessage));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        internal static string DeleteServiceClient(string methodNameWithQueryParameter)
        {
            try
            {
                string serviceClientBaseUri = ConfigurationManager.AppSettings["WebApiBaseUrl"];
                if (!string.IsNullOrWhiteSpace(serviceClientBaseUri))
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(serviceClientBaseUri);
                        //HTTP GET
                        var responseTask = client.DeleteAsync(methodNameWithQueryParameter);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            return readTask.Result;

                        }
                        else
                        {
                            throw new Exception(string.Format("Status Code: {0}, Message: {1}.", result.StatusCode, result.RequestMessage));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        internal static string PutServiceClient(string methodNameWithQueryParameter, dynamic jsonStringData)
        {
            try
            {
                string serviceClientBaseUri = ConfigurationManager.AppSettings["WebApiBaseUrl"];
                if (!string.IsNullOrWhiteSpace(serviceClientBaseUri))
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.BaseAddress = new Uri(serviceClientBaseUri);

                        var stringContent = new StringContent(jsonStringData, UnicodeEncoding.UTF8, "application/json");

                        var putTask = client.PutAsync(methodNameWithQueryParameter, stringContent);
                        putTask.Wait();

                        var result = putTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();
                            return !string.IsNullOrWhiteSpace(readTask.Result) ? readTask.Result : readTask.Status.ToString();
                        }
                        else
                        {
                            throw new Exception(string.Format("Status Code: {0}, Message: {1}.", result.StatusCode, result.RequestMessage));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}