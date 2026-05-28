using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatbot.GUI
{
    public class ChatbotEngine
    {
        private Dictionary<string, List<string>> responses;
        private Random random = new Random();

        private string lastTopic = "";
        private string favouriteTopic = "";
        private string userName = "";

        public ChatbotEngine()
        {
            responses = new Dictionary<string, List<string>>()
            {
                {
                    "password",
                    new List<string>()
                    {
                        "Use strong and unique passwords for every account.",
                        "Avoid using your name or birthdate in passwords.",
                        "Use a password manager to keep passwords safe."
                    }
                },

                {
                    "phishing",
                    new List<string>()
                    {
                        "Never click suspicious email links.",
                        "Scammers often pretend to be banks or trusted companies.",
                        "Always verify emails before entering personal information."
                    }
                },

                {
                    "privacy",
                    new List<string>()
                    {
                        "Review your social media privacy settings regularly.",
                        "Avoid sharing sensitive information online.",
                        "Use two-factor authentication for better account security."
                    }
                },

                {
                    "scam",
                    new List<string>()
                    {
                        "Be careful of offers that seem too good to be true.",
                        "Never send money to unknown people online.",
                        "Online scammers often create urgency to pressure victims."
                    }
                }
            };
        }

        public string GetResponse(string input)
        {
            input = input.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please enter a message.";
            }

            // Store user name
            if (input.StartsWith("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();
                return $"Nice to meet you, {userName}!";
            }

            // Memory feature
            if (input.Contains("i'm interested in"))
            {
                string[] words = input.Split(' ');

                favouriteTopic = words[words.Length - 1];

                return $"Great! I'll remember that you're interested in {favouriteTopic}.";
            }

            // Sentiment detection
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried about cybersecurity. Remember to stay cautious online and avoid suspicious links.";
            }

            if (input.Contains("frustrated"))
            {
                return "Cybersecurity can feel overwhelming sometimes, but learning small safety habits helps a lot.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is great! Learning about cybersecurity helps protect your digital life.";
            }

            // Conversation flow
            if (input.Contains("tell me more") || input.Contains("another tip") || input.Contains("explain more"))
            {
                if (lastTopic != "")
                {
                    return GetRandomResponse(lastTopic);
                }

                return "Can you tell me which topic you want to learn more about?";
            }

            // Keyword recognition
            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastTopic = keyword;

                    return GetRandomResponse(keyword);
                }
            }

            // Personalised response
            if (favouriteTopic != "")
            {
                return $"As someone interested in {favouriteTopic}, remember to stay alert online and protect your accounts.";
            }

            return "I'm not sure I understand. Can you try rephrasing?";
        }

        private string GetRandomResponse(string topic)
        {
            List<string> topicResponses = responses[topic];

            int index = random.Next(topicResponses.Count);

            return topicResponses[index];
        }
    }
}
