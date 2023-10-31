﻿using System;
using Deepgram.Clients;
using Deepgram.Interfaces;
using Deepgram.Models;
using Deepgram.Utilities;

namespace Deepgram
{
    public class DeepgramClient : BaseClient
    {
        public IKeyClient Keys { get; protected set; }
        public IProjectClient Projects { get; protected set; }
        public ITranscriptionClient Transcription { get; protected set; }
        public IUsageClient Usage { get; protected set; }
        public ILiveTranscriptionClient CreateLiveTranscriptionClient() => new LiveTranscriptionClient(Credentials);
        public DeepgramClient() : this(null) { }

        public DeepgramClient(Credentials credentials) : this(credentials, new HttpClientUtil()) { }

        /// <summary>
        /// Only directly called by unit tests,
        /// but indirectly called by the other constructors.
        /// </summary>
        /// <param name="credentials">Credentials to pass for access to the deepgram services</param>
        /// <param name="httpClientUtil">The instance to get the HttpClient from</param>
        internal DeepgramClient(Credentials credentials, HttpClientUtil httpClientUtil)
            : base(credentials, httpClientUtil)
        {
            Initialize(credentials);
        }

        /// <summary>
        /// Sets the Timeout of the HTTPClient used to send HTTP requests
        /// </summary>
        /// <param name="timeout">Timespan to wait before the request times out.</param>
        public void SetHttpClientTimeout(TimeSpan timeout)
        {
            HttpClientUtil.SetTimeOut(timeout);
            //reinitialize the clients to respect the timeout
            InitializeClients();
        }
        private void Initialize(Credentials credentials)
        {
            Credentials = CredentialsUtil.Clean(credentials);
            InitializeClients();
        }

        protected void InitializeClients()
        {
            Keys = new KeyClient(Credentials, HttpClientUtil);
            Projects = new ProjectClient(Credentials, HttpClientUtil);
            Transcription = new TranscriptionClient(Credentials, HttpClientUtil);
            Usage = new UsageClient(Credentials, HttpClientUtil);
        }
    }
}
