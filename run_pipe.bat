pushd "%~dp0"

cd src\main\java

javac bmsstream\Sender.java

java bmsstream.Sender "R" "20" | dotnet run --project Receiver\BatteryDataStreamingReceiver\BatteryDataStreamingReceiver.csproj

popd
