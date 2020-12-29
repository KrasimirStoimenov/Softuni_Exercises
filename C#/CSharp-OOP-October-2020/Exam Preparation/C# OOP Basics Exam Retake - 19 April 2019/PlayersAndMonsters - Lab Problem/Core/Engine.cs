using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;
        private IReader reader;
        private IWriter writer;

        public Engine()
        {
            this.managerController = new ManagerController();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                string action = input[0];
                if (action == "Exit")
                {
                    Environment.Exit(0);
                }
                string output = string.Empty;
                try
                {
                    switch (action)
                    {
                        case "AddPlayer":
                            string playerType = input[1];
                            string username = input[2];
                            output = this.managerController.AddPlayer(playerType, username);
                            break;
                        case "AddCard":
                            string cardType = input[1];
                            string name = input[2];
                            output = this.managerController.AddCard(cardType, name);
                            break;
                        case "AddPlayerCard":
                            string playerName = input[1];
                            string cardName = input[2];
                            output = this.managerController.AddPlayerCard(playerName, cardName);
                            break;
                        case "Fight":
                            string attacker = input[1];
                            string defender = input[2];
                            output = this.managerController.Fight(attacker, defender);
                            break;
                        case "Report":
                            output = this.managerController.Report();
                            break;

                    }
                    writer.WriteLine(output);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }
        }
    }
}


