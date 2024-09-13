/*
 * Observer is a behavioral design pattern that lets you define a subscription mechanism to notify
 * multiple objects about any events that happen to the object they're observing.
 *
 * The Observer pattern is commonly used for implementing distributed event handling systems and
 * is a key part in the model-view-controller (MVC) architectural pattern.
 *
 * TODO: Exercise: Implementing the Observer Pattern for a weather monitoring system
 *
 * Objective: Create a weather station that notifies multiple displays when the weather measurements change.
 */
namespace DesignPatterns.Behavioral;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

public interface IDisplayElement
{
    void Display();
}

public class WeatherStation : ISubject
{
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherStation()
    {
        observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature, humidity, pressure);
        }
    }
    
    public void SetMeasurements(float _temperature, float _humidity, float _pressure)
    {
        temperature = _temperature;
        humidity = _humidity;
        pressure = _pressure;
        NotifyObservers();
    }
}

public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    private ISubject weatherStation;
    private float temperature;
    private float humidity;
    private float pressure;
    
    public CurrentConditionsDisplay(ISubject _weatherStation)
    {
        weatherStation = _weatherStation;
        weatherStation.RegisterObserver(this);
    }
    
    public void Update(float _temperature, float _humidity, float _pressure)
    {
        temperature = _temperature;
        humidity = _humidity;
        pressure = _pressure;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: temperature: {temperature}C, humidity: {humidity}%, pressure: {pressure} hPa");
    }
}

public class StatisticsDisplay : IObserver, IDisplayElement
{
    private float maxTemp = 0.0f;
    private float minTemp = 200;
    private float tempSum = 0.0f;
    private int numReadings = 0;
    private ISubject weatherStation;
    
    public StatisticsDisplay(ISubject _weatherStation)
    {
        weatherStation = _weatherStation;
        weatherStation.RegisterObserver(this);
    }
    
    public void Update(float temperature, float humidity, float pressure)
    {
        tempSum += temperature;
        numReadings++;
        maxTemp = (temperature > maxTemp) ? temperature : maxTemp;
        minTemp = (temperature < minTemp) ? temperature : minTemp;

        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Avg/Max/Min temperature = {tempSum / numReadings}/{maxTemp}/{minTemp}");
    }
}

public class ObserverExample
{
    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Observer Pattern Example:");
        Console.ResetColor();
        WeatherStation weatherStation = new WeatherStation();

        CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherStation);
        StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherStation);

        weatherStation.SetMeasurements(20, 65, 1000);
        Console.WriteLine();
        weatherStation.SetMeasurements(21, 70, 1001);
        Console.WriteLine();
        weatherStation.SetMeasurements(25, 90, 999);
        Console.WriteLine();
    }
}