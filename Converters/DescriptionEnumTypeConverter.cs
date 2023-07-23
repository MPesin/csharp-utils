using System;
using System.ComponentModel;
using System.Reflection;


namespace Utils.Converters
{
    public class DescriptionEnumTypeConverter : EnumConverter
    {
        public DescriptionEnumTypeConverter(Type type)
            : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                        System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            if (value != null)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                if (fi != null)
                {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0 && !String.IsNullOrEmpty(attributes[0].Description))
                        return attributes[0].Description;
                    else
                        return value.ToString();
                }
            }
            return string.Empty;
        }
    }
}
