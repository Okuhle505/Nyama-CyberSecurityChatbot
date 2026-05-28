using System;
using System.Media;
public static class UIHelper
{
    public static void DisplayHeader()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== CYBERSECURITY BOT ===");

        Console.WriteLine("Stay Safe Online");
        Console.ResetColor();
    }
    public static void PlayVoiceGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("greeting.wav");
            player.Play();
        }
        catch {
            Console.WriteLine("Voice greeting not found");
        }
    }
}