using System;

namespace Design_Patterns.Structural_Patterns.Facade.Concrete
{
    public class Tester
    {
        public void Test()
        {
            Steam steam = new Steam(new GameLoader(), new GameInstaller(), new GameUpdater(), new GameLauncher());
            steam.Play();
        }
    }

    public class GameLoader
    {
        public void LoadGame() => Console.WriteLine("Game Loaded");
        public void LoadAdditionalSoftware() => Console.WriteLine("Additional Software Loaded");
    }
    public class GameInstaller
    {
        public void InstallGame() => Console.WriteLine("Game Installed");
        public void InstallAdditionalSoftware() => Console.WriteLine("Additional Software Installed");
    }
    public class GameUpdater
    {
        public void UpdateGame() => Console.WriteLine("Game Updated");
        public void UpdateAdditionalSoftware() => Console.WriteLine("Additional Software Updated");
    }
    public class GameLauncher
    {
        public void LaunchGame() => Console.WriteLine("Game Launched");
    }
    public class Steam
    {
        public Steam(GameLoader gameLoader, GameInstaller gameInstaller, GameUpdater gameUpdater, GameLauncher gameLauncher)
        {
            this.gameLoader = gameLoader;
            this.gameInstaller = gameInstaller;
            this.gameUpdater = gameUpdater;
            this.gameLauncher = gameLauncher;
        }

        private GameLoader gameLoader;
        private GameInstaller gameInstaller;
        private GameUpdater gameUpdater;
        private GameLauncher gameLauncher;

        public void Play()
        {
            gameLoader.LoadGame();
            gameLoader.LoadAdditionalSoftware();
            gameInstaller.InstallGame();
            gameInstaller.InstallAdditionalSoftware();
            gameUpdater.UpdateGame();
            gameUpdater.UpdateAdditionalSoftware();
            gameLauncher.LaunchGame();
        }
    }
}