using System;

namespace DZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Артём", "3-1П9");
            student.GetNameOfPerson();
            student.GetOrientation();
            student.Prava();

            Console.WriteLine("-----");

            Teacher teacher = new Teacher("Юлька", "Учитель по матеше");
            teacher.GetNameOfPerson();
            teacher.GetOrientation();
            teacher.Prava();

            Console.WriteLine("-----");

            Kadrovik kadrovik = new Kadrovik("Вася", "Кадровик");
            kadrovik.GetNameOfPerson();
            kadrovik.GetOrientation();
            kadrovik.CreateNewPerson("Сишарповин", "Василий", "Джавович", 18, "3-1П9");
            kadrovik.CreateNewPerson("Гелийвин", "Евгений", "Уранович", "Химия");
        }
    }
}

interface IGetPerson
{
    string Name { get; set; }        //Имя чел
    string Orientation { get; set; } //Должность чел
    void GetNameOfPerson();          //Выводит имя чел
    void GetOrientation();           //Выводит должность чел
}

interface IRabota
{
    void Prava(); //Что может чк
}

//Студент
class Student : IGetPerson, IRabota
{
    public string Name { get; set; }
    public string Orientation { get; set; }

    public Student(string name, string orientation)
    {
        Name = name;
        Orientation = orientation;
    }

    public void GetNameOfPerson()
    {
        Console.WriteLine($"Меня звать - {Name}");
    }

    public void GetOrientation()
    {
        Console.WriteLine($"Я из группы {Orientation}");
    }

    public void Prava()
    {
        Console.WriteLine("'Отчисление' Кто куда, а я в автотрах!");
    }
}

//Учитель
class Teacher : IGetPerson, IRabota
{
    public string Name { get; set; }
    public string Orientation { get; set; }

    public Teacher(string name, string orientation)
    {
        Name = name;
        Orientation = orientation;
    }

    public void GetNameOfPerson()
    {
        Console.WriteLine($"Я ваш новый препод по матеше - {Name}");
    }

    public void GetOrientation()
    {
        Console.WriteLine($"Моя должность - {Orientation}");
    }

    public void Prava()
    {
        Console.WriteLine("Начинаем лекцию. Записываем новую тему...");
    }
}

//Кадровик
class Kadrovik : IGetPerson
{
    public string Name { get; set; }
    public string Orientation { get; set; }

    public Kadrovik(string name, string orientation)
    {
        Name = name;
        Orientation = orientation;
    }

    public void GetNameOfPerson()
    {
        Console.Write($"Я - {Name}. ");
    }

    public void GetOrientation()
    {
        Console.WriteLine($"Я - {Orientation}");
    }

    //Создание студентов и учителей
    public void CreateNewPerson(string Name, string LastName, string Patronymic, int age, string group)
    {
        Console.WriteLine($"Шалом группа {group}, у нас новый спиногрыз - {Name} {LastName} {Patronymic}, ему {age} лет");
    }

    public void CreateNewPerson(string Name, string LastName, string Patronymic, string doljnost)
    {
        Console.WriteLine($"Коллеги, у вас появилась свежая кровь - {Name} {LastName} {Patronymic}. Будет вести {doljnost}");
    }
} 