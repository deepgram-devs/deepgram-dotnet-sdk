﻿// Copyright 2021-2023 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Models.Manage.v1;

public record UsageSummary
{
    /// <summary>
    /// Start date for included requests.
    /// </summary>
    [JsonPropertyName("start")]
    public DateTime? StartDateTime { get; set; }

    /// <summary>
    /// End date for included requests.
    /// </summary>
    [JsonPropertyName("end")]
    public DateTime? EndDateTime { get; set; }

    /// <summary>
    /// Length of time (in hours) of audio submitted in included requests.
    /// </summary>
    [JsonPropertyName("hours")]
    public double? Hours { get; set; }

    /// <summary>
    /// Length of time (in hours) of audio processed in included requests.
    /// </summary>
    [JsonPropertyName("total_hours")]
    public double? TotalHours { get; set; }

    /// <summary>
    /// Number of included requests.
    /// </summary>
    [JsonPropertyName("requests")]
    public int? Requests { get; set; }

    /// <summary>
    /// Token information
    /// </summary>
    [JsonPropertyName("tokens")]
    public Token? Tokens { get; set; }
}

