using System;
using System.Text;

namespace FieldApp
{
    // Базовий клас Field
    class Field
    {
        // Захищені поля
        protected string name;
        protected double r; // вага посіяних насіння
        protected double k; // коефіцієнт типу поля

        // Конструктор базового класу
        public Field(string name, double r, double k)
        {
            this.name = name;
            this.r = r;
            this.k = k;
        }

        // Приватний метод для розрахунку врожаю з одиниці площі
        private double Calculate()
        {
            return k * r;
        }

        // Приватний метод для виведення інформації про поле
        private void DisplayInfo()
        {
            Console.WriteLine($"Поле: {name}");
            Console.WriteLine($"Вага насіння на одиницю: {r}");
            Console.WriteLine($"Коефіцієнт врожайності: {k}");
            Console.WriteLine($"Врожай з одиниці: {Calculate()}");
        }

        // Метод для доступу до приватних методів (можна викликати у нащадках)
        public void ShowInfo()
        {
            DisplayInfo();
        }

        // Метод для доступу до приватного методу розрахунку
        public double GetYieldPerUnit()
        {
            return Calculate();
        }
    }

    // Похідний клас PotatoField
    class PotatoField : Field
    {
        // Захищене поле площі
        protected double S;

        // Конструктор похідного класу
        public PotatoField(string name, double r, double k, double S)
            : base(name, r, k)
        {
            this.S = S;
        }

        // Приватний метод для розрахунку загального врожаю
        private double CalculateTotalYield()
        {
            return GetYieldPerUnit() * S;
        }

        // Приватний метод для виведення інформації про поле
        private new void DisplayInfo()
        {
            base.ShowInfo(); // Викликає метод виведення базового класу
            Console.WriteLine($"Площа поля: {S}");
            Console.WriteLine($"Загальний врожай: {CalculateTotalYield()}");
        }

        // Метод для доступу до інформації про поле
        public new void ShowInfo()
        {
            DisplayInfo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Дані від користувача для базового поля
            Console.Write("Введіть назву базового поля: ");
            string baseFieldName = Console.ReadLine();

            Console.Write("Введіть вагу насіння на одиницю для базового поля: ");
            double baseR = double.Parse(Console.ReadLine());

            Console.Write("Введіть коефіцієнт врожайності для базового поля: ");
            double baseK = double.Parse(Console.ReadLine());

            // Створюємо об'єкт базового класу
            Field field = new Field(baseFieldName, baseR, baseK);

            // Дані від користувача для поля картоплі
            Console.Write("\nВведіть назву поля картоплі: ");
            string potatoFieldName = Console.ReadLine();

            Console.Write("Введіть вагу насіння на одиницю для поля картоплі: ");
            double potatoR = double.Parse(Console.ReadLine());

            Console.Write("Введіть коефіцієнт врожайності для поля картоплі: ");
            double potatoK = double.Parse(Console.ReadLine());

            Console.Write("Введіть площу для поля картоплі: ");
            double S = double.Parse(Console.ReadLine());

            // Створення об'єкту похідного класу
            PotatoField potatoField = new PotatoField(potatoFieldName, potatoR, potatoK, S);

            // Викликаємо методи для відображення інформації
            Console.WriteLine("\nІнформація про базове поле:");
            field.ShowInfo();

            Console.WriteLine("\nІнформація про поле картоплі:");
            potatoField.ShowInfo();

            Console.ReadKey(); 
        }
    }
}
