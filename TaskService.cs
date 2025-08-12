using System.Text.Json;

public class TaskService
{
    private const string FileName = "tasks.json"; // Create a file to store tasks - could be databae in future
    private List<TaskItem> tasks = new();

    public TaskService() // Create a public fn TaskService
    {
        if (File.Exists(FileName)) // If we have ran the program before, add a new item
        {
            var json = File.ReadAllText(FileName);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new(); // updates the global task variable to existing tasks
        }
    }

    public void UpdateFile() =>
        File.WriteAllText(
            FileName,
            JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true })
        );

    public void AddTask(string description)
    {
        // Get all tasks from the file, and add one
        // Increment the ID by 1

        var newId = tasks.Count > 0 ? tasks[^1].Id + 1 : 1; // get the last task ID and increment it, or start at 1

        tasks.Add(new TaskItem { Id = newId, Description = description });
        UpdateFile(); // Save all new tasks to file
    }

    public IEnumerable<TaskItem> GetTasks() => tasks; // Returns collection of TaskItem objects

    public void CompleteTask(int id)
    {
        var selectedTask = tasks.FirstOrDefault(t => t.Id == id); // Find the task with the given ID and set IsComplete to true

        if (selectedTask != null)
        {
            selectedTask.IsComplete = true; // Mark the task as complete
            UpdateFile(); // Save the updated task list to file
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}
