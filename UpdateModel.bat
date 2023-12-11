cd bdgame
dotnet ef dbcontext scaffold "Server=dadds2.database.windows.net;Database=english;user id=sysadmin;password=7c419eae$;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f 
pause