namespace BatteryDataStreamingReceiver
{
    public class Temperature
    {
        private double _minimumTemperature = double.MaxValue;

        public double MinimumTemperature
        {
            get { return _minimumTemperature; }
            set { _minimumTemperature = value; }
        }

        private double _maximumTemperature = double.MinValue;

        public double MaximumTemperature
        {
            get { return _maximumTemperature; }
            set { _maximumTemperature = value; }
        }

        public double MovingAverageTemperature { get; set; }
    }
}
