using System;

public static class CommandLineHandler{
	
	static int clp; //Command line pointer
	
	public static void process(string[] args){
		
		clp = 0;
		
		if(args.Length < 1){
			return;
		}
		
		if(args[0] == "-q"){
			Tebas.quiet = true; //Activate quiet mode
			clp++;
		}
		
		for(int i = 0; i < args.Length; i++){
			args[i] = StringHelper.removeQuotesSingle(args[i]);
		}
		
		string[] t = args[0].Split(".");
		if(t.Length > 0 && t[t.Length - 1] == "tbtem"){
			string[] a = {"template", "install", args[0]};
			commands(a);
			Console.WriteLine("Press any key to close");
			Console.ReadKey();
		}
		
		else if(t.Length > 0 && t[t.Length - 1] == "tebas"){
			Tebas.workingDirectory = Path.GetDirectoryName(args[0]);
			string[] a = {"local", "info"};
			commands(a);
			Console.WriteLine("Press any key to close");
			Console.ReadKey();
		}
		
		commands(args);
	}
	
	//Body of the program, where it actually does things
	static void commands(string[] args){		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "project":
			clp++;
			commandsProject(args);
			break;
			
			case "channel":
			clp++;
			commandsChannel(args);
			break;
			
			case "template":
			clp++;
			commandsTemplate(args);
			break;
			
			case "global":
			clp++;
			commandsGlobal(args);
			break;
			
			case "local":
			clp++;
			commandsLocal(args);
			break;
			
			case "help":
			clp++;
			commandHelp(args);
			break;
			
			default:
			commandsProjectOrLocal(args);
			break;
		}
	}
	
	static void commandsProject(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "new":
			clp++;
			commandProjectNew(args);
			break;
			
			case "rename":
			clp++;
			commandProjectRename(args);
			break;
			
			case "delete":
			clp++;
			commandProjectDelete(args);
			break;
			
			default:
			Tebas.consoleOutput("Unknown command");
			break;
		}
	}
	
	static void commandsChannel(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "set":
			clp++;
			commandChannelSet(args);
			break;
			
			case "rename":
			clp++;
			commandChannelRename(args);
			break;
			
			case "delete":
			clp++;
			commandChannelDelete(args);
			break;
			
			case "list":
			clp++;
			commandChannelList(args);
			break;
			
			case "info":
			clp++;
			commandChannelInfo(args);
			break;
			
			default:
			commandChannelSet(args);
			break;
		}
	}
	
	static void commandsTemplate(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "install":
			clp++;
			commandTemplateInstall(args);
			break;
			
			case "delete":
			clp++;
			commandTemplateDelete(args);
			break;
			
			case "list":
			clp++;
			commandTemplateList(args);
			break;
			
			case "info":
			clp++;
			commandTemplateInfo(args);
			break;
			
			default:
			Tebas.consoleOutput("Unknown command");
			break;
		}
	}
	
	static void commandsGlobal(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "config":
			clp++;
			commandGlobalConfig(args);
			break;
			
			case "list":
			clp++;
			commandGlobalList(args);
			break;
			
			default:
			Tebas.consoleOutput("Unknown command");
			break;
		}
	}
	
	static void commandsLocal(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){			
			case "info":
			clp++;
			commandLocalInfo(args);
			break;
			
			case "git":
			clp++;
			commandLocalGit(args);
			break;
			
			case "stats":
			clp++;
			commandLocalStats(args);
			break;
			
			case "remote":
			clp++;
			commandsLocalRemote(args);
			break;
			
			case "commit":
			clp++;
			commandLocalCommit(args);
			break;
			
			case "add":
			clp++;
			commandLocalAdd(args);
			break;
			
			case "push":
			clp++;
			commandLocalPush(args);
			break;
			
			case "pull":
			clp++;
			commandLocalPull(args);
			break;
			
			default:
			commandTryScript(args);
			break;
		}
	}
	
	static void commandsProjectOrLocal(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "new":
			clp++;
			commandProjectNew(args);
			break;
			
			case "rename":
			clp++;
			commandProjectRename(args);
			break;
			
			case "delete":
			clp++;
			commandProjectDelete(args);
			break;
			
			case "info":
			clp++;
			commandLocalInfo(args);
			break;
			
			case "git":
			clp++;
			commandLocalGit(args);
			break;
			
			case "stats":
			clp++;
			commandLocalStats(args);
			break;
			
			case "remote":
			clp++;
			commandsLocalRemote(args);
			break;
			
			case "commit":
			clp++;
			commandLocalCommit(args);
			break;
			
			case "add":
			clp++;
			commandLocalAdd(args);
			break;
			
			case "push":
			clp++;
			commandLocalPush(args);
			break;
			
			case "pull":
			clp++;
			commandLocalPull(args);
			break;
			
			default:
			commandTryScript(args);
			break;
		}
	}
	
	static void commandsLocalRemote(string[] args){
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		switch(args[clp]){
			case "list":
			clp++;
			commandLocalRemoteList(args);
			break;
			
			case "set":
			clp++;
			commandLocalRemoteSet(args);
			break;
			
			case "delete":
			clp++;
			commandLocalRemoteDelete(args);
			break;
			
			case "rename":
			clp++;
			commandLocalRemoteRename(args);
			break;
			
			default:
			Tebas.consoleOutput("Unknown command");
			break;
		}
	}
	
	
	//Individual commands
	static void commandProjectNew(string[] args){
		string channelName;
		string templateName;
		string projectName;
		
		if(!determineIfEnoughLength(2, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		if(args[clp].Length > 0 && args[clp][0] == '-'){ //get channel
			channelName = args[clp].Substring(1);
			clp++;
			
			if(!determineIfEnoughLength(2, args.Length)){
				Tebas.consoleOutput("Not enough arguments");
				return;
			}
		}else{
			channelName = "default";
		}
		
		templateName = args[clp];
		clp++;
		
		projectName = args[clp];
		clp++;
		
		Tebas.projectNew(channelName, templateName, projectName);
	}
	
	static void commandProjectRename(string[] args){
		string channelName;
		string oldName;
		string newName;
		
		if(!determineIfEnoughLength(2, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		if(args[clp].Length > 0 && args[clp][0] == '-'){ //get channel
			channelName = args[clp].Substring(1);
			clp++;
			
			if(!determineIfEnoughLength(2, args.Length)){
				Tebas.consoleOutput("Not enough arguments");
				return;
			}
		}else{
			channelName = "default";
		}
		
		oldName = args[clp];
		clp++;
		
		newName = args[clp];
		clp++;
		
		Tebas.projectRename(channelName, oldName, newName);
	}
	
	static void commandProjectDelete(string[] args){
		string channelName;
		string name;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		if(args[clp].Length > 0 && args[clp][0] == '-'){ //get channel
			channelName = args[clp].Substring(1);
			clp++;
			
			if(!determineIfEnoughLength(1, args.Length)){
				Tebas.consoleOutput("Not enough arguments");
				return;
			}
		}else{
			channelName = "default";
		}
		
		name = args[clp];
		clp++;
		
		Tebas.projectDelete(channelName, name);
	}
	
	//Channel
	static void commandChannelSet(string[] args){
		string name;
		string v;
		
		if(!determineIfEnoughLength(2, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		name = args[clp];
		clp++;
		
		v = args[clp];
		clp++;
		
		ChannelHandler.set(name, v);
	}
	
	static void commandChannelRename(string[] args){
		string oldName;
		string newName;
		
		if(!determineIfEnoughLength(2, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		oldName = args[clp];
		clp++;
		
		newName = args[clp];
		clp++;
		
		ChannelHandler.rename(oldName, newName);
	}
	
	static void commandChannelDelete(string[] args){
		string name;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		name = args[clp];
		clp++;
		
		ChannelHandler.delete(name);
	}
	
	static void commandChannelList(string[] args){		
		ChannelHandler.list();
	}
	
	static void commandChannelInfo(string[] args){
		string name;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		name = args[clp];
		clp++;
		
		ChannelHandler.info(name);
	}
	
	//Template
	static void commandTemplateInstall(string[] args){
		string path;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		path = args[clp];
		clp++;
		
		TemplateHandler.install(path);
	}
	
	static void commandTemplateDelete(string[] args){
		string name;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		name = args[clp];
		clp++;
		
		TemplateHandler.delete(name);
	}
	
	static void commandTemplateList(string[] args){
		TemplateHandler.list();
	}
	
	static void commandTemplateInfo(string[] args){
		string name;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		name = args[clp];
		clp++;
		
		TemplateHandler.info(name);
	}
	
	//Global
	static void commandGlobalConfig(string[] args){
		string key;
		string v;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		key = args[clp];
		clp++;
		
		if(key == "list"){
			Tebas.globalConfig(key, null);
			return;
		}
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		v = args[clp];
		clp++;
		
		Tebas.globalConfig(key, v);
	}
	
	static void commandGlobalList(string[] args){
		Tebas.globalList();
	}
	
	//Local
	static void commandLocalInfo(string[] args){
		Tebas.localInfo();
	}
	
	static void commandLocalGit(string[] args){
		Tebas.localGit();
	}
	
	static void commandLocalStats(string[] args){
		Tebas.localStats();
	}
	
	static void commandLocalAdd(string[] args){
		Tebas.localAdd();
	}
	
	static void commandLocalCommit(string[] args){
		string m;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		m = args[clp];
		clp++;
		
		Tebas.localCommit(m);
	}
	
	static void commandLocalPush(string[] args){
		if(args.Length > clp){
			string m = args[clp];
			clp++;
		
			Tebas.localPush(m);
			return;
		}
		
		Tebas.localPush(null);
	}
	
	static void commandLocalPull(string[] args){
		if(args.Length > clp){
			string m = args[clp];
			clp++;
		
			Tebas.localPull(m);
			return;
		}
		
		Tebas.localPull(null);
	}
	
	static void commandTryScript(string[] args){
		string v;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		v = args[clp];
		clp++;
		
		Tebas.tryScript(v);
	}
	
	//local config remote
	
	static void commandLocalRemoteList(string[] args){
		Tebas.localRemoteList();
	}
	
	static void commandLocalRemoteSet(string[] args){
		string n;
		string u;
		
		if(!determineIfEnoughLength(2, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		n = args[clp];
		clp++;
		
		u = args[clp];
		clp++;
		
		Tebas.localRemoteSet(n, u);
	}
	
	static void commandLocalRemoteDelete(string[] args){
		string n;
		
		if(!determineIfEnoughLength(1, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		n = args[clp];
		clp++;
		
		Tebas.localRemoteDelete(n);
	}
	
	static void commandLocalRemoteRename(string[] args){
		string n;
		string u;
		
		if(!determineIfEnoughLength(2, args.Length)){
			Tebas.consoleOutput("Not enough arguments");
			return;
		}
		
		n = args[clp];
		clp++;
		
		u = args[clp];
		clp++;
		
		Tebas.localRemoteRename(n, u);
	}
	
	static void commandHelp(string[] args){
		Tebas.consoleOutput("Help for command line arguments:");
		Tebas.consoleOutput("");
		Tebas.consoleOutput("Sections:");
		Tebas.consoleOutput("channel");
		Tebas.consoleOutput(" Manages channels(folders where projects are). This section can be executed anywhere");
		Tebas.consoleOutput("        [name] [path]            followed by any name and a folder path, will create or set that channel");
		Tebas.consoleOutput("        delete [name]            deletes that channel");
		Tebas.consoleOutput("        rename [name] [newname]  renames that channel");
		Tebas.consoleOutput("        list                     shows a list of all channels");
		Tebas.consoleOutput("        info [name]              shows info on a specific channel");
		Tebas.consoleOutput("");
		Tebas.consoleOutput("template");
		Tebas.consoleOutput(" Manages the templates (templates for projects). This section can be executed anywhere");
		Tebas.consoleOutput("         install [path]  installs the template from a file (.tbtem)");
		Tebas.consoleOutput("         delete [name]   deletes that template");
		Tebas.consoleOutput("         list            shows list of all templates installed");
		Tebas.consoleOutput("         info [name]     shows info on a specific template");
		Tebas.consoleOutput("");
		Tebas.consoleOutput("global");
		Tebas.consoleOutput(" Manages global things. This section can be executed anywhere");
		Tebas.consoleOutput("       config [key] [value]  Changes the global config. You can also do config list for a list of all keys");
		Tebas.consoleOutput("       list                  Shows list of all of the projects");
		Tebas.consoleOutput("");
		Tebas.consoleOutput("project");
		Tebas.consoleOutput(" Manages projects. This section can be executed anywhere, and the project keyword can be skipped entirely (For example, instead of \'tebas project new\', \'tebas new\'");
		Tebas.consoleOutput("        new -[channel] [template] [name]    Creates a new project. The channel can be skipped, and the default one will be used. To specify the channel, precede its name with a \'-\'");
		Tebas.consoleOutput("        delete -[channel] [name]            Deletes a project. The channel can be skipped, and the default one will be used. To specify the channel, precede its name with a \'-\'");
		Tebas.consoleOutput("        rename -[channel] [name] [newname]  Renames a project. The channel can be skipped, and the default one will be used. To specify the channel, precede its name with a \'-\'");
		Tebas.consoleOutput("");
		Tebas.consoleOutput("local");
		Tebas.consoleOutput(" Manages the local project. This section must be executed in a folder containing a project, and the local keyword can be skipped entirely (For example, instead of \'tebas local info\', \'tebas info\'");
		Tebas.consoleOutput("      git               The equivalent of doing \'git status\'");
		Tebas.consoleOutput("      push [remote]     The equivalent of doing \'git push\'. If there is only one remote, you dont need to specify it");
		Tebas.consoleOutput("      pull [remote]     The equivalent of doing \'git pull\'. If there is only one remote, you dont need to specify it");
		Tebas.consoleOutput("      add               The equivalent of doing \'git add .\'");
		Tebas.consoleOutput("      commit [message]  The equivalent of doing \'git commit\'");
		Tebas.consoleOutput("      remote            Maneges git remotes. This has more options:");
		Tebas.consoleOutput("             set [name] [URL]         Sets that remote");
		Tebas.consoleOutput("             delete [name]            Deletes that remote");
		Tebas.consoleOutput("             rename [name] [newname]  Deletes that remote");
		Tebas.consoleOutput("             list                     Shows a list of all remotes");
		Tebas.consoleOutput("");
		Tebas.consoleOutput("      info              Shows info on the current project");
		Tebas.consoleOutput("      stats             Shows stats on the current project");
		Tebas.consoleOutput("      [script]          Attempts to run a script of the current template");
	}
	
	//utilitie
	static bool determineIfEnoughLength(int n, int l){
		if(clp + n - 1 >= l){
			return false;
		}
		return true;
	}
}