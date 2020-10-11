namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using Springboard365.Tools.CommandLine.Core;
    using Springboard365.Tools.DynamicsCrm.Common;

    public class SolutionVersionCommandLineParameters : CrmCommandLineParameterBase
    {
        [CommandLineArgument(ArgumentType.Required, "SolutionUniqueName", Description = "Show the solution unique name.", Shortcut = "UniqueName")]
        public string SolutionUniqueName { get; set; }

        [CommandLineArgument(ArgumentType.Required, "SolutionVersionPartToIncrement", Description = "Show the solution version part to increment - major|minor|build|release|none.", Shortcut = "PartToIncrement")]
        public string SolutionVersionPartToIncrement { get; set; }

        [CommandLineArgument(ArgumentType.Optional, "FileNameToWriteVersionNumberTo", Description = "To be able to use Version number in later builds stages, write version to a file.", Shortcut = "Filename")]
        public string FileNameToWriteVersionNumberTo { get; set; }
    }
}