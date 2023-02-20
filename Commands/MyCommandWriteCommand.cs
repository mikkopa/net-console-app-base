using System.CommandLine;

namespace net_console_app_base.Commands;

public class MyCommandWriteCommand : Command
{
    public MyCommandWriteCommand() : base("write", "Write some stuff.")
    {
        var outputOption = new Option<string>(
            name: "--output",
            description: "Result will be written here.",
            getDefaultValue: () => "myfile.txt");
        outputOption.AddAlias("-o");

        var textArgument = new Argument<string?>(
            name: "--text",
            description: "Text to write to file.");

        AddArgument(textArgument);
        AddOption(outputOption);

        this.SetHandler(async (path, output, text, verbose) =>
            {
                await Handle(path!, output, text, verbose);
            },
            GlobalOptions.SourcePathOption, outputOption, textArgument, GlobalOptions.VerboseOption);

    }

    async Task Handle(DirectoryInfo path, string output, string? text, bool verbose)
    {
        // set working directory to path
        Directory.SetCurrentDirectory(path.FullName);

        if (verbose)
        {
            Console.WriteLine($"Writing \"{(text ?? "Hello World!")}\" to {output}.");
        }
        await File.WriteAllTextAsync(output, text ?? "Hello World!");
    }
}
