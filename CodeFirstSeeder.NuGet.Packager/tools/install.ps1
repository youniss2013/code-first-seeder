param($installPath, $toolsPath, $package, $project)

$configItem = $project.ProjectItems.Item("SeederExample.xml")

$copyToOutput = $configItem.Properties.Item("CopyToOutputDirectory")
$copyToOutput.Value = 2

$buildAction = $configItem.Properties.Item("BuildAction")
$buildAction.Value = 2
