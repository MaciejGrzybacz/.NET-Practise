using System;
using System.Collections.Generic;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using DesignPatterns.Structural;


public class Program
{
    public static void Main()
    {
        RunAllBehavioralExamples();
    }

    public static void RunAllBehavioralExamples()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Observer Pattern Example:");
        Console.ResetColor();
        ObserverExample observer = new ObserverExample();
        observer.Run();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Visitor Pattern Example:");
        Console.ResetColor();
        VisitorExample visitor = new VisitorExample();
        visitor.Run();
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Mediator Pattern Example:");
        Console.ResetColor();
        MediatorExample mediator = new MediatorExample();
        mediator.Run();
    }
    
    public static void RunAllCreationalExamples()
    {
        // Console.ForegroundColor = ConsoleColor.Yellow;
        // Console.WriteLine("Abstract Factory Pattern Example:");
        // Console.ResetColor();
        // AbstractFactoryExample abstractFactory = new AbstractFactoryExample();
        // abstractFactory.Run();
        //
        // Console.ForegroundColor = ConsoleColor.Yellow;
        // Console.WriteLine("Builder Pattern Example:");
        // Console.ResetColor();
        // BuilderExample builder = new BuilderExample();
        // builder.Run();
        //
        // Console.ForegroundColor = ConsoleColor.Yellow;
        // Console.WriteLine("Factory Method Pattern Example:");
        // Console.ResetColor();
        // FactoryMethodExample factoryMethod = new FactoryMethodExample();
        // factoryMethod.Run();
        //
        // Console.ForegroundColor = ConsoleColor.Yellow;
        // Console.WriteLine("Prototype Pattern Example:");
        // Console.ResetColor();
        // PrototypeExample prototype = new PrototypeExample();
        // prototype.Run();
        //
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Singleton Pattern Example:");
        Console.ResetColor();
        SingletonExample singleton = new SingletonExample();
        singleton.Run();
    }
}