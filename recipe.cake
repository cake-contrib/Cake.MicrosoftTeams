#load nuget:https://pkgs.dev.azure.com/cake-contrib/Home/_packaging/addins/nuget/v3/index.json?package=Cake.Recipe&version=4.0.0-alpha0122

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.MicrosoftTeams",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.MicrosoftTeams",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunInspectCode: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolPreprocessorDirectives(
                            gitReleaseManagerGlobalTool: "#tool dotnet:?package=GitReleaseManager.Tool&version=0.18.0");

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
