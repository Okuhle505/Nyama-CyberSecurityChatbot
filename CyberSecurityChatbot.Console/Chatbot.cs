using System;
public class Chatbot
{
    private string userName;
    public Chatbot(string name)
    {
        userName = string.IsNullOrWhiteSpace(name) ? "User" : name;
    }
    public void StartChat()
    {
        Console.WriteLine($"\nHello {userName}! Ask me anything cybersecurity.\n");
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("> ");
            Console.ResetColor();
            string input = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Enter something.");
                continue;
            }
            if (input.Contains("exit"))
            {
                Console.WriteLine("Goodbye! Stay safe");
                break;
            }
            Respond(input);

        }
    }
    private void Respond(string input)
    {
        if (input.Contains("How are you?"))
        {
            Console.WriteLine("I'm just a bot, but I'm here to help you stay safe online.");
        }
        else if (input.Contains("What is your purpose?"))
        {
            Console.WriteLine("My aim is to educate you about cybersecurity.");
        }
        else if (input.Contains("password"))
        {
            Console.WriteLine("Use strong passwords and don't share them");
        }
        else if (input.Contains("What is phishing?"))
        {
            Console.WriteLine("Be careful of emails asking for personal info");
        }
        else if (input.Contains("How can I stay safe online while browsing?"))
        {
            Console.WriteLine("Avoid clicking unknown links");
        }
        else
        {
            Console.WriteLine("I didn't understand.");
        }
    }
}