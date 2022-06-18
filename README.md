# the_wire

Simple C2 written in C#. Only meant for learning purposes. Dont use for bad guy stuff.

## Things might do

- Binary patching
- Custom Web Dashboard
- Backend database storage

## Publishing Implant

``` sh 
# Linux
dotnet publish -p:PublishSingleFile=true -r linux-x64 -c Release

# Windows
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release
```