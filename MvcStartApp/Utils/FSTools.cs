using System.Linq.Expressions;

namespace MvcStartApp.Utils
{
    public class FSTools
    {
        public static DirectoryInfo CreateFolder(String path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            try
            {
                if (!directoryInfo.Exists)
                    directoryInfo.Create();

                return directoryInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static FileInfo CreateFile(String path)
        {
            FileInfo fileInfo = new FileInfo(path);

            try
            {
                if (!fileInfo.Exists)
                    fileInfo.Create();

                return fileInfo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
    }
}
