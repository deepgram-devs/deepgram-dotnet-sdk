﻿using Deepgram.Models;
using System.Threading.Tasks;

namespace Deepgram.Interfaces
{
    public interface IBillingClient
    {
        /// <summary>
        /// Generates a list of outstanding balances for the specified project. To see balances, the authenticated account must be a project owner or administrator
        /// </summary>
        /// <param name="projectId">Unique identifier of the project for which you want to retrieve outstanding balances</param>
        /// <returns>List of Deepgram balances</returns>
        Task<BillingList> GetAllBalancesAsync(string projectId);

        /// <summary>
        /// Retrieves details about the specified balance. To see balances, the authenticated account must be a project owner or administrator
        /// </summary>
        /// <param name="projectId">Unique identifier of the project for which you want to retrieve the specified balance</param>
        /// <param name="balanceId">Unique identifier of the balance that you want to retrieve</param>
        /// <returns>A Deepgram balance</returns>
        Task<Billing> GetBalanceAsync(string projectId, string balanceId);
    }
}
