﻿namespace Deepgram.Models;

public class LiveTranscriptionOptions
{
    /// <summary>
    /// AI model used to process submitted audio
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// Version of the model to use.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// BCP-47 language tag that hints at the primary spoken language.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    /// <summary>
    /// Level of model you would like to use in your request.
    /// </summary>
    /// <remarks>Defaults to base. Possible values are: base, enhanced</remarks>
    [JsonPropertyName("tier")]
    public string? Tier { get; set; }

    /// <summary>
    /// Indicates whether to add punctuation and capitalization to the transcript.
    /// </summary>
    [JsonPropertyName("punctuate")]
    public bool? Punctuate { get; set; }

    /// <summary>
    /// Indicates whether to remove profanity from the transcript.
    /// </summary>
    [JsonPropertyName("profanity_filter")]
    public bool? ProfanityFilter { get; set; }

    /// <summary>
    /// Indicates whether to redact sensitive information, replacing redacted content with asterisks (*).
    /// </summary>
    /// <remarks>Possible values are: pci, numbers, ssn</remarks>
    [JsonPropertyName("redact")]
    public string[]? Redaction { get; set; }

    /// <summary>
    /// Indicates whether to recognize speaker changes. When set to true, each word in the transcript
    /// will be assigned a speaker number starting at 0. 
    /// </summary>
    [JsonPropertyName("diarize")]
    public bool? Diarize { get; set; }

    /// <summary>
    /// Indicates which version of the diarizer to use. When passed in, each word in the transcript will
    /// be assigned a speaker number starting at 0. Ex: YYYY-MM-DD.X where YYYY-MM-DD is the version date
    ///  and X is the version number.
    /// </summary>
    [JsonPropertyName("diarize_version ")]
    public string? DiarizationVersion { get; set; }

    /// <summary>
    /// Indicates whether to recognize alphanumeric strings. When set to true, whitespace will be removed
    /// between characters identified as part of an alphanumeric string. 
    /// </summary>
    [Obsolete("NamedEntityRecognition is deprecated in favor of SmartFormat.")]
    [JsonPropertyName("ner")]
    public bool? NamedEntityRecognition { get; set; }

    /// <summary>
    /// Indicates whether to transcribe each audio channel independently.
    /// </summary>
    [JsonPropertyName("multichannel")]
    public bool? MultiChannel { get; set; }

    /// <summary>
    /// Maximum number of transcript alternatives to return.
    /// </summary>
    [JsonPropertyName("alternatives")]
    public int? Alternatives { get; set; }

    /// <summary>
    /// Indicates whether to convert numbers from written format (e.g., one) to numerical format (e.g., 1).
    /// Same as numbers. This option will be deprecated in the future.
    /// </summary>
    [JsonPropertyName("numerals")]
    public bool? Numerals { get; set; }

    /// <summary>
    /// Indicates whether to convert numbers from written format (e.g., one) to numerical format (e.g., 1).
    /// Same as numerals. 
    /// </summary>
    [JsonPropertyName("numbers")]
    public bool? Numbers { get; set; }

    /// <summary>
    /// Indicates whether to add spaces between spoken numbers
    /// </summary>
    [JsonPropertyName("numbers_spaces")]
    public bool? NumbersSpaces { get; set; }

    /// <summary>
    /// Indicates whether to convert dates from written format(e.g., January first) to numerical format(e.g., 01/01).
    /// </summary>
    [JsonPropertyName("dates")]
    public bool? Dates { get; set; }

    /// <summary>
    /// Indicates the format to use for dates. 
    /// Formatted string is specified using chrono strftime notation https://docs.rs/chrono/latest/chrono/format/strftime/index.html
    /// </summary>
    [JsonPropertyName("date_format")]
    public string? DateFormat { get; set; }

    /// <summary>
    /// Indicates whether to convert times from written format(e.g., three oclock) to numerical format(e.g., 3:00).
    /// </summary>
    [JsonPropertyName("times")]
    public bool? Times { get; set; }

    /// <summary>
    /// Option to format punctuated commands
    /// Example: Before - “i went to the store period new paragraph then i went home”
    ///          After - “i went to the store. <\n> then i went home”
    /// </summary>
    [JsonPropertyName("dictation")]
    public bool? Dictation { get; set; }

    /// <summary>
    /// Option to convert measurments to numerical format.
    /// </summary>
    [JsonPropertyName("measurements")]
    public bool? Measurements { get; set; }

    /// <summary>
    /// Indicates whether to use Smart Format on the transcript. When enabled,
    /// Smart Format will add punctuation and formatting to entities like dates, times,
    /// tracking numbers, and more.
    /// </summary>
    [JsonPropertyName("smart_format")]
    public bool? SmartFormat { get; set; }

    /// <summary>
    /// Terms or phrases to search for in the submitted audio.
    /// </summary>
    [JsonPropertyName("search")]
    public string[]? SearchTerms { get; set; }

    /// <summary>
    /// Terms or phrases to search for in the submitted audio and replace.
    /// </summary>
    /// <remarks>Phrases should be submitted in the format: searchfor:replacewith</remarks>
    [JsonPropertyName("replace")]
    public string[]? Replace { get; set; }

    /// <summary>
    /// Callback URL to provide if you would like your submitted audio to be processed asynchronously.
    /// When passed, Deepgram will immediately respond with a request_id. 
    /// </summary>
    [JsonPropertyName("callback")]
    public string? Callback { get; set; }

    /// <summary>
    /// Keywords to which the model should pay particular attention to boosting or suppressing to help
    /// it understand context.
    /// </summary>
    [JsonPropertyName("keywords")]
    public string[]? Keywords { get; set; }

    /// <summary>
    /// Support for out-of-vocabulary (OOV) keyword boosting when processing streaming audio is 
    /// currently in beta; to fall back to previous keyword behavior append the 
    /// query parameter keyword_boost=legacy to your API request.
    /// </summary>
    [JsonPropertyName("keyword_boost")]
    public string? KeywordBoost { get; set; }

    /// <summary>
    /// Indicates whether Deepgram will segment speech into meaningful semantic units, which allows
    /// the model to interact more naturally and effectively with speakers' spontaneous speech patterns.
    /// </summary>
    [JsonPropertyName("utterances")]
    public bool? Utterances { get; set; }

    /// <summary>
    /// Indicates whether Deepgram will split audio into paragraphs to improve transcript
    /// readability. When paragraphs is set to true, you must also set either punctuate, 
    /// diarize, or multichannel to true.
    /// </summary>
    [JsonPropertyName("paragraphs")]
    public bool? Paragraphs { get; set; }

    /// <summary>
    /// Indicates whether the streaming endpoint should send you updates to its transcription as more 
    /// audio becomes available.
    /// </summary>
    [JsonPropertyName("interim_results")]
    public bool? InterimResults { get; set; }

    /// <summary>
    /// Indicates whether Deepgram will detect whether a speaker has finished speaking (or paused 
    /// for a significant period of time, indicating the completion of an idea). 
    /// Can be "false" to disable endpointing, or can be the milliseconds of silence to wait before returning a transcript. Default is 10 milliseconds. Is string here so it can accept "false" as a value.
    /// </summary>
    [JsonPropertyName("endpointing")]
    public string? Endpointing { get; set; }

    /// <summary>
    /// Length of time in milliseconds of silence that voice activation detection (VAD) will use 
    /// to detect that a speaker has finished speaking.
    /// </summary>
    [JsonPropertyName("vad_turnoff")]
    public int? VADTurnoff { get; set; }

    /// <summary>
    /// Expected encoding of the submitted streaming audio.
    /// </summary>
    [JsonPropertyName("encoding")]
    public string? Encoding { get; set; }

    /// <summary>
    /// Number of independent audio channels contained in submitted streaming audio.
    /// </summary>
    [JsonPropertyName("channels")]
    public int? Channels { get; set; }

    /// <summary>
    /// Sample rate of submitted streaming audio. Required (and only read) when a value 
    /// is provided for encoding.
    /// </summary>
    [JsonPropertyName("sample_rate")]
    public int? SampleRate { get; set; }
}
