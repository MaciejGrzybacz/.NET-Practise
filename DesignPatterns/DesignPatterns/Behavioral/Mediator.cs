/*
The Mediator implementation should include the following elements:

1. Mediator Interface:
   - Define an interface that facilitates communication between objects (colleagues).
   - The interface should include a `Notify` method that takes the sender and a message, allowing the mediator to act accordingly.

2. Concrete Mediator:
   - Implement the mediator interface in a concrete class.
   - This class will manage communication between different components. It will decide how to handle messages and delegate actions to the appropriate components.

3. Colleague Components:
   - Define individual components (colleagues) that will communicate through the mediator.
   - These components should not directly communicate with each other but instead use the mediator to send messages.
   - Each component can have a reference to the mediator to send notifications when certain events occur.

4. Interaction Flow:
   - When a component needs to interact with another component, it should notify the mediator.
   - The mediator will then determine the appropriate response or action and notify the necessary component(s).


TODO: Exercise: Implementing the Mediator Pattern for a Smart Home System

Objective: Design and implement a smart home management system using the Mediator design pattern.

Tips:
- Ensure that devices communicate with each other only through the mediator.
- In device methods that need to notify the mediator, use this.mediator.Notify(this, "EVENT_NAME").
- In SmartHomeHub, implement logic to decide how to react to various events from devices.

Extension (optional):
- Add more device types, e.g., audio system, window blinds, or garden irrigation.
- Implement more complex interaction scenarios between devices.
*/

public interface IMediator
{
    public void Notify(SmartDevice sender, string eventName);
}

public class SmartHomeHub : IMediator
{
    private LightningSystem _lightningSystem;
    private SecuritySystem _securitySystem;
    private ClimateControlSystem _climateControlSystem;
    
    public SmartHomeHub(LightningSystem lightningSystem, SecuritySystem securitySystem, ClimateControlSystem climateControlSystem)
    {
        this._lightningSystem = lightningSystem;
        this._securitySystem = securitySystem;
        this._climateControlSystem = climateControlSystem;
        
        this._lightningSystem.SetMediator(this);
        this._securitySystem.SetMediator(this);
        this._climateControlSystem.SetMediator(this);
    }

    public void Notify(SmartDevice sender, string eventName)
    {
        if (sender is LightningSystem)
        {
            if (eventName == "MOTION DETECTED!")
            {
                this._lightningSystem.TurnOnLights();
                this._securitySystem.ActivateAlarm();
            }
        }
        else if (sender is SecuritySystem)
        {
            if (eventName == "NIGHT MODE")
            {
                this._lightningSystem.ActivateNightMode();
                this._securitySystem.ActivateNightSurveillance();
                this._climateControlSystem.SetNightTemperature();
            }
            else if (eventName == "DAILY MODE")
            {
                this._lightningSystem.AdjustBrightness();
                this._securitySystem.ActivateAlarm();
                this._climateControlSystem.AdjustTemperature();
            }
        }
        else if (sender is ClimateControlSystem)
        {
            if (eventName == "TEMPERATURE THRESHOLD REACHED")
            {
                this._securitySystem.ActivateAlarm();
            }
        }
    }
}

public abstract class SmartDevice
{
    protected IMediator SmartHomeMediator;
    
    public void SetMediator(IMediator mediator)
    {
        this.SmartHomeMediator = mediator;
    }
}

public class LightningSystem : SmartDevice
{
    public void TurnOnLights()
    {
        Console.WriteLine("Turning on lights...");
    }

    public void AdjustBrightness()
    {
        Console.WriteLine("Adjusting brightness...");
    }

    public void ActivateNightMode()
    {
        Console.WriteLine("Activating nightmode...");
    }

    public void MotionDetection()
    {
        Console.WriteLine("Motion detected...");
        this.SmartHomeMediator.Notify(this, "MOTION DETECTED!");
    }
}

public class SecuritySystem : SmartDevice
{
    public void ActivateAlarm()
    {
        Console.WriteLine("Activating the alarm...");
    }

    public void ActivateNightSurveillance()
    {
        Console.WriteLine("Activating night surveillance system");
    }

    public void StartNightMode()
    {
        Console.WriteLine("Starting nightmode");
        this.SmartHomeMediator.Notify(this, "NIGHT MODE");
    }
    
    public void StartDailyMode()
    {
        Console.WriteLine("Activating daily mode");
        this.SmartHomeMediator.Notify(this, "DAILY MODE");
    }
}

public class ClimateControlSystem : SmartDevice
{
    public void AdjustTemperature()
    {
        Console.WriteLine("Adjusting temperature...");
    }
    
    public void SetNightTemperature()
    {
        Console.WriteLine("Setting night temperature...");
    }
    
    public void TemperatureThresholdReached()
    {
        Console.WriteLine("Temperature threshold reached...");
        this.SmartHomeMediator.Notify(this, "TEMPERATURE THRESHOLD REACHED");
    }
}

public class MediatorExample
{
    public void Run()
    {
        LightningSystem lightningSystem = new LightningSystem();
        SecuritySystem securitySystem = new SecuritySystem();
        ClimateControlSystem climateControlSystem = new ClimateControlSystem();
        
        SmartHomeHub smartHomeHub = new SmartHomeHub(lightningSystem, securitySystem, climateControlSystem);
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Motion detection scenario:");
        Console.ResetColor();
        lightningSystem.MotionDetection();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Temperature threshold scenario:");
        Console.ResetColor();
        climateControlSystem.TemperatureThresholdReached();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Night mode activation scenario:");
        Console.ResetColor();
        securitySystem.StartNightMode();
    }
}