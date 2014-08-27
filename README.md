#Sample Tag source
==================

This is a sample plugin which shows how to write a plugin to import tags from other systems into ManicTime.

To test it:
1. Clone the repository and build it. 
2. Go to bin/(Debug or Release)/Packages folder. In it, there should be a folder named ManicTime.TagSource.SampleWeb. Copy this whole folder to c:\Users\<user>\AppData\Local\Finkit\ManicTime\Plugins\Packages\
3. Restart ManicTime. 
4. Go to Tag editor and under Tag sources -> Add you should see "Tags from Web"

Package folder is created in a post-build event
__What is in the package folder:__
1. The dll of the plugin as well as any other dll not included in the .Net installation.
2. There is also a PluginSpec.json file:
..* __Id__ must be the same as the folder name
..* __Name__ and __Description__ are used in ManicTime when the plugin is shown
..* __Type__ needs to be TagSource
..* _AssemblyName__ is the dll of the plugin.

##How it works
When the plugin is first created, it will look for a class derived from TagSourceSettingsViewModel. The view will be presented to the user, use it to collect the necessary information like username, password, service url and anything else you need for your plugin to work.

When the user presses Ok, the settings will be saved. 
Then the plugin will be created by calling CreateServerTagSourceInstance in class SampleWebTagSource. Any plugin can have more than one instance, you could for example load tags from GitHub from multiple accounts.

Most of the work in your plugin is done by the Update function in SampleWebTagSourceInstance. In this function you can connect to the service and get the list of tags from the remote service. ManicTime will then present them in Add tag window.
