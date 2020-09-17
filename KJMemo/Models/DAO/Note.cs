﻿using KJMemo.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Models.DAO
{
    public class Note
    {

        [Key]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "${0} max length is {1}")]
        public string Title { get; set; }

        [StringLength(2000, ErrorMessage = "${0} max length is {1}")]
        public string Content { get; set; }

        [EnumDataType(typeof(ENoteCategory))]
        [JsonConverter(typeof(StringToEnumConverter<ENoteCategory>))]
        public ENoteCategory Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
