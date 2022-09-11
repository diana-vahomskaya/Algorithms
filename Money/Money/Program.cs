﻿// Программист Петя очень любит складывать все имеющиеся у него деньги в кошельки и фиксировать, 
// сколько денег лежит в каждом кошельке. Для этого он сохраняет в файле набор целых положительных 
// чисел — количество денег, которое лежит в каждом из его кошельков (Петя не любит, когда хотя бы 
// один из его кошельков пустует). Петя хранит все деньги в монетах, номинал каждой монеты — 1 условная 
// единица.
// 
// Однажды у Пети сломался блок магнитных головок и ему пришлось восстанавливать данные с жесткого диска. 
// Он хочет проверить, корректно ли восстановились данные, и просит вас убедиться, что можно ту сумму денег, 
// которая у него была, разложить во все его кошельки, чтобы получились те же числа, что и в восстановленном 
// файле.

// Формат ввода
// В первой строке выходных данных содержится натуральное число n(1≤n≤100) — количество кошельков у Пети.
// Во второй строке через пробел записаны данные из восстановленного файла: n натуральных чисел ai, 
// каждое из которых означает, сколько денег лежит в i-м кошельке у Пети (1≤ai≤100).
// В третьей строке записано натуральное число m(1≤m≤10^4) — общая сумма денег, которая была 
// у Пети до того, как он разложил её по кошелькам.

// Пример 1
// Ввод 	Вывод
// 2        Yes
// 2 3
// 5

// Пример 2
// Ввод 	Вывод
// 2		No
// 2 3
// 4

// Пример 3
// Ввод 	Вывод
// 2		Yes
// 2 3
// 3

// Примечания
// В первом примере у Пети есть два кошелька, в первом лежат две монеты, во втором — три.
// Конфигурации, приведенной во втором примере, не может существовать, поэтому файл восстановлен некорректно.
// В третьем примере предложенная конфигурация возможна: во втором кошельке лежит одна монета и первый кошелёк, 
// внутри которого лежат две монеты. 



using System;

namespace Money
{
    public class Programm
    {
        public static void Main()
        {
            int Num_Wallets = 0; //переменная для кол-ва кошельков, первая строка
            int[] Money; // массив данных о том сколько денег лежит в итом кошельке, вторая строка
            int SumMoney = 0; // общая сумма денег, которая была у пети до того как он разложил ее по кошелькам
            int count = 0; // подсчет массива данных о монетах вторая строка
            Num_Wallets = Int32.Parse(Console.ReadLine()); //чтение с экрана кол-ва кошельков
            Money = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();// чтение данных о монетах
            SumMoney = Int32.Parse(Console.ReadLine());// чтение общей суммы денег
            count = Money.Sum();

            if(count < SumMoney) // если сумма подсчитанных монет меньше чем общее кол-во денег то возврат нет, т.к. такого быть не может
            {
                Console.WriteLine("No"); return;
            }
            else if(count == SumMoney) // если сумма подсчитанных монет = общее кол - во денег то возврат yes
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.Write(CheckWalletsIn(SumMoney, Money, count, 0) ? "Yes" : "No");
            }
        }

        /// <summary>
        /// Проверить распределение денег по кошелькам
        /// </summary>
        /// <param name="SumMoney">Общее количество денег</param>
        /// <param name="Money">Кошельки</param>
        /// <param name="count">Максимально возможное количество денег во всех кошельках</param>
        /// <param name="countWallAll">Индекс кошелька</param>
        /// <returns></returns>
        private static bool CheckWalletsIn(int SumMoney, int[] Money, int count, int countWallAll) 
        {
            if(countWallAll == Money.Length || count < SumMoney)
            {
                return false;
            }
            // еще пара условий, но пока не пойму условие задачи.
            return true;
        }
    }
}