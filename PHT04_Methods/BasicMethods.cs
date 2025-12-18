using System;
namespace BasicMethods
{
    // Khởi tạo lớp Program
    public class Program
    {
        // Phương thức tính tổng cơ bản
        // Khởi tạo method Add
        public int Add(int a, int b)
        {
            return (a + b);
        }
        // khởi tạo Method Multiply
        public double Multiply(Double a, double b)
        {
            return (a * b);
        }
        // Phương thức Void Không trả về
        // khởi tạo method PrintBox
        public void PrintBox(String text)
        {
            Console.WriteLine($"***********");
            Console.WriteLine($"*   {text}    *");
            Console.WriteLine($"***********");
        }
        // Phương thức với mảng
        // Khởi tạo method SumArray
        public int SumArray(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        //khởi tạo Method FindMax
        public int FindMax(int[] numbers)
        {
            int findmax = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (findmax <= numbers[i])
                {
                    findmax = numbers[i];
                }
            }
            return findmax;
        }
        // Nạp chồng Phương thức
        // Print 2 phiên bản
        // khởi tạo Method Print với tham số int x
        public void Print(int x)
        {
            Console.WriteLine($"{x}");
            
        }
        // khởi tạo Method Print với tham số string text
        public void Print(string text)
        {
            Console.WriteLine($"{text}");
            
        }
        // Add 2 phiên bản
        // Khởi tạo add với 2 tham số double a và double b
        public double add(int a, int b)
        {
            return(a + b);
        }
        // Khởi tạo Add với 2 tham số string a và string b
        public double Add(double a, double b)
        {
            return(a + b);
        }
        // Đệ quy - Tính Giai thừa
        // Cách dùng vòng lặp
        public long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;    
            }
            return result;
        }
        // Cách đùng đệ quy
        public long factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * factorial(n - 1);
        }


        public static void Main(string[] args)
        {
            Program pg = new Program();
            Console.WriteLine($"tổng của a và b là {pg.Add(6, 7)}");
            Console.WriteLine($"Tích của a và b là {pg.Multiply(5.5 , 2)}");
            Console.WriteLine($"-----------------------------");
            pg.PrintBox("Hello");
            pg.PrintBox("Chí");
            pg.PrintBox("ăn");
            pg.PrintBox("Giò");
            Console.WriteLine($"-----------------------------");
            int [] numbers = {85, 92, 78, 90, 88};
            int tong = pg.SumArray(numbers);
            Console.WriteLine($"Tổng mảng = {tong}");
            int tich = pg.FindMax(numbers);
            Console.WriteLine($"Số lớn nhất là: {tich}");
            Console.WriteLine($"-----------------------------");
            pg.Print(2);
            pg.Print("đời");
            int add1 = pg.Add(6, 7);
            Console.WriteLine($"{add1}");
            double add2 = pg.Add(4.5, 6.7);
            Console.WriteLine($"{add2}");
            Console.WriteLine($"-----------------------------");
            long Fac = pg.Factorial(5);
            Console.WriteLine($"{Fac}");
            long fac = pg.factorial(10);
            Console.WriteLine($"{fac}");
        }
    }
}