using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// http://ejudge.1gb.ru/cgi-bin/new-register?contest_id=9
/// E-Number Series
/// 
/// По каналу связи передаётся последовательность положительных целых чисел, все числа не превышают 1000.
/// Количество чисел известно, но может быть очень велико.
/// Затем передаётся контрольное значение последовательности - наибольшее число R, удовлетворяющее следующим условиям: 
/// 1)	R - произведение двух различных переданных элементов последовательности
/// («различные» означает, что не рассматриваются квадраты переданных чисел, произведения различных элементов последовательности, равных по величине, допускаются);
/// 2)	R делится на 22.
/// Если такого числа R нет, то контрольное значение полагается равным 0.
/// В результате помех при передаче как сами числа, так и контрольное значение могут быть искажены.
/// Напишите эффективную, в том числе по используемой памяти, программу, которая будет проверять правильность контрольного значения.
/// Программа должна напечатать отчёт по следующей форме:
/// CONTROL: <> TRUE - Если контроль пройден(или- FALSE - если контроль не пройден)
/// 
/// На вход программе в первой строке подаётся количество чисел N.
/// В каждой из последующих N строк записано одно натуральное число, не превышающее 1000.
/// В последней строке записано контрольное значение.
/// </summary>
namespace E_Number_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prepare console
            Console.ForegroundColor = ConsoleColor.Green;

            // read line count
            int n = Int32.Parse(Console.ReadLine());

            // create and initialize empty array
            int[] numbers = new int[n];
            
            // Fill array of numbers
            for (int i = 0; i < n; i++)
                numbers[i] = Int32.Parse(Console.ReadLine());

            // read Control number
            int iControl = Int32.Parse(Console.ReadLine());

            // create Control status
            bool bControl = false;
            
            // Check if Control = 0;
            if (iControl == 0) bControl = true;

            // Check Control value and Control status
            if (!bControl && iControl % 22 == 0)
                for (int i = 0; i < n && !bControl; i++)
                    for (int j = 0; j < n && !bControl && i != j; j++)
                        if (numbers[i] * numbers[j] == iControl) bControl = true;

            // print out result in requested format
            Console.WriteLine($"CONTROL: {bControl.ToString().ToUpper()}");
            
            Console.ReadKey();
        }
    }
}
