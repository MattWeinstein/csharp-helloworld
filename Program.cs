// See https://aka.ms/new-console-template for more information
var service = new TaskService();

while (true)
{
    Console.WriteLine("\nTask Tracker");
    Console.WriteLine("1. List tasks");
    Console.WriteLine("2. Add task");
    Console.WriteLine("3. Complete task");
    Console.WriteLine("4. Exit");
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
            Console.WriteLine("Invalid choice.");
            break;
    }
}
