# C# Design Patterns Implementation

This project aims to implement a variety of design patterns in C#. The purpose of this repository is to serve as a reference for learning and understanding how different design patterns can be applied in real-world C# applications.


## Design Patterns Implemented

### Behavioral Patterns

Behavioral patterns are concerned with communication between objects. They define how objects interact with each other and distribute responsibilities.

- #### Mediator Pattern
   - The **Mediator Pattern** defines an object that encapsulates how a set of objects interact. Instead of allowing objects to refer to each other explicitly, they communicate through the mediator. This reduces dependencies between communicating objects, promoting loose coupling.
   You can find the implementation of the Mediator pattern in the `Behavioral/Mediator.cs` file.
- #### Observer Pattern
   - The **Observer Pattern** defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. This pattern is useful when you need to maintain consistency between related objects without making them tightly coupled.
   You can find the implementation of the Observer pattern in the `Behavioral/Observer.cs` file.
- #### Visitor Pattern
   - The **Visitor Pattern** allows you to separate algorithms from the objects on which they operate. It lets you define new operations without changing the classes of the elements on which they operate. This pattern is useful when you have to perform multiple operations on objects of different types.
   You can find the implementation of the Visitor pattern in the `Behavioral/Visitor.cs` file.
- #### Template Method Pattern
   - The **Template Method Pattern** defines the skeleton of an algorithm in a method, deferring some steps to subclasses. It allows subclasses to redefine certain steps of an algorithm without changing its structure. This pattern is useful when you want to define a common algorithm structure but allow subclasses to provide specific implementations for some steps.
   You can find the implementation of the Template Method pattern in the `Behavioral/TemplateMethod.cs` file.
- #### Chain of Responsibility Pattern
   - The **Chain of Responsibility Pattern** allows you to pass a request along a chain of handlers. Each handler decides either to process the request or to pass it to the next handler in the chain. This pattern is useful when you want to decouple senders and receivers of requests.
   You can find the implementation of the Chain of Responsibility pattern in the `Behavioral/ChainOfResponsibility.cs` file.
  
### Creational Patterns

Creational patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

 - #### Singleton Pattern
    - The **Singleton Pattern** ensures that a class has only one instance and provides a global point of access to that instance. It is useful when you want to restrict object creation to a single instance to save resources.
      You can find the implementation of the Singleton pattern in the `Creational/Singleton.cs` file.

### Structural Patterns

Structural patterns are concerned with how classes and objects are composed to form larger structures. They define how different components of a system can be connected to work together effectively.

- #### Decorator Pattern
    - The **Decorator Pattern** allows for the dynamic addition of new behaviors to existing objects without altering their structure. It provides a flexible alternative to subclassing for extending functionality.
      You can find the implementation of the Decorator pattern in the `Structural/Decorator.cs` file.

## To be implemented
- **Behavioral Patterns**
    - Command
    - Iterator
    - Memento
    - State 
    - Strategy
- **Creational Patterns**
    - Abstract Factory
    - Builder
    - Factory Method
    - Prototype
- **Structural Patterns**
    - Adapter
    - Bridge
    - Composite
    - Facade
    - Flyweight
    - Proxy

## How to Run

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/design-patterns-csharp.git
    ```
2. Open the project in Visual Studio or your preferred C# IDE.
3. Navigate to the pattern you'd like to explore.
4. Run the pattern-specific project.
