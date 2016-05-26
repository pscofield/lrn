using System;
using System.Collections;
using System.ComponentModel;

namespace TheObserverPattern
{
    /// <summary>
    /// This is the weather provider implementation of the default "Weather-O-Rama" manufacturer.
    /// </summary>
    public class DefaultORamaWeatherProvider : IWeatherProvider
    {
        private ArrayList RegisteredWeatherDataObjects;

        private WeatherDataObject _latestWeatherDataObject;

        public DefaultORamaWeatherProvider()
        {
            RegisteredWeatherDataObjects = new ArrayList();
            _latestWeatherDataObject = new WeatherDataObject();
        }

        public DefaultORamaWeatherProvider(ArrayList initialListOfRegisteredDataObjects,
            WeatherDataObject initialWeatherDataObject)
        {
            RegisteredWeatherDataObjects = initialListOfRegisteredDataObjects;
            _latestWeatherDataObject = initialWeatherDataObject;
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in RegisteredWeatherDataObjects)
            {
                observer.Update(_latestWeatherDataObject);
            }
        }

        public void RemoveObserver(IObserver o)
        {
            if (RegisteredWeatherDataObjects.Contains(o))
            {
                RegisteredWeatherDataObjects.Remove(o);
            }
            else
            {
                Console.WriteLine("The following input object could not be removed because it wasn't a part of the list of observers: {0}.", o.ToString());
            }
        }

        public void AddObserver(IObserver o)
        {
            if (RegisteredWeatherDataObjects.Contains(o))
            {
                Console.WriteLine("The following input object was already added to the list of observers: {0}.", o.ToString());
            }
            else
            {
                RegisteredWeatherDataObjects.Add(o);
            }
        }

        public double GetTemperature()
        {
            return _latestWeatherDataObject.Temperature;
        }

        public double GetHumidity()
        {
            return _latestWeatherDataObject.Humidity;
        }

        public double GetPressure()
        {
            return _latestWeatherDataObject.Pressure;
        }

        /// <summary>
        /// This is triggered whenever the measurements change.
        /// </summary>
        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        /// <summary>
        /// A test hook to support the update of weather data.
        /// </summary>
        /// <param name="newWeatherData">The new data that will be passed to the observers.</param>
        public void SetMeasurements(WeatherDataObject newWeatherData)
        {
            _latestWeatherDataObject = newWeatherData;
            MeasurementsChanged();
        }
    }

    /// <summary>
    /// This class encapsulates all the weather data that needs to be communicated.
    /// </summary>
    public class WeatherDataObject
    {
        public WeatherDataObject()
        {
            Temperature = 0;
            Humidity = 0;
            Pressure = 0;
        }
        public WeatherDataObject(double temperature, double humidity, double pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double Pressure { get; set; }

        public double HeatIndex
        {
            get { return 16.923 + 0.185212*Temperature + 5.37941*Humidity - 0.100254*Temperature*Humidity; }
        }
    }
}