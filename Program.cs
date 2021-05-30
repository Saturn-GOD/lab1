using System;

namespace lab2_2_1
{
    class Program
    {
        public delegate float SampleDelegate(float a, float b, float c);
        public delegate float Calc(float a, float b);
        public delegate int Average(int a);
        
        

        static void Main(string[] args)
        {
            float a = 3;
            float b = 4;
            float c = 5;

            //Анонимный метод
            SampleDelegate sd;
            sd = delegate(float a, float b, float c) { return (a+b+c)/3 ; } ;
            Console.WriteLine("Среднее арифметическое 3, 4, 5: " + sd(a,b,c) + "\n\n");

            //Калькулятор
            Console.Write("   Калькулятор\n\nВведите первое число: ");
            a = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите второе число: ");
            b = (float)Convert.ToDouble(Console.ReadLine());

            Calc calc1 = Add;
            int add =  Convert.ToInt32(calc1(a, b));
            Console.WriteLine($"Добавление: {add}");
            calc1 = Sub;
            int sub = Convert.ToInt32(calc1(a, b));
            Console.WriteLine($"Отнимание: {sub}");
            calc1 = Div;
            int div = Convert.ToInt32(calc1(a, b));
            Console.WriteLine($"Деление: {calc1(a, b)}");
            calc1 = Mult;
            int mult = Convert.ToInt32(calc1(a, b));
            Console.WriteLine($"Умножение: {mult}\n\n");

            //Анонимный метод который возвращает среднее арифметическое массива делегатов.
            Random rnd = new Random();
            Average[] averageArr = new Average[rnd.Next(1, 10)];
            int asd = 0;
            for (int i = 0; i < averageArr.Length; i++)
            {
                averageArr[i] = delegate (int a) { return a; };
                asd += averageArr[i].Invoke(rnd.Next(1, 10));
            }

            Console.WriteLine("Среднее арифметическое (масив делегатов с рандомными числами): " + asd / averageArr.Length);
            Console.ReadKey();

        }

        public static float Add(float a, float b)
        {
            return a + b;
    }

        private static float Sub(float a, float b)
        {
            return a - b;
        }

        private static float Div(float a, float b)
        {
            if (b == 0)
            {
                Console.WriteLine("Ошибка: делимость = 0");
                return 0;
            }
            else
            {
                return a / b;
            }
        }

        private static float Mult(float a, float b)
        {
            return a * b;
        }

        

    }
}
