$originalFolder = Get-Location
Set-Location "$PSScriptRoot/../"

$publishFolder = "Publish"
if (Test-Path -Path $publishFolder) {
	Remove-Item $publishFolder -Recurse
}
New-Item -Path $publishFolder -ItemType Directory

$password = Read-Host "Enter Android Signing Key Pass"
dotnet publish Freesome/Freesome.csproj --framework net7.0-android --configuration Release --output "$publishFolder/Freesome" /p:AndroidSigningKeyPass=$password /p:AndroidSigningStorePass=$password /p:AndroidSigningKeyStore=freesome.keystore

Set-Location $originalFolder