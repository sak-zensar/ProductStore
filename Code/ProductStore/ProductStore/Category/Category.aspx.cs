using Models;
using Newtonsoft.Json;
using ProductStore.Shared;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ProductStore.Category
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }

        private void BindData()
        {
            try
            {
                List<CategoryModel> categoryList = new List<CategoryModel>();
                string methodNameWithQueryParameter = string.Format("Category/");
                string result = ServiceClient.GetServiceClient(methodNameWithQueryParameter);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    JsonResponse jsonObj = JsonConvert.DeserializeObject<JsonResponse>(result.Replace("\\", "").Trim('"'));
                    if (jsonObj != null && jsonObj.IsValid && jsonObj.ResultData != null)
                    {
                        categoryList = jsonObj.ResultData.ToObject<List<CategoryModel>>();
                    }
                }
                CategoryGrid.DataSource = categoryList;
                CategoryGrid.DataBind();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }

        protected void CategoryGrid_PageIndexChanging(object source, GridViewPageEventArgs e)
        {
            try
            {
                CategoryGrid.PageIndex = e.NewPageIndex;
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
        protected void CategoryGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)CategoryGrid.Rows[e.RowIndex];
                Label lblCategoryId = row.FindControl("lblCategoryId") as Label;
                if (lblCategoryId == null)
                {
                    return;
                }

                int deleteProdId = Convert.ToInt32(lblCategoryId.Text);
                if (deleteProdId < 1)
                {
                    return;
                }

                string methodNameWithQueryParameter = string.Format("Category/{0}", deleteProdId);
                string result = ServiceClient.DeleteServiceClient(methodNameWithQueryParameter);
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
        protected void CategoryGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                CategoryGrid.EditIndex = e.NewEditIndex;
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
        protected void CategoryGrid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            try
            {
                //Finding the controls from Gridview for the row which is going to update 
                GridViewRow editedRow = CategoryGrid.Rows[e.RowIndex];
                if (editedRow != null)
                {
                    Label lbDispCategoryId = editedRow.FindControl("lbDispCategoryNum") as Label;
                    TextBox txtName = editedRow.FindControl("txtName") as TextBox;
                    TextBox txtDescription = editedRow.FindControl("txtDescription") as TextBox;
                    int catId = Convert.ToInt32(lbDispCategoryId.Text);
                    CategoryModel Category = new CategoryModel { CategoryId = catId, Name = txtName.Text.Trim(), Description = txtDescription.Text };

                    string jsonString = JsonConvert.SerializeObject(Category);
                    string methodNameWithQueryParameter = string.Format("Category/{0}", catId);
                    string result = ServiceClient.PutServiceClient(methodNameWithQueryParameter, jsonString);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                        CategoryGrid.EditIndex = -1;
                        //Call ShowData method for displaying updated data  
                        BindData();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
        protected void CategoryGrid_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            try
            {
                //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                CategoryGrid.EditIndex = -1;
                BindData();
            }
            catch (Exception ex)
            {
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
        protected void CategoryGrid_PreRender(object sender, EventArgs e)
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
                CommonHelper.DisplayErrorMessage(ex, ref lblErrorMessage);
            }
        }
        protected void CategoryGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}