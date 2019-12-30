using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductStore.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string ErrorMessage
        {
            get
            {
                return lblErrorSummury.Text;
            }
            set
            {
                lblErrorSummury.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}