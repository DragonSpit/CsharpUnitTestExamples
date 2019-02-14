using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.GettingStarted
{
    public interface ICreditDecisionService
    {
        string GetCreditDecision(int creditScore);
    }
}
