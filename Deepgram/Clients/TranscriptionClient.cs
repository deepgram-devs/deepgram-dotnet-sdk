﻿using Deepgram.Interfaces;
using Deepgram.Models;

namespace Deepgram.Clients
{
    internal class TranscriptionClient : ITranscriptionClient
    {
        public IPrerecordedTranscriptionClient Prerecorded { get; private set; }
        public TranscriptionClient(Credentials credentials)
        {
            Prerecorded = new PrerecordedTranscriptionClient(credentials);
        }
    }
}
