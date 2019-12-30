using Models;
using Newtonsoft.Json;
using ProductStore.Shared;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductStore.Product
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindData();
                    CommonHelper.FillCategoryDropDownList(ref ddlSearchCategory, null);
                    CommonHelper.FillUnitDropDownList(ref ddlSearchUnit, null);
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }

        private void BindData(string productName = "", int categoryId = -1, string categoryName = "", int unitId = -1)
        {
            try
            {
                string methodNameWithQueryParameter = string.Format("Product/ProductSearch?ProductName={0}&CategoryId={1}&CategoryName={2}&UnitId={3}", productName, categoryId, categoryName, unitId);
                string result = ServiceClient.GetServiceClient(methodNameWithQueryParameter);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    JsonResponse jsonObj = JsonConvert.DeserializeObject<JsonResponse>(result.Replace("\\", "").Trim('"'));
                    if (jsonObj != null && jsonObj.IsValid && jsonObj.ResultData != null)
                    {
                        List<ProductDetails> productList = jsonObj.ResultData.ToObject<List<ProductDetails>>(); //(List<ProductDetails>)(jsonObj.ResultData);
                        if (productList != null && productList.Count > 0)
                        {
                            ProductGrid.DataSource = productList;
                        }
                    }
                }
                ProductGrid.DataBind();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }

        protected void ProductGrid_PageIndexChanging(object source, GridViewPageEventArgs e)
        {
            try
            {
                ProductGrid.PageIndex = e.NewPageIndex;
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
        protected void ProductGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)ProductGrid.Rows[e.RowIndex];
                Label lblProductId = row.FindControl("lblProductId") as Label;
                if (lblProductId == null)
                {
                    return;
                }

                int deleteProdId = Convert.ToInt32(lblProductId.Text);
                if (deleteProdId < 1)
                {
                    return;
                }

                string methodNameWithQueryParameter = string.Format("Product/DeleteProduct?ProductId={0}", deleteProdId);
                string result = ServiceClient.DeleteServiceClient(methodNameWithQueryParameter);
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
        protected void ProductGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ProductGrid.EditIndex = e.NewEditIndex;
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
        protected void ProductGrid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            try
            {
                //Finding the controls from Gridview for the row which is going to update 
                GridViewRow editedRow = ProductGrid.Rows[e.RowIndex];
                if (editedRow != null)
                {
                    Label lblDispProductId = editedRow.FindControl("lblDispProductId") as Label;
                    TextBox txtProductName = editedRow.FindControl("txtProductName") as TextBox;
                    DropDownList ddlCategory = editedRow.FindControl("ddlCategory") as DropDownList;
                    DropDownList ddlUnit = editedRow.FindControl("ddlUnit") as DropDownList;
                    TextBox txtPrice = editedRow.FindControl("txtPrice") as TextBox;
                    TextBox txtCurrency = editedRow.FindControl("txtCurrency") as TextBox;

                    ProductDetails product = new ProductDetails { CategoryId = Convert.ToInt32(ddlCategory.SelectedValue), ProductId = Convert.ToInt32(lblDispProductId.Text), ProductName = txtProductName.Text.Trim(), UnitId = Convert.ToInt32(ddlUnit.SelectedValue), Price = Convert.ToDecimal(txtPrice.Text), Currency = txtCurrency.Text };

                    string jsonString = JsonConvert.SerializeObject(product);
                    string methodNameWithQueryParameter = string.Format("Product/UpdateProduct");
                    string result = ServiceClient.PutServiceClient(methodNameWithQueryParameter, jsonString);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                        ProductGrid.EditIndex = -1;
                        //Call ShowData method for displaying updated data  
                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
        protected void ProductGrid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            try
            {
                //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                ProductGrid.EditIndex = -1;
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
        protected void ProductGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && ProductGrid.EditIndex == e.Row.RowIndex)
                {
                    string methodNameWithQueryParameter = string.Empty;
                    string result = string.Empty;
                    DropDownList ddlCategory = e.Row.FindControl("ddlCategory") as DropDownList;
                    if (ddlCategory != null)
                    {
                        HiddenField hfCategory = e.Row.FindControl("hfCategory") as HiddenField;
                        CommonHelper.FillCategoryDropDownList(ref ddlCategory, hfCategory);
                    }

                    DropDownList ddlUnit = e.Row.FindControl("ddlUnit") as DropDownList;
                    if (ddlUnit != null)
                    {
                        HiddenField hfUnit = e.Row.FindControl("hfUnit") as HiddenField;
                        CommonHelper.FillUnitDropDownList(ref ddlUnit, hfUnit);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
        protected void ProductGrid_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridView grid = (GridView)sender;
                if (grid != null)
                {
                    GridViewRow pagerRow = (GridViewRow)grid.BottomPagerRow;
                    if (pagerRow != null)
                    {
                        pagerRow.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = -1;
                int unitId = -1;
                if (ddlSearchCategory.SelectedIndex > 0)
                {
                    int.TryParse(ddlSearchCategory.SelectedValue, out categoryId);
                }

                if (ddlSearchUnit.SelectedIndex > 0)
                {
                    int.TryParse(ddlSearchUnit.SelectedValue, out unitId);
                }

                BindData(string.Empty, categoryId, string.Empty, unitId);

            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex);
            }
        }
    }
}