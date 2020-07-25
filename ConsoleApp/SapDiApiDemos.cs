//
//using DataAccessLayer.SAPHandler.DiApiHandler;
//using static DataAccessLayer.SAPHandler.DiApiHandler.SapDiApiContext;
//using SAPbobsCOM;
//
//namespace ConsoleApp
//{
//    class SapDiApiDemos
//    {
//        static string diapiConn = "Server=CM-SAP-SERVER;LicenseServer=CM-SAP-SERVER:30000;SLDServer=CM-SAP-SERVER:40000;CompanyDB=ClearMeshLTD_SAP_2014;UserName=משרד;Password=1234;DbUserName=cm;DbPassword=Aa1234567;UseTrusted=false;DbServerType=MSSQL2012;";
//
//        static void Maina(string[] args)
//        {
//            var sapDiApi = new SapDiApiContext(diapiConn);
//            CompanyContext companyContext = new CompanyContext(diapiConn, new Company());
//
//            var company = companyContext.ConnectCompany();
//            var qut = (Documents)company.GetBusinessObject(BoObjectTypes.oQuotations);
//
//            qut.GetByKey(120683);
//
//
//
//       
//             var ordr = (Documents)company.GetBusinessObject(BoObjectTypes.oQuotations);
//
//
//        }
//
//    }
//}
