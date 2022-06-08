using System;
using System.Collections;
namespace Interface
{




    //class Human
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public DateTime BirthDate { get; set; }
    //    public override string ToString()
    //    {
    //        return $"\nФамилия: {LastName} Имя: {FirstName} Дата рождения {BirthDate.ToLongDateString()}";
    //    }
    //}

    //class Employee : Human
    //{
    //    public string Position { get; set; }
    //    public double Salary { get; set; }

    //    public override string ToString()
    //    {
    //        return base.ToString()+$"Должность: {Position} Заработная плата {Salary} Руб.";
    //    }
    //}
    //interface IWorker
    //{
    //    bool IsWorking { get; }
    //    string Work();
    //}
    //interface IManager
    //{
    //    List<IWorker> ListOfWorkers { get; set; }
    //    void Organize();
    //    void MakeBudget();
    //    void Control();
    //}

    //class Director: Employee, IManager
    //{
    //    public List<IWorker> ListOfWorkers { get; set; }

    //    public void Control()
    //    {
    //        Console.WriteLine("Контролирую работу");
    //    }

    //    public void MakeBudget()
    //    {
    //        Console.WriteLine("Формирую бюджет");
    //    }

    //    public void Organize()
    //    {
    //        Console.WriteLine("Организую бюджет");
    //    }

    //}

    //class Seller : Employee, IWorker
    //{

    //    bool isWorking = true;

    //    public bool IsWorking
    //    {
    //        get
    //        {
    //            return isWorking;
    //        }
    //    }

    //    public string Work()
    //    {
    //        return "Продаю товар!";
    //    }
    //}

    //class Cashier : Employee, IWorker
    //{
    //    bool isWorking = true;
    //    public bool IsWorking
    //    {
    //        get
    //        {
    //            return isWorking;
    //        }
    //    }
    //    public string Work()
    //    {
    //        return "Принимаю оплату за товар!";
    //    }
    //}
    //class Storekeeper : Employee, IWorker
    //{
    //    bool isWorking = true;
    //    public bool IsWorking
    //    {
    //        get
    //        {
    //            return isWorking;
    //        }
    //    }
    //    public string Work()
    //    {
    //        return "Учитываю товар!";
    //    }
    //}





    interface IIndexer
    {
        string this [int index] { get; set; }
        string this[string index] { get; }
    }

    enum Numbers { one, two, three, four, five };

    class IndexerClass: IIndexer
    {
        string[] _Names = new string[5];

        public IndexerClass()
        {
            this[0] = "Bob";
            this[1] = "Tailer";
            this[2] = "Jimmy";
            this[3] = "Joey";
            this[4] = "Nicole";
        }


        public string this [int index]
        {
            get { return _Names[index]; }

            set
            {
                _Names[index] = value;
            }
        }

        public string this[string index]
        {
            get
            {
                if (Enum.IsDefined(typeof(Numbers), index))
                {
                    return _Names[(int)Enum.Parse(typeof(Numbers), index)];
                }
                else
                {
                    return "";
                }
            }
        }
    }


    class StudentCard
    {
        public int Number { get; set; }
        public string Series { get; set; }
        public override string ToString()
        {
            return $"Студенчиский билет: {Series} {Number}";
        }
    }

    class Student :IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public StudentCard StudentCard { get; set; }


        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                return LastName.CompareTo((obj as Student).
               LastName);
            }
            throw new NotImplementedException();
        }

        public void Print()
        {
            Console.WriteLine($"Имя {FirstName} Фамилия {LastName}  Дата рождения {BirthDate.ToLongDateString()}  {StudentCard.ToString()}");
        }
    }
    class DateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).
                BirthDate, (y as Student).BirthDate);
            }
            throw new NotImplementedException();
        }
    }
    class Auditory : IEnumerable
    {
        public Student[] students = 
        {
            new Student
            {
                FirstName ="John",
                LastName ="Miller",
                BirthDate = new DateTime(1997, 3, 12),
                StudentCard = new StudentCard
                {
                    Number = 189356,
                    Series ="AB"
                }
            },

            new Student
            {
                FirstName ="Candice",
                LastName ="Leman",
                BirthDate = new DateTime(1998,7,22),
                StudentCard = new StudentCard
                {
                    Number = 345185,
                    Series ="XA"
                }
            },

            new Student
            {
                FirstName ="Joey",
                LastName ="Finch",
                BirthDate = new DateTime(1996,11,30),
                StudentCard = new StudentCard
                {
                    Number = 258322,
                    Series ="AA"
                }
            },

            new Student
            {
                FirstName ="Nicole",
                LastName ="Taylor",
                BirthDate = new DateTime(1996,5,10),
                StudentCard = new StudentCard
                {
                    Number = 513484,
                    Series ="AA"
                }
            },
        };

        public IEnumerator GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

    }



    class Program
    {

        static void Main(string[] args)
        {
            //Director director = new Director { LastName = "Doe", FirstName = "John", BirthDate = new DateTime(1988, 10, 12), Position = "Директор", Salary = 12000 };
            //IWorker seller = new Seller { LastName = "Beam", FirstName = "Jim", BirthDate = new DateTime(1956, 5, 23), Position = "Продавец", Salary = 3780 };

            //if (seller is Employee)
            //{
            //    Console.WriteLine($"заработная плата продавца: {(seller as Employee).Salary}");

            //}

            //director.ListOfWorkers = new List<IWorker>
            //{
            //    seller, new Cashier { LastName = "Smith",
            //    FirstName = "Nicole",
            //    BirthDate = new DateTime(1956, 5, 23),
            //    Position = "Кассир", Salary = 3780 },
            //    new Storekeeper { LastName = "Ross",
            //    FirstName = "Bob", BirthDate =
            //    new DateTime(1956, 5, 23),
            //    Position = "Кладовщик", Salary = 4500 }
            //};

            //Console.WriteLine(director);
            //if (director is IManager)
            //{
            //    director.Control();
            //}
            //foreach (IWorker item in director.ListOfWorkers)
            //{
            //    Console.WriteLine(item);
            //    if (item.IsWorking)
            //    {
            //        Console.WriteLine(item.Work());
            //    }
            //}


            //IndexerClass indexerClass = new IndexerClass();

            //Console.WriteLine("\t\tВывод значений\n");
            //Console.WriteLine("Использование индексатора с целочисенным параметром");
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(indexerClass[i]);
            //}

            //Console.WriteLine("Использование индексатора со строковым параметром");
            //foreach (string item in Enum.GetNames(typeof(Numbers)))
            //{
            //    Console.WriteLine(indexerClass[item]);
            //}



            Auditory auditory = new Auditory();

            auditory.Sort(new DateComparer());
            foreach (Student student in auditory)
            {
                student.Print();
                Console.WriteLine(student);
            }

        }
    }
}
