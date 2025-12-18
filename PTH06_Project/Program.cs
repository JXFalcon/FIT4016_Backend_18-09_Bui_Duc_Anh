using System;

namespace StudentManagementSystem
{
    //TODO 6.2 tạo lớp StudentManager
    public class Program
    {
        private string _StudentsID = string.Empty;
        private string _Name = string.Empty;
        private double _Score;
        public string StudentsID
        {
            get {return _StudentsID;}
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("bạn đã để trống");
                }
                if (!value.StartsWith("SV"))
                {
                    throw new ArgumentException("Mã SV phải bắt đầu từ Mx 'SV'");
                }
                string numberpart = value.Substring(2);
                if (!int.TryParse(numberpart, out int id) || id < 1)
                {
                    throw new ArgumentException("Mã sinh viên phải có số >= 01");
                }
                _StudentsID = value;
            }
        }
        public string Name
        {
            get{return _Name;} 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("bạn không được để trống tên");
                }
                _Name = value;
            }
        }
        public double Score
        {
            get {return _Score;} 
            set
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentException("Bạn nhập điểm thấp hơn 0 hoặc hớn hơn 10");
                }
                _Score = value;
            }
        }
        // constructor
        public void Student(string studentsid, string name, double score)
        {
            StudentsID = studentsid;
            Name = name;
            Score = score;
        }
        //method
        public void Display()
        {
            Console.WriteLine($"ID: [{StudentsID}] | Name: [{Name}] | Score: [{Score}]");
            
        }
    }
    // Todo 6.2 Tạo lớp quản lý sinh viên
    public class StudentManager
    {
        private Student[] students = new Student[50];
        private int count = 0;

        //method
        public void AddStudent(string id, string name, double score)
        {
            if (count >= students.Length)
            {
                Console.WriteLine($"Danh sách sinh viên đã đầy");
                    return;
            }
            
            // kiểm tra trùng lặp ID
            for (int i = 0; i < count; i++)
            {
                if (students[i].StudentsID == id)
                {
                    Console.WriteLine($"Sinh viên với ID {id}");
                    return;
                }
            }

        // thêm sinh viên mới
        students[count] = new Student(id, name, score);
        count++;
        Console.WriteLine($"Đã thêm sinh viên thành công");

        }

         // hiển thị toàn bộ danh sách
        public void DisplayAll()
        {
            for (int i = 0; i < count; i++)
            {
                students[i].Display();
            }
        }

        // method xóa sinh viên theo id
        public void RemoveStudent(string id)
        {
            int index = -1;
            // tìm vị trí sinh viên có ID cần xóa
            for (int i = 0; i < count; i++)
            {
                if (students[i].StudentsID == id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine($"không tìm thấy sinh viên với ID {id}");
                return;
            }
            // dịch các phần tử phía sau lên
            for (int i = index; i < count - 1; i++)
            {
                students[i] = students[i + 1];
            }
            //giảm số lượng
            count--;
            Console.WriteLine($"Đã xóa sinh viên với ID {id}");
            
        }
        public void UpdateScore(string id, double newscore)
        {
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (students[i].StudentsID == id)
                {
                    if (newscore < 0 || newscore > 10)
                    {
                        Console.WriteLine($"điểm phải nằm trong khu vực từ 0 - 10");
                        
                    }
                    students[i].Score = newscore;
                    Console.WriteLine($"đã cập nhập điểm cho sinh viên");
                    found = true;
                    break;
                    
                }
            }
            if (!found)
            {
                Console.WriteLine($"Không tìm thấy sinh viên với mã ID {id}");
                
            }
        }
        public double GetAverageScore()
        {
            if (count == 0)
            {
                Console.WriteLine($"Danh sách sinh viên trống, không có điểm trung bình");
                return 0;
                
            }
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += students[i].Score;

            }
            double avg = sum / count;
            return avg;
        }
        public double GetMaxScore()
        {
            if (count == 0)
            {
                Console.WriteLine($"Danh sách sinh viên trống");
                return 0;
            }
            double maxScore = students[0].Score; // giả sử phần tử đầu tiên lẫm
            for (int i = 0; i < count; i++)
            {
                if (students[i].Score > maxScore)
                {
                    maxScore = students[i].Score;
                }
            }
            return maxScore;
        }
        public Student? FindStudentByID(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i]. StudentsID == id)
                {
                    return students[i]; //trả về đối tượng student tìm thấy
                
                }
            }
            return null; // không tìm thấy
        }
    }
}