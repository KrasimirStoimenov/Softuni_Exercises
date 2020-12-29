using System;
using System.Linq;

class Person
{
    protected string firstName;
    protected string lastName;
    protected int id;

    public Person() { }
    public Person(string firstName, string lastName, int identification)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.id = identification;
    }
    public void printPerson()
    {
        Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
    }
}

class Student : Person
{
    private int[] testScores;

    public Student(string firstName, string lastName, int identification, int[] scores)
        : base(firstName, lastName, identification)
    {
        this.testScores = scores;
    }

    public char Calculate()
    {
        int average = (int)testScores.Average();

        if(average < 40)
        {
            return 'T';
        }
        else if (average < 55)
        {
            return 'D';
        }
        else if (average < 70)
        {
            return 'P';
        }
        else if (average < 80)
        {
            return 'A';
        }
        else if (average < 90)
        {
            return 'E';
        }
        else
        {
            return 'O';
        }
    }
}

class Solution
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        string firstName = inputs[0];
        string lastName = inputs[1];
        int id = Convert.ToInt32(inputs[2]);
        int numScores = Convert.ToInt32(Console.ReadLine());
        inputs = Console.ReadLine().Split();
        int[] scores = new int[numScores];
        for (int i = 0; i < numScores; i++)
        {
            scores[i] = Convert.ToInt32(inputs[i]);
        }

        Student s = new Student(firstName, lastName, id, scores);
        s.printPerson();
        Console.WriteLine("Grade: " + s.Calculate() + "\n");
    }
}