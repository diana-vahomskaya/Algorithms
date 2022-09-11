﻿//Последовательность точек на плоскости называется тривиальной, если она является строго упорядоченной по возрастанию или по убыванию
//расстояния до одной из точек этой последовательности. Последовательность точек в трёхмерном пространстве называется хорошей,
//если ни одна из последовательностей, полученных взятием проекции исходной на одну из базовых плоскостей (Oxy, Oyz и Oxz), не является тривиальной.
//Дана последовательность из n точек с целочисленными координатами в трёхмерном пространстве. Необходимо найти такую нечётную перестановку её индексов,
//что после её применения последовательность становится хорошей.
//Гарантируется, что решение существует.

//В первой строке входных данных записано целое число n (3≤n≤1000), в следующих n строчках через пробел записаны по три целочисленных координаты 
//xi yi zi (−104≤xi,yi,zi≤104) каждой из точек.Гарантируется, что проекции всех точек на любую из базовых плоскостей различны.

//Выведите n чисел: искомая перестановка индексов от 1 до n. Если существует несколько решений, выведите любое из них. Числа в строке следует разделять пробелами.

//Ввод               Вывод
//4                  1 2 4 3
//1 1 1
//2 4 16
//3 9 81
//4 16 256

using System;
using System.Linq;

namespace Point
{
    public class Programm
    {
        public static void Main()
        {
            int count_points = 0;
            count_points = Int32.Parse(Console.ReadLine());
            Point[] coord = new Point[count_points];
            for (int i = 0; i < count_points; i++)
            {
                var points = Console.ReadLine().Split(' ');
                coord[i]= new Point(int.Parse(points[0]), int.Parse(points[1]), int.Parse(points[2]));
            }
        }
    }
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}