using System;
using System.IO;
using AnchorMapLib;

namespace FileTest
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var file = File.ReadAllText("Text.txt");
			Console.WriteLine(file);

			//var ser = new PaletteSerializer();

			//var pal = ser.FileDeserialize("Deserialiation.palette");

			//var fin = ser.Serialize(pal);

			//File.WriteAllText("Output.txt", fin);



			//Console.WriteLine(pal.PaletteName);

			Console.ReadKey();

		}
	}
}