# Receiver

There are basically 2 projects

1. BatteryDataStreamingReceiver
2. BatteryDataStreamingReceiverTests

## BatteryDataStreamingReceiver :

BatteryDataStreamingReceiver is an console application which continously reads the data that it
receives.
From the received data it calculates Minimum,Maximum and Moving Average for Temperature and StateOfCharge. 

After calculating it prints as below

Minimum Temperature - 0 Maximum Temperature - 37

Minimum StateOfCharge - 22 Maximum StateOfCharge - 72

Moving Average Temperature - 14.2 Moving AveragetateOfCharge - 53.6


#### **Note: Moving average calculation starts after receiving the 5 values only**

## BatteryDataStreamingReceiverTests :
- BatteryDataStreamingReceiverTest.cs class contains the tests for the BatteryDataStreamingReceiver project
