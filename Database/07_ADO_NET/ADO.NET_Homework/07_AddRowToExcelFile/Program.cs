namespace _07_AddRowToExcelFile
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
            Console.Title = "Add row to excel file";

            try
            {
                ReadExcelFile();

                Console.WriteLine("\n To add row fill data.");
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter score: ");
                string scoreStr = Console.ReadLine();

                int score = int.Parse(scoreStr);

                OleDbConnection conn = new System.Data.OleDb
                    .OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=scores.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";");

                conn.Open();

                using (conn)
                {
                    var command = new OleDbCommand(
                        "INSERT INTO [Sheet1$] VALUES(@name, @score);", conn);

                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@score", score);

                    var afectedRows = command.ExecuteNonQuery();

                    Console.WriteLine("afected rows: {0}\n", afectedRows);

                    ReadExcelFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input!");
                Console.WriteLine(ex.Message);
            }

        }

        public static void ReadExcelFile()
        {
            Console.WriteLine("    Excel file content:");

            OleDbConnection conn = new System.Data.OleDb
                .OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=scores.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";");

            conn.Open();

            using (conn)
            {
                var command = new OleDbCommand(
                    "SELECT * FROM [Sheet1$]", conn);

                var reader = command.ExecuteReader();
                var table = new DataTable();

                using (reader)
                {
                    table.Load(reader);
                }

                Console.WriteLine("name:        score:\n");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Console.WriteLine("{0, -15} {1}", table.Rows[i].ItemArray[0], table.Rows[i].ItemArray[1]);
                }
            }
        }
    }
}
