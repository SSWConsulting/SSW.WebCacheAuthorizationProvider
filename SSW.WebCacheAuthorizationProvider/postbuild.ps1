

param
(
	[string]$projectDir
)

Write-Host "Copying dlls into package folder..."

Write-Host ($projectDir + "bin\Release\*.dll")

Copy-Item ($projectDir + "bin\Release\*.dll") ($projectDir + "package\lib\net40") 