﻿namespace Deepgram.Tests.UnitTests.UtilitiesTests;

public class QueryParameterUtilTests
{
    [Test]
    public void GetParameters_Should_Return_EmptyString_When_Parameters_Is_Null()
    {
        //Arrange
        PrerecordedSchema? para = null;
        //Act
        var result = QueryParameterUtil.GetParameters(para);

        //Assert
        result.Should().BeEmpty();

    }
    [Test]
    public void GetParameters_Should_Return_String_When_Passing_String_Parameter()
    {
        //Arrange
        var prerecordedOptions = new AutoFaker<PrerecordedSchema>().Generate();
        var expectedModel = HttpUtility.UrlEncode(prerecordedOptions.Model)!;
        var expected = $"{nameof(prerecordedOptions.Model).ToLower()}={expectedModel.ToLower()}";
        //Act
        var result = QueryParameterUtil.GetParameters(prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_Respecting_CallBack_Casing()
    {
        //Arrange
        var prerecordedOptions = new AutoFaker<PrerecordedSchema>().Generate();
        prerecordedOptions.Callback = "https://Signed23.com";
        var expected = $"{nameof(prerecordedOptions.Callback).ToLower()}={HttpUtility.UrlEncode("https://Signed23.com")}";
        //Act
        var result = QueryParameterUtil.GetParameters(prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Int_Parameter()
    {
        //Arrange 
        var obj = new PrerecordedSchema() { Alternatives = 1 };
        var expected = $"alternatives={obj.Alternatives}";

        //Act
        var result = QueryParameterUtil.GetParameters(obj);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Array_Parameter()
    {
        //Arrange
        var prerecordedOptions = new PrerecordedSchema
        {
            Keywords = ["test", "acme"]
        };
        var expected = $"keywords={prerecordedOptions.Keywords[0].ToLower()}";

        //Act
        var result = QueryParameterUtil.GetParameters(prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Decimal_Parameter()
    {
        //Arrange
        var prerecordedOptions = new PrerecordedSchema() { UttSplit = 2.3 };
        var expected = $"utt_split={HttpUtility.UrlEncode(prerecordedOptions.UttSplit.ToString())}";

        //Act
        // need to set manual as the precision can be very long and gets trimmed from autogenerated value

        var result = QueryParameterUtil.GetParameters(prerecordedOptions);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_Boolean_Parameter()
    {
        //Arrange 
        var obj = new PrerecordedSchema() { Paragraphs = true };
        var expected = $"{nameof(obj.Paragraphs).ToLower()}=true";
        //Act
        var result = QueryParameterUtil.GetParameters(obj);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_String_When_Passing_DateTime_Parameter()
    {
        //Arrange 
        var obj = DateTime.Now;
        var option = new CreateProjectKeySchema()
        {
            ExpirationDate = obj
        };
        var expected = $"expiration_date={HttpUtility.UrlEncode(obj.ToString("yyyy-MM-dd"))}";

        //Act
        var result = QueryParameterUtil.GetParameters(option);

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected); ;
    }

    [Test]
    public void GetParameters_Should_Return_Valid_String_When_CallBack_Set()
    {
        //Arrange 
        var signedCallBackUrl = "As$Ssw.com";
        var expected = HttpUtility.UrlEncode(signedCallBackUrl);

        //Act
        var result = QueryParameterUtil.GetParameters(new PrerecordedSchema() { Callback = signedCallBackUrl, Diarize = true });

        //Assert
        result.Should().NotBeNull();
        result.Should().Contain(expected);
    }

    [Test]
    public void GetParameters_Should_Return_Empty_String_When_Parameter_Has_No_Values()
    {
        //Act
        var result = QueryParameterUtil.GetParameters(new PrerecordedSchema());

        //Assert
        result.Should().NotBeNull();
        result.Should().Be(string.Empty);
    }
}