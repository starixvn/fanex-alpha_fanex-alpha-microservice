using System;
using Sunplus.Agent.Model.Entities;

namespace Fanex.Alpha.MicroServices.Messages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int customerId = UserSession.Current.CustId;
            lblCustomerId.Text = "Customer: " + (customerId <= 0 ? "None" : UserSession.Current.UserName);
        }
    }
}