using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

public class MyAttribute : TypeFilterAttribute
{
    private string ids;
    public MyAttribute() : base(typeof(BasicAuthorize))
    {
        Arguments = new object[] { ids = "12345" };
    }
}

public class BasicAuthorize : IAuthorizationFilter
{
    private readonly IConfiguration configuration;
    private readonly MyService myServicee;
    private readonly string ids;

    public BasicAuthorize(IConfiguration configuration, MyService myService, string ids)
    {
        this.configuration = configuration;
        this.myServicee = myService;
        this.ids = ids;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string result = "configuration is null: " + configuration.GetValue("Test", "");
        //string result = "Random Number is " + myServicee.num;
        context.Result = new OkObjectResult(result);
    }
}