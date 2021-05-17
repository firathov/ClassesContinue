using System;

namespace Class_hw1
{
    class Student
    {
        private string surname;
        private int course;
        private int gradeBook;

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                course = value;
            }
        }
        public int GradeBook
        {
            get
            {
                return gradeBook;
            }
            set
            {
                gradeBook = value;
            }
        }

        Student[] data;
        public Student()
        {
            data = new Student [1000000000];
        }
        public Student this [int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public Student(string surname, int course, int gradeBook)
        {
            this.surname = surname;
            this.course = course;
            this.gradeBook = gradeBook;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Студент: { Surname }\nКурс: { Course }\nНомер зачетной книги: { GradeBook }");
        }

    }

    class Aspirant: Student
    {
        private string slideShow;

        public string SlideShow
        {
            get
            {
                return slideShow;
            }
            set
            {
                slideShow = value;
            }
        }
        Student[] aspirants;
        public Aspirant()
        {
            aspirants = new Student[10000000];
        }
        public Student this[int index]
        {
            get
            {
                return aspirants[index];
            }
            set
            {
                aspirants[index] = value;
            }
        }

        public Aspirant(string slideShow, string surname, int course, int gradeBook)
            : base(surname, course, gradeBook)
        {
            this.slideShow = slideShow;
        }

        public override void Print()
        {
            Console.WriteLine($"Студент: { Surname }\nКурс: { Course }\nНомер зачетной книги: { GradeBook }\n Название презентации { SlideShow }");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Aspirant aspirant = new Aspirant();
            int studentCounter = 0;
            int aspirantCounter = 0;
            
            for (;;)
            {
                Menu();
                Console.WriteLine("\nВыбирайте номер");
                int switcher = forNumberCheck();
                switch (switcher)
                {
                    case 1:
                        {
                            Console.WriteLine("Чтобы добавить студента, введите его/её фамилию");
                            string surname = ForSurnameCheck();
                            Console.WriteLine("Введите курс");
                            int course = forCourseCheck();
                            Console.WriteLine("Введите номер зачетной книги");
                            int gradeBook = ForGradeBookCheck();
                            student[studentCounter] = new Student { Surname = surname, Course = course, GradeBook = gradeBook };
                            studentCounter++;
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Чтобы добавить аспиранта, введите его/её фамилию");
                            string surname = ForSurnameCheck();
                            Console.WriteLine("Введите курс");
                            int course = forCourseCheck();
                            Console.WriteLine("Введите номер зачетной книги");
                            int gradeBook = ForGradeBookCheck();
                            Console.WriteLine("Введите название презентации");
                            string slideShow = ForSurnameCheck();
                            aspirant[aspirantCounter] = new Aspirant { Surname = surname, Course = course, GradeBook = gradeBook, SlideShow = slideShow };
                            aspirantCounter++;
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"Количесто студентов: {studentCounter}");
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine($"Количество аспирантов: {aspirantCounter}");
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 5:
                        {
                            if (studentCounter == 0)
                            {
                                Console.WriteLine("Студентов нет");
                            }
                            for (int i = 0; i < studentCounter; i++)
                            {
                                if (student[i] == null)
                                {
                                    continue;
                                }
                                else
                                {
                                    Student human = student[i];
                                    Console.WriteLine($"{i+1}) Фамилия - {human.Surname}, Курс - {human.Course}, Номер зачетной книги - {human.GradeBook}");
                                }
                            }
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 6:
                        {
                            if (aspirantCounter == 0)
                            {
                                Console.WriteLine("Аспирантов нет");
                            }
                            for (int i = 0; i < aspirantCounter; i++)
                            {
                                if (aspirant [i] == null)
                                {
                                    continue;
                                }
                                else
                                {
                                    Aspirant human = (Aspirant)aspirant[i];
                                    Console.WriteLine($"{i+1}) Фамилия - {human.Surname}, Курс - {human.Course},Номер зачетной книги - {human.GradeBook}, Название презентации - {human.SlideShow}");
                                }
                            }
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 7:
                        {
                            if (studentCounter == 0)
                            {
                                Console.WriteLine("Студентов нет");
                                Console.WriteLine("\nНажимайте на любую клавишу\n");
                                break;
                            }
                            Console.WriteLine("Для вывода студента, введите порядковый номер");
                            int studentIndex = forNumberCheck() - 1;
                            if (studentIndex >= studentCounter)
                            {
                                Console.WriteLine("Такого студента у нас нет");
                            }
                            else
                            {
                                Student human2 = student[studentIndex];
                                Console.WriteLine($"Фамилия - {human2.Surname}, Курс - {human2.Course},Номер зачетной книги - {human2.GradeBook}");
                            }
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 8:
                        {
                            if (aspirantCounter == 0)
                            {
                                Console.WriteLine("Аспирантов нет");
                                Console.WriteLine("\nНажимайте на любую клавишу\n");
                                break;
                            }
                            Console.WriteLine("Для вывода аспиранта, введите порядковый номер");
                            int aspirantIndex = forNumberCheck() - 1;
                            if (aspirantIndex >= aspirantCounter)
                            {
                                Console.WriteLine("У нас нет такого аспиранта");
                            }
                            else
                            {
                                Aspirant human4 = (Aspirant)aspirant[aspirantIndex];
                                Console.WriteLine($"Фамилия - {human4.Surname}, Курс - {human4.Course},Номер зачетной книги - {human4.GradeBook}, Название презентации - {human4.SlideShow}");
                            }
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 9:
                        {
                            if (studentCounter == 0)
                            {
                                Console.WriteLine("Студентов нет");
                                Console.WriteLine("\nНажимайте на любую клавишу\n");
                                break;
                            }
                            Console.WriteLine("Для удаления студента, введите его порядковый номер");
                            int deletteStudent = forNumberCheck() - 1;
                            if (deletteStudent >= studentCounter)
                            {
                                Console.WriteLine("У нас нет такого студента");
                                Console.WriteLine("\nНажимайте на любую клавишу\n");
                                break;
                            }
                            else
                            {
                                Student human3 = student[deletteStudent];
                                Console.WriteLine($"Студент {human3.Surname} под порядковым номером {deletteStudent+1} удалён");
                                student[deletteStudent] = null;
                            }
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 10:
                        {
                            if (aspirantCounter == 0)
                            {
                                Console.WriteLine("Аспирантов нет");
                                Console.WriteLine("\nНажимайте на любую клавишу\n");
                                break;
                            }
                            Console.WriteLine("Для удаления аспиранта, введите его порядковый номер");
                            int deletteAspirant = forNumberCheck() - 1;
                            if (deletteAspirant >= aspirantCounter)
                            {
                                Console.WriteLine("У нас нет такого аспиранта");
                            }
                            else
                            {
                                Aspirant human5 = (Aspirant)aspirant[deletteAspirant];
                                Console.WriteLine($"Аспирант {human5.Surname} под порядковым номером {deletteAspirant + 1} удалён");
                                aspirant[deletteAspirant] = null;
                            }
                            Console.WriteLine("\nНажимайте на любую клавишу\n");
                            break;
                        }
                    case 11:
                        {
                            Console.WriteLine("Удачи (ненавижу индексаторы)");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Такой цифры нет, выбирайте с 1-11: ");
                            break;
                        }
                }
                Console.ReadKey();
            }
            
        }

        public static void Menu()
        {
            Console.WriteLine("1)Добавить Студента");
            Console.WriteLine("2)Добавить Аспиранта");
            Console.WriteLine("3)Вывести количество студентов");
            Console.WriteLine("4)Вывести количество аспирантов");
            Console.WriteLine("5)Вывести список всех студентов");
            Console.WriteLine("6)Вывести список всех аспирантов");
            Console.WriteLine("7)Вывести студента по порядковому индексу");
            Console.WriteLine("8)Вывести аспиранта по порядковому индексу");
            Console.WriteLine("9)Удаление студента по порядковому индексу");
            Console.WriteLine("10)Удаление аспиранта по порядковому индексу");
            Console.WriteLine("11)Exit");
        }

        public static bool surnameCompare = true;

        //public static string CheckerSurname()
        //{
        //    do
        //    {
        //        string personName = Convert.ToString(Console.ReadLine());

        //        for (int i = 0; i < personName.Length; i++)
        //        {
        //            char element = personName[i];

        //            if (!Char.IsLetter(element))
        //            {
        //                checkerName = false;
        //                Console.Write("Incorrect name type, please enter correct name: ");
        //                break;
        //            }
        //            else
        //            {
        //                checkerName = true;
        //            }
        //        }

        //        NameForCompare = personName;

        //        if (NameForCompare.Length < 3)
        //        {
        //            Console.Write("Name cannot be less than 2 letters or empty result\nEnter surname: ");
        //            checkerName = false;
        //        }
        //    }
        //    while (checkerName == false);

        //    return NameForCompare;
        //}

        static string ForSurnameCheck()
        {
            string humanSurname;
            do
            {
                humanSurname = Console.ReadLine();

                for (int i = 0; i < humanSurname.Length; i++)
                {
                    char element = humanSurname[i];

                    if (!Char.IsLetter(element))
                    {
                        surnameCompare = false;
                        Console.Write("Вы ввели неправильный символ, попробуйте ещё: ");
                        break;
                    }
                    else
                    {
                        surnameCompare = true;
                    }
                }
                if (humanSurname.Length < 3)
                {
                    Console.WriteLine("Имя не может быть меньше 3 трёх букв, попробуйте ещё");
                    surnameCompare = false;
                }

                
            }
            while (surnameCompare == false);
            return humanSurname;
        }

        static int ForGradeBookCheck()
        {
            int number;

            for (; ; )
            {
                string checkingNumber = Console.ReadLine();
                number = 0;
                Int32.TryParse(checkingNumber, out number);
                
                if (number > 0 && number < 10000)
                {
                    return number;
                }
                else
                {
                    Console.Write("Вы ввели неправильно, введите от 1 до 9999: ");
                }
            }
        }

        static int forCourseCheck()
        {
            int number;

            for (; ; )
            {
                string checkingNumber = Console.ReadLine();
                number = 0;
                Int32.TryParse(checkingNumber, out number);
                
                if (number > 0 && number < 9)
                {
                    return number;
                }
                else
                {
                    Console.Write("Такого курса у нас нет, введите от 1 до 8: ");
                }
            }
        }

        static int forNumberCheck()
        {
            int number;

            for (; ; )
            {
                string checkingNumber = Console.ReadLine();
                ;
                if (Int32.TryParse(checkingNumber, out number) && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.Write("Вы ввели неправильный символ, попробуйте ещё: ");
                }
            }
        }
    }
}