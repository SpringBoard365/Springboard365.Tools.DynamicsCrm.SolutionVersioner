namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Springboard365.Tools.CommandLine.Core;

    public class VersionIncrementor : IVersionIncrementor
    {
        private readonly Dictionary<string, int> solutionPartNameList = new Dictionary<string, int>
        {
            { "major", 1 },
            { "minor", 2 },
            { "build", 3 },
            { "revision", 4 },
        };

        public string IncrementVersion(string currentSolutionVersion, string solutionVersionPartToIncrement)
        {
            if (solutionVersionPartToIncrement.Equals("none"))
            {
                return currentSolutionVersion;
            }

            var solutionVersionSplit = currentSolutionVersion.Split('.');

            var solutionVersionPartAsString = solutionVersionSplit[solutionPartNameList[solutionVersionPartToIncrement] - 1];

            ConsoleLogger.LogMessage($"Solution Version {solutionVersionPartToIncrement}: {solutionVersionPartAsString}");

            var paddedWithAZero = solutionVersionPartAsString.StartsWith("0");

            var solutionVersionPart = int.Parse(solutionVersionPartAsString);
            solutionVersionPart++;

            var newSolutionVersionPart = solutionVersionPart.ToString(CultureInfo.InvariantCulture);

            if (paddedWithAZero)
            {
                if (solutionVersionPart <= 9)
                {
                    newSolutionVersionPart = $"0{solutionVersionPart.ToString(CultureInfo.InvariantCulture)}";
                }
            }

            ConsoleLogger.LogMessage($"New Solution Version {solutionVersionPartToIncrement}: {newSolutionVersionPart}");
            solutionVersionSplit[solutionPartNameList[solutionVersionPartToIncrement] - 1] = newSolutionVersionPart;

            for (var i = solutionPartNameList[solutionVersionPartToIncrement]; i < solutionVersionSplit.Count(); i++)
            {
                if (paddedWithAZero)
                {
                    ConsoleLogger.LogMessage($"Updating '{solutionPartNameList.ElementAt(i)}' to 01");
                    solutionVersionSplit[i] = "01";
                }
                else
                {
                    ConsoleLogger.LogMessage($"Updating '{solutionPartNameList.ElementAt(i)}' to zero");
                    solutionVersionSplit[i] = 0.ToString(CultureInfo.InvariantCulture);
                }
            }

            var newSolutionVersion = string.Join(".", solutionVersionSplit);

            ConsoleLogger.LogMessage($"New Solution Version '{newSolutionVersion}'");
            return newSolutionVersion;
        }
    }
}