using System;
using System.Collections;

/* На вход подается число N.
 * На каждой из следующих N строках записаны ФИО человека, 
 * разделенные одним пробелом. Отчество может отсутствовать.
 * Используя собственноручно написанный итератор, выведите имена людей,
 * отсортированные в лексико-графическом порядке в формате 
 *      <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>.
 * Затем выведите имена людей в исходном порядке.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield.
 * 
 * Пример входных данных:
 * 3
 * Banana Bill Bananovich
 * Apple Alex Applovich
 * Carrot Clark Carrotovich
 * 
 * Пример выходных данных:
 * Apple A.
 * Banana B.
 * Carrot C.
 * 
 * Banana B.
 * Apple A.
 * Carrot C.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int N;
                if (!int.TryParse(Console.ReadLine(), out N))
                    throw new ArgumentException();
                Person[] people = new Person[N];
                for (int pers = 0; pers < N; ++pers)
                {
                    string[] info = Console.ReadLine().Split();
                    if (info.Length < 2) throw new ArgumentException();
                    people[pers] = new Person(info[0], info[1]);
                }
                People peopleList = new People(people);

                foreach (Person p in peopleList)
                    Console.WriteLine(p);
                Console.WriteLine();
                foreach (Person p in peopleList.GetPeople)
                    Console.WriteLine(p);
            }
            catch (ArgumentException)
            { Console.Write("error"); }
            catch (Exception)
            { Console.Write("error"); }
        }
    }

    public class Person
    {
        public string firstName;
        public string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString() => firstName + " " + lastName[0] + ".";
    }


    public class People : IEnumerable
    {
        private Person[] _people;
        public Person[] GetPeople
        { get => _people; }

        public People(Person[] people)
        { _people = people; }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public PeopleEnum GetEnumerator() => new PeopleEnum(_people);
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        int position = -1;

        public PeopleEnum(Person[] people)
        {
            int n = people.Length;
            Person[] peopleNew = new Person[n];
            for (int p = 0; p < n; ++p)
                peopleNew[p] = people[p];

            Array.Sort(peopleNew, (x, y) =>
            {
                string xInfo = x.ToString();
                string yInfo = y.ToString();

                if (xInfo.Length < yInfo.Length)
                    for (int sp = 0; sp < yInfo.Length - xInfo.Length; ++sp)
                        xInfo += " ";

                if (yInfo.Length < xInfo.Length)
                    for (int sp = 0; sp < xInfo.Length - yInfo.Length; ++sp)
                        yInfo += " ";

                for (int s = 0; s < xInfo.Length; ++s)
                {
                    if (xInfo[s] > yInfo[s]) return 1;
                    if (xInfo[s] < yInfo[s]) return -1;
                }

                return 0;
            });
            _people = peopleNew;
        }

        public bool MoveNext()
        {
            if (position < _people.Length - 1)
            { ++position; return true; }

            return false;
        }

        public void Reset()
        { position = -1; }

        public object Current
        { get => _people[position]; }
    }
}
