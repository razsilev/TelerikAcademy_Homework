namespace _3_BuildDirectoryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Folder rootFolder;

        public static void Main()
        {
            FillDirectoryTree("windows");

            Console.Clear();

            Console.WriteLine("Directories names in windows folder:");
            foreach (var item in rootFolder.Folders)
            {
                Console.WriteLine(item.Name);
            }

            // Search directory Size
            string directoryName = "Microsoft.NET";

            long directorySize = CalculateDirectorySizeInDirectory(directoryName);

            Console.WriteLine("\nSize of directory {1}: {0} bytes", directorySize, directoryName);
        }

        private static long CalculateDirectorySizeInDirectory(string name)
        {
            Queue<Folder> foldersForCheck = new Queue<Folder>();
            foldersForCheck.Enqueue(rootFolder);
            Folder start = null;

            while (foldersForCheck.Count > 0)
            {
                Folder current = foldersForCheck.Dequeue();

                if (current.Name == name)
                {
                    start = current;
                    break;
                }

                foreach (var item in current.Folders)
                {
                    if (item.Name == name)
                    {
                        foldersForCheck.Enqueue(item);
                        break;
                    }

                    foldersForCheck.Enqueue(item);
                }
            }


            // calculate directory size

            foldersForCheck.Clear();
            foldersForCheck.Enqueue(start);
            long sizeSum = 0;

            while (foldersForCheck.Count > 0)
            {
                Folder current = foldersForCheck.Dequeue();

                foreach (var item in current.Files)
                {
                    sizeSum += item.Size;
                }

                foreach (var item in current.Folders)
                {
                    foldersForCheck.Enqueue(item);
                }
            }

            return sizeSum;
        }

        private static void FillDirectoryTree(string folderName)
        {
            rootFolder = new Folder(folderName);
            System.IO.DriveInfo di = new System.IO.DriveInfo("C");

            // Here we skip the drive if it is not ready to be read. This 
            // is not necessarily the appropriate action in all scenarios. 

            System.IO.DirectoryInfo rootDir = di.RootDirectory;
            WalkDirectoryTree(rootDir.GetDirectories("WINDOWS").FirstOrDefault(), rootFolder);

            rootFolder = rootFolder.Folders.FirstOrDefault();
        }

        static void WalkDirectoryTree(System.IO.DirectoryInfo root, Folder folder)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            Folder newFolder = new Folder(root.Name);

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater 
            // than the application provides. 
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse. 
                // You may decide to do something different here. For example, you 
                // can try to elevate your privileges and access the file again.
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we 
                    // want to open, delete or modify the file, then 
                    // a try-catch block is required here to handle the case 
                    // where the file has been deleted since the call to TraverseTree().
                    //Console.WriteLine(fi.Name);

                    File newFile = new File(fi.Name, fi.Length);

                    newFolder.Files.Add(newFile);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    folder.Folders.Add(newFolder);
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo, newFolder);
                    
                    
                }
            }
        }
    }
}
