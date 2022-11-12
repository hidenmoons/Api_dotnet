From mcr.microsoft.com/dotnet/nightly/sdk:6.0 AS build 
WORKDIR app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else
COPY . ./

CMD [ "dotnet", "run" ]