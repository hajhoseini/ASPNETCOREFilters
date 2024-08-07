using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace ASPNETCOREFilters.Models.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
        private string _cacheKey;
        private readonly IModelMetadataProvider _metadataProvider;

        public CustomResourceFilter(IModelMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;
        }

        //after
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if(!String.IsNullOrEmpty(_cacheKey) && !_cache.ContainsKey(_cacheKey) )
            {
                var result = context.Result as ViewResult;
                if(result != null)
                {
                    _cache.Add(_cacheKey, result.Model);
                }
            }
        }

        //before
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();

            if(_cache.ContainsKey(_cacheKey))
            {
                var cachData = _cache[_cacheKey] as string;
                if(cachData != null)
                {
                    context.Result = new ViewResult()
                    {
                        ViewName = "Index",
                        ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState)
                        {
                            Model = cachData
                        }
                    };
                }
            }
        }
    }
}
