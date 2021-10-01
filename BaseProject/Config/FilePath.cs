using System.IO;
using System.Reflection;

namespace BaseProject.Config
{
    public class FilePath
    {
        public static string GetFilePathFromDirectory()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var replaced = currentDirectory.Replace("bin", "Reporting").Replace("Debug", "index.html").Replace("net5.0", "");
            var replaceSlashes = replaced.Remove(replaced.Length - 1, 1);
            return replaceSlashes;
        }
    }
}
