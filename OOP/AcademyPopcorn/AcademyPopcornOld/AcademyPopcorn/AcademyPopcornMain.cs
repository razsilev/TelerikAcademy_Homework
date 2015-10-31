using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;
        const int gameSpeed = 200;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow + 3, i));

                engine.AddObject(currBlock);

                Block otherBlock = new Block(new MatrixCoords(19, i));

                engine.AddObject(otherBlock);

                if (i > 19 && i < 30)
                {
                    // add unpassableBlocks
                    UnpassableBlock currUnpassableBlock = new UnpassableBlock(new MatrixCoords(18, i + 1));

                    engine.AddObject(currUnpassableBlock);
                }

            }

            // add GiftBlock
            GiftBlock giftBlock = new GiftBlock(new MatrixCoords(8, 15));
            engine.AddObject(giftBlock);

            // add explodingBlock
            ExplodingBlock explodingBlock = new ExplodingBlock(new MatrixCoords(startRow + 4, startCol + 1));
            ExplodingBlock explodingBlock1 = new ExplodingBlock(new MatrixCoords(startRow + 14, startCol + 19));

            engine.AddObject(explodingBlock);
            engine.AddObject(explodingBlock1);

            // add disapiared object
            TrailObject trailObject = new TrailObject(new MatrixCoords(17, 5), new char[,] { {'X', 'X', 'X'} }, 100);
            engine.AddObject(trailObject);

            for (int row = startRow - 1; row < WorldRows; row++)
            {
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(row, 0));
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(leftWallBlock);
                engine.AddObject(rightWallBlock);
            }

            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock upWallBlock = new IndestructibleBlock(new MatrixCoords(1, col));

                engine.AddObject(upWallBlock);
            }

            // change ball
            MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            
            engine.AddObject(theRacket);

            // test we should remove the previous racket from this.allObjects
            //engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            MyEngine gameEngine = new MyEngine(renderer, keyboard, gameSpeed);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
