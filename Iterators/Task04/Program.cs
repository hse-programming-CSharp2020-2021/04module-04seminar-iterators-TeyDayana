using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value;
                if (!int.TryParse(Console.ReadLine(), out value))
                    throw new ArgumentException();
                MyInts myInts = new MyInts();
                IEnumerator enumerator = myInts.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
                enumerator.Reset();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                Console.WriteLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
                Console.Write(enumerator.Current + " ");
        }
    }

    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        public int quant;
        int number = 0;

        public MyInts() { }
        public MyInts(int val)
        { quant = val; }

        public IEnumerator MyEnumerator(int val) => new MyInts(val);

        public bool MoveNext()
        {
            if (number > quant - 1) return false;
            ++number; return true;
        }

        public void Reset()
        { number = 0; }

        public object Current
        { get => number * number; }
    }
}
