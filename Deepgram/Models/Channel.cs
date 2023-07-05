﻿namespace Deepgram.Models;

public class Channel
{
    /// <summary>
    /// Array of Search objects.
    /// </summary>
    [JsonPropertyName("search")]
    public Search[] Search { get; set; }

    /// <summary>
    /// Array of Alternative objects.
    /// </summary>
    [JsonPropertyName("alternatives")]
    public Alternative[] Alternatives { get; set; }

    /// <summary>
    /// BCP-47 language tag for the dominant language identified in the channel.
    /// </summary>
    /// <remark>Only available in pre-recorded requests</remark>
    [JsonPropertyName("detected_language")]
    public string DetectedLanguage { get; set; } = string.Empty;
}
