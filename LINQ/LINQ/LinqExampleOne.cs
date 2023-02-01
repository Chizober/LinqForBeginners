namespace LINQ
{
    public partial class LinqExamples
    {
        public void linqExample1()
        {
            int[] num1 = { 5, 4, 1, 3, 9, 8 };
            var answer = from num in num1 where num > 4 select num;
            foreach (var n in answer)
            {
                Console.WriteLine($"\n\t{n} are greater than 4");
            }
        }

        public void linqExample2()
        {
            // multiple select
            int[] num2 = { 0, 2, 4, 5, 6, 8, 9 };
            int[] num3 = { 1, 3, 5, 8 };
            var pairs = from a in num2 from b in num3 where a < b select new { a, b };
            foreach (var pair in pairs)
            {
                Console.WriteLine(
                    $"\n\t{pair.a} in the first array is lesser than {pair.b} in the second array\n"
                );
            }
        }

        public void linqExample3()
        {
            // Order by
            string[] words = { "Cherry", "Apple", "Blueberry" };
            var sortedWords = from w in words orderby w select w;
            Console.WriteLine("\n\tSorted words using Order by");
            foreach (var w in sortedWords)
            {
                Console.WriteLine($"\n\t{w}");
            }

            Console.WriteLine("\n\tCount Function");
            int[] num4 = { 5, 6, 5, 7, 5, 3, 6 };
            int uniqueNums = num4.Distinct().Count();
            Console.WriteLine($"\n\tThere are {uniqueNums} unique numbers\n");

            //OR
            int[] num5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 10, 12 };
            int evenNumbers = num5.Count(n => n % 2 == 0);

            Console.WriteLine($"\n\tThere are {evenNumbers} even numbers\n");
        }

        public void linqExample4()
        {
            Console.WriteLine("\n\tElement Access Methods");
            string[] words = { "Cherry", "Apple", "tea", "Blueberry", "pen", "pawpaw", "orange" };
            Console.WriteLine($"\n\tWord at index  3 is {words.ElementAt(3)}");
            Console.WriteLine($"\n\tThe first word  is {words.First()}");
            Console.WriteLine($"\n\tThe last word  is {words.Last()}");
            Console.WriteLine(
                $"\n\tThe first word with 5 letters is {words.First(word => word.Length == 5)}"
            );
            Console.WriteLine(
                $"\n\tThe last word with 6 letters is {words.Last(word => word.Length == 6)}"
            );
        }

        public void linqExample5()
        {
            Console.WriteLine("\n\tAggregation calculations");
            var num6 = new List<int> { 6, 2, -6, 4, -2, 7, 9, 8 };
            var answer1 = num6.Count();
            Console.WriteLine($"\n\tThere are {answer1} elements");
            //Sum

            var sum = num6.Sum();
            Console.WriteLine($"\n\tThe sum of all values is: {sum}");

            var sum2 = num6.Sum(a => a > 0 ? a : 0);
            Console.WriteLine($"\n\tThe sum of all positive values is: {sum2}");

            var sum3 = num6.Sum(a => a < 0 ? a : 0);
            Console.WriteLine($"\n\tThe sum of all negative values is: {sum3}");

            var avg = num6.Average();
            Console.WriteLine($"\n\tThe average of the values is: {avg}");
            var max = num6.Max();
            Console.WriteLine($"\n\tThe maximum value is: {max}");

            var min = num6.Min();
            Console.WriteLine($"\n\tThe minimum value is: {min}\n");
        }
    }
}
