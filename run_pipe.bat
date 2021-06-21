pushd "%~dp0"

#mvn compile exec:java -Dexec.mainClass="bmsstream.Sender" -Dexec.args="R 20" | dotnet run --project Receiver\BatteryDataStreamingReceiver\BatteryDataStreamingReceiver.csproj
java -ea -cp "src*" main.java.bmsstream.Sender "R" "20" | dotnet run --project Receiver\BatteryDataStreamingReceiver\BatteryDataStreamingReceiver.csproj

popd
