using System;

namespace machinelearning
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] data = new double[,] {{1,2}, {3,4}, {5,6}, {7, 8}, {9, 10}, {11, 12}};

            Kmeans.Train(data, 7);
        }
    }
}
