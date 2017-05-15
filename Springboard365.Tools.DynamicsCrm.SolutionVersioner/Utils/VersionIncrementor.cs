namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using log4net;

    public class VersionIncrementor : IVersionIncrementor
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(VersionIncrementor));
        private readonly Dictionary<string, int> solutionPartNameList = new Dictionary<string,int>
        {
            { "major", 1 },
            { "minor", 2 },
            { "build", 3 },
            { "revision", 4 }
        };

        public string IncrementVersion(string currentSolutionVersion, string solutionVersionPartToIncrement)
        {
            var solutionVersionSplit = currentSolutionVersion.Split('.');

            var solutionVersionPart = int.Parse(solutionVersionSplit[solutionPartNameList[solutionVersionPartToIncrement] - 1]);

            logger.DebugFormat("Solution Version {0}: {1}", solutionVersionPartToIncrement, solutionVersionPart);
            solutionVersionPart++;

            logger.DebugFormat("New Solution Version {0}: {1}", solutionVersionPartToIncrement, solutionVersionPart);
            solutionVersionSplit[solutionPartNameList[solutionVersionPartToIncrement] - 1] = solutionVersionPart.ToString(CultureInfo.InvariantCulture);

            for (var i = solutionPartNameList[solutionVersionPartToIncrement]; i < solutionVersionSplit.Count(); i++)
            {
                logger.InfoFormat("Updating '{0}' to zero", solutionPartNameList.ElementAt(i));
                solutionVersionSplit[i] = 0.ToString(CultureInfo.InvariantCulture);
            }

            var newSolutionVersion = string.Join(".", solutionVersionSplit);

            logger.DebugFormat("New Solution Version {0}: {1}", solutionVersionPartToIncrement, solutionVersionPart);
            return newSolutionVersion;
        }
    }
}