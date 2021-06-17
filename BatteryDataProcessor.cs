using System;
using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public class BatteryDataProcessor : IProcessBatteryData
    {
        private BatteryCharacteristics batteryCharacteristics;
        private IParseBatteryData batteryDataParser;

        public BatteryDataProcessor(IParseBatteryData _batteryDataParser)
        {
            batteryDataParser = _batteryDataParser;
            batteryCharacteristics = new BatteryCharacteristics();
        }
        public BatteryCharacteristics GetMovingAverageValue(List<string> batteryInputParameters)
        {
            List<BatteryParameter> batteryParameters = batteryDataParser.GetParsedBatteryParametersFromInput(batteryInputParameters);
            CalculateMovingAverage(batteryParameters);
            return batteryCharacteristics;
        }

        public BatteryCharacteristics GetMinimumAndMaximumValues(string batteryParameter)
        {
            List<BatteryParameter> batteryParameters = batteryDataParser.GetParsedBatteryParametersFromInput(new List<string>() { batteryParameter });
            CalculateMinimumValue(batteryParameters[0]);
            CalculateMaximumValue(batteryParameters[0]);
            return batteryCharacteristics;
        }

        private void CalculateMinimumValue(BatteryParameter batteryParameter)
        {
            batteryCharacteristics.Temperature.Minimum = Math.Min(batteryCharacteristics.Temperature.Minimum, batteryParameter.Temperature);
            batteryCharacteristics.StateOfCharge.Minimum = Math.Min(batteryCharacteristics.StateOfCharge.Minimum, batteryParameter.StateOfCharge);
        }

        private void CalculateMaximumValue(BatteryParameter batteryParameter)
        {
            batteryCharacteristics.Temperature.Maximum = Math.Max(batteryCharacteristics.Temperature.Maximum, batteryParameter.Temperature);
            batteryCharacteristics.StateOfCharge.Maximum = Math.Max(batteryCharacteristics.StateOfCharge.Maximum, batteryParameter.StateOfCharge);
        }

        private void CalculateMovingAverage(List<BatteryParameter> batteryParameters)
        {
            if (batteryParameters.Count <= 0)
                return;
            batteryCharacteristics.Temperature.MovingAverage = batteryParameters[0].Temperature;
            batteryCharacteristics.StateOfCharge.MovingAverage = batteryParameters[0].StateOfCharge;

            double sumOfTemperature = 0;
            double sumOfStateOfCharge = 0;
            foreach (BatteryParameter batteryParameter in batteryParameters)
            {
                sumOfTemperature += batteryParameter.Temperature;
                sumOfStateOfCharge += batteryParameter.StateOfCharge;
            }
            batteryCharacteristics.Temperature.MovingAverage = sumOfTemperature / batteryParameters.Count;
            batteryCharacteristics.StateOfCharge.MovingAverage = sumOfStateOfCharge / batteryParameters.Count;
        }
    }
}