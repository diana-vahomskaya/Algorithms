//Даны k перестановок из n элементов, каждая из которых принадлежит к одному из m типов.
//Посчитайте позицию первого элемента, если последовательно применить эти k перестановок, убрав одну из них.

//Формат ввода
//В первой строке входных данных заданы числа n и m (1≤n≤100,1≤m≤100).В следующих 
//m строках записано по n чисел. i-е число описывает позицию, на которую нужно переставить i-й элемент.
//В следующей строке записано число k (1≤k≤5⋅10^4)). В следующей строке записаны 
//k чисел от 1 до m — типы перестановок в начальном наборе.

//Формат вывода
//Для каждой из k перестановок выведите в отдельной строке позицию первого элемента, если последовательно применить все остальные перестановки.

//Ввод                 Вывод         
//3 2                  3
//1 3 2                1
//2 3 1                2
//3
//1 2 1

//Ввод                 Вывод
//2 2                  2
//1 2                  1
//2 1                  2
//3
//1 2 1

//Ввод                 Вывод
//1 1                  1
//1                   
//1                   
//1

using System;
using System.IO;
using System.Numerics;

namespace One
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] paramNM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse); // первая строка состоящая из n (кол-во элементов) и m (кол-во типов)
            List<List<int>> Perm_M = new List<List<int>>();
            for (int i = 0; i < paramNM[1]; i++)
            {
                Perm_M.Add(Console.ReadLine().Split(' ').Select(s => int.Parse(s) - 1).ToList());
            }
            Console.ReadLine();
            int[] queueK = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s) - 1); // порядок применения перестановок
            List<List<int>> Perm_K = new List<List<int>>();
            for (int i = 0; i < queueK.Length; i++)
            {
                if (i == 0) Perm_K.Add(Perm_M[queueK[i]]);
                else Perm_K.Add(Permutations_Multiply(Perm_K[i - 1], Perm_M[queueK[i]]));
            }
            for(int i = 0; i < queueK.Length; i++)
            {
                List<int> reverse = new List<int>(Permutation_Reverse(Perm_K[i]));
                List<int> remove = new List<int>(Permutations_Multiply(reverse, Perm_K[queueK.Length - 1]));

                if (i == 0) Console.WriteLine(remove[0] + 1);
                else
                {
                    Console.WriteLine(Permutations_Multiply(Perm_K[i - 1], remove)[0] + 1);
                }
            }
        }
        public static List<int> Permutation_Reverse(List<int>one)
        {
            List<int> result = new List<int>(new int[one.Count]);
            for(int i = 0; i < one.Count; i++)
            {
                result[one[i]] = i;
            }
            return result;
        }
        public static List<int> Permutations_Multiply(List<int> one, List<int> two)
        {
            List<int> perm = new List<int>();
            for(int i = 0; i < one.Count; i++)
            {
                perm.Add(two[one[i]]);
            }
            return perm;
        }
    }
}
