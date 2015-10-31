namespace _05_RetrieveImagesFromNorthwind
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class Program
    {
        private static string path = @"Images_From_DB_Northwind";

        public static void Main()
        {
            CreateDirectoryForImagesSave();

            //The images will be placed in the bin directory of the project
            ExtractImageFromDB();
        }

        private static void CreateDirectoryForImagesSave()
        {
            try
            {
                // Delete directory whether the directory exists. 
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public static void ExtractImageFromDB()
        {
            SqlConnection dbConn = new SqlConnection("Server=.; " + "Database=Northwind; Integrated Security=true");
            dbConn.Open();

            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT PICTURE, CategoryID, CategoryName FROM Categories", dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        byte[] rawData = (byte[])reader["Picture"];
                        string fileName = reader["CategoryName"].ToString().Replace('/', '_') + ".jpg";
                        int len = rawData.Length;
                        int header = 78;
                        byte[] imgData = new byte[len - header];
                        Array.Copy(rawData, 78, imgData, 0, len - header);

                        MemoryStream memoryStream = new MemoryStream(imgData);
                        Image image = System.Drawing.Image.FromStream(memoryStream);
                        image.Save(new FileStream(path + "/" + fileName, FileMode.Create), ImageFormat.Jpeg);
                    }

                }
            }
        }
    }
}
