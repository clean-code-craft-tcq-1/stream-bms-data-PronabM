using System;
using System.Collections.Generic;
namespace BatteryDataStreamingReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IParseBatteryData batteryDataParser = new BatteryDataParser(",");
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            List<string> batteryData = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != null && !input.Equals("###"))
            {
                Console.WriteLine(input);
                batteryData.Add(input);
                BatteryCharacteristics batteryCharacteristics;
                batteryCharacteristics = batteryDataProcessor.GetMinimumAndMaximumValues(input);
                string message = string.Format("Minimum Temperature - {0} Maximum Temperature - {1}\n" +
                                                "Minimum StateOfCharge - {2} Maximum StateOfCharge - {3}", batteryCharacteristics.Temperature.MinimumTemperature,
                                                batteryCharacteristics.Temperature.MaximumTemperature, batteryCharacteristics.StateOfCharge.MinimumSoc, batteryCharacteristics.StateOfCharge.MaximumSoc);
                Display(message);
                if (batteryData.Count >= 5)
                {
                    batteryCharacteristics = batteryDataProcessor.GetMovingAverageValue(batteryData.GetRange(batteryData.Count - 5, 5));
                    message = string.Format("Moving Average Temperature - {0} Moving AveragetateOfCharge - {1}",
                        batteryCharacteristics.Temperature.MovingAverageTemperature, batteryCharacteristics.StateOfCharge.MovingAverageSoc);
                    Display(message);
                }
            }
        }
        private static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
