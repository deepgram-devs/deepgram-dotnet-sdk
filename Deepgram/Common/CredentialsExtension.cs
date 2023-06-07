﻿using System;
using Deepgram.Models;

namespace Deepgram.Common
{
    public static class CredentialsExtension
    {
        public static Credentials Clean(Credentials credentials = null)
        {
            //if no credentials are passed in the constructor create a empty credentials
            if (credentials == null)
                credentials = new Credentials();

            //Set values and clean them up 
            return new Credentials(
                CheckApiKey(credentials.ApiKey),
                CleanApiUrl(credentials.ApiUrl),
                CleanRequireSSL(credentials.RequireSSL));

        }
        internal static string CheckApiKey(string apiKey = null)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Deepgram API Key must be provided in constructor");

            return apiKey;
        }

        internal static string CleanApiUrl(string apiUrl = null) =>
            string.IsNullOrEmpty(apiUrl) ? "api.deepgram.com" : TrimApiUrl(apiUrl);

        internal static string TrimApiUrl(string apiUrl) =>
            apiUrl.Contains("://") ? apiUrl.Substring(apiUrl.IndexOf("://") + 3) : apiUrl;

        internal static bool CleanRequireSSL(Nullable<bool> requireSSL = null) =>
            !requireSSL.HasValue ? true : Convert.ToBoolean(requireSSL);

    }
}
