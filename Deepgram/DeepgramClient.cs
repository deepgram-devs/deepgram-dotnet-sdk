﻿using Deepgram.Clients;

namespace Deepgram;

public class DeepgramClient
{
    private CleanCredentials _credentials;
    public IKeyClient Keys { get; protected set; }
    public IProjectClient Projects { get; protected set; }
    public ITranscriptionClient Transcription { get; protected set; }
    public IUsageClient Usage { get; protected set; }
    public IBillingClient Billing { get; protected set; }
    public IInvitationClient Invitation { get; protected set; }
    public ILiveTranscriptionClient CreateLiveTranscriptionClient() => new LiveTranscriptionClient(_credentials);

    public DeepgramClient(Credentials credentials) => Initialize(credentials);

    /// <summary>
    /// Sets the Timeout of the HTTPClient used to send HTTP requests
    /// </summary>
    /// <param name="timeout">Timespan to wait before the request times out.</param>
    public void SetHttpClientTimeout(TimeSpan timeout) =>
        HttpClientUtil.SetTimeOut(timeout);

    private void Initialize(Credentials credentials)
    {
        _credentials = CredentialsUtil.Clean(credentials);
        InitializeClients();
    }

    protected void InitializeClients()
    {
        Keys = new KeyClient(_credentials);
        Projects = new ProjectClient(_credentials);
        Transcription = new TranscriptionClient(_credentials);
        Usage = new UsageClient(_credentials);
        Billing = new BillingClient(_credentials);
        Invitation = new InvitationClient(_credentials);
    }
}
