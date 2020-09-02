using System;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Attributes
{
    public class TimeRangeAttribute : ValidationAttribute
    {
        private int MinMinute { get; }
        private int MaxMinute { get; }

        public TimeRangeAttribute(int min_minute, int max_minute)
        {

            MinMinute = min_minute;
            MaxMinute = max_minute;

        }

        public string GetErrorMessage() => $"Timestamp Error";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //요청 시간이 지정 범주 안에 있는지 확인

            long TimeSpan;

            bool IsLongType = long.TryParse(value.ToString(), out TimeSpan);

            if (IsLongType)
            {

                long Now =  DateTimeOffset.Now.ToUnixTimeSeconds();

                if(Now - TimeSpan > MinMinute*60)
                {

                    return new ValidationResult(String.Format("more then {0} minute", MinMinute));
                }
                else if(TimeSpan - Now > MinMinute*60)
                {

                    return new ValidationResult(String.Format("is less then {0} minute", MaxMinute));
                }

                return ValidationResult.Success;
                
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }

        }


    }
}
