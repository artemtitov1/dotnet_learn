using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LibraryService
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        string booksXML = "\\Data\\Books.xml";

        [OperationContract]
        [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        public void GetAllBooks()
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

            string result = "";
            XDocument document = XDocument.Load(booksXML);
            XElement catalog = document.Element("catalog");
            foreach (XElement book in catalog.)
            {

            }
            return; 
        }

        //public string getBookByID(string id)
        //{
        //    string book = "";

        //    return book;
        //}
    }
}
