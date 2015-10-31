namespace ComputerBuildingSystem
{
    using System;
    using ComputerBuildingSystem.Computerr;
    using ComputerBuildingSystem.Cpuu;
    using ComputerBuildingSystem.Motherboardd;
    using ComputerBuildingSystem.Ram;
    using ComputerBuildingSystem.VideoCard;

    public class Computers
    {
        public const int Eight = 8;

        private static PC pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            InitializeComputers();

            while (true)
            {
                var c = Console.ReadLine();
                if (c == null)
                {
                    goto end;
                }

                if (c.StartsWith("Exit"))
                {
                    goto end;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var cn = cp[0];
                var ca = int.Parse(cp[1]);

                if (cn == "Charge")
                {
                    laptop.ChargeBattery(ca);
                }
                else if (cn == "Process")
                {
                    server.Process(ca);
                }
                else if (cn == "Play")
                {
                    pc.Play(ca);
                }

                continue;

                // Console.WriteLine("Invalid command!");
            }

        end: ;
            Console.ReadKey(true);
        }

        private static void InitializeComputers()
        {
            var manufacturer = Console.ReadLine();

            if (manufacturer == "HP")
            {
                // pc
                var ram = new RamMemory(2);
                var videoCard = VideoCardFactory.CrateVideoCard(VideoCardType.COLORFUL);
                var motherboard = new Motherboard(videoCard, ram);
                var cpu = new Cpuu.Cpu(2, CpuType.BIT32, motherboard);

                pc = new PC(cpu, motherboard, new HardDriver(500, false, 0));

                var serverRam = new RamMemory(32);
                var serverVideo = VideoCardFactory.CrateVideoCard(VideoCardType.MONOCHROME);
                var serverMBoard = new Motherboard(serverVideo, serverRam);
                var serverCpu = new Cpu(4, CpuType.BIT32, serverMBoard);

                server = new Server(serverCpu, serverMBoard, new[] { new HardDriver(1000, true, 2) });

                var ramLaptop = new RamMemory(4);
                var videoCardLaptop = VideoCardFactory.CrateVideoCard(VideoCardType.COLORFUL);
                var motherboardLaptop = new Motherboard(videoCardLaptop, ram);
                var cpuLaptop = new Cpuu.Cpu(2, CpuType.BIT64, motherboard);

                laptop = new Laptop(cpu, motherboard, new HardDriver(500, false, 0), new ComputerBuildingSystem.Computerr.LaptopBattery());
            }
            else if (manufacturer == "Dell")
            {
                // pc
                var ram = new RamMemory(8);
                var videoCard = VideoCardFactory.CrateVideoCard(VideoCardType.COLORFUL);
                var motherboard = new Motherboard(videoCard, ram);
                var cpu = new Cpuu.Cpu(2, CpuType.BIT64, motherboard);

                pc = new PC(cpu, motherboard, new HardDriver(1000, false, 0));

                var serverRam = new RamMemory(64);
                var serverVideo = VideoCardFactory.CrateVideoCard(VideoCardType.MONOCHROME);
                var serverMBoard = new Motherboard(serverVideo, serverRam);
                var serverCpu = new Cpu(8, CpuType.BIT64, serverMBoard);

                server = new Server(serverCpu, serverMBoard, new[] { new HardDriver(2000, true, 2) });

                var ramLaptop = new RamMemory(8);
                var videoCardLaptop = VideoCardFactory.CrateVideoCard(VideoCardType.COLORFUL);
                var motherboardLaptop = new Motherboard(videoCardLaptop, ram);
                var cpuLaptop = new Cpuu.Cpu(2, CpuType.BIT32, motherboard);

                laptop = new Laptop(cpu, motherboard, new HardDriver(1000, false, 0), new ComputerBuildingSystem.Computerr.LaptopBattery());
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }
    }
}
