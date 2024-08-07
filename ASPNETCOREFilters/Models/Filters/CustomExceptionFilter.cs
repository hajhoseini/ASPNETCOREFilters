using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ASPNETCOREFilters.Models.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly IModelMetadataProvider _metadataProvider;

        public CustomExceptionFilter(IModelMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult() { ViewName = "CustomException" };
            result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
            //result.ViewData.Add("Exception", context.Exception);

            //log
            result.ViewData.Add("Exception", "خطایی در سیستم رخ داده است");
            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
