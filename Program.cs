
class Program
    {
        static double Function(double x)
        {
            return 2 * x * x - 5 - Math.Pow(2, x);
        }

        static double Derivative(double x)
        {
            return 4 * x - Math.Pow(2, x) * Math.Log(2);
        }

        static double CombinedMethod(double a, double b, double eps)
        {
            double x0 = a, x1 = b;
            while (Math.Abs(x1 - x0) > eps)
            {
                double f0 = Function(x0);
                double f1 = Function(x1);
                double f0_der = Derivative(x0);

                // Метод хорд
                double x_new = x1 - f1 * (x1 - x0) / (f1 - f0);
                // Метод касательных
                if (Math.Abs(f0_der) > eps)
                    x_new = x0 - f0 / f0_der;

                x0 = x1;
                x1 = x_new;
            }
            return x1;
        }

        static void Main()
        {
            double a = 2.1;
            double b = 2.2;
            double eps = 0.000001;
            double root = CombinedMethod(a, b, eps);
            Console.WriteLine($"Корень комбинированным методом: {root}");
        }
    }

