#load nuget:?package=Cake.Recipe&version=2.2.1

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.MicrosoftTeams",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.MicrosoftTeams",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunDupFinder: false,
                            shouldRunInspectCode: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] {
                                BuildParameters.RootDirectoryPath + "/src/Cake.MicrosoftTeams/**/*.AssemblyInfo.cs",
                                BuildParameters.RootDirectoryPath + "/src/Cake.MicrosoftTeams/LitJson/**/*.cs" });

Build.RunDotNetCore();
