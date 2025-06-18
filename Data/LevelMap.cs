using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Squence.Data
{
    // описание уровня
    internal static class LevelMap
    {
        public static TileMapDefinition GetTileMapDefinition()
        {
            var tileSize = 64;
            var width = 14;
            var height = 11;

            List<Point> roadTiles = 
            [
                new Point(10, 0), new Point(10, 1), new Point(10, 2), new Point(9, 2),
                new Point(8, 2), new Point(7, 2), new Point(6, 2), new Point(5, 2),
                new Point(4, 2), new Point(3, 2), new Point(2, 2), new Point(2, 3),
                new Point(2, 4), new Point(3, 4), new Point(4, 4), new Point(4, 5),
                new Point(4, 6), new Point(3, 6), new Point(2, 6), new Point(1, 6),
                new Point(0, 6), new Point(8, 3), new Point(8, 4), new Point(8, 5),
                new Point(8, 6), new Point(7, 6), new Point(6, 6), new Point(5, 6),
                new Point(13, 5), new Point(12, 5), new Point(11, 5), new Point(10, 5),
                new Point(10, 6), new Point(10, 7), new Point(11, 7), new Point(12, 7),
                new Point(12, 8), new Point(12, 9), new Point(11, 9), new Point(10, 9),
                new Point(9, 9), new Point(8, 9), new Point(7, 9), new Point(7, 8),
                new Point(6, 8), new Point(5, 8), new Point(4, 8), new Point(4, 7)
                ];
            List<Point> buildZoneTiles = [
                new Point(3, 3), new Point(7, 3), new Point(7, 5),
                new Point(11, 6), new Point(5, 7), new Point(11, 8)
                ];
            
            List<List<Point>> enemyPathesList = [
                [ 
                    new Point(10, 0), new Point(10, 2), new Point(2, 2),
                    new Point(2, 4), new Point(4, 4), new Point(4, 6),
                    new Point(0, 6)
                ],
                [
                    new Point(10, 0), new Point(10, 2), new Point(8, 2),
                    new Point(8, 6), new Point(0, 6),
                ],
                [
                    new Point(13, 5), new Point(10, 5), new Point(10, 7),
                    new Point(12, 7), new Point(12, 9), new Point(7, 9),
                    new Point(7, 8), new Point(4, 8), new Point(4, 6),
                    new Point(0, 6)
                ],
                ];

            List<Wave> wavesList = [
                new Wave(
                    [
                        new WavePhase(5, enemyPathesList[0], 0.4f),
                        new WavePhase(4, enemyPathesList[1], 0.5f)
                    ],
                    2f
                ),
                new Wave(
                    [
                        new WavePhase(6, enemyPathesList[2], 0.35f),
                        new WavePhase(5, enemyPathesList[0], 0.4f),
                        new WavePhase(5, enemyPathesList[1], 0.5f)
                    ],
                    3f
                ),
                new Wave(
                    [
                        new WavePhase(8, enemyPathesList[2], 0.3f),
                        new WavePhase(6, enemyPathesList[1], 0.35f),
                        new WavePhase(4, enemyPathesList[0], 0.4f)
                    ],
                    2.5f
                ),
                new Wave(
                    [
                        new WavePhase(5, enemyPathesList[0], 0.4f),
                        new WavePhase(5, enemyPathesList[1], 0.4f),
                        new WavePhase(6, enemyPathesList[2], 0.3f)
                    ],
                    3f
                ),
                new Wave(
                    [
                        new WavePhase(7, enemyPathesList[1], 0.35f),
                        new WavePhase(8, enemyPathesList[2], 0.3f)
                    ],
                    2f
                )
                ];

            return new TileMapDefinition(
                tileSize,
                width,
                height,
                roadTiles,
                buildZoneTiles,
                enemyPathesList,
                wavesList
                );
            
        }
    }
}
