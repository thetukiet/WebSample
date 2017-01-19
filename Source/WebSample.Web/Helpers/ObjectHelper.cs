using System.Linq;
using System.Reflection;
using System.Web.Routing;

namespace WebSample.Helpers
{
    public static class ObjectHelper
    {
        public static RouteValueDictionary ToRouteValueDictionary(this object source, 
            BindingFlags bindingAttr = BindingFlags.DeclaredOnly 
            | BindingFlags.Public 
            | BindingFlags.Instance)
        {
            var dataDict = source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

            return new RouteValueDictionary(dataDict);
        }
    }
}