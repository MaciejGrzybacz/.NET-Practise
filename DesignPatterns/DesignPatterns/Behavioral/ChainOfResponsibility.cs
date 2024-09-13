/*
The Chain of Responsibility implementation should include the following elements:

1. Handler Interface:
   - Define an interface or an abstract class for handlers in the chain.
   - The interface should include a method for handling requests and a property to set the next handler in the chain.

2. Concrete Handlers:
   - Create concrete classes that implement the handler interface.
   - Each handler should process the request if it can, or pass the request along the chain if it cannot handle it.

3. Client:
   - Create a client class that constructs the chain of handlers and initiates the request.
   - The client should be able to configure which handler starts the chain and handle the request through the chain.

4. Interaction Flow:
   - When a request is sent, it travels through the chain of handlers.
   - Each handler in the chain has the opportunity to process the request or pass it along to the next handler.

TODO: Exercise: Implementing the Chain of Responsibility Pattern for a Support Ticket System

Objective: Design and implement a support ticket management system using the Chain of Responsibility design pattern.

Tips:
- Define a base handler interface or abstract class with a method to handle requests and a property for the next handler.
- Implement concrete handler classes that process specific types of requests or forward them to the next handler.
- In the client, build the chain by linking handlers together and initiate the request through the chain.

Extension (optional):
- Add more handler types to handle different types of requests or provide more detailed processing logic.
- Implement logging or additional functionality in handlers to demonstrate the request's progress through the chain.
*/

namespace DesignPatterns.Behavioral
{
    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;

        public void SetNext(SupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(string request);
    }

    public class Level1SupportHandler : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Basic Issue")
            {
                Console.WriteLine("Level 1 Support: Resolved basic issue.");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("Level 1 Support: Passing to the next level...");
                _nextHandler.HandleRequest(request);
            }
        }
    }

    public class Level2SupportHandler : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Intermediate Issue")
            {
                Console.WriteLine("Level 2 Support: Resolved intermediate issue.");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("Level 2 Support: Passing to the next level...");
                _nextHandler.HandleRequest(request);
            }
        }
    }

    public class Level3SupportHandler : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "Complex Issue")
            {
                Console.WriteLine("Level 3 Support: Resolved complex issue.");
            }
            else if (_nextHandler != null)
            {
                Console.WriteLine("Level 3 Support: Issue could not be resolved at this level. Escalating...");
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Level 3 Support: Issue cannot be resolved by the support team.");
            }
        }
    }
    
    public class SupportTicketSystem
    {
        private SupportHandler _firstHandler;

        public SupportTicketSystem()
        {
            SupportHandler level1 = new Level1SupportHandler();
            SupportHandler level2 = new Level2SupportHandler();
            SupportHandler level3 = new Level3SupportHandler();

            level1.SetNext(level2);
            level2.SetNext(level3);

            _firstHandler = level1;
        }

        public void ProcessRequest(string issue)
        {
            Console.WriteLine($"Support Ticket: Processing request for '{issue}'");
            _firstHandler.HandleRequest(issue);
        }
    }
    
    public class ChainOfResponsibilityExample
    {
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Observer Pattern Example:");
            Console.ResetColor();
            
            SupportTicketSystem supportSystem = new SupportTicketSystem();

            Console.WriteLine("Scenario 1: Handling Basic Issue");
            supportSystem.ProcessRequest("Basic Issue");

            Console.WriteLine("\nScenario 2: Handling Intermediate Issue");
            supportSystem.ProcessRequest("Intermediate Issue");

            Console.WriteLine("\nScenario 3: Handling Complex Issue");
            supportSystem.ProcessRequest("Complex Issue");

            Console.WriteLine("\nScenario 4: Handling Unknown Issue");
            supportSystem.ProcessRequest("Unknown Issue");
            Console.WriteLine();
        }
    }
}
