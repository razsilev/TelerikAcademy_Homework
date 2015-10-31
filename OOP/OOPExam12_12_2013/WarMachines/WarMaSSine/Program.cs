using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarMaSSine
{
    public class WarMachinesProgram
    {
        public static void Main()
        {
            WarMachineEngine.Instance.Start();
        }
    }

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            // TODO: Implement this method
            return new Pilot(name);
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            // TODO: Implement this method
            return new Tank(name, attackPoints, defensePoints);
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            // TODO: Implement this method
            return new Fighter(name, attackPoints, defensePoints, stealthMode);
        }
    }

    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }

    public interface IMachine
    {
        string Name { get; set; }

        IPilot Pilot { get; set; }

        double HealthPoints { get; set; }

        double AttackPoints { get; }

        double DefensePoints { get; }

        IList<string> Targets { get; }

        void Attack(string target);

        string ToString();
    }

    public interface IPilot
    {
        string Name { get; }

        void AddMachine(IMachine machine);

        string Report();
    }

    public interface IWarMachineEngine
    {
        void Start();
    }

    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';

        private string name;
        private IList<string> parameters;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of strings cannot be null.");
                }

                this.parameters = value;
            }
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            var indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);

            this.Name = input.Substring(0, indexOfFirstSeparator);
            this.Parameters = input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    public sealed class WarMachineEngine : IWarMachineEngine
    {
        private const string InvalidCommand = "Invalid command name: {0}";
        private const string PilotHired = "Pilot {0} hired";
        private const string PilotExists = "Pilot {0} is hired already";
        private const string TankManufactured = "Tank {0} manufactured - attack: {1}; defense: {2}";
        private const string FighterManufactured = "Fighter {0} manufactured - attack: {1}; defense: {2}; stealth: {3}";
        private const string MachineExists = "Machine {0} is manufactured already";
        private const string MachineHasPilotAlready = "Machine {0} is already occupied";
        private const string PilotNotFound = "Pilot {0} could not be found";
        private const string MachineNotFound = "Machine {0} could not be found";
        private const string MachineEngaged = "Pilot {0} engaged machine {1}";
        private const string InvalidMachineOperation = "Machine {0} does not support this operation";
        private const string FighterOperationSuccessful = "Fighter {0} toggled stealth mode";
        private const string TankOperationSuccessful = "Tank {0} toggled defense mode";
        private const string InvalidAttackTarget = "Tank {0} cannot attack stealth fighter {1}";
        private const string AttackSuccessful = "Machine {0} was attacked by machine {1} - current health: {2}";

        private static readonly WarMachineEngine SingleInstance = new WarMachineEngine();

        private IMachineFactory factory;
        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;

        private WarMachineEngine()
        {
            this.factory = new MachineFactory();
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public static WarMachineEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);

                currentLine = Console.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                string commandResult;

                switch (command.Name)
                {
                    case "HirePilot":
                        var pilotName = command.Parameters[0];
                        commandResult = this.HirePilot(pilotName);
                        reports.Add(commandResult);
                        break;

                    case "Report":
                        var pilotReporting = command.Parameters[0];
                        commandResult = this.PilotReport(pilotReporting);
                        reports.Add(commandResult);
                        break;

                    case "ManufactureTank":
                        var tankName = command.Parameters[0];
                        var tankAttackPoints = double.Parse(command.Parameters[1]);
                        var tankDefensePoints = double.Parse(command.Parameters[2]);
                        commandResult = this.ManufactureTank(tankName, tankAttackPoints, tankDefensePoints);
                        reports.Add(commandResult);
                        break;

                    case "DefenseMode":
                        var defenseModeTankName = command.Parameters[0];
                        commandResult = this.ToggleTankDefenseMode(defenseModeTankName);
                        reports.Add(commandResult);
                        break;

                    case "ManufactureFighter":
                        var fighterName = command.Parameters[0];
                        var fighterAttackPoints = double.Parse(command.Parameters[1]);
                        var fighterDefensePoints = double.Parse(command.Parameters[2]);
                        var fighterStealthMode = command.Parameters[3] == "StealthON" ? true : false;
                        commandResult = this.ManufactureFighter(fighterName, fighterAttackPoints, fighterDefensePoints, fighterStealthMode);
                        reports.Add(commandResult);
                        break;

                    case "StealthMode":
                        var stealthModeFighterName = command.Parameters[0];
                        commandResult = this.ToggleFighterStealthMode(stealthModeFighterName);
                        reports.Add(commandResult);
                        break;

                    case "Engage":
                        var selectedPilotName = command.Parameters[0];
                        var selectedMachineName = command.Parameters[1];
                        commandResult = this.EngageMachine(selectedPilotName, selectedMachineName);
                        reports.Add(commandResult);
                        break;

                    case "Attack":
                        var attackingMachine = command.Parameters[0];
                        var defendingMachine = command.Parameters[1];
                        commandResult = this.AttackMachines(attackingMachine, defendingMachine);
                        reports.Add(commandResult);
                        break;

                    default:
                        reports.Add(string.Format(InvalidCommand, command.Name));
                        break;
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            Console.Write(output.ToString());
        }

        private string HirePilot(string name)
        {
            if (this.pilots.ContainsKey(name))
            {
                return string.Format(PilotExists, name);
            }

            var pilot = this.factory.HirePilot(name);
            this.pilots.Add(name, pilot);

            return string.Format(PilotHired, name);
        }

        private string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.ContainsKey(name))
            {
                return string.Format(MachineExists, name);
            }

            var tank = this.factory.ManufactureTank(name, attackPoints, defensePoints);
            this.machines.Add(name, tank);

            return string.Format(TankManufactured, name, attackPoints, defensePoints);
        }

        private string ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            if (this.machines.ContainsKey(name))
            {
                return string.Format(MachineExists, name);
            }

            var fighter = this.factory.ManufactureFighter(name, attackPoints, defensePoints, stealthMode);
            this.machines.Add(name, fighter);

            return string.Format(FighterManufactured, name, attackPoints, defensePoints, stealthMode == true ? "ON" : "OFF");
        }

        private string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.ContainsKey(selectedPilotName))
            {
                return string.Format(PilotNotFound, selectedPilotName);
            }

            if (!this.machines.ContainsKey(selectedMachineName))
            {
                return string.Format(MachineNotFound, selectedMachineName);
            }

            if (this.machines[selectedMachineName].Pilot != null)
            {
                return string.Format(MachineHasPilotAlready, selectedMachineName);
            }

            var pilot = this.pilots[selectedPilotName];
            var machine = this.machines[selectedMachineName];

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return string.Format(MachineEngaged, selectedPilotName, selectedMachineName);
        }

        private string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.ContainsKey(attackingMachineName))
            {
                return string.Format(MachineNotFound, attackingMachineName);
            }

            if (!this.machines.ContainsKey(defendingMachineName))
            {
                return string.Format(MachineNotFound, defendingMachineName);
            }

            var attackingMachine = this.machines[attackingMachineName];
            var defendingMachine = this.machines[defendingMachineName];

            if (attackingMachine is ITank && defendingMachine is IFighter && (defendingMachine as IFighter).StealthMode)
            {
                return string.Format(InvalidAttackTarget, attackingMachineName, defendingMachineName);
            }

            attackingMachine.Targets.Add(defendingMachineName);

            var attackPoints = attackingMachine.AttackPoints;
            var defensePoints = defendingMachine.DefensePoints;

            var damage = attackPoints - defensePoints;

            if (damage > 0)
            {
                var newHeathPoints = defendingMachine.HealthPoints - damage;

                if (newHeathPoints < 0)
                {
                    newHeathPoints = 0;
                }

                defendingMachine.HealthPoints = newHeathPoints;
            }

            return string.Format(AttackSuccessful, defendingMachineName, attackingMachineName, defendingMachine.HealthPoints);
        }

        private string PilotReport(string pilotReporting)
        {
            if (!this.pilots.ContainsKey(pilotReporting))
            {
                return string.Format(PilotNotFound, pilotReporting);
            }

            return this.pilots[pilotReporting].Report();
        }

        private string ToggleFighterStealthMode(string stealthModeFighterName)
        {
            if (!this.machines.ContainsKey(stealthModeFighterName))
            {
                return string.Format(MachineNotFound, stealthModeFighterName);
            }

            if (this.machines[stealthModeFighterName] is ITank)
            {
                return string.Format(InvalidMachineOperation, stealthModeFighterName);
            }

            var machineAsFighter = this.machines[stealthModeFighterName] as IFighter;
            machineAsFighter.ToggleStealthMode();

            return string.Format(FighterOperationSuccessful, stealthModeFighterName);
        }

        private string ToggleTankDefenseMode(string defenseModeTankName)
        {
            if (!this.machines.ContainsKey(defenseModeTankName))
            {
                return string.Format(MachineNotFound, defenseModeTankName);
            }

            if (this.machines[defenseModeTankName] is IFighter)
            {
                return string.Format(InvalidMachineOperation, defenseModeTankName);
            }

            var machineAsFighter = this.machines[defenseModeTankName] as ITank;
            machineAsFighter.ToggleDefenseMode();

            return string.Format(TankOperationSuccessful, defenseModeTankName);
        }
    }

    public interface IFighter : IMachine
    {
        bool StealthMode { get; }

        void ToggleStealthMode();
    }

    public interface IMachineFactory
    {
        IPilot HirePilot(string name);

        ITank ManufactureTank(string name, double attackPoints, double defensePoints);

        IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode);
    }

    public interface ITank : IMachine
    {
        bool DefenseMode { get; }

        void ToggleDefenseMode();
    }

    public class DeleteMe
    {
        // TODO: Implement all machine classes in this namespace - WarMachines.Machines
    }

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.Append(this.name);

            if (0 == this.machines.Count)
            {
                report.Append(" - no machines");
            }
            else
            {
                report.AppendFormat(" - {0} machines", this.machines.Count);

                if (1 == this.machines.Count)
                {
                    report.Length--;
                }

                var sortedMachines = this.machines.OrderBy(mach => mach.HealthPoints).ThenBy(mach => mach.Name);

                foreach (var machine in sortedMachines)
                {
                    report.AppendLine();

                    report.Append(machine.ToString());
                }
            }

            return report.ToString();
        }
    }

    public abstract class WarMachine : IMachine
    {
        protected string name;
        protected double healthPoints;
        protected double attackPoints;
        protected double defensePoints;
        protected IPilot pilot;
        IList<string> targets;

        public WarMachine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }

            protected set
            {
                this.targets = value;
            }
        }

        public virtual void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("- {0}", this.Name);
            result.AppendLine();
            result.AppendFormat(" *Type: {0}", this.GetType().Name);
            result.AppendLine();
            result.AppendFormat(" *Health: {0}", this.HealthPoints);
            result.AppendLine();
            result.AppendFormat(" *Attack: {0}", this.AttackPoints);
            result.AppendLine();
            result.AppendFormat(" *Defense: {0}", this.DefensePoints);
            result.AppendLine();

            if (0 == this.Targets.Count)
            {
                result.Append(" *Targets: None");
                result.AppendLine();
            }
            else
            {
                result.Append(" *Targets:");

                for (int j = 0; j < this.Targets.Count; j++)
                {
                    string curentTarget = this.Targets[j];

                    result.AppendFormat(" {0},", curentTarget);
                }

                result.Length--;
                result.AppendLine();
            }

            return result.ToString();
        }
    }

    public class Tank : WarMachine, ITank
    {
        private bool defenseMode;
        const double StartHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, Tank.StartHealthPoints, attackPoints, defensePoints)
        {
            this.defenseMode = true;
            this.DefensePoints += 30;
            this.AttackPoints -= 40;
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
        }

        public void ToggleDefenseMode()
        {
            if (this.defenseMode)
            {
                this.defenseMode = false;
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                this.defenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public override string ToString()
        {
            string defenseModeString = "OFF";
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            if (this.defenseMode)
            {
                defenseModeString = "ON";
            }

            result.AppendFormat(" *Defense: {0}", defenseModeString);

            return result.ToString();
        }
    }

    public class Fighter : WarMachine, IFighter
    {
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, 200, attackPoints, defensePoints)
        {
            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            if (this.stealthMode)
            {
                this.stealthMode = false;
            }
            else
            {
                this.stealthMode = true;
            }
        }

        public override string ToString()
        {
            string stelthModeString = "OFF";
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());

            if (this.stealthMode)
            {
                stelthModeString = "ON";
            }

            result.AppendFormat(" *Stealth: {0}", stelthModeString);

            return result.ToString();
        }
    }

}
