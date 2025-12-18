using System;

namespace StudentManagementSystem
{
    public class StudentManagement
    {
        public static void Main(string[] args)
        {
            StudentManager sm1 = new StudentManager();
            bool running = true;
            while (running)
            {
                // TODO in Menu
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Cập nhật điểm");
                Console.WriteLine("4. In danh sách");
                Console.WriteLine("5. Tính điểm trung bình");
                Console.WriteLine("6. Tìm điểm cao nhất");
                Console.WriteLine("7. Tìm sinh viên");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("========================");
                // TODO nhận lựa chọn từ người dùng
                // đọc phím bấm
                Console.WriteLine($"Nhập lựa chọn: ");
                string? input = Console.ReadLine();
                
                // kiểm tra hợp lệ
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine($"Vui lòng nhập số từ 0 đến 7");
                    continue;
                    
                }
                switch (choice)
                {
                    case 1:
                        {
                            sm1.AddStudent("SV01", "A", 9.4); // thêm sinh viên vào mảng
                            sm1.AddStudent("SV02", "B", 9.2);
                            sm1.AddStudent("SV03", "C", 8.5);
                            sm1.DisplayAll();
                            break;
                        }
                    case 2:
                        {
                            sm1.RemoveStudent("SV02"); // xóa sinh viên theo ID
                            sm1.DisplayAll();  
                            break;
                        }
                    case 3:
                        {
                            sm1.UpdateScore("SV01", 9.2); // cập nhật điểm
                            sm1.DisplayAll();
                            break;
                        }
                    case 4:
                        {
                            double average = sm1.GetAverageScore(); // điểm trung bình lớp
                            Console.WriteLine($"Điểm trung bình của lớp: {average}");
                            break;
                        }
                    case 5 :
                        {
                            double max = sm1.GetMaxScore(); // điểm cao nhất lớp
                            Console.WriteLine($"Điểm cao nhất lớp là: {max}");
                            break;
                        }
                    case 6:
                        {
                            // tìm sinh viên theo ID
                            Student? st = sm1.FindStudentByID("SV01");
                            if (st != null)
                            {
                                Console.WriteLine($"Đã tìm thấy sinh viên");
                                st.Display();
                            }
                            else
                            {
                                Console.WriteLine($"Không tìm thấy sinh viên với ID SV01");

                            }
                            // thử tìm ID không tồn tại
                            Student? st2 = sm1.FindStudentByID("SV67");
                            if (st2 == null)
                            {
                                Console.WriteLine($"Không tìm thấy sinh viên với ID SV67");
                                
                            }
                            break;
                        }
                    case 7 :
                        {
                            // hiển thị tất cả sinh viên trong danh sách
                            sm1.DisplayAll();
                            break;
                        }
                    default :
                        {
                            Console.WriteLine($"Đang thoát");
                            running = false;
                            break;
                        }
                }
            }
        }
    }
}