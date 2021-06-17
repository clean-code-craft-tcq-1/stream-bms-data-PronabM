namespace BatteryDataStreamingReceiver
{
    public class BatteryCharacteristics
    {
        public BatteryCharacteristics()
        {
            Temperature = new Temperature();
            StateOfCharge = new StateOfCharge();
        }
        public Temperature Temperature { get; set; }
        public StateOfCharge StateOfCharge { get; set; }
    }
}