using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<int>();

            for(var i = 0; i<10;i++)
            {
                collection.Add(i);
            }
            //1-ый linq запрос
            var result = from item in collection//для итем в колекции
                         where item < 5//где каждый итем меньше 5
                         select item;//отберем его в коллекию 
            var result2 = collection.Where(item => item < 5);//аналогичная тому что выше,но ввиде метода Where
                                                             // принимающий предикат возращающие значение bool(т.е задаем условие)

            var result3 = collection.Select(t => t < 5 ? "kek":"cheburek");//по выбранному объекту из коллецкции возращает от объекта его экземпляр или его поля/возращаемые значения методов
            var result4 = collection.OrderBy( k => 6);//сортирует по ключу(инту)
            var result5 = collection.OrderBy(k => k);
            var result6 = collection.GroupBy(k=>k < 5);//разделит на две группы , те что меньше 5 и те что больше или равно 5 
            //var result6 = collection.GroupBy(k=>k.Energy); //разделит на группы по параметру Energy.            foreach (var group in result6)
            foreach(var group in result6)
            {
                Console.WriteLine("Key "+group.Key);
                
                foreach(var item in group)
                {
                    Console.WriteLine("Item "+item);
                }
            }
            
            output<int>(result);
            output<int>(result);
            var item_int = 5;
            Console.WriteLine(collection.All(k=>k<20));//Проверяет все ли элименты задают условию .Будет True
            Console.WriteLine(collection.Any(k => k > 20));//Проверяет есть ли хотя бы один элемент удовлет заданному условию .Будет False
            Console.WriteLine(collection.Contains(item_int));//входит ли объект 5-ка в этот список
            var array = new String[] { "kek", "privet", "kek", " dela " };
            var array1 = new int[] { 1, 2, 3, 4 };
            var array2 = new int[] { 1, 2, 3, 6 };
            var union = array1.Union(array2);//объединяет массивы-множества a\/b
            var intersect = array1.Intersect(array2);//ищет пересечения массивов множест a/\b
            var except = array1.Except(array2);//разность двух мн-в a\b
            var sum = array.Sum(k=>k.Length);//суммирует кол-во символов во всех строках массива

            var min = array1.Min(k=>k);
            var max = array1.Max(k => k);

            //Реализуем 4! через агрегейт 

            var aggregate = array1.Aggregate((k,y) => k*y);//аналогична операции 1*2*3*4
            
            Console.WriteLine("4! = " + aggregate);
            aggregate = array1.Aggregate((k, y) => y - k);//аналогична операции 4-(3-(2-1))
            Console.WriteLine("(4-(3-(2-1))) = " + aggregate);
            aggregate = array1.Aggregate((k, y) => -k+y);//аналогична операции 4-(3-(2-1))
            Console.WriteLine("(4-(3-(2-1))) = " + aggregate);
            aggregate = array1.Aggregate((k, y) => k - y);//аналогична операции 1-2-3-4
            Console.WriteLine("1-2-3-4 = " + aggregate);
            Console.WriteLine(sum);
            Console.WriteLine(array1.Skip(1).Take(2).Sum());

            var first = array.First(k => k=="kek");//необходимо чтобы объект не был пустым иначе выкенет эксепшон

            //var elementAt = array.ElementAt(5);
            var dic = array1.ToDictionary(k => k);
            //var dic = array1.ToDictionary(k => k);
            foreach (var t in dic)
            {
                Console.WriteLine("Key " + t.Key);
                Console.WriteLine("Value " + t.Value);
            }
            first = array.FirstOrDefault();//в случае пустого листа возращает null или 0;

            //var single = array.Single(k=>k=="kek");//вылетит эксепшон т.к два объекта одинаковых.
            var single = array.Single(k => k == "privet");
            foreach (var t in union)
            {
                Console.WriteLine(t);
            }
        }
        
        static void output<T>(IEnumerable<T> ts)
        {


        }

        
    }


}
