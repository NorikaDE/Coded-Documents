using System.Collections.Generic;

namespace Documentation.Core.FileSystem.Interfaces
{
    /// <summary>
    /// Provides file system write access
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Writes the given text to the specified file system path.
        /// </summary>
        /// <param name="path">File name</param>
        /// <param name="text">Text to write to the file</param>
        /// <returns>True if the file could be written</returns>
        bool WriteAllText(string path, string text);
        
        /// <summary>
        /// Writes the given lines to the specified file system path.
        /// </summary>
        /// <param name="path">File name</param>
        /// <param name="text">Lines to write to the file</param>
        /// <returns>True if the file could be written</returns>
        bool WriteAllLines(string path, IList<string> text);
    }
}