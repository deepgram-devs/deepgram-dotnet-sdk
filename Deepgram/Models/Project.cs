﻿using Newtonsoft.Json;
using System;

namespace Deepgram.Models
{
    public class Project
    {
        /// <summary>
        /// Unique identifier of the Deepgram project
        /// </summary>
        [JsonProperty("project_id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Name of the Deepgram project
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Name of the company associated with the Deepgram project
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }
    }
}
