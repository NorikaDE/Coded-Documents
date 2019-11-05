using System.Collections.Generic;
using System.IO;
using Documentation.Core.FileSystem.Interfaces;

namespace Documentation.Core.FileSystem
{
    /// <summary>
    /// Default file system writer implementation
    /// </summary>
    public class FileWriter : IFileWriter
    {
        /// <summary>
        /// <inheritdoc cref="IFileWriter.WriteAllText"/>
        /// </summary>
        public bool WriteAllText(string path, string text)
        {
            File.WriteAllText(path, text);
            return File.Exists(path);
        }

        
        /// <summary>
        /// <inheritdoc cref="IFileWriter.WriteAllLines"/>
        /// </summary>
        public bool WriteAllLines(string path, IList<string> text)
        {
            File.WriteAllLines(path, text);
            return File.Exists(path);
        }
    }
}