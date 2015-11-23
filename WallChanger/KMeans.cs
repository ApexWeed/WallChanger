using System;
using System.IO;
using System.Threading.Tasks;

namespace WallChanger
{
    public static class KMeans
    {
        public static int Mean(int[] RawData, int NumberOfClusters = 5)
        {
            var data = PrepareData(RawData);
            var clusters = Cluster(data, NumberOfClusters);
            var means = new int[NumberOfClusters];
            var meanCounts = new int[NumberOfClusters];
            var max = 0;
            var hue = 0;
            using (var fs = File.Open("butt.txt", FileMode.Create))
            {
                using (var w = new StreamWriter(fs))
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        w.Write($"{data[i][0]},{data[i][1]}\n");
                    }
                    w.Write("\n");
                    for (int i = 0; i < data.Length; i++)
                    {
                        w.Write($"{clusters[i]}, ");
                        means[clusters[i]] += data[i][0] * data[i][1];
                        meanCounts[clusters[i]] += data[i][1];
                    }
                    w.Write('\n');
                    for (int i = 0; i < NumberOfClusters; i++)
                    {
                        var mean = meanCounts[i] == 0 ? 0 : means[i] / meanCounts[i];
                        w.WriteLine($"{means[i]} {meanCounts[i]} {mean}");
                        System.Diagnostics.Debug.Print($"mean: {means[i]}, count: {meanCounts[i]}, value: {mean}");
                        means[i] = mean;
                        if (meanCounts[i] > max)
                        {
                            max = meanCounts[i];
                            hue = means[i];
                        }
                    }
                    w.Write($"\nHue: {hue}\n");
                    ShowVector(clusters, true, w);
                    ShowData(data, false, true, w);
                    ShowClustered(data, clusters, NumberOfClusters, w);
                }
            }

            return hue;
        }

        private static int[][] PrepareData(int[] RawData)
        {
            var nonZero = 0;
            for (int i = 0; i < RawData.Length; i++)
            {
                if (RawData[i] != 0)
                    nonZero++;
            }
            var data = new int[nonZero][];
            var index = 0;
            for (int i = 0; i < RawData.Length; i++)
            {
                if (RawData[i] != 0)
                {
                    data[index] = new int[2];
                    data[index][0] = i;
                    data[index][1] = RawData[i];
                    index++;
                }
            }

            return data;
        }

        public static int[] Cluster(int[][] RawData, int NumberOfClusters)
        {
            var data = Normalise(RawData);
            var changed = true;
            var success = true;
            var clustering = InitClustering(data.Length, NumberOfClusters);
            var means = Allocate(NumberOfClusters, data[0].Length);
            var maxCount = data.Length * 10;
            var ct = 0;
            while (changed && success && ct < maxCount)
            {
                ct++;
                success = UpdateMeans(data, clustering, means);
                changed = UpdateClustering(data, clustering, means);
            }

            return clustering;
        }

        private static double[][] Normalise(int[][] RawData)
        {
            var result = new double[RawData.Length][];
            for (int i = 0; i < RawData.Length; i++)
            {
                result[i] = new double[RawData[i].Length];
                Array.Copy(RawData[i], result[i], RawData[i].Length);
            }

            for (int j = 0; j < result[0].Length; j++)
            {
                var colSum = 0.0;
                for (int i = 0; i < result.Length; i++)
                {
                    colSum += result[i][j];
                }
                var mean = colSum / result.Length;
                var sum = 0.0;
                for (int i = 0; i < result.Length; i++)
                {
                    sum += (result[i][j] - mean) * (result[i][j] - mean);
                }
                var sd = sum / result.Length;
                for (int i = 0; i < result.Length; i++)
                {
                    result[i][j] = (result[i][j] - mean) / sd;
                }
            }

            return result;
        }

        private static int[] InitClustering(int NumberOfTuples, int NumberOfClusters)
        {
            var random = new Random();
            var clustering = new int[NumberOfTuples];
            for (int i = 0; i < NumberOfClusters; i++)
            {
                clustering[i] = i;
            }
            for (int i = NumberOfClusters; i < clustering.Length; i++)
            {
                clustering[i] = random.Next(0, NumberOfClusters);
            }

            return clustering;
        }

        private static bool UpdateMeans(double[][] Data, int[] Clustering, double[][] Means)
        {
            var numberOfClusters = Means.Length;
            var clusterCounts = new int[numberOfClusters];
            for (int i = 0; i < Data.Length; i++)
            {
                var cluster = Clustering[i];
                clusterCounts[cluster]++;
            }

            for (int i = 0; i < numberOfClusters; i++)
            {
                if (clusterCounts[i] == 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < Means.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Means[i][j] = 0.0;
                }
            }

            for (int i = 0; i < Data.Length; i++)
            {
                var cluster = Clustering[i];
                for (int j = 0; j < Data[i].Length; j++)
                {
                    Means[cluster][j] += Data[i][j];
                }
            }

            for (int i = 0; i < Means.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Means[i][j] /= clusterCounts[i];
                }
            }

            return true;
        }

        private static double[][] Allocate(int NumberOfClusters, int NumberOfColumns)
        {
            var result = new double[NumberOfClusters][];
            for (int i = 0; i < NumberOfClusters; i++)
            {
                result[i] = new double[NumberOfColumns];
            }
            return result;
        }

        private static bool UpdateClustering(double[][] Data, int[] Clustering, double[][] Means)
        {
            var numberOfClusters = Means.Length;
            var changed = false;

            var newClustering = new int[Clustering.Length];
            Array.Copy(Clustering, newClustering, Clustering.Length);

            var distances = new double[numberOfClusters];

            Parallel.For(0, Data.Length, (i) =>
            {
                for (int j = 0; j < numberOfClusters; j++)
                {
                    distances[j] = Distance(Data[i], Means[j]);
                }

                var newClusterID = MinIndex(distances);
                if (newClusterID != newClustering[i])
                {
                    changed = true;
                    newClustering[i] = newClusterID;
                }
            });

            if (!changed)
            {
                return false;
            }

            var clusterCounts = new int[numberOfClusters];
            for (int i = 0; i < Data.Length; i++)
            {
                var cluster = newClustering[i];
                clusterCounts[cluster]++;
            }

            for (int i = 0; i < numberOfClusters; i++)
            {
                if (clusterCounts[i] == 0)
                {
                    return false;
                }
            }

            Array.Copy(newClustering, Clustering, newClustering.Length);
            return true;
        }

        private static double Distance(double[] Tuple, double[] Mean)
        {
            var sumSquaredDiffs = 0.0;
            for (int i = 0; i < Tuple.Length; i++)
            {
                sumSquaredDiffs += (Tuple[i] - Mean[i]) * (Tuple[i] - Mean[i]);
            }
            return Math.Sqrt(sumSquaredDiffs);
        }

        private static int MinIndex(double[] Distances)
        {
            var indexOfMin = 0;
            var smallDist = Distances[0];
            for (int i = 0; i < Distances.Length; i++)
            {
                if (Distances[i] < smallDist)
                {
                    smallDist = Distances[i];
                    indexOfMin = i;
                }
            }

            return indexOfMin;
        }

        private static void ShowData(int[][] data, bool indices, bool newLine, StreamWriter w)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (indices)
                    w.Write(i.ToString().PadLeft(3) + " ");
                for (int j = 0; j < data[i].Length; ++j)
                {
                    if (data[i][j] >= 0.0)
                        w.Write(" ");
                    w.Write(data[i][j] + " ");
                }
                w.Write('\n');
            }
            if (newLine)
                w.Write('\n');
        }

        private static void ShowVector(int[] vector, bool newLine, StreamWriter w)
        {
            for (int i = 0; i < vector.Length; ++i)
                w.Write(vector[i] + " ");
            if (newLine)
                w.Write('\n');
        }

        private static void ShowClustered(int[][] data, int[] clustering, int numClusters, StreamWriter w)
        {
            for (int k = 0; k < numClusters; ++k)
            {
                w.Write("===================\n");
                for (int i = 0; i < data.Length; ++i)
                {
                    var clusterID = clustering[i];
                    if (clusterID != k)
                        continue;
                    w.Write(i.ToString().PadLeft(3) + " ");
                    for (int j = 0; j < data[i].Length; ++j)
                    {
                        if (data[i][j] >= 0.0)
                            w.Write(" ");
                        w.Write(data[i][j] + " ");
                    }
                    w.Write('\n');
                }
                w.Write("===================\n");
            } // k
        }
    }
}
