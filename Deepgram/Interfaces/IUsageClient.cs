﻿using System.Threading;
using System.Threading.Tasks;
using Deepgram.Models;

namespace Deepgram.Interfaces
{
    public interface IUsageClient : IBaseClient
    {
        /// <summary>
        /// Generates a list of requests sent to the Deepgram API for the specified project over a given time range. 
        /// </summary>
        /// <param name="projectId">Unique identifier of the project to report on</param>
        /// <param name="options">Pagination & filtering options</param>
        /// <returns>Usage Requests that fit the parameters provided</returns>
        Task<ListAllRequestsResponse> ListAllRequestsAsync(string projectId, ListAllRequestsOptions options, CancellationToken token = new CancellationToken());

        /// <summary>
        /// Returns details about a specific request to the Deepgram API
        /// </summary>
        /// <param name="projectId">Unique identifier of the project to report on</param>
        /// <param name="requestId">Unique identifier of the request to retrieve</param>
        /// <returns>Usage Request identified</returns>
        Task<UsageRequest> GetUsageRequestAsync(string projectId, string requestId, CancellationToken token = new CancellationToken());

        /// <summary>
        /// Retrieves a summary of usage statistics. 
        /// </summary>
        /// <param name="projectId">Unique identifier of the project to report on</param>
        /// <param name="options">Pagination & filtering options</param>
        /// <returns>Summary of usage statistics</returns>
        Task<UsageSummary> GetUsageSummaryAsync(string projectId, GetUsageSummaryOptions options, CancellationToken token = new CancellationToken());

        /// <summary>
        /// Retrieves a list of features, models, tags, languages, and processing method used for requests in the specified project.
        /// </summary>
        /// <param name="projectId">Unique identifier of the project to report on</param>
        /// <param name="options">Pagination & filtering options</param>
        /// <returns>List of features, models, tags, languages, and processing method used for requests in the specified project.</returns>
        Task<UsageFields> GetUsageFieldsAsync(string projectId, GetUsageFieldsOptions options, CancellationToken token = new CancellationToken());
    }
}
