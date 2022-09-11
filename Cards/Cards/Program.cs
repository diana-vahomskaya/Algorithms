using System;
public class Programm
{
    static int count;
    static int[] numbers;
    static int PSum;
    static int VSUm;

    public static void Main(string[] args)
    {
        count = Convert.ToInt16(Console.ReadLine());
        numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
        PSum = 0;
        VSUm = 0;
        for (int i = 0; i < count; i += 3)
        {
            PSum += numbers[i];
            VSUm += numbers[i + 1];

            if (numbers[i] < numbers[i + 1])
                PSum += numbers[i + 2];
            else
                VSUm += numbers[i + 2];
        }
        if (VSUm > PSum)
        {
            Console.WriteLine("Vasya");
        }
        else
        {
            Console.WriteLine("Petya");
        }
    }
}