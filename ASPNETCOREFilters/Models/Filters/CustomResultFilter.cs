using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETCOREFilters.Models.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        //after
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        //before
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("MyHeader", "this is a test");
        }
    }
}
