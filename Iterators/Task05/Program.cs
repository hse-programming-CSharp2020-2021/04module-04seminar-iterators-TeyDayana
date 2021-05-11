using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
 * и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе.
 * Элементы коллекции разделять пробелом. 
 * Очередной вывод коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 2
 * 
 * Пример выходных данных:
 * 1 1024
 * 1024 1
 * 1 1024
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int value;
                if (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                    throw new ArgumentException();
                MyDigits myDigits = new MyDigits();
                MyDigits2 myDigits2 = new MyDigits2();
                IEnumerator enumerator = myDigits.MyEnumerator(value);
                IEnumerator enumerator2 = myDigits2.MyEnumerator(value);

                IterateThroughEnumeratorWithoutUsingForeach(enumerator, value);
                Console.WriteLine();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator2, value);
                Console.WriteLine();
                enumerator.Reset();
                IterateThroughEnumeratorWithoutUsingForeach(enumerator, value);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator, int value)
        {
            int num = 0;
            while (enumerator.MoveNext())
            {
                Console.Write(enumerator.Current);
                ++num;
                if (num != value)
                    Console.Write(" ");
            }
        }
    }

    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        public int quant;
        int number = 0;

        public MyDigits() { }
        public MyDigits(int val)
        { quant = val; }

        public IEnumerator MyEnumerator(int val) => new MyDigits(val);

        public bool MoveNext()
        {
            if (number > quant - 1) return false;
            ++number; return true;
        }

        public void Reset()
        { number = 0; }

        public object Current
        { get => Math.Pow(number, 10); }
    }

    class MyDigits2 : IEnumerator
    {
        int number;

        public MyDigits2() { }
        public MyDigits2(int val)
        { number = val + 1; }

        public IEnumerator MyEnumerator(int val) => new MyDigits2(val);

        public bool MoveNext()
        {
            if (number <= 1) return false;
            --number; return true;
        }

        public void Reset()
        { number = int.MaxValue; }

        public object Current
        { get => Math.Pow(number, 10); }
    }
}
