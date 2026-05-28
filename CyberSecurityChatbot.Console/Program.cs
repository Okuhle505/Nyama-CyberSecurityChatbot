using System;
class Program
{
    static void Main()
    {
        UIHelper.DisplayHeader();
        UIHelper.PlayVoiceGreeting();
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();
        Chatbot bot = new Chatbot(name);
        bot.StartChat();
    }
}