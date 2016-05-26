using System;

namespace TheObserverPattern
{
    public class CurrentConditionsDisplay : IWeatherDataObserver, IDisplayDevice
    {
        private WeatherDataObject _latestWeatherData;
        public static void DisplayEachData(string valueType, double value)
        {
            Console.WriteLine("The value for '" + valueType + "' is: " + value + ".");
        }

        public void Update(object latestDataObject)
        {
            // Explicitly cast the generic 'object' data type to WeatherDataObject.
            // This is to support the IObserver's generic 'Update' method.
            _latestWeatherData = (WeatherDataObject) latestDataObject;
            Display();
        }

        /// <summary>
        /// Displays the data to the screen.
        /// </summary>
        public void Display()
        {
            DisplayEachData("CC_Temperature", _latestWeatherData.Temperature);
            DisplayEachData("CC_Humidity", _latestWeatherData.Humidity);
            DisplayEachData("CC_Pressure", _latestWeatherData.Pressure);
            DisplayEachData("CC_HeatIndex", _latestWeatherData.HeatIndex);
        }
    }

    public class StatisticsDisplay : IWeatherDataObserver, IDisplayDevice
    {
        private WeatherDataObject _latestWeatherData;

        public void Update(object latestDataObject)
        {
            // Explicitly cast the generic 'object' data type to WeatherDataObject.
            // This is to support the IObserver's generic 'Update' method.
            _latestWeatherData = (WeatherDataObject)latestDataObject;
            Display();
        }

        /// <summary>
        /// Displays the data to the screen.
        /// </summary>
        public void Display()
        {
            CurrentConditionsDisplay.DisplayEachData("ST_Temperature", _latestWeatherData.Temperature);
            CurrentConditionsDisplay.DisplayEachData("ST_Humidity", _latestWeatherData.Humidity);
            CurrentConditionsDisplay.DisplayEachData("ST_Pressure", _latestWeatherData.Pressure);
            CurrentConditionsDisplay.DisplayEachData("ST_HeatIndex", _latestWeatherData.HeatIndex);
        }
    }

    public class ForecastDisplay : IWeatherDataObserver, IDisplayDevice
    {
        private WeatherDataObject _latestWeatherData;

        public void Update(object latestDataObject)
        {
            // Explicitly cast the generic 'object' data type to WeatherDataObject.
            // This is to support the IObserver's generic 'Update' method.
            _latestWeatherData = (WeatherDataObject)latestDataObject;
            Display();
        }

        /// <summary>
        /// Displays the data to the screen.
        /// </summary>
        public void Display()
        {
            CurrentConditionsDisplay.DisplayEachData("FC_Temperature", _latestWeatherData.Temperature);
            CurrentConditionsDisplay.DisplayEachData("FC_Humidity", _latestWeatherData.Humidity);
            CurrentConditionsDisplay.DisplayEachData("FC_Pressure", _latestWeatherData.Pressure);
            CurrentConditionsDisplay.DisplayEachData("FC_HeatIndex", _latestWeatherData.HeatIndex);
        }
    }
}