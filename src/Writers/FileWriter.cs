﻿namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System.IO;
    using Springboard365.Tools.CommandLine.Core;

    public class FileWriter : IFileWriter
    {
        private char delimiterToSplit = '.';
        private string delimiterToOutput = "_";

        public void WriteVersionNumberToFile(string versionNumber, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            using (var file = new StreamWriter($"{Directory.GetCurrentDirectory()}\\{fileName}"))
            {
                var versionNumberSplit = versionNumber.Split(delimiterToSplit);
                var newSolutionVersion = string.Join(delimiterToOutput, versionNumberSplit);
                file.WriteLine(newSolutionVersion);
                ConsoleLogger.LogMessage($"Writing {newSolutionVersion} to {fileName}");
            }
        }
    }
}