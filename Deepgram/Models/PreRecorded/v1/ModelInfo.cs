﻿// Copyright 2021-2023 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Models.PreRecorded.v1;

public record ModelInfo
{
    /// <summary>
    /// TODO
    /// </summary>
    [JsonPropertyName("arch")]
    public string? Arch { get; set; }

    /// <summary>
    /// TODO
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// TODO
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
