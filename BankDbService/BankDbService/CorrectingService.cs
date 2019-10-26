using BankingAppRepository;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankDbService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class CorrectingService : ICorrectingService
    {
        Correcting correcting;
        public CorrectingService()
        {
            correcting = new Correcting();
        }
        public void Correct(decimal amount, BankAccount bankAccount)
        {
            correcting.Correct(amount, bankAccount);
        }
    }
}
