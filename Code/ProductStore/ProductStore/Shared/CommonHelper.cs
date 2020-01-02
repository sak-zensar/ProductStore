using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ProductStore.Shared
{
    public class CommonHelper
    {
        public static void DisplayErrorMessage(Exception ex, ref Label lblErrorMessage)
        {
            //Site site = new Site();
            //site.ErrorMessage = ex.InnerException != null ? string.Format("Exception Message: {0}, Inner Message: {1}.", ex.Message, ex.InnerException.Message) : string.Format("Exception Message: {0}.", ex.Message);
            /*
            / We can implement logs here instaed of showing error in followings way
            / 1. Log4Net
            / 2. File
            / 3. Database
            / 4. Event Viewer
            */
            if (lblErrorMessage != null)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = ex.InnerException != null ? string.Format("Exception Message: {0}, Inner Message: {1}.", ex.Message, ex.InnerException.Message) : string.Format("Exception Message: {0}.", ex.Message);
            }
        }

        public static void FillCategoryDropDownList(ref DropDownList ddlCategory, HiddenField hfCategory)
        {
            try
            {
                string methodNameWithQueryParameter = string.Format("Category/");
                string result = ServiceClient.GetServiceClient(methodNameWithQueryParameter);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    JsonResponse jsonObj = JsonConvert.DeserializeObject<JsonResponse>(result.Replace("\\", "").Trim('"'));
                    if (jsonObj != null && jsonObj.IsValid && jsonObj.ResultData != null)
                    {
                        List<CategoryModel> categoryList = jsonObj.ResultData.ToObject<List<CategoryModel>>(); //JsonConvert.DeserializeObject<List<CategoryModel>>(result);
                        if (categoryList != null && categoryList.Count > 0)
                        {
                            ddlCategory.DataSource = categoryList;
                            ddlCategory.DataTextField = "Name";
                            ddlCategory.DataValueField = "CategoryId";
                            ddlCategory.DataBind();
                            if (hfCategory != null)
                            {
                                string selectedCategory = hfCategory.Value.Trim();
                                ListItem liCat = ddlCategory.Items.FindByText(selectedCategory);
                                if (liCat != null)
                                {
                                    liCat.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }

        public static void FillUnitDropDownList(ref DropDownList ddlUnit, HiddenField hfUnit)
        {
            try
            {
                string methodNameWithQueryParameter = string.Format("Unit/");
                string result = ServiceClient.GetServiceClient(methodNameWithQueryParameter);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    JsonResponse jsonObj = JsonConvert.DeserializeObject<JsonResponse>(result.Replace("\\", "").Trim('"'));
                    if (jsonObj != null && jsonObj.IsValid && jsonObj.ResultData != null)
                    {
                        List<UnitModel> unitList = jsonObj.ResultData.ToObject<List<UnitModel>>();// JsonConvert.DeserializeObject<List<UnitModel>>(result);
                        if (unitList != null && unitList.Count > 0)
                        {
                            ddlUnit.DataSource = unitList;
                            ddlUnit.DataTextField = "UnitCode";
                            ddlUnit.DataValueField = "UnitId";
                            ddlUnit.DataBind();
                            if (hfUnit != null)
                            {
                                string selectedCategory = hfUnit.Value.Trim();
                                ListItem liUnit = ddlUnit.Items.FindByText(selectedCategory);
                                if (liUnit != null)
                                {
                                    liUnit.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
        }
    }
}