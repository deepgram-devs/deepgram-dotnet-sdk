﻿using AutoBogus;
using Deepgram.Transcription;
using Deepgram.Usage;
using Deepgram.Utilities;
using Xunit;

namespace Deepgram.Tests.UtilitiesTests
{

    public class QueryParameterUtilTests
    {
        readonly PrerecordedTranscriptionOptions _prerecordedTranscriptionOptions;

        public QueryParameterUtilTests()
        {
            _prerecordedTranscriptionOptions = new PrerecordedTranscriptionOptions();

        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_String_Parameter()
        {
            //Act
            _prerecordedTranscriptionOptions.Language = "en-uk";
            var result = QueryParameterUtil.GetParameters(_prerecordedTranscriptionOptions)!;

            //Assert
            Assert.NotNull(result);

            Assert.Contains($"{nameof(_prerecordedTranscriptionOptions.Language).ToLower()}={_prerecordedTranscriptionOptions.Language.ToLower()}", result);

        }
        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Int_Parameter()
        {
            //Arrange 
            var obj = new ListAllRequestsOptions() { Limit = 2 };

            //Act
            var result = QueryParameterUtil.GetParameters(obj);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"{nameof(obj.Limit).ToLower()}={obj.Limit}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Array_Parameter()
        {
            //Arrange
            //need to manual assign this as bogus can put phrase in as words
            _prerecordedTranscriptionOptions.Keywords = new string[] { "test" };

            //Act
            var result = QueryParameterUtil.GetParameters(_prerecordedTranscriptionOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"keywords={_prerecordedTranscriptionOptions.Keywords[0].ToLower()}", result);

        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Decimal_Parameter()
        {
            //Act
            // need to set manual as the precison can be very long and gets trimmed from autogenerated value
            _prerecordedTranscriptionOptions.UtteranceSplit = (decimal)2.3;
            var result = QueryParameterUtil.GetParameters(_prerecordedTranscriptionOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"utt_split={_prerecordedTranscriptionOptions.UtteranceSplit}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_Boolean_Parameter()
        {
            //Arrange 
            _prerecordedTranscriptionOptions.Punctuate = true;

            //Act
            var result = QueryParameterUtil.GetParameters(_prerecordedTranscriptionOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"{nameof(_prerecordedTranscriptionOptions.Punctuate).ToLower()}={_prerecordedTranscriptionOptions.Punctuate.ToString()?.ToLower()}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_String_When_Passing_DateTime_Parameter()
        {
            //Arrange 
            var listAllRequestsOptions = new AutoFaker<ListAllRequestsOptions>().Generate();
            var date = listAllRequestsOptions.StartDateTime.Value.ToString("yyyy-MM-dd");


            //Act
            var result = QueryParameterUtil.GetParameters(listAllRequestsOptions);

            //Assert
            Assert.NotNull(result);
            Assert.Contains($"start={date}", result);
        }

        [Fact]
        public void GetParameters_Should_Return_Empty_String_When_Parameter_Has_No_Values()
        {
            //Arrange 
            var obj = new PrerecordedTranscriptionOptions();

            //Act
            var result = QueryParameterUtil.GetParameters(obj);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(string.Empty, result);
        }
    }
}