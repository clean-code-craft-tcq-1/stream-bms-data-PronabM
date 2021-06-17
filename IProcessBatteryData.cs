using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public interface IProcessBatteryData
    {
        BatteryCharacteristics GetMovingAverageValue(List<string> batteryParameters);
        BatteryCharacteristics GetMinimumAndMaximumValues(string batteryParameter);
    }
}