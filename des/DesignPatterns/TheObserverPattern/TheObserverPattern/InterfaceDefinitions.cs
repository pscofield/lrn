using System;
using System.Collections;

namespace TheObserverPattern
{
    /// <summary>
    /// This is the generic publisher/subject interface.
    /// </summary>
    interface IPublisher
    {
        void NotifyObservers();
        void RemoveObserver(IObserver o);
        void AddObserver(IObserver o);
    }

    /// <summary>
    /// This is the generic observer interface.
    /// </summary>
    public interface IObserver
    {
        void Update(Object latestDataObject);
    }

    /// <summary>
    /// This is the generic interface for all weather providers/stations.
    /// </summary>
    interface IWeatherProvider : IPublisher
    {
        double GetTemperature();
        double GetHumidity();
        double GetPressure();
    }

    /// <summary>
    /// This is the interface for all weather data observers.
    /// </summary>
    interface IWeatherDataObserver : IObserver
    {

    }

    interface IDisplayDevice
    {
        void Display();
    }

}