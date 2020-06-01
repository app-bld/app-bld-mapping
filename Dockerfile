FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

# restore

WORKDIR /work

COPY *.sln .

COPY src/*/*.csproj ./

RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

COPY test/*/*.csproj ./

RUN for file in $(ls *.csproj); do mkdir -p test/${file%.*}/ && mv $file test/${file%.*}/; done

RUN dotnet restore

# build 

COPY . .

RUN dotnet build --nologo -c Release

# test

#RUN dotnet test --nologo --no-build -c Release

RUN dotnet test -m:1 \
  /p:CollectCoverage=true /p:CoverletOutput="/out/" /p:MergeWith="/out/coverage.json" /p:CoverletOutputFormat=\"opencover,json\"

# pack

WORKDIR /work/src/App.Bld.Mapping.Practises

RUN dotnet pack --nologo --include-symbols --include-source -c Release -o /dist

