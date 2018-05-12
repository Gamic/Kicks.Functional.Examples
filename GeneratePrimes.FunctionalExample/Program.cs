using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePrimes.FunctionalExample {
    class Program {
        static int Inc(int i) => i + 1;
        static int StartValue = 2;
        static int NumberToGet = 20;
        static void Main(string[] args) => 
            Sieves(Iterate(Inc, StartValue))
                .Take(NumberToGet)
                .ForEach(Console.WriteLine)
                .ForEach(x => Console.WriteLine("Press To Continue"))
                .ForEach(x => Console.ReadLine())
                .ToList();

        static IEnumerable<int> Iterate(Func<int, int> it, int val) {
            while (true) {
                yield return val;
                val = it(val);
            }
        }
        static IEnumerable<int> Sieves(IEnumerable<int> ints) {
            while (true) {
                var p = ints.First();
                yield return p;
                ints = ints.Where(n => n % p != 0);
            }
        }

    }
    public static class Extension {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> arr, Action<T> act) {
            foreach (var item in arr) {
                act(item);
                yield return item;
            }
        }
    }
}
