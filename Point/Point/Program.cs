//Последовательность точек на плоскости называется тривиальной, если она является строго упорядоченной по возрастанию или по убыванию
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

        public static int swap_count = 0;
        public static int FindMaxMobileElement(Point[] perm, int[] direction)
        {
            int index = -1;
            for (int i = 0; i < perm.Length; i++)
            {
                int next_elem_index = i + direction[i];
                if (next_elem_index >= 0 && next_elem_index < perm.Length)
                {
                    if (perm[i].index > perm[next_elem_index].index)
                    {
                        if (index == -1)
                        {
                            index = i;
                        }
                        else
                        {
                            if (perm[i].index > perm[index].index)
                                index = i;
                        }
                    }
                }
            }
            return index;
        }

        public static void ChangeDirection(Point[] perm, int[] direction, int MobileELement)
        {
            for (int i = 0; i < perm.Length; i++)
            {
                if (perm[i].index > MobileELement)
                {
                    direction[i] = direction[i] * (-1);
                }
            }
        }
        public static void swap(Point[] array, int[] direct, int i, int j)
        {
            Point permtmp = array[i];
            array[i] = array[j];
            array[j] = permtmp;

            int directtmp = direct[i];
            direct[i] = direct[j];
            direct[j] = directtmp;
            swap_count++;
        }
        public static void PermGen(int n, Point[] array)
        {
            int[] direct = new int[n];
            for (int i = 0; i < direct.Length; i++)
            {
                direct[i] = -1;
            }
            int mobileElemntIndex = FindMaxMobileElement(array, direct);
            while (mobileElemntIndex != -1)
            {
                int mobilElement = array[mobileElemntIndex].index;
                int nextIndex = mobileElemntIndex + direct[mobileElemntIndex];
                swap(array, direct, mobileElemntIndex, nextIndex);
                ChangeDirection(array, direct, mobilElement);
                if (swap_count % 2 != 0)
                {
                    if (TrivialityUp(array) && TrivialityDown(array)) 
                    {
                        Console.WriteLine(string.Join(" ", array.Select(x => x.index)));
                        break; 
                    }
                    
                }
                mobileElemntIndex = FindMaxMobileElement(array, direct);
            }

        }
        public static double Distance(int x1, int x2, int y1, int y2)
        {
            var distance = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            return distance;
        }

        ///Функция проверки точек на тривиальность на три плоскости Ox, Oy, Oz: точнее на то, что последовательность стала не тривиальной
        private static bool TrivialityUp(Point[] array)
        {
            double last_x = 0;
            double last_y = 0;
            double last_z = 0;

            var Oxy = false;
            var Oyz = false;
            var Oxz = false;

            for (int i = 1; i < array.Length; ++i)
            {
                double distance_x = Distance(array[0].x, array[i].x, array[0].y, array[i].y);
                double distance_y = Distance(array[0].y, array[i].y, array[0].z, array[i].z);
                double distance_z = Distance(array[0].x, array[i].x, array[0].z, array[i].z);

                if (distance_x <= last_x)
                {
                    Oxy = true;
                }
                if(distance_y <= last_y)
                {
                    Oyz = true;
                }
                if(distance_z <= last_z)
                {
                    Oxz = true;
                }

                if(Oxy == true && Oyz == true && Oxz == true)
                {
                    return true;
                }
                last_x = distance_x;
                last_y = distance_y;
                last_z = distance_z;
            }

            return false;
        }
        private static bool TrivialityDown(Point[] array )
        {
            double last_x = 0;
            double last_y = 0;
            double last_z = 0;

            var Oxy = false;
            var Oyz = false;
            var Oxz = false;

            for (int i = array.Length - 2; i >= 0; --i)
            {
                double distance_x = Distance(array[array.Length - 1].x, array[i].x, array[array.Length - 1].y, array[i].y);
                double distance_y = Distance(array[array.Length - 1].y, array[i].y, array[array.Length - 1].z, array[i].z);
                double distance_z = Distance(array[array.Length - 1].x, array[i].x, array[array.Length - 1].z, array[i].z);

                if (distance_x <= last_x)
                {
                    Oxy = true;
                }
                if (distance_y <= last_y)
                {
                    Oyz = true;
                }
                if (distance_z <= last_z)
                {
                    Oxz = true;
                }

                if (Oxy == true && Oyz == true && Oxz == true)
                {
                    return true;
                }
                last_x = distance_x;
                last_y = distance_y;
                last_z = distance_z;
            }

            return false;
        }

       
        public static void Main()
        {
            int count_points = Int32.Parse(Console.ReadLine());
            Point[] coord = new Point[count_points];
            for (int i = 0; i < count_points; i++)
            {
                var points = Console.ReadLine().Split(' ');
                coord[i]= new Point(int.Parse(points[0]), int.Parse(points[1]), int.Parse(points[2]), i + 1);
            }
            PermGen(count_points, coord);
        }
    }
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        public int index { get; set; }
        public Point(int x, int y, int z, int index)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.index = index;
        }
    }
}