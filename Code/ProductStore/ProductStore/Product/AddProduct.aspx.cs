using Models;
using Newtonsoft.Json;
using ProductStore.Shared;
using System;
using System.Web.UI;

namespace ProductStore.Product
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    CommonHelper.FillCategoryDropDownList(ref ddlCategory, null);
                    CommonHelper.FillUnitDropDownList(ref ddlUnits, null);
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }

        protected void btnProsuctSave_Click(object sender, EventArgs e)
        {
            try
            {
                string prodName = txtProductName.Text;
                int categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                int unitId = Convert.ToInt32(ddlUnits.SelectedValue);
                decimal price = Convert.ToDecimal(txtPrice.Text);
                string currency = txtCurrency.Text;

                ProductDetails product = new ProductDetails { CategoryId = categoryId, ProductId = 0, ProductName = prodName, UnitId = unitId, Price = price, Currency = currency };

                string jsonString = JsonConvert.SerializeObject(product);

                string methodNameWithQueryParameter = string.Format("Product/InsertProduct");
                string result = ServiceClient.PostServiceClient(methodNameWithQueryParameter, jsonString);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    Response.Redirect("~/Product/Product.aspx");
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
    }
}