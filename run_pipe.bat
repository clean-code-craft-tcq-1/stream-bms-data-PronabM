pushd "%~dp0"

java -ea -cp "src" main.java.bmsstream.Sender "R" "20" | dotnet run --project src\Receiver\Receiver\Receiver.csproj

popd
