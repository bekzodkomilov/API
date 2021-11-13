using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tasks.Model
{
    public class NewTask
    {

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public DateTimeOffset OnADay { get; set; }

        public DateTimeOffset AtATime { get; set; }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ETaskStatus? Status { get; set; }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ETaskRepeat? Repeat { get; set; }
        

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ETaskPriority? Priority { get; set; }

        public TaskLocation Location { get; set; }

        public string Url { get; set; }
    }
}