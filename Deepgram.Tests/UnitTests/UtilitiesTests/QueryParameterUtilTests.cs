﻿// Copyright 2021-2024 Deepgram .NET SDK contributors. All Rights Reserved.
// Use of this source code is governed by a MIT license that can be found in the LICENSE file.
// SPDX-License-Identifier: MIT

using Deepgram.Models.Manage.v1;
using Deepgram.Models.PreRecorded.v1;

namespace Deepgram.Tests.UnitTests.UtilitiesTests;

public class QueryParameterUtilTests
{
    [Test]
    public void GetParameters_Should_Return_EmptyString_When_Parameters_Is_Null()
    {
        // Input and Output
        PreRecordedSchema? para = null;
        var expected = $"https://{Defaults.DEFAULT_URI}";

        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, para);

        //Assert
        result.Should().Contain(expected);

    }
    [Test]
    public void GetParameters_Should_Return_String_When_Passing_String_Parameter()
    {
        // Input and Output
        var prerecordedOptions = new AutoFaker<PreRecordedSchema>().Generate();
        var expectedModel = HttpUtility.UrlEncode(prerecordedOptions.Model)!;
        var expected = $"{nameof(prerecordedOptions.Model).ToLower()}={expectedModel}";
        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_Respecting_CallBack_Casing()
    {
        // Input and Output
        var prerecordedOptions = new AutoFaker<PreRecordedSchema>().Generate();
        prerecordedOptions.CallBack = "https://Signed23.com";
        var expected = $"{nameof(prerecordedOptions.CallBack).ToLower()}={HttpUtility.UrlEncode("https://Signed23.com")}";
        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Int_Parameter()
    {
        // Input and Output 
        var obj = new PreRecordedSchema() { Alternatives = 1 };
        var expected = $"alternatives={obj.Alternatives}";

        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, obj);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Array_Parameter()
    {
        // Input and Output
        var prerecordedOptions = new PreRecordedSchema
        {
            Keywords = ["test", "acme"]
        };
        var expected = $"keywords={prerecordedOptions.Keywords[0].ToLower()}";

        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    public void GetParameters_Should_Return_String_When_Passing_Dictonary_Parameter()
    {
        // Input and Output
        var prerecordedOptions = new PreRecordedSchema()
        {
            Extra = new Dictionary<string, string>
            {
                {"KeyOne","ValueOne" },
                {"KeyTwo","ValueTwo" }
            }
        };
        var expected = $"extra={HttpUtility.UrlEncode("KeyOne:ValueOne")}&extra={HttpUtility.UrlEncode("KeyTwo:ValueTwo")}";

        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Decimal_Parameter()
    {
        // Input and Output
        var prerecordedOptions = new PreRecordedSchema() { UttSplit = 2.3 };
        var expected = $"utt_split={HttpUtility.UrlEncode(prerecordedOptions.UttSplit.ToString())}";

        //Act
        // need to set manual as the precision can be very long and gets trimmed from autogenerated value

        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Boolean_Parameter()
    {
        // Input and Output 
        var obj = new PreRecordedSchema() { Paragraphs = true };
        var expected = $"{nameof(obj.Paragraphs).ToLower()}=true";
        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, obj);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_DateTime_Parameter()
    {
        // Input and Output 
        var options = new AutoFaker<KeySchema>().Generate();
        var time = DateTime.Now;
        options.ExpirationDate = time;

        var expected = $"expiration_date={HttpUtility.UrlEncode(time.ToString("yyyy-MM-dd"))}";

        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, options);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected); ;
    }

    [Test]
    public void GetParameters_Should_Return_Valid_String_When_CallBack_Set()
    {
        // Input and Output 
        var signedCallBackUrl = "As$Ssw.com";
        var expected = HttpUtility.UrlEncode(signedCallBackUrl);

        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, new PreRecordedSchema() { CallBack = signedCallBackUrl, Diarize = true });

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_Empty_String_When_Parameter_Has_No_Values()
    {
        //Act
        var result = QueryParameterUtil.FormatURL(Defaults.DEFAULT_URI, new PreRecordedSchema());

        //Assert
        result.Should().NotBeNull();
        result.Should().Be($"https://{Defaults.DEFAULT_URI}");
    }

}