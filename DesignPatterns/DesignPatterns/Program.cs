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
        RunAllCreationalExamples();
        RunAllStructuralExamples();
    }

    public static void RunAllBehavioralExamples()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Behavioral Design Patterns:");
        Console.ResetColor();
        ObserverExample observer = new ObserverExample();
        observer.Run();
        
        VisitorExample visitor = new VisitorExample();
        visitor.Run();
        
        MediatorExample mediator = new MediatorExample();
        mediator.Run();
        
        TemplateExample template = new TemplateExample();
        template.Run();
        
        ChainOfResponsibilityExample chainOfResponsibility = new ChainOfResponsibilityExample();
        chainOfResponsibility.Run();
        
        Console.WriteLine();
    }
    
    public static void RunAllCreationalExamples()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Creational Design Patterns:");
        Console.ResetColor();
        
        SingletonExample singleton = new SingletonExample();
        singleton.Run();
        
        Console.WriteLine();
    }
    
    public static void RunAllStructuralExamples()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Structural Design Patterns:");
        Console.ResetColor();
        
        DecoratorExample decorator = new DecoratorExample();
        decorator.Run();
        
        Console.WriteLine();
    }
}