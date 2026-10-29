using SpiderGame;
using System;
using System.IO;
using Xunit;

namespace TestSpiderGame
{
    public class UnitTest1
    {
        [Fact]
        public void PlayerCreateWithCorrectPosition()
        {
            var player = new Player(3, 5);
            Assert.Equal(3, player.X);
            Assert.Equal(5, player.Y);
        }

        [Fact]
        public void Player_Spawned_HasValidCoordinatesOnField()
        {
            var map = new char[,]
            {
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' },
                { '.', '.', '.', '.', '.' }
            };
            int spawnX = 2, spawnY = 3;

            var player = new Player(spawnX, spawnY);
            var field = new Field () { Map = map, Player = player };

            Assert.InRange(player.X, 0, map.GetLength(0) - 1);
            Assert.InRange(player.Y, 0, map.GetLength(1) - 1);
        }
    }
}