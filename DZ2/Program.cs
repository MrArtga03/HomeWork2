using System;

namespace DZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Kadrovik kadrovik = new Kadrovik("Третьяков Роберт Фёдорович");
            Console.WriteLine(kadrovik.GetName());
            Console.WriteLine(kadrovik.GetDoljnost() + "\n");

            Student student = kadrovik.GetCosdaetStudent("Смирнов Борис Львович", "3-1П9");
            Console.WriteLine(student.GetName());
            Console.WriteLine(student.GetZayavlen());
            Console.WriteLine(student.GetGroup() + "\n");

            Teacher newTeacher = kadrovik.GetCosdaetTeacher("Игнатьева Татьяна Сергеевна", Rank.Assistant);
            Console.WriteLine(newTeacher.GetName());
            Console.WriteLine(newTeacher.GetDoljnost() + "\n");

            Teacher teacher = new Teacher("Пономаренко Альберт Александрович", Rank.StLecturer);
            Console.WriteLine(teacher.GetName());
            Console.WriteLine(teacher.GetDoljnost());
            Console.WriteLine(teacher.GetLekcee() + "\n");
        }
    }
}

/// <summary>
/// Интерфейс, задающий метод для получения имени
/// </summary>
interface IName
{
    string GetName();
}

/// <summary>
/// Интерфейс, задающий метод для получения должности сотрудника
/// </summary>
interface IDoljnost : IName
{
    string GetDoljnost();
}

/// <summary>
/// Интерфейс, задающий метод для получения учебной группы студента
/// </summary>
interface IGroup : IName
{
    string GetGroup();
}

/// <summary>
/// Интерфейс, задающий метод для подания заявления об отчислении студента
/// </summary>
interface IZayava : IGroup
{
    string GetZayavlen();
}

/// <summary>
/// Интерфейс, задающий метод для создания студентов и преподавателей (учителей)
/// </summary>
interface ICosdaet : IDoljnost
{
    Student GetCosdaetStudent(string name, string group);
    Teacher GetCosdaetTeacher(string name, Rank doljnost);
}

/// <summary>
/// Перечисление для задания ранга преподавателя
/// </summary>
public enum Rank
{
    Assistant = 0,
    StLecturer = 1
}

/// <summary>
/// Интерфейс, задающий метод для проведения лекций преподавателем
/// </summary>
interface ILekcee : IDoljnost
{
    string GetLekcee();
}

/// <summary>
/// Абстрактный класс для создания людей
/// </summary>
abstract class Person : IName
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }
}

/// <summary>
/// Абстрактный класс, описывающий сотрудников
/// </summary>
abstract class Sotrudnik : Person
{
    public string Doljnost { get; set; }

    public Sotrudnik(string name, string doljnost) : base(name)
    {
        Doljnost = doljnost;
    }

    public string GetDoljnost()
    {
        return Doljnost;
    }
}

/// <summary>
/// Класс, описывающий студентов
/// </summary>
class Student : Person, IZayava
{
    public string Group { get; set; }

    public Student(string name, string group) : base(name)
    {
        Group = group;
    }

    public string GetGroup()
    {
        return Group;
    }

    public string GetZayavlen()
    {
        return $"Заявыление на отчисление на имя: {Name}";
    }
}

/// <summary>
/// Класс, описывающий преподавателей (учителей)
/// </summary>
class Teacher : Sotrudnik, ILekcee
{
    static string[] doljnost = new string[] { "Ассистент", "Старший преподаватель"};

    public Teacher(string name, Rank RankOfTheTeacher) : base(name, doljnost[(int)RankOfTheTeacher]) { }

    public string GetLekcee()
    {
        return "Проводит лекции";
    }
}

/// <summary>
/// Класс, описывающий кадровиков
/// </summary>
class Kadrovik : Sotrudnik, ICosdaet
{
    public Kadrovik(string name) : base(name, "кадровик") { }

    public Student GetCosdaetStudent(string name, string group)
    {
        return new Student(name, group);
    }

    public Teacher GetCosdaetTeacher(string name, Rank doljnost)
    {
        return new Teacher(name, doljnost);
    }
}