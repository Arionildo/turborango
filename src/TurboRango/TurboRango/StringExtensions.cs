using System;

namespace TurboRango.Dominio
{
    public static class StringExtensions
    {
        public static T ToEnum<T>(this string str, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), str, ignoreCase);
        }
    }
}