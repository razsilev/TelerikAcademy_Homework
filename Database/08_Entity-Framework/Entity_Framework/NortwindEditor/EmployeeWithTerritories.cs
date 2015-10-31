namespace NortwindEditor
{
    using System.Collections.Generic;

    public class EmployeeWithTerritories : Employee
    {
        public HashSet<Territory> Territories { get; set; }
    }
}
