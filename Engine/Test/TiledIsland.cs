using System;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using AnchorMapLib;
using System.Web.Script.Serialization;

namespace Test
 {
 	public class TiledIsland : Anchor
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

		 private Anchor RefToFoucs;

		 public TiledIsland(string Name, Anchor focus)
		 {
			 this.Name = Name;
			 RefToFoucs = focus;
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
						 if (Vector2.Distance(RefToFoucs.Location, pos) <= 2500)
							 SYSTEM.SpriteBatch.Draw(SandTile.Texture, pos, Color.White);
						 break;
					 case 1:
						 pos = new Vector2(position.X * WetSandTile.Texture.Width, position.Y * WetSandTile.Texture.Height);
						 if (Vector2.Distance(RefToFoucs.Location, pos) <= 2500)
							 SYSTEM.SpriteBatch.Draw(WetSandTile.Texture, pos, Color.White);
						 break;
					 case 2:
						 pos = new Vector2(position.X * WaterTile.Texture.Width, position.Y * WaterTile.Texture.Height);
						 if(Vector2.Distance(RefToFoucs.Location, pos) <= 2500)
						 	SYSTEM.SpriteBatch.Draw(WaterTile.Texture, pos, Color.White);
						 break;
					 case 3:
						 pos = new Vector2(position.X * DeepWaterTile.Texture.Width, position.Y * DeepWaterTile.Texture.Height);
						 if(Vector2.Distance( RefToFoucs.Location, pos) <= 2500)
						 	SYSTEM.SpriteBatch.Draw(DeepWaterTile.Texture, pos, Color.White);
						 break;
					 case 4:
						 pos = new Vector2(position.X * GrassTile.Texture.Width,
							 position.Y * GrassTile.Texture.Height);
						 if(Vector2.Distance(RefToFoucs.Location, pos) <= 2500)
							 SYSTEM.SpriteBatch.Draw(GrassTile.Texture, pos, Color.White);
						 break;
					 default:
						 pos = new Vector2(position.X * ErrorTile.Texture.Width, position.Y * ErrorTile.Texture.Height);
						 if(Vector2.Distance(RefToFoucs.Location, pos) <= 2500)
							 SYSTEM.SpriteBatch.Draw(ErrorTile.Texture, pos, Color.White);
						 break;
				 }
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
			 WaterTile.fileLocation = "ShallowWater";
			 ErrorTile = new AncSprite(this);
			 ErrorTile.fileLocation = "Error";
			 WetSandTile = new AncSprite(this);
			 WetSandTile.fileLocation = "WetSand";
			 DeepWaterTile = new AncSprite(this);
			 DeepWaterTile.fileLocation = "DeepWater";

			 jsonFileLocation = "island.json";
		 }
	 }
 }