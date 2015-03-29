using System.ServiceModel;
using System.ServiceModel.Web;

namespace LivraisonRepasServices
{
    [ServiceContract(Name = "LivraisonRepasService")]
    public interface ILivraisonRepasService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Test/{test}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string TestGet(string test);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Test/Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void TestPOST(Test test);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Test/Update/{test}", RequestFormat = WebMessageFormat.Json)]
        void TestPUT(string test, Test test2);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Test/Delete/{test}")]
        void TestDelete(string test);
    }
}
