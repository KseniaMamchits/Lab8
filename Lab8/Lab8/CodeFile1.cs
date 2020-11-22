using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{
    abstract class Exam
    {
        protected string Name;
        protected byte Mark;

        public Exam(string Name, byte Mark)
        {
            this.Name = Name;
            this.Mark = Mark;
        }

        public abstract void Move();
    }

    class FinalExam : Exam
    {
        string specialty;

        public FinalExam(string specialty, string Name, byte Mark) : base(Name, Mark)
        {
            this.specialty = specialty;
        }

        public override void Move()
        {
            Console.WriteLine("Выпускной экзамены для специальности " + specialty + ": " + Name + ". Проходной балл: " + Mark);
        }
        public void Show()
        {
 
            Console.WriteLine("Специальность: " + specialty + "\n" + "Cтудент: " + Name+" "+Mark);
        }
    }
    
    interface IGeneralized<T>
    {
        void Add(T elem);
        void Remove(T elem);
        void Show(Set<T> elems);
    }
    public class Exceptionist : Exception
    {
        public Exceptionist(string message) : base(message)
        {

        }
    }
    public class Set<T> : IGeneralized<T>
    { 
        public List<T> Items = new List<T>();

        public void Add(T item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }
       

        public void Remove(T item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else
            {
                throw new Exceptionist("элемента не существует, невозможно удалить");
            }
        }

        public void Show(Set<T> Item)
        {
            foreach (T elem in Item.Items)
            {
                Console.Write($"{elem}  ");
            }
            Console.WriteLine();
        }
        public static int count;
        public Set()
        {
            Console.WriteLine($"Создано множество");
        }
        public static Set<T> operator ++(Set<T> item11)
        {
            Random run = new Random();
            int val = run.Next(-2, 12);
            List<T> item111 = new List<T>();
            foreach (T elem in item11.Items)
            {
                item111.Add(elem);
            }
            foreach (T elems in item111)
            {
                Console.WriteLine(elems);
            }
            Console.WriteLine(val);
            return null;
        }
        public static string operator >=(Set<T> item1, Set<T> item2)
        {
            System.Collections.IList list = item1.Items;
            System.Collections.IList list2 = item2.Items;
            if (list.Count >= list2.Count)
            {
                Console.WriteLine("Множество 1 больше множества 2");
            }
            else
            {
                Console.WriteLine("Множество 1 меньше множества 2");
            }
            return null;
        }
        public static string operator <=(Set<T> item1, Set<T> item2)
        {
            System.Collections.IList list = item1.Items;
            System.Collections.IList list2 = item2.Items;
            if (list.Count <= list2.Count)
            {
                Console.WriteLine("Множество 1 меньше множества 2");
            }
            else
            {
                Console.WriteLine("Множество 1 больше множества 2");
            }
            return null;
        }
        public static string operator *(Set<T> item1, Set<T> item2)//мощность множеств
        {
            System.Collections.IList list = item1.Items;
            System.Collections.IList list2 = item2.Items;
            Console.WriteLine("Мощность множества 1 - " + list.Count);
            Console.WriteLine("Мощность множества 2 - " + list2.Count);
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Set<int> obj1 = new Set<int>();
                obj1.Add(-5);
                obj1.Add(3);
                obj1.Add(-2);
                obj1.Add(7);
                obj1.Add(3);
                obj1.Add(-1);
                obj1.Show(obj1);
                Set<double> obj11 = new Set<double>();
                obj11.Add(-5);
                obj11.Add(3.6);
                obj11.Add(-2);
                obj11.Add(7.89);
                obj11.Show(obj11);
                Console.WriteLine(++obj11);
                Set<FinalExam> obj2 = new Set<FinalExam>();
                FinalExam a1, a2, a3;
                a3 = new FinalExam("Дэиви", "Миронова", 9);
                a2 = new FinalExam("Поит","Гридин", 8);
                a1 = new FinalExam("Исит", "Иванов",6);
                obj2.Add(a1);
                obj2.Add(a2);
                obj2.Add(a3);
                a1.Show();
                a2.Show();
                a3.Show();

            }
            catch (Exceptionist ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("конец");
            }
        }
    }
}
