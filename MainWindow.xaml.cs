using System;
using System.Windows;

namespace WpfApp.QuadraticEquationApp
{
    public partial class MainWindow : Window
    {
        private double _a, _b, _c;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputA.Text, out _a) || !double.TryParse(InputB.Text, out _b) || !double.TryParse(InputC.Text, out _c))
            {
                MessageBox.Show("Введите корректные значения для всех коэффициентов.");
                return;
            }
            try
            {
                var eq1 = new QuadraticEquation(_a, _b, _c);
                double[] roots = eq1.Solve();

                if (roots.Length == 0)
                {
                    RootsTextBlock.Text = "Корней нет";
                }
                else
                {
                    RootsTextBlock.Text = "Корни уравнения: ";
                    foreach (double root in roots)
                    {
                        RootsTextBlock.Text += root + " ";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void CheckOperationsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var eq1 = new QuadraticEquation(_a, _b, _c);

                eq1++;
                eq1--;

                double discriminant = eq1;
                bool hasRoots = (bool)eq1;

                MessageBox.Show($"Дискриминант: {discriminant}\nЕсть ли корни: {hasRoots}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
