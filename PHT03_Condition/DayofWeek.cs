using System;
namespace DayOfWeek
{
    class Switch
    {
        public int Day;
        public void dayofweek()
        {
            switch (Day)
            {
                case 1:
                    {
                        Console.WriteLine($"Thứ 2");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine($"Thứ 3");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine($"Thứ 4");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"Thứ 5");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine($"Thứ 6");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine($"Thứ 7");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine($"Chủ Nhật");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"Nhập sai ngày");
                        break;
                    }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Switch s = new Switch();
            s.Day = 5;
            s.dayofweek();
        }
    }
}