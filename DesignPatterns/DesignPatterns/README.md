# C# Design Patterns Implementation

This project aims to implement a variety of design patterns in C#. The purpose of this repository is to serve as a reference for learning and understanding how different design patterns can be applied in real-world C# applications.


## Design Patterns Implemented

### Behavioral Patterns

Behavioral patterns are concerned with communication between objects. They define how objects interact with each other and distribute responsibilities.

- #### Mediator Pattern
   - The **Mediator Pattern** defines an object that encapsulates how a set of objects interact. Instead of allowing objects to refer to each other explicitly, they communicate through the mediator. This reduces dependencies between communicating objects, promoting loose coupling.
   You can find the implementation of the Mediator pattern in the `Behavioral/Mediator.cs` file.

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
    - Chain of Responsibility
    - Command
    - Iterator
    - Memento
    - Observer
    - State
    - Strategy
    - Template Method
    - Visitor
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
