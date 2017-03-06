using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using TidalLibrary;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test
{
	public class TiledIsland : Anchor
	{
		//Map chunks
		private readonly List<string> _chunkList = new List<string>();

		private MapData _currentMap;

		private readonly List<List<TileInfo>> _tiles = new List<List<TileInfo>>();

		private readonly List<TileInfo> _deepWater = new List<TileInfo>();
		private readonly List<TileInfo> _shallowWater = new List<TileInfo>();
		private readonly List<TileInfo> _wetSand = new List<TileInfo>();
		private readonly List<TileInfo> _drySand = new List<TileInfo>();
		private readonly List<TileInfo> _grass = new List<TileInfo>();

		//Tiles
		private AncSprite _deepwaterTile;
		private AncSprite _shallowWaterTile;
		private AncSprite _wetSandTile;
		private AncSprite _drySandTile;
		private AncSprite _longGrass;
		private AncSprite _shortGrass;

		private AncSprite _errorTile;

		//Reference

	    public TiledIsland(string name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			var ser = new JavaScriptSerializer();

			foreach (var chunk in _chunkList)
			{
				_currentMap = ser.Deserialize<MapData>(chunk);

				foreach (var position in _currentMap.Data)
					switch (position.Id)
					{
						case 0:
							_drySand.Add(position);
							break;
						case 1:
							_wetSand.Add(position);
							break;
						case 2:
							_shallowWater.Add(position);
							break;
						case 3:
							_deepWater.Add(position);
							break;
						case 4:
							_grass.Add(position);
							break;
					}
			}

			_deepwaterTile.Texture = SystemRef.Content.Load<Texture2D>(_deepwaterTile.FileLocation);
			_shallowWaterTile.Texture = SystemRef.Content.Load<Texture2D>(_shallowWaterTile.FileLocation);
			_wetSandTile.Texture = SystemRef.Content.Load<Texture2D>(_wetSandTile.FileLocation);
			_drySandTile.Texture = SystemRef.Content.Load<Texture2D>(_drySandTile.FileLocation);
			_longGrass.Texture = SystemRef.Content.Load<Texture2D>(_longGrass.FileLocation);
			_shortGrass.Texture = SystemRef.Content.Load<Texture2D>(_shortGrass.FileLocation);
			_errorTile.Texture = SystemRef.Content.Load<Texture2D>(_errorTile.FileLocation);

			var grassPool = new VariantPool();
			grassPool.Add(_longGrass, _shortGrass);

			foreach (var grass in _grass)
			{
			    var rnd = new Random();
			    grass.Id = rnd.Next(0, 1000) <= 499 ? 40 : 41;
			}

			_tiles.Add(_drySand);
			_tiles.Add(_deepWater);
			_tiles.Add(_shallowWater);
			_tiles.Add(_wetSand);
			_tiles.Add(_grass);
		}

		public override void Update(GameTime gameTime)
		{
		}

		public override void Draw(GameTime gameTime)
		{
			AncSprite tile;

			foreach (var Tile in _tiles)
			foreach (var position in Tile)
				switch (position.Id)
				{
					case 0:
						tile = _drySandTile;
						SystemRef.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Microsoft.Xna.Framework.Color.White);
						break;
					case 1:
						tile = _wetSandTile;
						SystemRef.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Microsoft.Xna.Framework.Color.White);
						break;
					case 2:
						tile = _shallowWaterTile;
						SystemRef.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height),Microsoft.Xna.Framework.Color.White);
						break;
					case 3:
						tile = _deepwaterTile;
						SystemRef.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Microsoft.Xna.Framework.Color.White);
						break;
					case 40:
						tile = _shortGrass;
						SystemRef.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Microsoft.Xna.Framework.Color.White);
						break;
					case 41:
						tile = _longGrass;
						SystemRef.SpriteBatch.Draw(tile.Texture,
							new Vector2(position.X * tile.Texture.Width, position.Y * tile.Texture.Height), Microsoft.Xna.Framework.Color.White);
						break;
					default:
						SystemRef.SpriteBatch.Draw(_errorTile.Texture,
							new Vector2(position.X * _errorTile.Texture.Width, position.Y * _errorTile.Texture.Height), Microsoft.Xna.Framework.Color.White);
						break;
				}


			/*
				STORE IN A CUSTOM CHUNK CLASS WITH X/Y MULTIPLIERS FOR POSITIONING
			*/
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SystemRef = sys;
			Parent = scene;

			_chunkList.Add(File.ReadAllText("TL.json"));
			_chunkList.Add(File.ReadAllText("TR.json"));
			_chunkList.Add(File.ReadAllText("BL.json"));
			_chunkList.Add(File.ReadAllText("BR.json"));


		    _drySandTile = new AncSprite(this) {FileLocation = "Sand"};

		    _wetSandTile = new AncSprite(this) {FileLocation = "WetSand"};

		    _deepwaterTile = new AncSprite(this) {FileLocation = "DeepWater"};

		    _shallowWaterTile = new AncSprite(this) {FileLocation = "ShallowWater"};

		    _shortGrass = new AncSprite(this) {FileLocation = "ShortGrass"};

		    _longGrass = new AncSprite(this) {FileLocation = "LongGrass"};

		    _errorTile = new AncSprite(this) {FileLocation = "Error"};
		}
	}
}