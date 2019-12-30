using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductStore.Shared
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblInnerMessage.Visible = false;
                lblStackTrace.Visible = false;
            }
        }

        public void SetErrorMessage(string errorMessage, string innerMessage, string stackTrace)
        {
            lblErrorMessage.InnerText = errorMessage;
            if(!string.IsNullOrWhiteSpace(innerMessage))
            {
                lblInnerMessage.Visible = true;
                lblInnerMessage.InnerText = innerMessage;
            }
            if (!string.IsNullOrWhiteSpace(stackTrace))
            {
                lblStackTrace.Visible = true;
                lblStackTrace.InnerText = stackTrace;
            }
        }
    }
}