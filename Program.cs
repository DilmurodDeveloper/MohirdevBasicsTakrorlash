using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- Vazifa menejeri ---");
            Console.WriteLine("1. Vazifalar ro'yxatini ko'rish");
            Console.WriteLine("2. Yangi vazifalarni qo'shish");
            Console.WriteLine("3. Vazifani bajarilgan deb belgilash");
            Console.WriteLine("4. Vazifani o'chirish");
            Console.WriteLine("5. Dasturdan chiqish");
            Console.WriteLine("\nTanlovingizni kiriting (1-5): ");

            string tanlash = Console.ReadLine();

            switch (tanlash)
            {
                case "1":
                    ShowTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    MarkTaskDone();
                    break;  
                case "4":
                    RemoveTask();
                    break;  
                case "5":
                    Console.WriteLine("Dastur tugatildi.");
                    return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov. Qaytadan buyruq kiriting.");
                    break;
            }
        }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Hech qanday vazifa yo'q.");
        }
        else
        {
            Console.WriteLine("\nVazifalar ro'yxati: ");
            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsDone ? "Bajarilgan" : "Bajarilmagan";
                Console.WriteLine($"{i+1}.{tasks[i].Name} - {status}");  
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Vazifa nomini kiriting: ");
        string taskName = Console.ReadLine();
        tasks.Add(new Task(taskName));
        Console.WriteLine($"Vazifa '{taskName}' qoshildi.");
    }

    static void MarkTaskDone()
    {
        ShowTasks();
        if (tasks.Count == 0) return;

        Console.Write("\nBajarilgan vazifa raqamini kiriting: ");
        if (int.TryParse(Console.ReadLine(), out int taskNum) && taskNum > 0 && taskNum <= tasks.Count)
        {
            tasks[taskNum - 1].IsDone = true;
            Console.WriteLine($"Vazifa '{tasks[taskNum - 1].Name}' bajarilgan deb belgilandi.");
        }
        else
        {
            Console.WriteLine("Noto'g'ri raqam kiritildi.");
        }
    }

    static void RemoveTask()
    {
        ShowTasks();
        if (tasks.Count == 0) return;

        Console.Write("\nO'chiriladigan vazifa raqamini kiriting: ");
        if (int.TryParse(Console.ReadLine(), out int taskNum) && taskNum > 0 && taskNum <= tasks.Count)
        {
            string removedTask = tasks[taskNum-1].Name;
            tasks.RemoveAt(taskNum - 1);
            Console.WriteLine($"Vazifa '{removedTask}' o'chirildi.");
        }
        else
        {
            Console.WriteLine("Noto'g'ri raqam kiritildi.");
        }
    }
}

class Task
{
    public string Name { get; set; }
    public bool IsDone { get; set; }

    public Task(string name)
    {
        Name = name;
        IsDone = false;
    }
}