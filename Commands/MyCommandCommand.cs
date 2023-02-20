using System.CommandLine;

namespace net_console_app_base.Commands;

public class MyCommandCommand : Command
{
    // this is a subcommand with no actions, only other command(s)
    public MyCommandCommand() : base("mycommand", "Do some stuff.")
    {
        Add(new MyCommandWriteCommand());
    }
}
