using System;
using System.Globalization;
using System.Web.Mvc;
using WebSample.Resources;
using WebSample.ViewModels;

namespace WebSample
{
    public class ModelBinding
    {
        public static void RegisterModelBinders()
        {
            //ModelBinders.Binders.Add(typeof(UserViewModel), new MyDateTimeModelBinder());
        }
    }

    public class MyDateTimeModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var displayFormat = bindingContext.ModelMetadata.DisplayFormatString;
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (!string.IsNullOrEmpty(displayFormat) && value != null)
            {
                DateTime date;
                displayFormat = displayFormat.Replace("{0:", string.Empty).Replace("}", string.Empty);
                
                // Use the format specified in the DisplayFormat attribute to parse the date
                if (DateTime.TryParseExact(value.AttemptedValue, displayFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }

                bindingContext.ModelState.AddModelError(
                    bindingContext.ModelName,
                    string.Format(ErrorMessages.InvalidDateFormat, value.AttemptedValue)
                );
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
