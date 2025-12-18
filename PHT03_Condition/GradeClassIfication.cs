using System;

namespace GradeClassification
{

    // khởi tạo lớp PhanLoaiDiem
    class PhanLoaiDiem
    {
        public int Score;

        // khởi tạo method Classify
        public void Classify()
        {
            if (Score >= 90 && Score <= 100)
            {
                Console.WriteLine("Xuất sắc");
            }
            else if (Score >= 80 && Score <= 89)
            {
                Console.WriteLine("Giỏi");
            }
            else if (Score >= 70 && Score <= 79)
            {
                Console.WriteLine("Khá");
            }
            else if (Score >= 60 && Score <= 69)
            {
                Console.WriteLine("Trung bình");
            }
            else
            {
                Console.WriteLine("Không đạt");
            }
        }
    }
    //
    // Khợi tạo class TinhTong
    class TinhTong
    {
        int Sum = 0;
        // khởi tạo method tinhtong
        public void tinhtong()
        {
            for (int i = 1; i <= 100; i++)
            {
                Sum += i;
            }
            Console.WriteLine($"Tổng từ 1 đến 100 là {Sum}");
        }
    }
    //
    // Khởi tạo lớp DoanSo
    class DoanSo
    {
        public int guessnumber = 50;
        public int guess;
        //Khởi tạo method doanso
        public void doanso()
        {
            Console.WriteLine($"Đoán từ 1 đến 100");
            do
            {
                Console.WriteLine($"Đoán đi: ");
                guess = int.Parse(Console.ReadLine());
                if (guess < guessnumber)
                {
                    Console.WriteLine($"Cao hơn");
                }
                else if (guess > guessnumber)
                {
                    Console.WriteLine($"Thấp hơn");
                }
                else
                {
                    Console.WriteLine($"Chính xác");
                }
            }
            while (guess != guessnumber);
        }
        
    }
    //
    // khởi tạo lớp InDanhSach
    class InDanhSach
    {
        string[] Friends = {"Khá", "Huấn", "Sena36", "5van"};
        // khởi tạo method indanhsach
        public void indanhsach()
        {
            int i = 0;
            foreach (var Friend in Friends)
            {
                i++;
                Console.WriteLine($"{i}.{Friend}");
                
            }
        }
    }
    //
    // Khởi tạo lớp InSoLe
    public class InSoLe
    {
        List<int> In = new List<int>();
        // khởi tạo method TimSoLe
        public void TimSoLe()
        {
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 != 0)
                {
                    In.Add(i);  
                }
                else
                    continue;
            }
            Console.WriteLine(string.Join($" ", In));
            
        }
    }
    // Khởi tạo class TimSoTrongMang
    public class TimSoTrongMang
    {
        int[] MangSo = {2, 5, 7, 1, 9, 7, 3};
        
        int SoCanTim = 7;
        // khởi tạo method TimSo
        public void TimSo()
        {
            Console.WriteLine(string.Join($" ", MangSo));
            for(int i = 0; i <= MangSo.Length; i++)
            {
                if (MangSo[i] == SoCanTim)
                {
                    Console.WriteLine($"Tìm thấy số 7 ở vị trí số {i + 1}");
                    break;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PhanLoaiDiem PLD1 = new PhanLoaiDiem();
            PLD1.Score = 95;
            PLD1.Classify();
            Console.WriteLine($"---------------------");
            TinhTong TT = new TinhTong();
            TT.tinhtong();
            Console.WriteLine($"---------------------");
            DoanSo DS = new DoanSo();
            DS.doanso();
            Console.WriteLine($"---------------------");
            InDanhSach ids = new InDanhSach();
            ids.indanhsach();
            Console.WriteLine($"---------------------");
            InSoLe ISL = new InSoLe();
            ISL.TimSoLe();
            TimSoTrongMang TSTM = new TimSoTrongMang();
            TSTM.TimSo();
        }
            
    }
}