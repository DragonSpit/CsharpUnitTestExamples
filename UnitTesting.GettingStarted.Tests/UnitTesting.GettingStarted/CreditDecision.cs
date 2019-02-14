// This assumes that there is an existing ICreditDecisionService interface and that CreditDecisionService implements it.
namespace UnitTesting.GettingStarted
{
    public class CreditDecision
    {
        private readonly ICreditDecisionService _creditDecisionService;
        public CreditDecision(ICreditDecisionService creditDecisionService)
        {
            _creditDecisionService = creditDecisionService;
        }

        public string MakeCreditDecision(int creditScore)
        {
            return _creditDecisionService.GetCreditDecision(creditScore);
        }
    }
}