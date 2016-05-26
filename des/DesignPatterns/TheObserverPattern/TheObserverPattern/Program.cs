using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheObserverPattern
{
    static class Program
    {
        /// <summary>
        /// Tests the observer pattern implementation.
        /// </summary>
        /// <param name="args">Cmdline input arguments.</param>
        static void Main(string[] args)
        {
            // Initialize the weather.
            var latestWeather = new WeatherDataObject(-1,-1,-1);

            // Initialize the observers.
            var currentDisplay = new CurrentConditionsDisplay();
            var statisticsDisplay = new StatisticsDisplay();
            var forecastDisplay = new ForecastDisplay();

            var initialObserverList = new ArrayList {currentDisplay, statisticsDisplay, forecastDisplay};

            // Initialize the weather provider.
            var defaultORamaWeatherProvider = new DefaultORamaWeatherProvider(initialObserverList, latestWeather);

            // Trigger the measurements changed function.
            defaultORamaWeatherProvider.MeasurementsChanged();

            // Update the data.
            defaultORamaWeatherProvider.SetMeasurements(new WeatherDataObject(25, 60, 0.78));

            // Remove the forecast device.
            defaultORamaWeatherProvider.RemoveObserver(forecastDisplay);

            // Update the data.
            defaultORamaWeatherProvider.SetMeasurements(new WeatherDataObject(15, 50, 0.68));

        }
    }
}
