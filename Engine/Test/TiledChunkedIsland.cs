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
	public class TiledChunkedIsland : Anchor
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
		private readonly Anchor _refToFoucs;

		public TiledChunkedIsland(string name, Anchor focus)
		{
			Name = name;
			_refToFoucs = focus;
		}

		public override void LoadContent()
		{
			var ser = new JavaScriptSerializer();
		    foreach (var json in _chunkList)
		    {
		        _currentMap = ser.Deserialize<MapData>(json);

		        foreach (var position in _currentMap.Data)
		        {
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

		        int last = 0;
		        var rnd = new Random();
		        int interval = 0;

		        foreach (var grass in _grass)
		        {
		            if (last != 0)
		            {
		                int odds = rnd.Next(1, 1000);
		                if (odds <= 550)
		                {
		                    grass.Id = last;
		                }
		                else
		                {
		                    switch (last)
		                    {
		                        case 40:
		                            grass.Id = 41;
		                            break;
		                        case 41:
		                            grass.Id = 40;
		                            break;
		                    }
		                }
		                var chance = rnd.Next(0, interval * 2) + rnd.Next(0, interval * 2);
		                if (interval >= chance - 20 && interval <= chance + 20)
		                {
		                    switch (last)
		                    {
		                        case 40:
		                            grass.Id = 41;
		                            break;
		                        case 41:
		                            grass.Id = 40;
		                            break;
		                    }
		                }
		                last = grass.Id;
		            }
		            else
		            {
		                grass.Id = 41;
		                last = 41;
		            }

		            interval += rnd.Next(20, 40);
		        }
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
		    var tile = _errorTile;

			foreach (var tileList in _tiles)
			{
				foreach (var position in tileList)
				{
					switch (position.Id)
					{
						case 0:
							tile = _drySandTile;
							break;
						case 1:
							tile = _wetSandTile;
							break;
						case 2:
							tile = _shallowWaterTile;
							break;
						case 3:
							tile = _deepwaterTile;
							break;
						case 40:
							tile = _longGrass;
							break;
						case 41:
							tile = _shortGrass;
							break;
						case 999:
							tile = _errorTile;
							break;

					}


					var x = position.X * tile.Texture.Width + (position.Xmodifier / 16) * tile.Texture.Width;
					var y = position.Y * tile.Texture.Height + (position.Ymodifier / 16) * tile.Texture.Height;

					if(Vector2.Distance(new Vector2(x,y), _refToFoucs.Location) <= 3000)
						SystemRef.SpriteBatch.Draw(tile.Texture, new Vector2(x,y), Microsoft.Xna.Framework.Color.White);



				}
			}
		}

		public override void Instantiate(AncSystem sys, AncScene scene)
		{
			SystemRef = sys;
			Parent = scene;

			//ChunkList.Add(File.ReadAllText("TL.json"));
			_chunkList.Add(File.ReadAllText("TR.json"));
			_chunkList.Add(File.ReadAllText("BL.json"));
			_chunkList.Add(File.ReadAllText("BR.json"));
			//ChunkList.Add(File.ReadAllText("TL16.json"));


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