using System;
using System.Collections.Generic;
using System.IO;

namespace GroceryCo.Parser
{
    /// <summary>
    /// Read the content of the file then parse it to an array of string
    /// </summary>
    public class TextParser
    {
        private readonly string path;

        /// <summary>
        /// Load the file
        /// </summary>
        /// <param name="textPath">file path</param>
        public TextParser(string textPath)
        {
            path = textPath;
        }

        /// <summary>
        /// Get the lines of text in the file
        /// </summary>
        /// <returns>list of string array</returns>
        public List<string[]> GetData()
        {
            //verify that the file exist
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);

                var list = new List<string[]>();

                //process each of the lines and convert the text to string array by spliting it using the tab delimited
                foreach (var line in lines)
                    list.Add(line.Split('\t'));

                return list;
            }
            throw new Exception(String.Format("{0} Not Found", path));
        }
    }
}