# Dialog-Engine
Small Dialog Generator for a small RPG/Adventure game

The idea behind the engine is a simple workflow as follows:
1) The user (an engine or some sort of script) asks the engine for a particular script ("Can you get me the script for Scene 11?")
2) The main entry point of the engine(TBD), will pass the request to the DialogGenerator, will find the file, tokenize it, and generate a map of dialog
3) This dialog map can be passed to a DialogPrinter, which is passed to the requestor
	- This Printer only does one thing, print. What matters here is that you can tell the printer 'when' to print
	- The idea is to 'de-couple' when dialog is printed and when it's needed. This was based on the idea that a 
	game for example, might want an initial line of dialog out, move a character, then have another line of dialog. By making it dependant on the caller, it separates responsibilities.
