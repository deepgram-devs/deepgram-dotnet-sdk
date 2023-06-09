﻿using Newtonsoft.Json;
using System;

namespace Deepgram.Models
{
    public class Summary
    {
        /// <summary>
        /// Summary of a section of the transcript
        /// </summary>
        [JsonProperty("summary")]
        public string TextSummary { get; set; }

        /// <summary>
        /// Word position in transcript where the summary begins
        /// </summary>
        [JsonProperty("start_word")]
        public int StartWord { get; set; }

        /// <summary>
        /// Word position in transcript where the summary ends
        /// </summary>
        [JsonProperty("end_word")]
        public int EndWord { get; set; }

    }
}
