using System;
using System.ComponentModel;
using System.Resources;
using System.Web;
using WebSample.Resources;

namespace WebSample.Attributes
{
    public class LabelAttribute : DisplayNameAttribute
    {
        private readonly string _resourceKey;
        private readonly Type _resource;
        private readonly bool _encodeText;

        public LabelAttribute(Type resource, string resourceKey, bool encodeText = true)
        {
            _resourceKey = resourceKey;
            _resource = resource;
            _encodeText = encodeText;
        }

        public LabelAttribute(string resourceKey, bool encodeText = true) : this(typeof (Labels), resourceKey) { }        


        public override string DisplayName
        {
            get
            {
                var resourceManager = new ResourceManager(_resource);
                var text = resourceManager.GetString(_resourceKey);

                if (string.IsNullOrWhiteSpace(text))
                    return string.Empty;

                var resource = _encodeText ? HttpUtility.HtmlEncode(text) : text;
                return resource ?? "";
            }
        }

    }
}