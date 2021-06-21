pushd "%~dp0"

cd src\main\java
java bmsstream.Sender "R" "20" | dotnet run --project Receiver\BatteryDataStreamingReceiver\BatteryDataStreamingReceiver.csproj

popd
