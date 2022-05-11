// Zackhriamina3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <chrono>
#include <clocale>
#include <conio.h>
#include <cstdio>
#include <cstdlib>
#include <cstdlib>
#include <fstream>
#include <functional>
#include <iomanip>
#include <iostream>
#include <iostream>
#include <mpi.h>


double f(double x)
{
    return (x + 1) * log(x);
}

void parallel_matrix_v()
{
    int rank, size;
    int i, j;
    const int n = 1600;
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    size = 2;
    const int n_partial = n / size;
    const auto a_partial = new double[n_partial * n];
    auto* x = new double[n];
    auto* y_partial = new double[n_partial];
    auto* y_total = new double[n];
    const auto a = new double[n * n];
    if (rank == 0)
    {
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                a[i * n + j] = rand() % 100;
            }
        }
        for (i = 0; i < n; i++)
        {
            x[i] = rand() % 100;
        }
    }
    double t = MPI_Wtime();
    MPI_Bcast(x, n, MPI_DOUBLE, 0, MPI_COMM_WORLD);
    MPI_Scatter(a, n_partial * n, MPI_DOUBLE, a_partial, n_partial * n, MPI_DOUBLE, 0, MPI_COMM_WORLD);
    for (i = 0; i < n_partial; i++)
    {
        for (j = 0; j < n; j++)
            y_partial[i] += a_partial[i * n + j] * x[j];
    }
    MPI_Gather(y_partial, n_partial, MPI_DOUBLE, y_total, n_partial, MPI_DOUBLE, 0, MPI_COMM_WORLD);
    t = MPI_Wtime() - t;
    if (rank == 0)
    {
        std::cout << "time = " << t << "\n";
    }
    delete[] a_partial;
    delete[] a;
    delete[] x;
    delete[] y_partial;
    delete[] y_total;
}

void parallel_matrix()
{
    int rank, size;
    int i, j;
    const int n = 1600;
    MPI_Comm_size(MPI_COMM_WORLD, &size);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    size = 2;
    const int n_partial = n / size;
    const auto a_partial = new double[n_partial * n];
    const auto x = new double[n * n];
    const auto y_partial = new double[n_partial * n];
    const auto y_total = new double[n * n];
    auto a = new double[n * n];
    if (rank == 0)
    {
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                a[i * n + j] = rand() % 100;
                x[i * n + j] = rand() % 100;
            }
        }
    }
    double t = MPI_Wtime();
    MPI_Bcast(x, n, MPI_DOUBLE, 0, MPI_COMM_WORLD);
    MPI_Scatter(a, n_partial * n, MPI_DOUBLE, a_partial, n_partial * n, MPI_DOUBLE, 0, MPI_COMM_WORLD);
    for (i = 0; i < n_partial; i++)
    {
        for (j = 0; j < n; j++)
            for (int k = 0; k < n; k++)
                y_partial[i * n + j] += a_partial[i * n + k] * x[k * n + j];
    }
    MPI_Gather(y_partial, n_partial * n, MPI_DOUBLE, y_total, n_partial * n, MPI_DOUBLE, 0, MPI_COMM_WORLD);
    t = MPI_Wtime() - t;
    if (rank == 0)
    {
        std::cout << "time = " << t << "\n";
    }
    delete[] a_partial;
    delete[] a;
    delete[] x;
    delete[] y_partial;
    delete[] y_total;
}

double rectangle_integral() {
	const double b = 2.71828182845904;
	const double a = 1;
	const int n = 500;
    int proc_numb;
    int proc_rank;
    double sum_global;
    MPI_Comm_size(MPI_COMM_WORLD, &proc_numb);
    MPI_Comm_rank(MPI_COMM_WORLD, &proc_rank);
    proc_numb = 2;
    double t = MPI_Wtime();
    double s = (f(a) + f(b)) / 2;
	const double h = (b - a) / n;
    for (int i = 0; i < n; ++i)
        s += f(a + i * h);
    double sum = h * s;
    MPI_Reduce(&sum, &sum_global, 1, MPI_DOUBLE, MPI_SUM, 0, MPI_COMM_WORLD);
    t = MPI_Wtime() - t;
    std::cout << "time = " << t << " Значение = ";
    return sum;
}

double trapezoid_integral() {
	const double b = 2.71828182845904;
	const double a = 1;
	const int n = 500;
    double sum = 0;
    int proc_numb;
    int proc_rank;
    double sum_global;
    MPI_Comm_size(MPI_COMM_WORLD, &proc_numb);
    MPI_Comm_rank(MPI_COMM_WORLD, &proc_rank);
    proc_numb = 2;
    double t = MPI_Wtime();
    const double width = (b - a) / n;
    for (int step = 0; step < n; step++) {
        const double x1 = a + step * width;
        const double x2 = a + (static_cast<__int64>(step) + 1) * width;
        sum += 0.5 * (x2 - x1) * (f(x1) + f(x2));
    }
    MPI_Reduce(&sum, &sum_global, 1, MPI_DOUBLE, MPI_SUM, 0, MPI_COMM_WORLD);
    t = MPI_Wtime() - t;
    std::cout << "time = " << t << " Значение = ";
    return sum;
}

void recursive_quick_sort(int* mas, const int size) {
    int i = 0;
    int j = size - 1;
    int proc_numb;
    int proc_rank;
    const auto mass = new int[size];
    const auto c = new int[size];
    const auto cc = new int[size];
    MPI_Comm_size(MPI_COMM_WORLD, &proc_numb);
    MPI_Comm_rank(MPI_COMM_WORLD, &proc_rank);
    proc_numb = 2;
    MPI_Scatter(mas, size, MPI_INT, mass, size, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Barrier(MPI_COMM_WORLD);
    const int mid = mass[size / 2];
    do {
        while (mass[i] < mid) {
            i++;
        }
        while (mass[j] > mid) {
            j--;
        }
        if (i <= j) {
	        const int tmp = mass[i];
            mass[i] = mass[j];
            mass[j] = tmp;

            i++;
            j--;
        }
    } while (i <= j);
    if (j > 0) {
        recursive_quick_sort(mass, j + 1);
    }
    if (i < size) {
        recursive_quick_sort(&mass[i], size - i);
    }
    for (int k = 0; k < size; k++) {
        cc[k] = mass[k];
    }
    MPI_Barrier(MPI_COMM_WORLD);
    MPI_Gather(cc, size, MPI_INT, c, size, MPI_INT, 0, MPI_COMM_WORLD);
}

int main(int argc, char** argv)
{
	setlocale(LC_ALL, "RUS");
    printf("Матрично-векторное умножение 1600х1600 * 1600х1 - ");
    MPI_Init(&argc, &argv);
    parallel_matrix_v();
    printf("Матричное умножение 1600х1600 * 1600х1600 - ");
    parallel_matrix();
    printf("Быстрая сортировка 40000 элементов - ");
    int s[40000];
    double t = MPI_Wtime();
    for (int& j : s)
    {
	    j = rand() % 100;
    }
    recursive_quick_sort(s, 40000);
    t = MPI_Wtime() - t;
    std::cout << "time = " << t << "\n";
    printf("Метод прямоугольников - ");
    std::cout << rectangle_integral() << "\n";
    printf("Метод трапеций - ");
    std::cout << trapezoid_integral() << "\n";
    getchar();
    MPI_Finalize();
}
