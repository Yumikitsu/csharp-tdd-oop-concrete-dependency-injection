using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames = new List<Game>();
        
        public PowerSupply powerSupply;

        public Computer(PowerSupply powerSupply) {
            this.powerSupply = powerSupply;
        }

        public Computer(PowerSupply powerSupply, List<Game> preinstalled)
        {
            this.powerSupply = powerSupply;
            this.installedGames = preinstalled;
        }

        public void turnOn() {
            powerSupply.turnOn();
        }

        public void installGame(string name) {
            this.installedGames.Add(new Game(name));
        }

        public String playGame(string name) {
            foreach (Game game in installedGames)
            {
                if(game.name == name)
                {
                    return game.start();
                }
            }

            return "Game not installed";
        }
    }
}
