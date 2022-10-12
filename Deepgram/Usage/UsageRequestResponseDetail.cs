﻿using System;
using Newtonsoft.Json;

namespace Deepgram.Usage
{
    public class UsageRequestResponseDetail
    {
        /// <summary>
        /// Cost of the request in USD, if project is non-contract and the requesting account has appropriate permissions.
        /// </summary>
        [JsonProperty("usd")]
        public Nullable<decimal> USD { get; set; }

        /// <summary>
        /// Length of time (in hours) of audio processed in the request.
        /// </summary>
        [JsonProperty("duration")]
        public Nullable<decimal> Duration { get; set; }

        /// <summary>
        /// Number of audio files processed in the request.
        /// </summary>
        [JsonProperty("total_audio")]
        public Nullable<int> TotalAudio { get; set; }

        /// <summary>
        /// Number of channels in the audio associated with the request.
        /// </summary>
        [JsonProperty("channels")]
        public Nullable<int> Channels { get; set; }

        /// <summary>
        /// Number of audio streams associated with the request.
        /// </summary>
        [JsonProperty("streams")]
        public Nullable<int> Streams { get; set; }

        /// <summary>
        /// Model applied when running the request.
        /// </summary>
        [JsonProperty("models")]
        public string[] Models { get; set; }

        /// <summary>
        /// Processing method used when running the request.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// List of tags applied when running the request.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        /// <summary>
        /// List of features used when running the request.
        /// </summary>
        [JsonProperty("features")]
        public string[] Features{ get; set; }

        /// <summary>
        /// Configuration used when running the request.
        /// </summary>
        [JsonProperty("config")]
        public UsageRequestResponseConfig Config { get; set; }
    }
}
