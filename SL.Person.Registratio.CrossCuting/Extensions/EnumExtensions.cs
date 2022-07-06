using System;
using System.ComponentModel;
using System.Reflection;

namespace SL.Person.Registratio.CrossCuting.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum valeu)
        {
            var fieldInfo = valeu.GetType().GetField(valeu.ToString());

            if (fieldInfo == null) return null;

            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }
    }
}
