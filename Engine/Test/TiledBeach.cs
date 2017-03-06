using System.IO;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TidalLibrary;
using System.Web.Script.Serialization;

namespace Test
{
	public class TiledBeach : Anchor
	{
		private AncSprite _grassTile;
		private AncSprite _sandTile;
		private AncSprite _waterTile;
		private AncSprite _errorTile;
		private AncSprite _wetSandTile;
		private AncSprite _deepWaterTile;

		private string _jsonFileLocation;
		private string _inputJson;
		private MapData _inputMap;
	    private Vector2 _pos;


		public TiledBeach(string name)
		{
			Name = name;
		}

		public override void LoadContent()
		{
			_grassTile.Texture = SystemRef.Content.Load<Texture2D>(_grassTile.FileLocation);
			_sandTile.Texture = SystemRef.Content.Load<Texture2D>(_sandTile.FileLocation);
			_waterTile.Texture = SystemRef.Content.Load<Texture2D>(_waterTile.FileLocation);
			_errorTile.Texture = SystemRef.Content.Load<Texture2D>(_errorTile.FileLocation);
			_wetSandTile.Texture = SystemRef.Content.Load<Texture2D>(_wetSandTile.FileLocation);
			_deepWaterTile.Texture = SystemRef.Content.Load<Texture2D>(_deepWaterTile.FileLocation);

			if(File.Exists(_jsonFileLocation))
				_inputJson = File.ReadAllText(_jsonFileLocation);

			var ser = new JavaScriptSerializer();
		 	_inputMap = ser.Deserialize<MapData>(_inputJson);

		}

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(GameTime gameTime)
		{

			foreach (var position in _inputMap.Data)
			{
				switch (position.Id)
				{
					case 0:
						_pos = new Vector2(position.X * _sandTile.Texture.Width, position.Y * _sandTile.Texture.Height);
						SystemRef.SpriteBatch.Draw(_sandTile.Texture, _pos, Microsoft.Xna.Framework.Color.White);
						break;
					case 1:
						_pos = new Vector2(position.X * _wetSandTile.Texture.Width, position.Y * _wetSandTile.Texture.Height);
						SystemRef.SpriteBatch.Draw(_wetSandTile.Texture, _pos, Microsoft.Xna.Framework.Color.White);
						break;
					case 2:
						_pos = new Vector2(position.X * _waterTile.Texture.Width, position.Y * _waterTile.Texture.Height);
						SystemRef.SpriteBatch.Draw(_waterTile.Texture, _pos, Microsoft.Xna.Framework.Color.White);
						break;
					case 3:
						_pos = new Vector2(position.X * _deepWaterTile.Texture.Width, position.Y * _deepWaterTile.Texture.Height);
						SystemRef.SpriteBatch.Draw(_deepWaterTile.Texture, _pos, Microsoft.Xna.Framework.Color.White);
						break;
					case 4:
						_pos = new Vector2(position.X * _grassTile.Texture.Width,
							position.Y *  _grassTile.Texture.Height);
						SystemRef.SpriteBatch.Draw(_grassTile.Texture, _pos, Microsoft.Xna.Framework.Color.White);
						break;
					default:
						_pos = new Vector2(position.X * _errorTile.Texture.Width, position.Y * _errorTile.Texture.Height);
						SystemRef.SpriteBatch.Draw(_errorTile.Texture, _pos, Microsoft.Xna.Framework.Color.White);
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
			SystemRef = sys;
			Parent = scene;

		    _grassTile = new AncSprite(this) {FileLocation = "Grass"};
		    _sandTile = new AncSprite(this) {FileLocation = "Sand"};
		    _waterTile = new AncSprite(this) {FileLocation = "Water"};
		    _errorTile = new AncSprite(this) {FileLocation = "Error"};
		    _wetSandTile = new AncSprite(this) {FileLocation = "WetSand"};
		    _deepWaterTile = new AncSprite(this) {FileLocation = "DeepWater"};

		    _jsonFileLocation = "Output.json";

		}
	}
}