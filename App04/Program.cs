using System;
using System.Text;

namespace App04
{
    abstract class Being
    {
        protected string name;
        protected string species;
        protected const bool living = true;

        public abstract void setName();
        public abstract string getName();
        public abstract string getSpecies();
        public override string ToString()
        {
            return "This object is a member of the Abstract Being Class";
        }
    }
    class Human : Being
    {

        private int age;

        public override void setName()
        {
            this.name = Console.ReadLine();
        }
        public override string getName()
        {
            return this.name;
        }
        public override string getSpecies()
        {
            return this.species;
        }
        public override string ToString()
        {
            return "This object is a member of the Derived Class Human";
        }
        public void setAge(int age)
        {
            this.age = age;
        }
        public int getAge()
        {
            return this.age;
        }

        public Human()
        {
            this.name = null;
            this.species = "Human";
        }
        public Human(string name, int age)
        {
            this.name = name;
            this.species = "Human";
            this.age = age;
        }
    }
    class Dog : Being
    {
        private string dogBreed;
        public override void setName()
        {
            this.name = Console.ReadLine();
        }
        public override string getName()
        {
            return this.name;
        }
        public override string getSpecies()
        {
            return this.species;
        }
        public override string ToString()
        {
            return "This object is a member of the Derived Class Dog";
        }
        public void setDogBreed(string dogBreed)
        {
            this.dogBreed = dogBreed;
        }
        public string getDogBreed()
        {
            return this.dogBreed;
        }

        public Dog()
        {
            this.name = null;
            this.species = "Dog";
        }
        public Dog(string name, string dogBreed)
        {
            this.name = name;
            this.species = "Dog";
            this.dogBreed = dogBreed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This small program shows OOP.");
            Console.WriteLine("It shows abstract classes, iheritance, polymorphism, and encapsulation.");
            Console.WriteLine("It uses a simple Being class that is abstract with derived classes of Human and Dog to show these concepts.");
        
            var human = new Human("Rodney", 35);
            var dog = new Dog("Buddy", "Lab/Weimaraner");

            Console.WriteLine(human.ToString());
            Console.WriteLine(dog.ToString());

            Console.WriteLine("Today {0} is going to adopt {1} for his family." , human.getName(), dog.getName());
            Console.WriteLine("{0} is {1} years old and he has wanted a dog for a long time." , human.getName(), human.getAge());
            Console.WriteLine("{0} is a {1} mixed breed dog and he is about 1 year old." , dog.getName(), dog.getDogBreed());

        }
    }
}
