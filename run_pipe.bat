pushd "%~dp0"

mvn compile exec:java -Dexec.mainClass="bmsstream.Sender" -Dexec.args="R 20" | dotnet run --project Receiver\BatteryDataStreamingReceiver\BatteryDataStreamingReceiver.csproj

popd
