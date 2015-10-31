namespace _3_BuildDirectoryTree
{
    using System.Collections.Generic;
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;

            this.Files = new HashSet<File>();
            this.Folders = new HashSet<Folder>();
        }

        public string Name { get; set; }

        public HashSet<File> Files { get; set; }

        public HashSet<Folder> Folders { get; set; }
    }
}
