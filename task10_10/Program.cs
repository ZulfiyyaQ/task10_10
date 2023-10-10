namespace task10_10
{
    internal class Program
    {
        static void Main(string[] args)
        {    //task1
            //Animal animal = new Animal("Male");
            //Dog dog = new Dog("Masha", "Haski", "Female");

            //Console.WriteLine($"Animal: Gender - {animal.Gender}, Birth Year - {animal.BirthYear}");
            //Console.WriteLine($"Dog: Name - {dog.Name}, Breed - {dog.Breed}, Gender - {dog.Gender}, Birth Year - {dog.BirthYear}");



            //task2
              
            Student[] students = {
            new Student("Sema", "Eliyeva", 20, true),
            new Student("Mikayil", "Seferov", 30, false),
            new Student("Aylin", "Memmedova", 21, true)
                 };

            Group group = new Group("IT", students);
            group.GetAll();
            group.GetOnlineStudents();
            group.GetOfflineStudents();
        }
    }
    //task2
    class Person
    {
        protected string _name;
        protected string _surname;
        protected int _age;

        public string Name 
        { 
            get { return _name; }
            set {
                    value = value.Trim();
                    if (value.Length >= 3 && value.Length <= 25)
                    {
                        _name = value;
                    }
                } 
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                value = value.Trim();
                if (value.Length >= 3 && value.Length <= 25)
                {
                    _surname = value;
                }
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 1 && value <= 120)
                {
                    _age = value;
                }
            }
        }

        public Person(string name,string surname,int age)
        {
            _name = name;
            _surname = surname;
            _age = age;

        }
        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public int GetAge()
        {
            return _age;
        }
    }
    class Student : Person 
    {
        private bool _isOnline;

        public bool IsOnline { get { return _isOnline;} set { _isOnline = value; } }
        
        public Student( string name, string surname, int age, bool isonline) : base(name, surname, age)
        {
            _isOnline = isonline;
        }
        public bool GetIsOnline()
        {
            return _isOnline;
        }

    }

    class Group
    {
        private string _groupName;
        private Student[] _students;

        public string GroupName { get { return _groupName; }  set { _groupName = value; } }
        public Student[] Students { get { return _students; } }

        public Group(string groupName, Student[] students)
        {
            _groupName = groupName;
            _students = students;
        }
        public void Add (Student student)
        {
            Array.Resize(ref _students, _students.Length + 1);

            _students[_students.Length - 1] = student;
        }
        public void GetAll()
        {
            Console.WriteLine($"Qrupdaki Studentler {_groupName}:");
            for (int i = 0; i < _students.Length; i++)
            {
                string name = _students[i].GetName();
                string surname= _students[i].GetSurname();
                Console.WriteLine(name + " "+ surname);
            }
        }
        public void GetOnlineStudents()
        {
            Console.WriteLine($"Qrupdaki Online telebeler {_groupName}:");
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].GetIsOnline())
                {
                    Console.WriteLine($"{_students[i].GetName()} {_students[i].GetSurname()}");
                }
            }
        }
        public void GetOfflineStudents()
        {
            Console.WriteLine($"Qrupdaki Offline telebeler {_groupName}:");
            for (int i = 0; i < _students.Length; i++)
            {
                if (!_students[i].GetIsOnline())
                {
                    Console.WriteLine($"{_students[i].GetName()} {_students[i].GetSurname()}");
                }
            }
        }



    }
    


    //task1
    record Animal
    {
         public string Gender{ get; init; }
         public DateTime BirthYear { get; init; }

        public Animal(string gender)
        {
            Gender = gender;
            BirthYear = DateTime.Now;
        }


    }
    record Dog:Animal
    {
         public string Name { get; set; }
         public string Breed { get; init; }

        public Dog(string name,string breed,string gender):base(gender)
        {
            Name=name;
            Breed=breed;
        }
    }


}