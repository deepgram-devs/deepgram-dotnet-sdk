﻿using Deepgram.Common;

namespace Deepgram.Tests.CommonTests;
public class ConfigureCredentialsTests
{


    [Fact]
    public void Should_Return_Same_APIKey_That_Passed_As_Parameter()
    {
        //Act
        var fakeKey = Guid.NewGuid().ToString();
        var result = CleanCredentials.CheckApiKey(fakeKey);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Equal(fakeKey, result);
    }

    [Fact]
    public void Should_Throw_ArgumentException_If_No_ApiKey_Found()
    {
        //Act

        var result = Assert.Throws<ArgumentException>(() => CleanCredentials.CheckApiKey(null));

        //Assert
        Assert.IsType<ArgumentException>(result);
        Assert.Equal(result.Message, "Deepgram API Key must be provided in constructor or via settings");
    }

    [Fact]
    public void Should_Return_TrimmedApiUrl_That_Passed_As_Parameter()
    {
        //Act
        var fakeUrl = "http://test.com";
        var result = CleanCredentials.CleanApiUrl(fakeUrl);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Equal("test.com", result);
    }



    [Fact]
    public void Should_Return_DefaultApiUrl_If_NO_ApiUrl_Present_In_Parameters()
    {
        //Act

        var result = CleanCredentials.CleanApiUrl(null);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.Equal("api.deepgram.com", result);
    }




    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Should_Return_RequireSSL_That_Passed_As_Parameter(Nullable<bool> requireSSL)
    {
        //Act

        var result = CleanCredentials.CleanRequireSSL(requireSSL);

        //Assert
        Assert.IsType<bool>(result);
        Assert.Equal(requireSSL, result);
    }


}
