using KJMemo.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Models.DTO.Note
{
    public class RequestNoteList
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "${0} is {1}")]
        public string Title { get; set; }

        public string Content { get; set; }

        [EnumDataType(typeof(ENoteCategory))]
        [JsonConverter(typeof(StringToEnumConverter<ENoteCategory>))]
        public ENoteCategory Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

    }
}
