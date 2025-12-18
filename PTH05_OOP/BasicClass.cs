using System;
namespace BasicClass
{
    // khai báo lớp Students
    class Students
    {
        int ID;
        string Name;
        double GPA;
        // hàm khởi tạo
        public Students(int ID, string Name, double GPA)
        {
            this.ID = ID;
            this.Name = Name;
            this.GPA = GPA;
        }
        // phương thức
        public void Display()
        {
            Console.WriteLine($"Mã ID: {ID}\nHọ và tên: {Name}\nGPA: {GPA}");
        }
    };
    // khai báo lớp Product
    class Product
    {
        int ID;
        string ProductName;
        double Price;

        // hàm khởi tạo
        public Product (int ID, string ProductName, double Price)
        {
            this.ID = ID;
            this.ProductName = ProductName;
            this.Price = Price;
        }
        // method display
        public void Display()
        {
            Console.WriteLine($"Mã sản phẩm: {ID}\nTên sản phẩm: {ProductName}\nGiá: {Price}");
            
        }
    }
    // khai báo lớp BackAccount
    class BankAccount
    {
        // Field public để lưu thông tin cơ bản
        public int ID { get; private set; }
        public string Name { get; private set; }

        // Field private lưu số dư
        private double _balance;

        // Constructor khởi tạo đầy đủ
        public BankAccount(int id, string name, double initialBalance)
        {
            ID = id;
            Name = name;
            _balance = initialBalance;
        }

        // Property chỉ đọc số dư
        public double Balance
        {
            get { return _balance; }
        }

        // Gửi tiền
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Đã gửi {amount}. Số dư mới là {_balance}");
            }
            else
            {
                Console.WriteLine("Số tiền gửi phải lớn hơn 0!");
            }
        }

        // Rút tiền
        public void WithDraw(double amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                Console.WriteLine($"Đã rút {amount}. Số dư mới là {_balance}");
            }
            else
            {
                Console.WriteLine("Không đủ tiền hoặc số tiền rút không hợp lệ!");
            }
        }
    }
    // khai váo lớp Animal
    class Animal
    {
        public string Name;
        // method MakeSound
        public virtual void MakeSound()
        {
            Console.WriteLine($"Animal make a sound");
            
        }
        public Animal()
        {
            Name = "";
        }
    }    
    // Lớp Dog kế thừa từ lớp Animal
    class Dog : Animal
    {
        public override void MakeSound() // sử dụng Method của Animal
        {
            Console.WriteLine($"Woof! Woof!");
            
        }
    }
    class Program
    {
        static void Main (string[] args)
        {
            Students s1 = new Students(1, "Ngô Bá Khá", 8.2);
            Students s2 = new Students(2, "Nguyễn Xuân Huấn", 9.5);
            s1.Display();
            s2.Display();
            Console.WriteLine($"-------------------------");
            Product pd1 = new Product(1, "Ma tóe", 2500000);
            Product pd2 = new Product(2, "Nước bò húc", 20000);
            pd1.Display();
            pd2.Display();
            Console.WriteLine($"-------------------------");
            // Khởi tạo tài khoản với ID, Name và số dư ban đầu
            BankAccount account = new BankAccount(1, "Ngô Bá Khá", 10000);

            Console.WriteLine($"ID: {account.ID}, Chủ tài khoản: {account.Name}");
            Console.WriteLine($"Số dư ban đầu: {account.Balance}");

            account.Deposit(500); // nạp tiền
            account.WithDraw(500); // rút tiền
            account.WithDraw(20000); // nạp quá số tiền đang có
            Console.WriteLine($"-------------------------");
            Animal a1 = new Animal();
            a1.Name = "con vật chung chung";
            Animal a2 = new Dog();
            a2.Name = "con tró";
            a1.MakeSound();
            a2.MakeSound();
        }
    }
}