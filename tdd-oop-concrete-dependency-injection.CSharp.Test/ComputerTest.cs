using tdd_oop_concrete_dependency_injection.CSharp.Main;
using NUnit.Framework;

namespace tdd_oop_concrete_dependency_injection.CSharp.Test
{
    class ComputerTest
    {
        [Test]
        public void shouldTurnOn()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            Computer myPc = new Computer(myPsu, preInstalled);
            myPc.turnOn();

            Assert.That(myPsu.isOn);
        }

        [Test]
        public void shouldInstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            Computer myPc = new Computer(myPsu, preInstalled);
            Game finalFantasy = new Game("Final Fantasy XI");

            myPc.installGame(finalFantasy);

            Assert.That(1, Is.EqualTo(myPc.installedGames.Count()));
            Assert.That("Final Fantasy XI", Is.EqualTo(myPc.installedGames[0].name));
        }

        [Test]
        public void shouldPlayGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            Computer myPc = new Computer(myPsu, preInstalled);
            Game duckGame = new Game("Duck Game");
            Game dragonDogma = new Game("Dragon's Dogma: Dark Arisen");
            Game morrowind = new Game("Morrowind");

            myPc.installGame(duckGame);
            myPc.installGame(dragonDogma);

            Assert.That("Playing Duck Game", Is.EqualTo(myPc.playGame(duckGame)));
            Assert.That("Playing Dragon's Dogma: Dark Arisen", Is.EqualTo(myPc.playGame(dragonDogma)));
            Assert.That("Game not installed", Is.EqualTo(myPc.playGame(morrowind)));
        }
        
        [Test]
        public void canPreinstallGames()
        {
            PowerSupply myPsu = new PowerSupply();
            List<Game> preInstalled = new List<Game>();
            Game dwarfFortress = new Game("Dwarf Fortress");
            Game baldurGate = new Game("Baldur's Gate");

            preInstalled.Add(dwarfFortress);
            preInstalled.Add(baldurGate);

            Computer myPc = new Computer(myPsu, preInstalled);

            Assert.That(2, Is.EqualTo(myPc.installedGames.Count));
            Assert.That("Dwarf Fortress", Is.EqualTo(myPc.installedGames[0].name));
            Assert.That("Baldur's Gate", Is.EqualTo(myPc.installedGames[1].name));
        }
    }
}