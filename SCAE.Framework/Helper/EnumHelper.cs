using System;
using System.ComponentModel;

namespace SCAE.Framework.Helper
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            if (value.ToString() == "0")
                return string.Empty;

            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }

        public static T GetValue<T>(string value) 
        {
            return (T)Enum.Parse(typeof(T), value.Replace(" ", "_"));
        }

        public static T GetCharValue<T>(string value)
        {
            try
            {
                foreach (var item in Enum.GetNames(typeof(T)))
                {
                    if ((char)Enum.Parse(typeof(T), item).GetHashCode() == char.Parse(value))
                    {
                        return (T)Enum.Parse(typeof(T), item);
                    }
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            return (T)Enum.Parse(typeof(T), value.ToString());

            //return ((char)Enum.Parse(typeof(T), value.Replace(" ", "_")).GetHashCode()).ToString();
        }
    }
}
