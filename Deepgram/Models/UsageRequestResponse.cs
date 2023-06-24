﻿using Newtonsoft.Json;
using System;

namespace Deepgram.Models
{
    public class UsageRequestResponse
    {
        /// <summary>
        /// Details of the request
        /// </summary>
        [JsonProperty("details")]
        public UsageRequestResponseDetail Details { get; set; }

        /// <summary>
        /// If the request failed, this will contain the error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
