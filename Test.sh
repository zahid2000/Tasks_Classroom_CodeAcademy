 echo "Starting..."
 pwd
 var=$(pwd)
 basename $(pwd)
 mydir="$(basename $PWD)"
 echo "Folder name is $mydir"
 dotnet new web -n $mydir  
 echo "Created $mydir web project"  
 dotnet new sln --name $mydir
 echo "Created $mydir.sln file"  
 dotnet sln  add $mydir/$mydir.csproj 
 echo "Added $mydir/$mydir.csproj in $mydir.sln"  

echo "Paketlər yüklənir..."
dotnet tool install --global  dotnet-ef
dotnet tool update --global  dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
cd $mydir
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef dbcontext scaffold "server=DESKTOP-QBQM5QA\SQLEXPRESS;database=northwind;trusted_connection=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models  -t Categories -t Products
