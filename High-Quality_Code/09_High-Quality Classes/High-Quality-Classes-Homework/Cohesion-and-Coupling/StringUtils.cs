namespace CohesionAndCoupling
{
    using System;

    public static class StringUtils
    {
        public static string GetFileExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("File name can not be null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("File name can not be null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
