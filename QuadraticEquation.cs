using System;

namespace WpfApp.QuadraticEquationApp
{
    public class QuadraticEquation
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        public QuadraticEquation(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        public double A
        {
            get { return _a; }
        }

        public double B
        {
            get { return _b; }
        }

        public double C
        {
            get { return _c; }
        }

        public double[] Solve()
        {
            if (_a == 0)
            {
                if (_b == 0)
                {
                    if (_c == 0)
                    {
                        throw new InvalidOperationException("Уравнение имеет бесконечно много решений.");
                    }
                    else
                    {
                        return new double[0];
                    }
                }
                else
                {
                    double x = -_c / _b;
                    return new[] { x };
                }
            }

            double discriminant = _b * _b - 4 * _a * _c;

            if (discriminant < 0)
            {
                return new double[0];
            }

            if (discriminant == 0)
            {
                double x = -_b / (2 * _a);
                return new[] { x };
            }

            double sqrtD = Math.Sqrt(discriminant);
            double x1 = (-_b + sqrtD) / (2 * _a);
            double x2 = (-_b - sqrtD) / (2 * _a);

            return new[] { x1, x2 };
        }

        public override string ToString()
        {
            return $"{_a}x^2 + {_b}x + {_c} = 0";
        }

        public static QuadraticEquation operator ++(QuadraticEquation equation)
        {
            return new QuadraticEquation(equation._a + 1, equation._b + 1, equation._c + 1);
        }

        public static QuadraticEquation operator --(QuadraticEquation equation)
        {
            return new QuadraticEquation(equation._a - 1, equation._b - 1, equation._c - 1);
        }

        public static implicit operator double(QuadraticEquation equation)
        {
            return equation._b * equation._b - 4 * equation._a * equation._c;
        }

        public static explicit operator bool(QuadraticEquation equation)
        {
            return (equation._b * equation._b - 4 * equation._a * equation._c) >= 0;
        }

        public static bool operator ==(QuadraticEquation left, QuadraticEquation right)
        {
            return !(left is null || right is null) &&
                   left._a == right._a &&
                   left._b == right._b &&
                   left._c == right._c;
        }


        public static bool operator !=(QuadraticEquation left, QuadraticEquation right)
        {
            return !(left == right);
        }

    }
}