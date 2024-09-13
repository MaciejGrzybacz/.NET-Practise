/*
The Template Method implementation should include the following elements:

1. Abstract Base Class:
   - Define an abstract class that provides a template method outlining the steps of the algorithm.
   - The template method should call other methods in a specific order.

2. Concrete Implementations:
   - Create concrete classes that inherit from the abstract base class.
   - Implement the steps of the algorithm that are specific to the concrete class.
   - The concrete classes should provide the actual behavior for the steps defined as abstract or hooks in the base class.

3. Template Method:
   - In the abstract base class, the template method should define the sequence of steps to execute the algorithm.
   - Some steps can be defined with a default implementation, while others should be abstract, forcing subclasses to provide specific implementations.

4. Interaction Flow:
   - When a concrete implementation of the abstract class is created, it will use the template method to execute the algorithm.
   - The template method will ensure that the steps are performed in the defined sequence, allowing subclasses to vary specific parts of the algorithm.

TODO: Exercise: Implementing the Template Method Pattern for a Smart Home System

Objective: Design and implement a smart home management system using the Template Method design pattern.

Tips:
- Define a template method in an abstract base class to manage the steps of the home management process.
- Implement specific behavior in concrete classes by overriding abstract methods in the base class.
- Ensure that the template method is used to control the flow of execution, while concrete classes handle the details.

Extension (optional):
- Add more concrete classes to handle different modes or scenarios in the smart home system.
- Implement additional methods or hooks in the abstract base class to provide more flexibility in the algorithm.
*/

namespace DesignPatterns.Behavioral;

public abstract class SmartHomeTemplate
{
    public void RunSmartHomeSystem()
    {
       InitializeDevices();
       ActivateDevices();
       DeactivateDevices();
       CleanupDevices();
    }

    protected abstract void InitializeDevices();

    protected void ActivateDevices()
    {
       Console.WriteLine("Template : Activating devices...");
    }

    protected void DeactivateDevices()
    {
       Console.WriteLine("Template : Deactivating devices...");
    }

    protected abstract void CleanupDevices();
}

public class ConcreteSmartHomeA : SmartHomeTemplate
{
   protected override void InitializeDevices()
   {
      Console.WriteLine("ConcreteA : Initializing devices...");
   }

   protected override void CleanupDevices()
   {
      Console.WriteLine("ConcreteA : Cleaning up devices...");
   }
}

public class ConcreteSmartHomeB : SmartHomeTemplate
{
   protected override void InitializeDevices()
   {
      Console.WriteLine("ConcreteB : Initializing devices...");
   }

   protected override void CleanupDevices()
   {
      Console.WriteLine("ConcreteB : Cleaning up devices...");
   }
}

public class TemplateExample
{
    public void Run()
    {
        Console.WriteLine("Smart Home System A:");
        SmartHomeTemplate smartHomeA = new ConcreteSmartHomeA();
        smartHomeA.RunSmartHomeSystem();

        Console.WriteLine();

        Console.WriteLine("Smart Home System B:");
        SmartHomeTemplate smartHomeB = new ConcreteSmartHomeB();
        smartHomeB.RunSmartHomeSystem();
    }
}