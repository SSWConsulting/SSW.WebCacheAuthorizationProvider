# get api key
$p = Split-Path $MyInvocation.MyCommand.Path
$apiKey = [IO.File]::ReadAllText("$p\SSW.Nuget.Api.key")

# pack and publish to nuget
.\Assets\nuget.exe pack .\package\SSW.WebCacheAuthorizationProvider.nuspec
.\Assets\nuget.exe setApiKey $apiKey
.\Assets\nuget.exe push SSW.WebCacheAuthorizationProvider.1.0.0.nupkg