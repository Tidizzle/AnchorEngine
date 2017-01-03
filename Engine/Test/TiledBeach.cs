 using System;
using System.IO;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AnchorMapLib;
using System.Web.Script.Serialization;

namespace Test
{
	public class TiledBeach : Anchor
	{
		private AncSprite GrassTile;
		private AncSprite SandTile;
		private AncSprite WaterTile;
		private AncSprite ErrorTile;
		private AncSprite WetSandTile;
		private AncSprite DeepWaterTile;

		private string jsonFileLocation;
		private string inputJSON;
		private MapData inputMap;
		private Vector2 pos;

		//private


		public TiledBeach(string name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			GrassTile.Texture = SYSTEM.Content.Load<Texture2D>(GrassTile.fileLocation);
			SandTile.Texture = SYSTEM.Content.Load<Texture2D>(SandTile.fileLocation);
			WaterTile.Texture = SYSTEM.Content.Load<Texture2D>(WaterTile.fileLocation);
			ErrorTile.Texture = SYSTEM.Content.Load<Texture2D>(ErrorTile.fileLocation);
			WetSandTile.Texture = SYSTEM.Content.Load<Texture2D>(WetSandTile.fileLocation);
			DeepWaterTile.Texture = SYSTEM.Content.Load<Texture2D>(DeepWaterTile.fileLocation);

			if(File.Exists(jsonFileLocation))
				inputJSON = File.ReadAllText(jsonFileLocation);

			JavaScriptSerializer ser = new JavaScriptSerializer();
		 	inputMap = ser.Deserialize<MapData>(inputJSON);

		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{

			foreach (var position in inputMap.Data)
			{
				switch (position.ID)
				{
					case 0:
						pos = new Vector2(position.X * SandTile.Texture.Width, position.Y * SandTile.Texture.Height);
						SYSTEM.SpriteBatch.Draw(SandTile.Texture, pos, Color.White);
						break;
					case 1:
						pos = new Vector2(position.X * WetSandTile.Texture.Width, position.Y * WetSandTile.Texture.Height);
						SYSTEM.SpriteBatch.Draw(WetSandTile.Texture, pos, Color.White);
						break;
					case 2:
						pos = new Vector2(position.X * WaterTile.Texture.Width, position.Y * WaterTile.Texture.Height);
						SYSTEM.SpriteBatch.Draw(WaterTile.Texture, pos, Color.White);
						break;
					case 3:
						pos = new Vector2(position.X * DeepWaterTile.Texture.Width, position.Y * DeepWaterTile.Texture.Height);
						SYSTEM.SpriteBatch.Draw(DeepWaterTile.Texture, pos, Color.White);
						break;
					case 4:
						pos = new Vector2(position.X * GrassTile.Texture.Width,
							position.Y *  GrassTile.Texture.Height);
						SYSTEM.SpriteBatch.Draw(GrassTile.Texture, pos, Color.White);
						break;
					default:
						pos = new Vector2(position.X * ErrorTile.Texture.Width, position.Y * ErrorTile.Texture.Height);
						SYSTEM.SpriteBatch.Draw(ErrorTile.Texture, pos, Color.White);
						break;
				}

				// 0 = sand
				// 1 = wetsand
				// 2 = shallow water
				// 3 = deep water
				// 4 = grass
			}
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SYSTEM = sys;
			Parent = scene;

			GrassTile = new AncSprite(this);
			GrassTile.fileLocation = "Grass";
			SandTile = new AncSprite(this);
			SandTile.fileLocation = "Sand";
			WaterTile = new AncSprite(this);
			WaterTile.fileLocation = "Water";
			ErrorTile = new AncSprite(this);
			ErrorTile.fileLocation = "Error";
			WetSandTile = new AncSprite(this);
			WetSandTile.fileLocation = "WetSand";
			DeepWaterTile = new AncSprite(this);
			DeepWaterTile.fileLocation = "DeepWater";

			jsonFileLocation = "Output.json";

		}
	}
}