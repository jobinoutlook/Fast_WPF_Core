using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_WPF_Core
{
    public class Class1
    {
        private readonly int[] numbers = { 10, 20, 30, 40, 50 };

        public void ModifyArray()
        {
            Span<int> span = numbers.AsSpan();
            span[1] = 25; // Modifies the original array
            Console.WriteLine(numbers[1]); // Output: 25
        }
    }
}
