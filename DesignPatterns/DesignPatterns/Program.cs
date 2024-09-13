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
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Template Pattern Example:");
        Console.ResetColor();
        TemplateExample template = new TemplateExample();
        template.Run();
    }
    
    public static void RunAllCreationalExamples()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Singleton Pattern Example:");
        Console.ResetColor();
        SingletonExample singleton = new SingletonExample();
        singleton.Run();
    }
}