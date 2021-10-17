using System;

namespace DZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person student = new Student("Галкин Артём Дмитриевич", "из группы 3-1П9", "подать заявление на отчисление");
            student.ShowName();
            student.ShowOrientation();
            student.ShowOccupation();

            Console.WriteLine("----");

            Person teacher = new Teacher("Саша спилберг", "Учитель", "преподавать");
            teacher.ShowName();
            teacher.ShowOrientation();
            teacher.ShowOccupation();

            Console.WriteLine("----");

            Person kadrovik = new Kadrovik("Зашибалкин Василий Петрович", "Кадровик", "создавать студентов и учителей");
            kadrovik.ShowName();
            kadrovik.ShowOrientation();
            kadrovik.ShowOccupation();
        }
    }
}


interface IRabota
{
    string Orientation { get; set; } //Должность
    string Occupation { get; set; }  //Род деятельности каждой из сущностей
    void ShowOrientation();          //Сообщить должность
    void ShowOccupation();           //Сообщить род деятельности
}

abstract class Person : IRabota
{
    public string Name { get; set; } //ФИО
    public string Orientation { get; set; }
    public string Occupation { get; set; }

    public Person(string name, string orientation, string occupation)
    {
        Name = name;
        Orientation = orientation;
        Occupation = occupation;
    }

    public void ShowName()
    {
        Console.Write($"Меня звать {Name}. ");
    }

    public virtual void ShowOrientation()
    {
        Console.WriteLine($"Я {Orientation}");
    }

    public virtual void ShowOccupation()
    {
        Console.WriteLine($"Я могу {Occupation}");
    }
}

class Student : Person
{
    public Student(string name, string orientation, string occupation) : base(name, orientation, occupation) { }
}
class Teacher : Person
{
    public Teacher(string name, string orientation, string occupation) : base(name, orientation, occupation) { }
}
class Kadrovik : Person
{
    public Kadrovik(string name, string orientation, string occupation) : base(name, orientation, occupation) { }
}