﻿namespace Deepgram.Tests.RequestTests;

public class ApiRequestTests
{
    [Fact]

    public async void Should_Return_A_Valid_Object_When_Deserialized()
    {
        //Arrange
        var responseObject = new AutoFaker<Project>().Generate();
        var client = FakeHttpMessageHandler.CreateHttpClientWithResult(responseObject);
        var SUT = new ApiRequest(client);

        //Act
        var result = await SUT.SendHttpRequestAsync<Project>(new HttpRequestMessage());

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<Project>(result);
    }







}