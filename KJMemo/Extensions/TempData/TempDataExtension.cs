using System;
using KJMemo.Models.Enums;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace KJMemo.Extensions.TempData
{
    public static class TempDataExtension
    {
        public static void Put<T>(this ITempDataDictionary tempData, ETempData key, T value) where T : class
        {
            string key_name = key.ToString();
            tempData[key_name] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, ETempData key) where T : class
        {
            string key_name = key.ToString();

            object o;
            tempData.TryGetValue(key_name, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}
