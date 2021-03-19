using System;
using System.Collections.Generic;
using System.IO;

namespace TestApp.Service
{
    public class FileService
    {
        public List<string> GetData()
        {
            var list = new List<string>();

            string SourceFilePath = "/Users/venkat/Desktop/Country.txt";
            StreamReader streamReader = new StreamReader(SourceFilePath);
            if (streamReader != null)
            {
                while (true)
                {
                    var line = streamReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    list.Add(line);
                }
            }
            return list;
        }
    }
}
