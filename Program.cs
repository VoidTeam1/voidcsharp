using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using System.Numerics;


namespace Test {

	interface IDamageable {
		void TakeDamage(int damage);
	}

	class Program {

		private static Timer timer;

		public static void Main(string[] args) {
			Console.WriteLine("Loaded!");

			Object[] hookArgs = {"Shit1", 42, "Shit3"};
			Hook.Call("Bullshit", hookArgs);

			Hook.Add("Bullshit", "CSharp.Bullshit", (dynamic[] arguments) => {
				
			});
			// Hook.Add("Think", "CSharp.Think")
		}
		public static void CheckPlayers() {
			Console.WriteLine("Checking players...");
			Player[] players = PlayerManager.GetAll();
			foreach (Player ply in players) {
				Console.WriteLine(ply.Nick());
			}
		}
	}
}