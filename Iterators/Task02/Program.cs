using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
В основной программе объявите и инициализируйте одномерный строковый массив 
и выполните циклический перебор его элементов с разных «начальных точек», 
разделяя элементы одним пробелом.

Тестирование приложения выполняется путем запуска разных наборов тестов.
На вход в первой строке поступает число - номер элемента, начиная с которого 
пойдет циклический перебор.
В следующей строке указаны элементы последовательности, разделенные одним или 
несколькими пробелами.
3
1 2 3 4 5
Программа должна вывести на экран:
3 4 5 1 2

В случае ввода некорректных данных выбрасывайте ArgumentException.

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.

 */
namespace Task02
{
    class IteratorSample
    {
        string[] values;
        int start;

        public IteratorSample(string[] values, int start)
        {
            foreach (string el in values)
                if (!int.TryParse(el, out _))
                    throw new ArgumentException();

            this.values = values;
            this.start = start;
        }

        public IEnumerator<string> GetEnumerator()
        {
            List<string> vals = new List<string>();
            for (int el = start - 1; el < values.Length; ++el)
                vals.Add(values[el]);
            for (int el = 0; el < start - 1; ++el)
                vals.Add(values[el]);
            foreach (string val in vals)
                yield return val;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int startingIndex;
                int.TryParse(Console.ReadLine(), out startingIndex);
                string[] values = Console.ReadLine().Split();

                foreach (string ob in new IteratorSample(values, startingIndex))
                    Console.Write(ob + " ");
                Console.WriteLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("error");
            }
            catch (Exception e)
            {
                Console.WriteLine("problem");
            }

            Console.ReadLine();
        }
    }
}
