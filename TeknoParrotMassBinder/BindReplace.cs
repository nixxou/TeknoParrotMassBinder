using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

	

	internal class BindReplace
	{

		public Dictionary<string, Game> ListGames { get; private set; }
		public Game SelectedGame { get; private set; }


		public BindReplace(string sourceDir) 
		{
			SelectedGame= null;
			if(!Directory.Exists(sourceDir)) throw new DirectoryNotFoundException();


			ListGames = new Dictionary<string, Game>();
			var fichiers = Directory.GetFiles(sourceDir,"*.xml");
			foreach(var f in fichiers)
			{
				Game game = new Game(f);
				ListGames.Add(game.Name, game);
			}
		}

		public void SelectGame(string gameName)
		{
			if (!ListGames.ContainsKey(gameName)) throw new Exception("Game not found");
			SelectedGame = ListGames[gameName];
		}
		
		public void SelectButton(string buttonName)
		{
			if (SelectedGame == null) throw new Exception("No Game Selected");
			if (!SelectedGame.HasButton(buttonName)) throw new Exception("Button not found on Selected game");

			//var SelectedBtn = SelectedGame[buttonName].
		}
	}
}
