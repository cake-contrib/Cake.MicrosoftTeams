#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context, 
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.MicrosoftTeams",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.MicrosoftTeams",
                            appVeyorAccountName: "cakecontrib");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] { 
                                BuildParameters.RootDirectoryPath + "/src/Cake.MicrosoftTeams/**/*.AssemblyInfo.cs", 
                                BuildParameters.RootDirectoryPath + "/src/Cake.MicrosoftTeams/LitJson/**/*.cs" });

Build.RunDotNetCore();
