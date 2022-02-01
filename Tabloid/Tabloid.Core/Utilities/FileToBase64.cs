namespace Tabloid.Core.Utilities
{
    public static class FileToBase64
    {
        public static string ConvertToBase64(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }
    }
}
