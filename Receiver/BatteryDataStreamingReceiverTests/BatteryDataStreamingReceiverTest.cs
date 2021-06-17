using Xunit;
using BatteryDataStreamingReceiver;
using System.Collections.Generic;

namespace BatteryDataStreamingReceiverTests
{
    public class BatteryDataStreamingReceiverTest
    {
        IParseBatteryData batteryDataParser = new BatteryDataParser(",");
        List<string> batteryData = new List<string>() { "12,45", "0,52", "10,12", "11,9", "51,54","31,58","43,45","20,45","56,45","34,45" };

        public List<BatteryParameter> ExpectedBatteryDataList()
        {
            List<BatteryParameter> expectedBatteryData = new List<BatteryParameter>();
            BatteryParameter batteryParameter = new BatteryParameter() { Temperature = 12, StateOfCharge = 45};
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 0, StateOfCharge = 52 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 10, StateOfCharge = 12 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 11, StateOfCharge = 9 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 51, StateOfCharge = 54 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 31, StateOfCharge = 58 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 43, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 20, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 56, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            batteryParameter = new BatteryParameter() { Temperature = 34, StateOfCharge = 45 };
            expectedBatteryData.Add(batteryParameter);
            return expectedBatteryData;
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsNull_ThenReturnBatteryParameterListEmpty()
        {
            List<string> batteryData = null;
            List<BatteryParameter> batteryParameters = batteryDataParser.GetParsedBatteryParametersFromInput(batteryData);
            Assert.True(batteryParameters.Count == 0);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsEmpty_ThenReturnBatteryParameterListEmpty()
        {
            List<string> batteryData = new List<string>();
            List<BatteryParameter> batteryParameters = batteryDataParser.GetParsedBatteryParametersFromInput(batteryData);
            Assert.True(batteryParameters.Count == 0);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenReturnExpectedBatteryParameterList()
        {
            List<BatteryParameter> batteryParameters = batteryDataParser.GetParsedBatteryParametersFromInput(batteryData);
            Assert.True(AssertObjectsHelper.ActualAndExpectedObjectsAreEqual(ExpectedBatteryDataList(), batteryParameters));
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckTemperatureMinimum()
        {
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            BatteryCharacteristics batteryCharacteristics = null;
            double expectedTemperature = 0;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.GetMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.Temperature.Minimum, expectedTemperature);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckTemperatureMaximum()
        {
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            BatteryCharacteristics batteryCharacteristics = null;
            double expectedTemperature = 56;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.GetMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.Temperature.Maximum, expectedTemperature);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckStateOfChargeMinimum()
        {
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            BatteryCharacteristics batteryCharacteristics = null;
            double expectedStateOfCharge = 9;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.GetMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.StateOfCharge.Minimum, expectedStateOfCharge);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataListIsValid_ThenCheckStateOfChargeMaximum()
        {
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            BatteryCharacteristics batteryCharacteristics = null;
            double expectedStateOfCharge = 58;
            for (int i = 0; i < batteryData.Count; i++)
            {
                batteryCharacteristics = batteryDataProcessor.GetMinimumAndMaximumValues(batteryData[i]);
            }
            Assert.Equal(batteryCharacteristics.StateOfCharge.Maximum, expectedStateOfCharge);
        }

        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataIsValid_ThenCheckMovingAverageForTemperature()
        {
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            double expectedTemperature = 26.8;
            BatteryCharacteristics batteryCharacteristics = batteryDataProcessor.GetMovingAverageValue(batteryData);
            Assert.Equal(batteryCharacteristics.Temperature.MovingAverage, expectedTemperature);
        }
        
        [Fact]
        public void GivenBatteryDataList_WhenBatteryDataIsValid_ThenCheckMovingAverageForStateOfCharge()
        {
            BatteryDataProcessor batteryDataProcessor = new BatteryDataProcessor(batteryDataParser);
            double expectedStateOfCharge = 41;
            BatteryCharacteristics batteryCharacteristics = batteryDataProcessor.GetMovingAverageValue(batteryData);
            Assert.Equal(batteryCharacteristics.StateOfCharge.MovingAverage, expectedStateOfCharge);
        }
    }
}
