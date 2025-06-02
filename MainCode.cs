using System;

class ToDoListManager
{
    static string[,] tasks = new string[100, 3];
    static int taskCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== TO-DO LIST MENU ===");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ListTasks();
                    break;
                case "3":
                    UpdateTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        if (taskCount >= tasks.GetLength(0))
        {
            Console.WriteLine("Task limit reached.");
            return;
        }

        Console.Write("Enter Task Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Priority (Important/Unimportant): ");
        string priority = Console.ReadLine();

        Console.Write("Enter Status (Pending/In Progress/Completed): ");
        string status = Console.ReadLine();

        tasks[taskCount, 0] = name;
        tasks[taskCount, 1] = priority;
        tasks[taskCount, 2] = status;
        taskCount++;

        Console.WriteLine("Task added successfully!");
    }

    static void ListTasks()
    {
        if (taskCount == 0)
        {
            Console.WriteLine("No tasks to display.");
            return;
        }

        Console.WriteLine("\n===== TASK LIST =====");
        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine($"{i + 1}. Name: {tasks[i, 0]}, Priority: {tasks[i, 1]}, Status: {tasks[i, 2]}");
        }
    }

    static void UpdateTask()
    {
        ListTasks();

        Console.Write("\nEnter the task number to update: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= taskCount)
        {
            index--;

            Console.Write("Enter new Task Name: ");
            tasks[index, 0] = Console.ReadLine();

            Console.Write("Enter new Priority (Important/Unimportant): ");
            tasks[index, 1] = Console.ReadLine();

            Console.Write("Enter new Status (Pending/In Progress/Completed): ");
            tasks[index, 2] = Console.ReadLine();

            Console.WriteLine("Task updated successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void DeleteTask()
    {
        ListTasks();

        Console.Write("\nEnter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= taskCount)
        {
            index--;


            for (int i = index; i < taskCount - 1; i++)
            {
                tasks[i, 0] = tasks[i + 1, 0];
                tasks[i, 1] = tasks[i + 1, 1];
                tasks[i, 2] = tasks[i + 1, 2];
            }


            tasks[taskCount - 1, 0] = null;
            tasks[taskCount - 1, 1] = null;
            tasks[taskCount - 1, 2] = null;

            taskCount--;
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}