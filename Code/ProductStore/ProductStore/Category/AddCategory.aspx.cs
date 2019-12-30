using Models;
using Newtonsoft.Json;
using ProductStore.Shared;
using System;

namespace ProductStore.Category
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            try
            {

                string categoryName = txtCategoryName.Text;
                string description = txtDescription.Text;

                CategoryModel product = new CategoryModel { Name = categoryName, Description = description };

                string jsonString = JsonConvert.SerializeObject(product);

                string methodNameWithQueryParameter = string.Format("Category/");
                string result = ServiceClient.PostServiceClient(methodNameWithQueryParameter, jsonString);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    Response.Redirect("~/Category/Category.aspx");
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
    }
}