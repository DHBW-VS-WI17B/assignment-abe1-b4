# app

## Usage


1. Build the solution or download the [latest binaries](https://github.com/DHBW-VS-WI17B/assignment-abe1-b4/releases) (the binaries are self-contained and don't require any runtime).
   - Install the [.NET Core SDK 3.1](https://dotnet.microsoft.com/download).
   - Build the solution (workdir = `src/app/`): 
     - Windows: `dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:DebugType=None -o build`
     - Linux: `dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true -p:DebugType=None -o build`
     - MacOS: `dotnet publish -c Release -r osx-x64 -p:PublishSingleFile=true -p:DebugType=None -o build`
2. Start the server: `./build/TicketStore.Server.App`
3. Initialize the client: `./build/TicketStore.Client.App --command Init`
4. Start the client and explore possible commands: `./build/TicketStore.Client.App --command List`

Also consider exploring possible options for the server and the client by using the command line argument `--help` oder `-h`.
