using System;
using System.Text;

public class Matrix
{
    private readonly double[,] data;
    public int Rows { get; }
    public int Cols { get; }

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        data = new double[rows, cols];
    }

    public Matrix(double[,] array)
    {
        Rows = array.GetLength(0);
        Cols = array.GetLength(1);
        data = (double[,])array.Clone();
    }

    public double this[int r, int c]
    {
        get => data[r, c];
        set => data[r, c] = value;
    }

    public double Determinant()
    {
        if (Rows != Cols) throw new InvalidOperationException();
        return Det(data, Rows);
    }

    private static double Det(double[,] m, int n)
    {
        if (n == 1) return m[0, 0];
        if (n == 2) return m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];

        double d = 0;
        for (int k = 0; k < n; k++)
        {
            double[,] minor = new double[n - 1, n - 1];
            for (int i = 1; i < n; i++)
                for (int j = 0, col = 0; j < n; j++)
                    if (j != k) minor[i - 1, col++] = m[i, j];
            d += (k % 2 == 0 ? 1 : -1) * m[0, k] * Det(minor, n - 1);
        }
        return d;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Rows; i++)
        {
            sb.Append("|");
            for (int j = 0; j < Cols; j++)
                sb.Append($" {data[i, j]:F2}");
            sb.Append(" |\n");
        }
        return sb.ToString();
    }
}

public class Program
{
    public static void Main()
    {
        Matrix m = new Matrix(3, 3);
        m[0, 0] = 1; m[0, 1] = 2; m[0, 2] = 3;
        m[1, 0] = 4; m[1, 1] = 5; m[1, 2] = 6;
        m[2, 0] = 7; m[2, 1] = 8; m[2, 2] = 9;

        Console.WriteLine("Матрица:");
        Console.WriteLine(m);

        try
        {
            Console.WriteLine($"Определитель: {m.Determinant():F2}");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Определитель вычисляется только для квадратных матриц");
        }
    }
}