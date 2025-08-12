// See https://aka.ms/new-console-template for more information
using Spectre.Console;

var service = new TaskService();

while (true)
{
    AnsiConsole.MarkupLine("[bold cyan]\nTask Tracker[/]");
    AnsiConsole.MarkupLine("[green]1[/]. List tasks");
    AnsiConsole.MarkupLine("[green]2[/]. Add task");
    AnsiConsole.MarkupLine("[green]3[/]. Complete task");
    AnsiConsole.MarkupLine("[green]4[/]. Exit");
    Console.Write("Choose an option: "); // Not writing the whole line

    var choice = Console.ReadLine(); // Read user input

    switch (choice)
    {
        case "1":
            foreach (var task in service.GetTasks())
                Console.WriteLine(
                    $"{task.Id} - [{(task.IsComplete ? "X" : " ")}] {task.Description}"
                );
            break;
        case "2":
            Console.Write("Task description: ");
            var desc = Console.ReadLine() ?? "";
            service.AddTask(desc);
            Console.WriteLine("Task Successfully Added!");
            break;
        case "3":
            Console.Write("Enter task ID to complete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                service.CompleteTask(id);
            break;
        case "4":
            return;
        default:
            AnsiConsole.MarkupLine("[red]Invalid choice.[/]");
            break;
    }
}
