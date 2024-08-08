using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace ASPNETCOREFilters.Models.Filters
{
    public class ShowMessageFilter : Attribute, IResultFilter
    {
        private readonly string _source;

        public ShowMessageFilter(string source)
        {
            _source = source;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Print(context, $"{_source} Executed");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Print(context, $"{_source} Executing");
        }

        private void Print(FilterContext context, string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"<div><h1>{message}</h1></div>");
            context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}