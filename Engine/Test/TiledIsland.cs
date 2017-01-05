using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using AnchorMapLib;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
	public class TiledIsland : Anchor
	{
		//Map chunks
		private readonly List<string> ChunkList = new List<string>();

		private MapData CurrentMap;

		private readonly List<List<TileInfo>> Tiles = new List<List<TileInfo>>();

		private readonly List<TileInfo> DeepWater = new List<TileInfo>();
		private readonly List<TileInfo> ShallowWater = new List<TileInfo>();
		private readonly List<TileInfo> WetSand = new List<TileInfo>();
		private readonly List<TileInfo> DrySand = new List<TileInfo>();
		private readonly List<TileInfo> Grass = new List<TileInfo>();

		//Tiles
		private AncSprite DeepwaterTile;
		private AncSprite ShallowWaterTile;
		private AncSprite WetSandTile;
		private AncSprite DrySandTile;
		private AncSprite LongGrass;
		private AncSprite ShortGrass;

		private AncSprite ErrorTile;

		//Reference
		private Anchor RefToFoucs;

		public TiledIsland(string Name, Anchor focus)
		{
			this.Name = Name;
			RefToFoucs = focus;
		}

		public override void LoadContent()
		{
			var ser = new JavaScriptSerializer();

			foreach (var chunk in ChunkList)
			{
				CurrentMap = ser.Deserialize<MapData>(chunk);

				foreach (var position in CurrentMap.Data)
					switch (position.ID)
					{
						case 0:
							DrySand.Add(position);
							break;
						case 1:
							WetSand.Add(position);
							break;
						case 2:
							ShallowWater.Add(position);
							break;
						case 3:
							DeepWater.Add(position);
							break;
						case 4:
							Grass.Add(position);
							break;
					}
			}

			DeepwaterTile.Texture = SYSTEM.Content.Load<Texture2D>(DeepwaterTile.fileLocation);
			ShallowWaterTile.Texture = SYSTEM.Content.Load<Texture2D>(ShallowWaterTile.fileLocation);
			WetSandTile.Texture = SYSTEM.Content.Load<Texture2D>(WetSandTile.fileLocation);
			DrySandTile.Texture = SYSTEM.Content.Load<Texture2D>(DrySandTile.fileLocation);
			LongGrass.Texture = SYSTEM.Content.Load<Texture2D>(LongGrass.fileLocation);
			ShortGrass.Texture = SYSTEM.Content.Load<Texture2D>(ShortGrass.fileLocation);
			ErrorTile.Texture = SYSTEM.Content.Load<Texture2D>(ErrorTile.fileLocation);

			var GrassPool = new VariantPool();
			GrassPool.Add(LongGrass, ShortGrass);

			foreach (var grass in Grass)
			{
				var rnd = new Random();
				if (rnd.Next(0, 1000) <= 499)
					grass.ID = 40;
				else
					grass.ID = 41;
			}

			Tiles.Add(DrySand);
			Tiles.Add(DeepWater);
			Tiles.Add(ShallowWater);
			Tiles.Add(WetSand);
			Tiles.Add(Grass);
		}

		public override void Update(GameTime gameTime)
		{
		}

		public override void Draw(GameTime gameTime)
		{
			var tile = DeepwaterTile;

			foreach (var Tile in Tiles)
			foreach (var position in Tile)
				switch (position.ID)
				{
					case 0:
						tile = DrySandTile;
						SYSTEM.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Color.White);
						break;
					case 1:
						tile = WetSandTile;
						SYSTEM.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Color.White);
						break;
					case 2:
						tile = ShallowWaterTile;
						SYSTEM.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Color.White);
						break;
					case 3:
						tile = DeepwaterTile;
						SYSTEM.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Color.White);
						break;
					case 40:
						tile = ShortGrass;
						SYSTEM.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Color.White);
						break;
					case 41:
						tile = LongGrass;
						SYSTEM.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Color.White);
						break;
					default:
						SYSTEM.SpriteBatch.Draw(ErrorTile.Texture,
							new Vector2(position.X * ErrorTile.Texture.Width, position.Y * ErrorTile.Texture.Height), Color.White);
						break;
				}


			/*
				STORE IN A CUSTOM CHUNK CLASS WITH X/Y MULTIPLIERS FOR POSITIONING
			*/
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SYSTEM = sys;
			Parent = scene;

			ChunkList.Add(File.ReadAllText("TL.json"));
			ChunkList.Add(File.ReadAllText("TR.json"));
			ChunkList.Add(File.ReadAllText("BL.json"));
			ChunkList.Add(File.ReadAllText("BR.json"));


			DrySandTile = new AncSprite(this);
			DrySandTile.fileLocation = "Sand";

			WetSandTile = new AncSprite(this);
			WetSandTile.fileLocation = "WetSand";

			DeepwaterTile = new AncSprite(this);
			DeepwaterTile.fileLocation = "DeepWater";

			ShallowWaterTile = new AncSprite(this);
			ShallowWaterTile.fileLocation = "ShallowWater";

			ShortGrass = new AncSprite(this);
			ShortGrass.fileLocation = "ShortGrass";

			LongGrass = new AncSprite(this);
			LongGrass.fileLocation = "LongGrass";

			ErrorTile = new AncSprite(this);
			ErrorTile.fileLocation = "Error";
		}
	}
}