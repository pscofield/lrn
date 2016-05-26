using System;
using TheObserverPattern;
using System.Collections.Generic;

namespace TheObserverPattern
{
    class WeatherDataProvider2 : IObservable<WeatherDataObject>
    {
        private List<IObserver<WeatherDataObject>> _listOfObservers; // Notice that the type
        // of the list is "IObserver". This should remind of "program to an interface,
        // not an implementation". It's even better if the type of the information that
        // is passed is also an interface, but we don't need that requirement here.

        private WeatherDataObject _latestWeatherData;

        public WeatherDataProvider2()
        {
            _listOfObservers = new List<IObserver<WeatherDataObject>>();
            _latestWeatherData = new WeatherDataObject(0,0,0);
        }

        public IDisposable Subscribe(IObserver<WeatherDataObject> observer)
        {
            if (!_listOfObservers.Contains(observer))
            {
                _listOfObservers.Add(observer);
                observer.OnNext(_latestWeatherData);
            }

            return null;
        }
    }

    class WeatherDataObserver21 : IObserver<WeatherDataObject>
    {
        private WeatherDataObject _currentWeatherDataObject;

        public void OnCompleted()
        {
 	        throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
 	        throw new NotImplementedException();
        }

        public void OnNext(WeatherDataObject value)
        {
            _currentWeatherDataObject = value;
        }
    }

    class WeatherDataObserver22 : IObserver<WeatherDataObject>
    {
        private WeatherDataObject _currentWeatherDataObject;

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(WeatherDataObject value)
        {
            _currentWeatherDataObject = value;
        }
    }
}