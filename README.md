# red-mango-api

[![Build .NET](https://github.com/Botche/red-mango-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Botche/red-mango-api/actions/workflows/dotnet.yml) \
[![Deploy project to Azure](https://github.com/Botche/red-mango-api/actions/workflows/azure-functions-app-dotnet.yml/badge.svg)](https://github.com/Botche/red-mango-api/actions/workflows/azure-functions-app-dotnet.yml)

The API is published on Azure and available on this link: [Red Mango API](https://redmangoapidotnet.azurewebsites.net/index.html)


## Requirements

|  Name                      | version       | Details                              |
| -------------------------- |:-------------:| -----------------------------------: |
| .NET                       | 7.0           | Check files .csproj                  |
| Microsoft Visual Studio    | 2022          | Community editition                  |
| SQL Server                 | 2019          | Express editition                    |

## Initial setup
In order to run the project locally you will need to add a key to appsettings.json. This is used for storing the images from the application.
```
"ConnectionStrings": {
  "ImagesStorageConnection": "ADD-YOUR-AZURE-STORAGE-CONNECTION"
}
```
