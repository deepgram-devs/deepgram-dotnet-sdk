﻿// Copyright 2021-2023 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Models.PreRecorded.v1;

public record SyncResponse
{
    /// <summary>
    /// Metadata of response <see cref="Metadata"/>
    /// </summary>
    [JsonPropertyName("metadata")]
    public Metadata? Metadata { get; set; }

    /// <summary>
    /// Results of Response <see cref="v1.Results"/>
    /// </summary>
    [JsonPropertyName("results")]
    public Results? Results { get; set; }

    public string ToWebVTT()
    {
        if (Results == null || Results.Utterances == null)
        {
            throw new Exception(
                "This method requires a transcript that was generated with the utterances feature."
            );
        }

        var webVTT = "WEBVTT\n\n";

        if (Metadata != null)
        {
            webVTT += $"NOTE\nTranscription provided by Deepgram\nRequest Id: {Metadata.RequestId}\nCreated: {Metadata.Created}\nDuration: {Math.Round((decimal)Metadata.Duration, 3)}\nChannels: {Metadata.Channels}\n\n";
        }

        var index = 1;
        foreach (var utterance in Results.Utterances)
        {
            var start = SecondsToTimestamp(utterance.Start);
            var end = SecondsToTimestamp(utterance.End);
            webVTT += $"{index}\n{start} --> {end}\n - {utterance.Transcript}\n\n";
            index++;
        }

        return webVTT;
    }

    public string ToSRT()
    {
        if (Results == null || Results.Utterances == null)
        {
            throw new Exception(
                "This method requires a transcript that was generated with the utterances feature."
            );
        }

        var srt = string.Empty;

        var index = 1;
        foreach (var utterance in Results.Utterances)
        {
            var start = SecondsToTimestamp(utterance.Start);
            var end = SecondsToTimestamp(utterance.End);
            srt += $"{index}\n{start} --> {end}\n - {utterance.Transcript}\n\n";
            index++;
        }

        return srt;
    }

    private static string SecondsToTimestamp(decimal? seconds) =>
        new TimeSpan((long)(seconds??0 * 10000000)).ToString().Substring(0, seconds % 1 == 0 ? 8 : 12);
}
