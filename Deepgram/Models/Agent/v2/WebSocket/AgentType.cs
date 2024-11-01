﻿// Copyright 2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

namespace Deepgram.Models.Agent.v2.WebSocket;

using Deepgram.Models.Common.v2.WebSocket;

public enum AgentType
{
    Open = WebSocketType.Open,
    Close = WebSocketType.Close,
    Unhandled = WebSocketType.Unhandled,
    Error = WebSocketType.Error,
    Welcome,
    ConversationText,
    UserStartedSpeaking,
    AgentThinking,
    FunctionCallRequest,
    FunctionCalling,
    AgentStartedSpeaking,
    AgentAudioDone,
    Audio,
}

public static class AgentClientTypes
{
    // user message types
    public const string SettingsConfiguration = "SettingsConfiguration";
    public const string UpdateInstructions = "UpdateInstructions";
    public const string UpdateSpeak = "UpdateSpeak";
    public const string InjectAgentMessage = "InjectAgentMessage";
    public const string FunctionCallResponse = "FunctionCallResponse";
    public const string KeepAlive = "KeepAlive";
    public const string Close = "Close";
}
