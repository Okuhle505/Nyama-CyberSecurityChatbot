using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CyberSecurityChatbot.GUI
{
    public partial class Form1 : Form
    {
        ChatbotEngine bot = new ChatbotEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chatBox.AppendText(" Welcome to the Cybersecurity Awareness Bot!\n");
            chatBox.AppendText("Ask me about passwords, phishing, scams, or privacy.\n\n");

            try
            {
                SoundPlayer player = new SoundPlayer("greetings.wav");
                player.Play();
            }
            catch
            {
                chatBox.AppendText("Voice greeting could not be loaded.\n");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string userInput = InputBox.Text;

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            chatBox.AppendText("YOU: " + userInput + "\n");

            string response = bot.GetResponse(userInput);

            chatBox.AppendText("BOT: " + response + "\n\n");

            InputBox.Clear();
        }
    }
}