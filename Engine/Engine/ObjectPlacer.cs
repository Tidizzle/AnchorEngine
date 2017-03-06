using TidalLibrary;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Engine;

namespace Engine
{
    public class ObjectPlacer
    {

        /*-Create a "map" (list of positions) that specific tiles can be placed on
        * Take in:
        * -tile you want positions on
        * -object you are putting in the positions
        * -map that you want positions for
        * -distance between objects / spawnChance
        *
        * return a list of positions
        */

        public static ObjectMap RandomPlacer(int sourceTileId, AncSprite Object, int spawnChance, Vector2 scale, int squareSize,
            params MapData[] maps)
        {
            var returnMap = new ObjectMap {PlacedObjects = new List<ObjectData>()};

            foreach (var map in maps)
            {
                var columns = map.Width / map.SquareWidth;
                var rows = map.Height / map.SquareHeight;

                var x = 0;
                var y = 0;
                var iteration = 1;
                var totalIterations = 100 / spawnChance;
                int lastIteration;

                for (var i = 0; i < columns * rows; i++)
                {
                    var tileLocation = new Vector2(x, y);
                    var query = from tile in map.Data
                        where tile.X == (int) tileLocation.X && tile.Y == (int) tileLocation.Y
                        select tile;


                    foreach (var tile in query)
                    {
                        if (tile.Id == sourceTileId)
                        {
                            if (iteration == totalIterations)
                            {
                                //var yPos = tile.Y + Object.Texture.Height;
                                var placementVector = new Vector2(tile.X * squareSize, tile.Y * squareSize);

                                var returnedTile = new ObjectData(placementVector, Object.Texture.Width, Object.Texture.Height, new Vector2(4f));

                                returnMap.PlacedObjects.Add(returnedTile);

                                iteration = 1;
                                lastIteration = totalIterations;

                                if (lastIteration  == 100 / spawnChance)
                                    totalIterations += 2;
                                else if (lastIteration == (100 / spawnChance) + 2)
                                    totalIterations -= 4;
                                else if (lastIteration == (100 / spawnChance) - 2)
                                    totalIterations += 2;
                            }

                            iteration++;
                        }
                    }

                    x++;

                    if (x <= columns) continue;
                    x = 0;
                    y++;

                    if(y <= columns) continue;
                    y = 0;
                    x++;
                }
            }

            return returnMap;
        }
    }
}
