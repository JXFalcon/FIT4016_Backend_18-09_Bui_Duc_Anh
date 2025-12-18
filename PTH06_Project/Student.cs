using System;

namespace StudentManagementSystem
{
//Todo 6.1 tạo lớp student và kiểm tra điều kiện
    public class Student
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
        public Student(string studentsid, string name, double score)
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
}