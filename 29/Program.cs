using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        MyClass obj = new MyClass();

        Console.WriteLine("Введіть назву методу для виклику  (наприклад, Print):");
        string methodName = Console.ReadLine();

        Console.WriteLine("Введіть параметр для методу:");
        string input = Console.ReadLine();

        Console.WriteLine("Виберіть колір тексту (Black, Blue, Cyan, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, DarkRed, DarkYellow, Gray, Green, Magenta, Red, White, Yellow):");
        string color = Console.ReadLine();

        ConsoleColor consoleColor;
        if (Enum.TryParse(color, true, out consoleColor))
        {
            Console.ForegroundColor = consoleColor;

            
            MethodInfo methodInfo = obj.GetType().GetMethod(methodName);
            if (methodInfo != null)
            {
                methodInfo.Invoke(obj, new object[] { input });
            }
            else
            {
                Console.WriteLine("Метод з такою назвою не знайдено!");
            }

            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("Невірний колір!");
        }
    }
}

public class MyClass
{
    public void Print(string message)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine(message);
    }
}
