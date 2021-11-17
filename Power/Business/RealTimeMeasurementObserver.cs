using Power.Models;
using Tibber.Sdk;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;


namespace Power.Business
{
    public class RealTimeMeasurementObserver : IObserver<RealTimeMeasurement>
    {
        public void OnCompleted() => Console.WriteLine("Real time measurement stream has been terminated. ");
        public void OnError(Exception error) => Console.WriteLine($"An error occured: {error}");
        public void OnNext(RealTimeMeasurement value) {

            var powerReading = new PowerModel() { averagePower = (int)value.AveragePower, power = (int)value.Power, consumption = value.AccumulatedConsumption, cost = (decimal)value.AccumulatedCost };

            using (FileStream createStream = File.Create("PowerReading.json"))
            {
                JsonSerializer.SerializeAsync(createStream, powerReading);
            }

            Console.WriteLine($"{value.Timestamp} - power: {powerReading.power:N0} W (average: {powerReading.averagePower:N0} W); consumption since last midnight: {powerReading.consumption:N3} kWh; cost since last midnight: {powerReading.cost:N2}");
        }
    }
}
