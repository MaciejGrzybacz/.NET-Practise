/*
 * Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.
 *
 * The Singleton pattern solves two problems at the same time, violating the Single Responsibility Principle:
 * - Ensures that a class has just a single instance.
 * - Provides a global access point to that instance.
 *
 * The Singleton pattern is useful when you need to control access to some shared resource, such as a database or a file.
 * The Singleton pattern is similar to the global variables, but it's more secure and lazy-loaded.
 * The Singleton pattern is often used in logging, driver objects, caching, thread pools, configuration settings, and more.
 *
 * TODO: Exercise: Implementing the Singleton Pattern for anything that should have only one instance
 *
 * Objective: Implement a Singleton class that ensures only one instance of the class is created and provides a global access point to that instance.
 */
namespace DesignPatterns.Creational;

public class Singleton
{
    private Singleton() { }
    private static Singleton instance;
    
    public static Singleton GetInstance()
    {
        if (instance is null)
        {
            instance = new Singleton();
        }
        return instance;
    }
    
    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }
}

public class SingletonExample
{
    public void Run()
    {
        Singleton singleton = Singleton.GetInstance();
        Singleton anotherSingleton = Singleton.GetInstance();
        
        Console.WriteLine($"Are both instances equals? {singleton == anotherSingleton}");
    }
}