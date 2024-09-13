namespace DesignPatterns.Structural;
/*
The Decorator implementation should include the following elements:

1. Component Interface:
   - Define an interface for objects that can have responsibilities added to them dynamically.
   - The interface should include methods that are common to both simple components and decorators.

2. Concrete Component:
   - Implement the component interface in a concrete class.
   - This class defines the basic behavior, which can be altered by decorators.

3. Base Decorator:
   - Create an abstract decorator class that implements the component interface.
   - This class should have a reference to a component object and delegate operations to it.

4. Concrete Decorators:
   - Create concrete decorator classes inheriting from the base decorator.
   - Each decorator adds new behavior before and/or after delegating to the component.

5. Interaction Flow:
   - The client works with components through the component interface.
   - This allows passing decorated objects to code that expects simple components.

TODO: Exercise: Implementing the Decorator Pattern to make a wrap over a message

Objective: Design and implement a message wrapper using the Decorator design pattern.

Tips:
- Ensure all components and decorators implement the same interface.
- Each decorator should contain a reference to a component object.
- Decorators can add new methods, but these should be used carefully to avoid violating the Liskov Substitution Principle.

Extension (optional):
- Add more decorator types, e.g., encryption, compression, logging.
- Implement the ability to dynamically combine decorators at runtime.
*/

interface IPrinter
{
   public string PrintMessage();
}

class Printer : IPrinter
{
   public string PrintMessage()
   {
      return "Message from printer";
   }
}

abstract class Decorator : IPrinter
{
   protected IPrinter printer;

   public Decorator(IPrinter _printer)
   {
      this.printer = _printer;
   }

   public virtual string PrintMessage()
   {
      if (this.printer is null)
      {
         return "";
      }

      return printer.PrintMessage();
   }
}

class DecoratorA : Decorator
{
   public DecoratorA(IPrinter _printer) : base(_printer) { }

   public override string PrintMessage()
   {
      return $"wrapped in A : ( {printer.PrintMessage()} )";
   }
}

class DecoratorB : Decorator
{
   public DecoratorB(IPrinter _printer) : base(_printer) { }

   public override string PrintMessage()
   {
      return $"wrapped in B : ( {printer.PrintMessage()} )";
   }
}

class DecoratorExample
{
   public void Run()
   {
      Printer printer = new Printer();
      DecoratorA decoratorA = new DecoratorA(printer);
      DecoratorB decoratorB = new DecoratorB(decoratorA);

      Console.WriteLine(decoratorB.PrintMessage());
   }
}

