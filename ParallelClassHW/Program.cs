using System;
using System.Text;

namespace ParallelClassHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Parallel.For(4, 20, Factorial);
            //Parallel.For(4, 8, TableMulti);
            
            List<int> nums = new List<int>();
            nums.Sum(x => x);
            foreach (string i in File.ReadLines("num.txt"))
            {
                int num;
                if(int.TryParse(i,out num))
                    nums.Add(num);
            }
            //Parallel.ForEach(nums, Fact);
            var res = nums.AsParallel().Sum(n => n);
            Console.WriteLine($"Summa = {res}");
            var res1 = nums.AsParallel().Min(n => n);
            Console.WriteLine($"Minimum = {res1}");
            var res2 = nums.AsParallel().Max(n => n);
            Console.WriteLine($"Maximum = {res2}");

            Console.ReadLine();

        }
        static void Factorial(int num)
        {
            long i = 1;
            for (int j = 1; j <= num; j++)
            {
                i *= j;
            }
            Console.WriteLine($"Factorial {num} = {i}");
            Parallel.Invoke(
                () => AmountNums(i),
                () => SummDigits(i));            
        }
        static void AmountNums(long num)
        {
             int amount_digit = num.ToString().Length; 
            Console.WriteLine($"Amount nums {num} = {amount_digit}"); 
        }
        static void SummDigits(long num)
        {
            long res = num;
            long sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine($"Summ digits {res} = {sum}");
        }
        static void TableMulti(int num)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
        }
        static void Fact(int x)
        {
            long i = 1;
            for (int j = 1; j <= x; j++)
            {
                i *= j;
            }
            Console.WriteLine($"Factorial {x} = {i}");
        }
    }
}
