using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public interface IParseBatteryData
    {
        List<BatteryParameter> GetParsedBatteryParametersFromInput(List<string> inputData);
    }
}