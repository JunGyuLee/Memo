using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KJMemo.Attributes
{
    public class ContainAttribute : ValidationAttribute
    {
        public string[] Array { get; }

        /// <summary>
        /// </summary>
        /// <param name="array">String[]</param>
        public ContainAttribute(string[] array)
        {
            Array = array;
        }

        public string GetErrorMessage() => $"This value in not contain string array";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //이넘 안에 있는지 검사

            if(value != null)
            {

                string value_str = value.ToString();

                bool is_contain = Array.Contains(value_str);

                if (!is_contain)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
    }
}
