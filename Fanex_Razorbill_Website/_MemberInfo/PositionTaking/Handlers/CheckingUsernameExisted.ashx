<%@ WebHandler Language="C#" Class="CheckingUsernameExisted" %>

using Fanex.Age.UI;
using Fanex.Razorbill.Module.ContextualCustomer.Services.CustomerInfo;

public class CheckingUsernameExisted : TplHandler, System.Web.SessionState.IReadOnlySessionState 
{

    string userName = string.Empty;

    public override void ProcessRequest(ref System.Collections.Hashtable p)
    {
        if (Request.Form["username"] != null)
        {
            userName = Request.Form["username"].ToString();
        }
        else
        {
            userName = Request.QueryString["username"];
        }
    }

    public override object ValidateRequest(System.Collections.Hashtable p)
    {
        return null;
    }

    public override object InvokeData(System.Collections.Hashtable p)
    {
        ICustomerInfoService customerService = new CustomerInfoService();
        var isExisted = customerService.CheckingUsernameIsExisted(userName);

        return new Result(isExisted ? 1 : 0, string.Empty);
    }

    public override void RenderResult(ref JSONData data)
    {
        Result r = View as Result;
        data.AsResult(r);
    }

}