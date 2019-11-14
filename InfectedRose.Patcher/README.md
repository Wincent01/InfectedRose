# InfectedRose.Patcher
Simple Console Application to patch the client to allow for loading of new and modified zones. Changes one
JZ instruction to JMP, skipping the checksum check.

## Use
```
dotnet ./InfectedRose.Patcher.dll <path-to-legouniverse.exe>
```