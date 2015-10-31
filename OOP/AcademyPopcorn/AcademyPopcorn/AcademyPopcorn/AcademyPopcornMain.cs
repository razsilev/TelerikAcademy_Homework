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

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            AddGameFieldWalls(engine);

            AddUnpassableBlocks(engine);

            AddExplodingBlocks(engine);

            AddGiftBlocks(engine);

            AddBall(engine);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength * 2);

            engine.AddObject(theRacket);
        }

        private static void AddGiftBlocks(Engine engine)
        {
            int startRow = 6;
            int startCol = 10;
            int endCol = 19;

            for (int col = startCol; col < endCol; col++)
            {
                var currBlock = new GiftBlock(new MatrixCoords(startRow, col), new FireGift());

                engine.AddObject(currBlock);
            }
        }

        private static void AddExplodingBlocks(Engine engine)
        {
            int startRow = 4;
            int startCol = 8;
            int endCol = 19;

            for (int i = startCol; i < endCol; i++)
            {
                var currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
        }

        private static void AddBall(Engine engine)
        {
            //UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1), 5);

            //engine.AddObject(unstoppableBall);

            //MeteoriteBall theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), 
            //    new MatrixCoords(-1, 1), 5);

            //engine.AddObject(theMeteoriteBall);

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);
        }

        private static void AddUnpassableBlocks(Engine engine)
        {
            int startRow = 13;
            int startCol = 2;
            int endCol = 19;

            for (int i = startCol; i < endCol; i++)
            {
                var currBlock = new UnpassableBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }
        }

        private static void AddGameFieldWalls(Engine engine)
        {
            // add left and right wolls
            for (int row = 2; row < WorldRows; row++)
            {
                var leftWoll = new IndestructibleBlock(new MatrixCoords(row, 0));
                var rightWoll = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(leftWoll);
                engine.AddObject(rightWoll);
            }

            // add roof
            for (int col = 0; col < WorldCols; col++)
            {
                var roof = new IndestructibleBlock(new MatrixCoords(1, col));
                
                engine.AddObject(roof);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            var gameEngine = new AdvancedEngine(renderer, keyboard, 50);

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

            // Start game
            gameEngine.Run();
        }
    }
}
