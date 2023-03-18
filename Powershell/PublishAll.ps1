$originalFolder = Get-Location
Set-Location "$PSScriptRoot/../"

Remove-Item Publish -Recurse
New-Item -Path Publish -ItemType Directory

$password = Read-Host "Enter Android Signing Key Pass" -AsSecureString
dotnet publish Freesome/Freesome.csproj --framework net7.0-android --configuration Release --output Publish/Freesome /p:AndroidSigningKeyPass=$password /p:AndroidSigningStorePass=$password

Set-Location $originalFolder