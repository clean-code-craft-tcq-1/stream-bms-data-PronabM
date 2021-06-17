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
            string input = string.Empty;
            int i = 0;
            List<string> batteryData = new List<string>();
            while ((input = Console.ReadLine()) != null && !input.Equals("###"))
            {
                Console.WriteLine(input);
                i++;
                batteryData.Add(input);
                BatteryCharacteristics batteryCharacteristics;
                batteryCharacteristics = batteryDataProcessor.GetMinimumAndMaximumValues(input);
                string message = string.Format("Minimum Temperature - {0} Maximum Temperature - {1}\n" +
                                                "Minimum StateOfCharge - {2} Maximum StateOfCharge - {3}", batteryCharacteristics.Temperature.Minimum,
                                                batteryCharacteristics.Temperature.Maximum, batteryCharacteristics.StateOfCharge.Minimum, batteryCharacteristics.StateOfCharge.Maximum);
                Display(message);
                if (i == 5)
                {
                    batteryCharacteristics = batteryDataProcessor.GetMovingAverageValue(batteryData);
                    message = string.Format("Moving Average Temperature - {0} Moving AveragetateOfCharge - {1}", 
                        batteryCharacteristics.Temperature.MovingAverage, batteryCharacteristics.StateOfCharge.MovingAverage);
                    Display(message);
                    batteryData = new List<string>();
                    i = 0;
                }
            }
        }
        private static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}