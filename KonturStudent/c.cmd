cd ClientGenerator\bin\Debug\netcoreapp3.1
@echo off
(
echo http://localhost:56456/swagger/v1/swagger.json
echo Client.ts
echo Client.cs
) | ClientGenerator.exe