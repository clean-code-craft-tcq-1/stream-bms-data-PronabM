using System;
using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    public class BatteryDataParser : IParseBatteryData
    {
        public BatteryDataParser(string delimeterValue)
        {
            delimeter = delimeterValue;
        }
        private string delimeter;
        public List<BatteryParameter> GetParsedBatteryParametersFromInput(List<string> inputData)
        {
            List<BatteryParameter> batteryParameters = new List<BatteryParameter>();
            if (inputData == null)
                return batteryParameters;
            foreach (string  parameter in inputData)
            {
                BatteryParameter batteryParameter = new BatteryParameter();
                string[] batteryParameterValues = parameter.Split(delimeter);
                batteryParameter.Temperature = Convert.ToDouble(batteryParameterValues[0]);
                batteryParameter.StateOfCharge = Convert.ToDouble(batteryParameterValues[1]);
                batteryParameters.Add(batteryParameter);
            }
            return batteryParameters;
        }
    }
}
