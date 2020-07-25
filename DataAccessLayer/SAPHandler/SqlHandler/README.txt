first add references via NuGet:
Microsoft.AspnetCore.App
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer

To create models from existing database use:
https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db

https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell

/////script/////
Scaffold-DbContext 
"Server=CM-SAP-SERVER;Database=ClearMeshLTD_SAP_2014;persist security info=True;user id=cm;password=Aa1234567;multipleactiveresultsets=True;"
-Provider Microsoft.EntityFrameworkCore.SqlServer 
-OutputDir SAPHandler\SqlHandler\Models -ContextDir SAPHandler\SqlHandler\DbContexts -Context SapSqlDbContext 
-Tables OADM,ODSC,ADM1,OCRD,OSLP,OCRG,OHEM,OHPS,OUDP,ORDR,OINV,OQUT,ORIN,ODLN,ODPI,RDR1,INV1,QUT1,RIN1,DLN1,DPI1,OITM,ITM1,OJDT,JDT1,OHPS,OUDP,OITM,OITB,ITM1,ODPI,DPI1,OIDC,OOND,OCLT,OCLS,OCLG,OADP,ATC1 
-UseDatabaseNames 
-Project DataAccessLayer
-Force 
////////////////



Be sure any project in your solution does not fail to build

Goto Tools-> NuGet Pacakge Manager -> NuGet Package  Manager Console and write th script above (one line)

Add migration:
///
dotnet ef migrations add MigrationName --context RalDbContext
///
