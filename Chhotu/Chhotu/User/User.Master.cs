using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chhotu.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.AbsoluteUri.ToString().Contains("~/Default.aspx"))
            {
                form1.Attributes.Add("class", "sub_page");
            }
            else
            {
                form1.Attributes.Remove("class");
                Control sliderUserControl = Page.LoadControl("~/User/SliderUserControl.ascx");
                pnlSliderUC.Controls.Add(sliderUserControl); 
            }
            if (Session["userId"] != null)
            {
                lbLoginOrLogout.Text = "Logout";
            }
            else
            {
                lbLoginOrLogout.Text = "Login";
            }
        }

        protected void lbLoginOrLogout_Click(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("~/User/Login.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("~/User/Login.aspx");
            }
        }

        protected void lbRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if (Session["userId"] != null)
            {
                lbRegisterOrProfile.ToolTip = "User Profile";
                Response.Redirect("~/User/Profile.aspx");
            }
            else
            {
                lbRegisterOrProfile.ToolTip = "User Registration";
                Response.Redirect("~/User/Registration.aspx");
            }
        }
    }
}