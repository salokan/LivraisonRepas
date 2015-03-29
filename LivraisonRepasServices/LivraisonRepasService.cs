using System.ServiceModel;
using System.ServiceModel.Activation;

namespace LivraisonRepasServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LivraisonRepasService : ILivraisonRepasService
    {
        public string TestGet(string test)
        {
            string returnString = "paramètre : " + test;

            return returnString;
        }

        public void TestPOST(Test test)
        {
            string post;
        }

        public void TestPUT(string test, Test test2)
        {
            string put;
        }

        public void TestDelete(string test)
        {
            string delete;
        }
    }
}
