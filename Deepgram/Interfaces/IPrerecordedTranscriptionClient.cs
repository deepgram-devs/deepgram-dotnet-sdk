﻿using Deepgram.Models;
using System;
using System.Threading.Tasks;

namespace Deepgram.Interfaces
{
    public interface IPrerecordedTranscriptionClient
    {
        /// <summary>
        /// Submits a request to the Deepgram API to transcribe prerecorded audio
        /// </summary>
        /// <param name="source">Url source to send for transcription</param>
        /// <param name="options">Feature options for the transcription</param>
        /// <returns>Transcription of the provided audio</returns>
        Task<PrerecordedTranscription> GetTranscriptionAsync(UrlSource source, PrerecordedTranscriptionOptions options);

        /// <summary>
        /// Submits a request to the Deepgram API to transcribe prerecorded audio
        /// </summary>
        /// <param name="source">Audio source to send for transcription</param>
        /// <param name="options">Feature options for the transcription</param>
        /// <returns>Transcription of the provided audio</returns>
        Task<PrerecordedTranscription> GetTranscriptionAsync(StreamSource source, PrerecordedTranscriptionOptions options);
    }
}
