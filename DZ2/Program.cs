using System;

namespace DZ2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Кадровик
            Kadrovik kadrovik = new Kadrovik("Вася", "кадровик", "создавать студентов и учителей");
            string NameKad = kadrovik.ShowName("Меня зовут ");
            string OrientKad = kadrovik.ShowOrientation("Моя должность - ");
            string OccupKad = kadrovik.ShowOccupation("По скольку я кадровик, я могу ");
            Console.WriteLine(NameKad);
            Console.WriteLine(OrientKad);
            Console.WriteLine(OccupKad);

            var newPerson1 = kadrovik.CreateStudent("Галкин Артём Дмитриевич", "студент", "учиться");
            Console.Write($"Меня зовут {newPerson1.Name}, и я {newPerson1.Orientation}, моя задача {newPerson1.Occupation}");

            Console.WriteLine("");

            var newPerson2 = kadrovik.CreateTeacher("Клим Саныч", "учитель", "истории");
            Console.Write($"Меня зовут {newPerson2.Name}, я ваш новый {newPerson2.Orientation} по {newPerson2.Occupation}");
        }
    }
}


interface IRabota
{
    string Orientation { get; set; }                 //Должность
    string Occupation { get; set; }                  //Род деятельности каждой из сущностей
    string ShowOrientation(string message);          //Сообщить должность
    string ShowOccupation(string message);           //Сообщить род деятельности
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

    public virtual string ShowName(string mes) { return mes + Name; }
    public virtual string ShowOrientation(string message) { return message + $"{Orientation}"; }
    public virtual string ShowOccupation(string message) { return message + $"{Occupation}"; }
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
    //Создание студентов и учителей
    public Student CreateStudent(string name, string orientation, string occupation) { return new Student(name, orientation, occupation);  }
    public Teacher CreateTeacher(string name, string orientation, string occupation) { return new Teacher(name, orientation, occupation); }
}