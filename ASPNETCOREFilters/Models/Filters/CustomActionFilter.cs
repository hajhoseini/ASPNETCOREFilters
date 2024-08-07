using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETCOREFilters.Models.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        //after
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        //before
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault();
            if(param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Model is null");
            }
            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
