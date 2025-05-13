using System;
using System.Linq;
using Random = UnityEngine.Random;

namespace Code.Common.Extensions
{
    public static class EnumExtensions
    {
        public static T GetRandom<T>(params T[] exclude) where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            T enumValue;
            
            do
            {
                var index = Random.Range(0, values.Length);
                enumValue = (T)values.GetValue(index);
            }
            while (exclude.Any(item => item.Equals(enumValue)));

            return enumValue;
        }
    }
}