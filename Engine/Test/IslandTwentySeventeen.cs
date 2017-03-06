using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Web.Script.Serialization;
using AnchorMapLib;
using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class IslandTwentySeventeen : Anchor
    {
        private readonly Anchor _refToFocus;
        private readonly Anchor _palm;
        public readonly List<string> Chunklist = new List<string>();

        private AncSprite _deepWaterTile;
        private AncSprite _shallowWaterTile;
        private AncSprite _wetSandTile;
        private AncSprite _drySandTile;
        private AncSprite _longGrass;
        private AncSprite _shortGrass;
        private AncSprite _errorTile;

        private readonly List<TileInfo> _deepWater = new List<TileInfo>();
        private readonly List<TileInfo> _shallowWater = new List<TileInfo>();
        private readonly List<TileInfo> _wetSand = new List<TileInfo>();
        private readonly List<TileInfo> _drySand = new List<TileInfo>();
        private readonly List<TileInfo> _grass = new List<TileInfo>();

        private readonly List<List<TileInfo>> _tiles = new List<List<TileInfo>>();

        private MapData _currentChunk;

        public IslandTwentySeventeen(string name, Anchor focus, Anchor Palm) //REMOVE LATER
        {
            Name = name;
            _refToFocus = focus;
            _palm = Palm;
        }

        private ObjectMap _map;
        private AncSprite _tree;

        public override void LoadContent()
        {
            var ser = new JavaScriptSerializer();

            foreach (var chunk in Chunklist)
            {
                _currentChunk = ser.Deserialize<MapData>(chunk);

                foreach (var tile in _currentChunk.Data)
                {
                    switch (tile.Id)
                    {
                        case 0:
                            _drySand.Add(tile);
                            break;
                        case 1:
                            _wetSand.Add(tile);
                            break;
                        case 2:
                            _shallowWater.Add(tile);
                            break;
                        case 3:
                            _deepWater.Add(tile);
                            break;
                        case 4:
                            _grass.Add(tile);
                            break;
                        default:
                            _grass.Add(tile);
                            break;
                    }
                }
            }

            _deepWaterTile.Texture = SystemRef.Content.Load<Texture2D>(_deepWaterTile.FileLocation);
            _shallowWaterTile.Texture = SystemRef.Content.Load<Texture2D>(_shallowWaterTile.FileLocation);
            _wetSandTile.Texture = SystemRef.Content.Load<Texture2D>(_wetSandTile.FileLocation);
            _drySandTile.Texture = SystemRef.Content.Load<Texture2D>(_drySandTile.FileLocation);
            _longGrass.Texture = SystemRef.Content.Load<Texture2D>(_longGrass.FileLocation);
            _shortGrass.Texture = SystemRef.Content.Load<Texture2D>(_shortGrass.FileLocation);
            _errorTile.Texture = SystemRef.Content.Load<Texture2D>(_errorTile.FileLocation);

            var last = 0;
            var rnd = new Random();
            var interval = 0;

            foreach (var grass in _grass)
            {
                if (last != 0)
                {

                    var odds = rnd.Next(1, 1000);
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

            _tiles.Add(_deepWater);
            _tiles.Add(_shallowWater);
            _tiles.Add(_wetSand);
            _tiles.Add(_drySand);
            _tiles.Add(_grass);

            _tree = new AncSprite(this)
            {
                FileLocation = "palmCondensed",
                Texture = SystemRef.Content.Load<Texture2D>("palmCondensed")
            };

            //_map = ObjectPlacer.RandomPlacer(4, _tree, 5, ser.Deserialize<MapData>(Chunklist[0]));
            _map = ObjectPlacer.RandomPlacer(0, _tree, 5, new Vector2(4f), 64,  ser.Deserialize<MapData>(Chunklist[0]));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var obj in _map.PlacedObjects)
            {

                if (Vector2.Distance(obj.Position, _refToFocus.Location) <= 500)
                {

                    var top = obj.ObjectBounds.Top + 56 * (int) obj.Scale.X;
                    var bottom = obj.ObjectBounds.Bottom;
                    var playerBottom = _refToFocus.Location.Y + (_refToFocus.GlobalHeight * (int) _refToFocus.Scale.Y);


                    if(playerBottom >= top )

                        Console.WriteLine("In range");

                }
            }

            if (AncInput.KeyHeld(Keys.I))
            {
                Console.Clear();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            const int total = 250 * 250 * 2;
            var lastx = -6400;
            var lasty = -6400;

            for (var i = 0; i < total; i++)
            {
                if (lastx >= 16000)
                {
                    lastx = -6400;
                    lasty += 64;
                }
                if (lasty >= 16000)
                    lasty = -6400;

                if(Vector2.Distance(new Vector2(lastx,lasty), _refToFocus.Location) <= 2500)
                    SystemRef.SpriteBatch.Draw(_deepWaterTile.Texture, new Vector2(lastx, lasty), Color.White);

                lastx += 64;
            }


            var tile = _errorTile;

            foreach (var tilelist in _tiles)
            {
                foreach (var position in tilelist)
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
                            tile = _deepWaterTile;
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
                        default:
                            tile = _errorTile;
                            break;
                    }

                    var x = position.X * tile.Texture.Width + (position.Xmodifier / (tile.Texture.Width / 2)) * tile.Texture.Width; //FIND OUT WHERE THE FUCK I GOT 16 AND FIX THAT SHIT
                    var y = position.Y * tile.Texture.Height + (position.Ymodifier / (tile.Texture.Width /2)) * tile.Texture.Height;

                    if(Vector2.Distance(new Vector2(x,y), _refToFocus.Location) <= 2500)
                        SystemRef.SpriteBatch.Draw(tile.Texture, new Vector2(x,y), scale: new Vector2(1f), color: Color.White, layerDepth: 0.001f );

                }
            }

            foreach (var obj in _map.PlacedObjects)
            {
                if(Vector2.Distance(obj.Position, _refToFocus.Location) <= 500)
                    SystemRef.SpriteBatch.Draw(_tree.Texture, obj.Position, null,  null, null, scale: new Vector2(4f), layerDepth:0.003f);
            }

        }

        public override void Instantiate(AncSystem sys, AncScene scene)
        {

            SystemRef = sys;
            Parent = scene;

            Chunklist.Add(File.ReadAllText("TL.json"));
            Chunklist.Add(File.ReadAllText("TR.json"));
            Chunklist.Add(File.ReadAllText("BL.json"));
            Chunklist.Add(File.ReadAllText("BR.json"));

            _drySandTile = new AncSprite(this);
            _wetSandTile = new AncSprite(this);
            _deepWaterTile = new AncSprite(this);
            _shallowWaterTile = new AncSprite(this);
            _shortGrass = new AncSprite(this);
            _longGrass = new AncSprite(this);
            _errorTile = new AncSprite(this);

            _drySandTile.FileLocation = "Sand";
            _wetSandTile.FileLocation = "WetSand";
            _deepWaterTile.FileLocation = "DeepWater";
            _shallowWaterTile.FileLocation = "ShallowWater";
            _shortGrass.FileLocation = "ShortGrass";
            _longGrass.FileLocation = "LongGrass";
            _errorTile.FileLocation = "Error";
        }

        //public static void isBehind()
    }
}