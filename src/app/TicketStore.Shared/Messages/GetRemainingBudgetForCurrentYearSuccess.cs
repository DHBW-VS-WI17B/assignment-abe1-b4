namespace TicketStore.Shared.Messages
{
    /// <summary>
    /// Immutable get remaining budget for current year success message.
    /// </summary>
    public class GetRemainingBudgetForCurrentYearSuccess
    {
        /// <summary>
        /// Remaining budget for ticket purchases for events in the current year.
        /// </summary>
        public double RemainingBuget { get; }

        /// <summary>
        /// Yearly budget.
        /// </summary>
        public double YearlyBudget { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="remainingBuget">Remaining budget for ticket purchases for events in the current year.</param>
        /// <param name="yearlyBudget">Yearly budget.</param>
        public GetRemainingBudgetForCurrentYearSuccess(double remainingBuget, double yearlyBudget)
        {
            RemainingBuget = remainingBuget;
            YearlyBudget = yearlyBudget;
        }
    }
}
