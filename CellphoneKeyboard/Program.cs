namespace keyboard;

public class Program
{
    public static void Main()
    {
        keyboard obj = new keyboard();

        obj.Hello();
        obj.SetUserInput(Console.ReadLine());
        obj.ProcessingDictionary();
        obj.FinalOutput();
    }
}