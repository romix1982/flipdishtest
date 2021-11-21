using System.IO;
using System.Reflection;

namespace Flipdish.Recruiting.UnitTest.Utils
{
    public static class ResourceLoader
    {
        public static string GetResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }

        public static byte[] GetResourceBytes(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(resourceName);
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);

            return bytes;
        }
    }
}
