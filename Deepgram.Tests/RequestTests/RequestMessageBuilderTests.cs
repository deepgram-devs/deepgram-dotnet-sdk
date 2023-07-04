﻿using System.Net.Http;
using AutoBogus;
using Bogus;
using Deepgram.Projects;
using Deepgram.Request;
using Deepgram.Tests.Fakers;
using Deepgram.Transcription;
using Xunit;

namespace Deepgram.Tests.RequestTests;

public class RequestMessageBuilderTests
{
    readonly CleanCredentials _credentials;
    readonly RequestMessageBuilder _sUT;
    readonly string _uriSegment;
    readonly UrlSource _urlSource;
    readonly PrerecordedTranscriptionOptions _prerecordedTranscriptionOptions;

    public RequestMessageBuilderTests()
    {
        _credentials = new CleanCredentialsFaker().Generate();
        _sUT = new RequestMessageBuilder();
        _uriSegment = new Faker().Lorem.Word();
        _urlSource = new UrlSource(new Faker().Internet.Url());
        _prerecordedTranscriptionOptions = new PrerecordedTranscriptionOptions();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateHttpRequestMessage_Should_Return_HttpRequestMessage_When_HttpMethod_Is_Get_No_QueryParameters(bool requireSSL)
    {
        //Arrange            
        _credentials.RequireSSL = requireSSL;
        var SUT = new RequestMessageBuilder();
        //Act
        var result = SUT.CreateHttpRequestMessage(HttpMethod.Get, _uriSegment, _credentials);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<HttpRequestMessage>(result);
        Assert.Equal(HttpMethod.Get, result.Method);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        Assert.Equal(_credentials.ApiKey, result.Headers.Authorization.Parameter);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateHttpRequestMessage_Should_Return_HttpRequestMessage_When_HttpMethod_Is_Get_With_QueryParameters(bool requireSSL)
    {
        //Arrange
        _credentials.RequireSSL = requireSSL;

        //Act
        var result = _sUT.CreateHttpRequestMessage(HttpMethod.Get, _uriSegment, _credentials, null, _prerecordedTranscriptionOptions);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<HttpRequestMessage>(result);
        Assert.Equal(HttpMethod.Get, result.Method);
        Assert.Equal(_credentials.ApiKey, result.Headers.Authorization.Parameter);

    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateHttpRequestMessage_Should_Return_HttpRequestMessage_When_HttpMethod_Is_Post_With_Body(bool requireSSL)
    {
        //Arrange
        _credentials.RequireSSL = requireSSL;


        //Act
        var result = _sUT.CreateHttpRequestMessage(HttpMethod.Post, _uriSegment, _credentials, _urlSource, _prerecordedTranscriptionOptions);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<HttpRequestMessage>(result);
        var content = result.Content;
        Assert.NotNull(result.Content);
        Assert.Equal(HttpMethod.Post, result.Method);
        Assert.Equal(_credentials.ApiKey, result.Headers.Authorization.Parameter);
        Assert.Equal("application/json", content.Headers.ContentType.MediaType!);


    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateHttpRequestMessage_Should_Return_HttpRequestMessage_When_HttpMethod_Is_Put_With_Body(bool requireSSL)
    {
        //Arrange
        _credentials.RequireSSL = requireSSL;
        var options = new AutoFaker<UpdateScopeOptions>().Generate();
        //Act
        var result = _sUT.CreateHttpRequestMessage(HttpMethod.Put, _uriSegment, _credentials, options, null);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<HttpRequestMessage>(result);
        var content = result.Content;
        Assert.NotNull(result.Content);
        Assert.Equal(HttpMethod.Put, result.Method);
        Assert.Equal(_credentials.ApiKey, result.Headers.Authorization.Parameter);
        Assert.Equal("application/json", content.Headers.ContentType.MediaType);


    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateHttpRequestMessage_Should_Return_HttpRequestMessage_When_HttpMethod_Is_Patch_With_Body(bool requireSSL)
    {
        //Arrange
        _credentials.RequireSSL = requireSSL;
        var project = new AutoFaker<Project>().Generate();
        //Act     
#if NETSTANDARD2_0
        var result = _sUT.CreateHttpRequestMessage(HttpMethod("PATCH"), _uriSegment, _credentials, project, null);

#else


        var result = _sUT.CreateHttpRequestMessage(HttpMethod.Patch, _uriSegment, _credentials, project, null);
#endif
        //Assert
        Assert.NotNull(result);
        Assert.IsType<HttpRequestMessage>(result);
        var content = result.Content;
        Assert.NotNull(result.Content);
#if NETSTANDARD2_0
 Assert.Equal(HttpMethod("PATCH"), result.Method);
#else
        Assert.Equal(HttpMethod.Patch, result.Method);
#endif

        Assert.Equal(_credentials.ApiKey, result.Headers.Authorization.Parameter);
        Assert.Equal("application/json", content.Headers.ContentType.MediaType);

    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void CreateStreamHttpRequestMessage_Should_Return_HttpRequestMessage_When_HttpMethod_Is_Post_With_Body(bool requireSSL)
    {
        //Arrange
        _credentials.RequireSSL = requireSSL;
        var streamSource = new StreamSourceFaker().Generate();
        //Act
        var result = _sUT.CreateStreamHttpRequestMessage(HttpMethod.Post, _uriSegment, _credentials, streamSource);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<HttpRequestMessage>(result);
        var content = result.Content!;
        Assert.NotNull(result.Content);
        Assert.Equal(HttpMethod.Post, result.Method);

        Assert.Equal(_credentials.ApiKey, result.Headers.Authorization.Parameter);
        Assert.Equal(streamSource.MimeType, content.Headers.ContentType.MediaType);


    }


}