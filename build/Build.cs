using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.Tools;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.Tooling;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;
using static Nuke.Core.EnvironmentInfo;

class Build : NukeBuild
{
    // Auto-injection fields:
    //  - [GitVersion] must have 'GitVersion.CommandLine' referenced
    //  - [GitRepository] parses the origin from git config
    //  - [Parameter] retrieves its value from command-line arguments or environment variables
    //
    //[GitVersion] readonly GitVersion GitVersion;
    //[GitRepository] readonly GitRepository GitRepository;
    //[Parameter] readonly string MyGetApiKey;


    // This is the application entry point for the build.
    // It also defines the default target to execute.
    public static int Main() => Execute<Build>(x => x.Publish);


    Target Clean => _ => _
        .Executes(() =>
        {
            //DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
            EnsureCleanDirectory(OutputDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() => { DotNetRestore(SolutionDirectory); });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() => { DotNetBuild(SolutionDirectory); });

    Target Publish => _ => _
        .DependsOn(Restore)
        .Executes(() => DotNetPublish(conf =>
            conf.EnableNoRestore()
                .SetToolPath(ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE")
                             ?? ToolPathResolver.GetPathExecutable("dotnet"))
                .SetProject(SourceDirectory / "Telegram.Bot.Web")
                .SetFramework("netcoreapp2.0")
                .SetConfiguration("Release")
                .SetOutput(OutputDirectory / "Telegram.Bot.Web"))
        ).Executes(() =>
        {
            File.Copy(SolutionDirectory / "README.md", OutputDirectory / "Telegram.Bot.Web/README.md");
            ZipFile.CreateFromDirectory(OutputDirectory / "Telegram.Bot.Web", OutputDirectory / "Telegram.Bot.Web.zip");
        });
}
