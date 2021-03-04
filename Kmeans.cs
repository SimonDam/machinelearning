using System.Collections.Generic;
using System;

namespace machinelearning
{
    class Kmeans
    {
        public static List<int> Train(double[,] data, int k)
        {
            int amount_of_samples = data.GetLength(0);
            bool done = false;
            while(!done)
            {
                for(int i = 0; i < amount_of_samples; i++)
                {
                    System.Console.Write($"Row {i}: [");
                    for(int j = 0; j < data.GetLength(1); j++)
                    {
                        System.Console.Write($"{data[i,j]}, ");
                    }
                    System.Console.WriteLine("]");
                }

                List<double[]> centers = _initialize_centers(data, k);
                int count = 0;
                foreach(double[] center in centers)
                {
                    System.Console.Write($"k = {count}: ");
                    for(int i = 0; i < center.Length; i++)
                    {
                        System.Console.Write($"{center[i]} ");
                    }
                    System.Console.WriteLine();
                }
                done = true;
            }
            
            return null;
        }

        private static List<double[]> _initialize_centers(double[,] data, int k)
        {
            int amount_of_samples = data.GetLength(0);
            if(k > amount_of_samples)
            {
                throw new ArgumentException($"k must be at most equal to amount of samples. Samples={amount_of_samples}, k={k}");
            }

            var rand = new Random();
            List<int> cluster_indexes = new List<int>();

            for(int _temp = 0; _temp < k; _temp++)
            {
                int proposal = rand.Next(0, amount_of_samples);
                while(cluster_indexes.Contains(proposal))
                {
                    if(proposal == amount_of_samples - 1)
                    {
                        proposal = 0;
                    }
                    else
                    {
                        proposal++;
                    }
                }
                cluster_indexes.Add(proposal);
            }

            List<double[]> cluster_centers = new List<double[]>();
            int sample_len = data.GetLength(1);
            foreach(int index in cluster_indexes)
            {
                double[] sample = new double[sample_len]; 
                for(int i = 0; i < sample_len; i++)
                {
                    sample[i] = data[index, i];
                }
                cluster_centers.Add(sample);
            }

            return cluster_centers;
        }
    }
}