namespace BatteryDataStreamingReceiver
{
    public class Temperature
    {
        private double _minimum = double.MaxValue;

        public double Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }

        private double _maximum = double.MinValue;

        public double Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }

        public double MovingAverage { get; set; }
    }
}