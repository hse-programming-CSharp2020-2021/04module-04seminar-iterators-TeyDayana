using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Необходимо построить ряд чисел Фибоначчи, ограниченный числом, введенным с клавиатуры.
 * 
 * Пример входных данных:
 * 6
 * Пример выходных данных:
 * 1 1 2 3 5
 * Пояснение:
 * следующее число 3 + 5 = 8 не выводится на экран, так как 8 > 6.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * 
*/
namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (int el in Fibonacci(int.Parse(Console.ReadLine())))
                {
                    Console.Write(el + " ");
                }
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }
        }

        public static IEnumerable<int> Fibonacci(int maxValue)
        {
            if (maxValue <= 0) throw new ArgumentException();

            List<int> nums = new List<int>();
            nums.Add(1); nums.Add(1);
            while (nums[nums.Count - 1] < maxValue)
                nums.Add(nums[nums.Count - 1] + nums[nums.Count - 2]);

            if (nums[nums.Count - 1] > maxValue)
                nums.RemoveAt(nums.Count - 1);

            foreach (int num in nums)
                yield return num;
        }
    }
}
