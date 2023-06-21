namespace BatteryDataStreamingReceiver
{
    public class StateOfCharge
    {
        private double _minimumSoc = double.MaxValue;
        public double MinimumSoc
        {
            get { return _minimumSoc; }
            set { _minimumSoc = value; }
        }
        private double _maximumSoc = double.MinValue;
        public double MaximumSoc
        {
            get { return _maximumSoc; }
            set { _maximumSoc = value; }
        }
        public double MovingAverageSoc { get; set; }
    }
}
