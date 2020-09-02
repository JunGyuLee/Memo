using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KJMemo.Attributes;

namespace KJMemo.Models.DAO
{
    public class Note : IValidatableObject
    {
        public int Id { get; set; }


        [StringLength(200, MinimumLength = 20, ErrorMessage = "${0} is {1}")]
        public string Title { get; set; }

        public string Content { get; set; }

        [Contain(new string[] { "A","B","C"})]
        public string Category { get; set; }

        private const int _min_id = 200;


        [TimeRange(3,3)]
        public long RequestTime { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (Id < _min_id)
            {
                yield return new ValidationResult(
                    $"Classic movies must have a release year no later than {_min_id}.");
            }
        }
    }
}
