namespace _06_ReadExcelFile
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class Program
    {
        public static void Main()
        {
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
