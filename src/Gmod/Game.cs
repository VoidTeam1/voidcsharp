
using System;

namespace VoidSharp
{

	public static class Game
	{
		/// <summary>
		/// Returns the name of the current map, without a file extension. On the menu state, returns "menu".
		/// </summary>
		public static string GetMap()
		{
			return Globals.Game.GetMap();
		}
	}
}