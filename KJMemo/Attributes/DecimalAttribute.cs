using System;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Attributes
{
    public class DecimalAttribute : RegularExpressionAttribute
    {
        public int DecimalPlaces { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="decimalPlaces">검증할 최대 자릿수</param>
        public DecimalAttribute(int decimalPlaces)
            : base(string.Format(@"^\d*\.?\d{{0,{0}}}$", decimalPlaces))
        {
            DecimalPlaces = decimalPlaces;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("This number can have maximum {0} decimal places", DecimalPlaces);
        }
    }
}
