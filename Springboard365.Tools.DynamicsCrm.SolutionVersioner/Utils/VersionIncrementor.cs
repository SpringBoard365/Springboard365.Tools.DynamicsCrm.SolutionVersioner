namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class VersionIncrementor : IVersionIncrementor
    {
        private readonly Dictionary<string, int> solutionPartNameList = new Dictionary<string, int>
        {
            { "major", 1 },
            { "minor", 2 },
            { "build", 3 },
            { "revision", 4 }
        };

        public string IncrementVersion(string currentSolutionVersion, string solutionVersionPartToIncrement)
        {
            if (solutionVersionPartToIncrement.Equals("none"))
            {
                return currentSolutionVersion;
            }

            var solutionVersionSplit = currentSolutionVersion.Split('.');

            var solutionVersionPartAsString = solutionVersionSplit[solutionPartNameList[solutionVersionPartToIncrement] - 1];

            Console.WriteLine("Solution Version {0}: {1}", solutionVersionPartToIncrement, solutionVersionPartAsString);

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

            Console.WriteLine("New Solution Version {0}: {1}", solutionVersionPartToIncrement, newSolutionVersionPart);
            solutionVersionSplit[solutionPartNameList[solutionVersionPartToIncrement] - 1] = newSolutionVersionPart;

            for (var i = solutionPartNameList[solutionVersionPartToIncrement]; i < solutionVersionSplit.Count(); i++)
            {
                if (paddedWithAZero)
                {
                    Console.WriteLine("Updating '{0}' to 01", solutionPartNameList.ElementAt(i));
                    solutionVersionSplit[i] = "01";
                }
                else
                {
                    Console.WriteLine("Updating '{0}' to zero", solutionPartNameList.ElementAt(i));
                    solutionVersionSplit[i] = 0.ToString(CultureInfo.InvariantCulture);
                }
            }

            var newSolutionVersion = string.Join(".", solutionVersionSplit);

            Console.WriteLine("New Solution Version '{0}'", newSolutionVersion);
            return newSolutionVersion;
        }
    }
}