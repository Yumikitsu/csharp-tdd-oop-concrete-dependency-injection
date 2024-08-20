using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_concrete_dependency_injection.CSharp.Main
{
    public class Computer 
    {
        public List<Game> installedGames;
        
        private PowerSupply _powerSupply;

        public Computer(PowerSupply powerSupply, List<Game> installedGames) {
            this._powerSupply = powerSupply;
            this.installedGames = installedGames;
        }

        public void turnOn() {
            _powerSupply.turnOn();
        }

        public void installGame(Game newGame) {
            this.installedGames.Add(newGame);
        }

        public String playGame(Game game) {
            if (installedGames.Contains(game))
            {
                return game.start();
            }

            return "Game not installed";
        }
    }
}
