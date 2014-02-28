using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    [ServiceContract]
    public interface IMSDNMagazineService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/")]
        IssuesCollection GetAllIssues();
        [OperationContract]
        [WebGet(UriTemplate = "/{year}")]
        IssuesData GetIssuesByYear(string year);
        [OperationContract]
        [WebGet(UriTemplate = "/{year}/{issue}")]
        Articles GetIssue(string year, string issue);
        [OperationContract]
        [WebGet(UriTemplate = "/{year}/{issue}/{article}")]
        Article GetArticle(string year, string issue, string article);
        [OperationContract]
        [WebInvoke(UriTemplate = "/{year}/{issue}", Method = "POST")]
        Article AddArticle(string year, string issue, Article article);

    }
}
