del .\wire\*.cs
.\src\packages\Thrift.0.9.0.0\tools\thrift-0.9.0.exe --gen csharp .\wire\DNHPacket.thrift
move gen-csharp\*.cs .\src\DotNetHack.RPC\
rmdir gen-csharp
PAUSE