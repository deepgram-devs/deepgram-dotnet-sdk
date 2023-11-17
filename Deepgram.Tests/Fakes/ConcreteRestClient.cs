﻿namespace Deepgram.Tests.Fakes;

public class ConcreteRestClient : AbstractRestClient
{

    public ConcreteRestClient(string? apiKey, DeepgramClientOptions clientOptions, IHttpClientFactory httpClientFactory)
        : base(apiKey, clientOptions, nameof(ConcreteRestClient), httpClientFactory)
    {
    }
}
