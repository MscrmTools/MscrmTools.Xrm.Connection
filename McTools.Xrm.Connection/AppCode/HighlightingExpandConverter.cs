using System;
using System.ComponentModel;
using System.Globalization;

namespace McTools.Xrm.Connection.AppCode
{
    internal class HighlightingExpandConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
            Type destType)
        {
            if (destType == typeof(string) && value is EnvironmentHighlighting eh)
            {
                return $"{eh.Color.Value.Name} / {eh.TextColor.Value.Name} : {eh.Text}";
            }
            else if(value == null)
            {
                return "Not set";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}