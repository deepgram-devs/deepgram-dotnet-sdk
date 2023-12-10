﻿namespace Deepgram.Records;

public record Details
{
    /// <summary>
    /// Cost of the request in USD, if project is non-contract and the requesting account has appropriate permissions.
    /// </summary>
    [JsonPropertyName("usd")]
    public double? USD { get; set; }

    /// <summary>
    /// Length of time (in hours) of audio processed in the request.
    /// </summary>
    [JsonPropertyName("duration")]
    public decimal? Duration { get; set; }

    /// <summary>
    /// Number of audio files processed in the request.
    /// </summary>
    [JsonPropertyName("total_audio")]
    public int? TotalAudio { get; set; }

    /// <summary>
    /// Number of channels in the audio associated with the request.
    /// </summary>
    [JsonPropertyName("channels")]
    public int? Channels { get; set; }

    /// <summary>
    /// Number of audio streams associated with the request.
    /// </summary>
    [JsonPropertyName("streams")]
    public int? Streams { get; set; }

    /// <summary>
    /// Model applied when running the request.
    /// </summary>
    [JsonPropertyName("models")]
    public IReadOnlyList<string> Models { get; set; }

    /// <summary>
    /// Processing method used when running the request.
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; }

    /// <summary>
    /// List of tags applied when running the request.
    /// </summary>
    [JsonPropertyName("tags")]
    public IReadOnlyList<string> Tags { get; set; }

    /// <summary>
    /// List of features used when running the request.
    /// </summary>
    [JsonPropertyName("features")]
    public IReadOnlyList<string> Features { get; set; }

    /// <summary>
    /// Configuration used when running the request.<see cref="Records.Config"/>
    /// </summary>
    [JsonPropertyName("config")]
    public Config Config { get; set; }
}
