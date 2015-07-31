using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// Created in 2012 by Jakob Krarup (www.xnafan.net).
// Use, alter and redistribute this code freely,
// but please leave this comment :)

// Updated to add multithreading and caching in 2015 by ApexWeed.


namespace XnaFan.ImageComparison
{

    /// <summary>
    /// A class with extensionmethods for comparing images
    /// </summary>
    public static class ImageTool
    {
#pragma warning disable CC0033 // Dispose Fields Properly
        static readonly Mutex QueueMutex = new Mutex();
#pragma warning restore CC0033 // Dispose Fields Properly

        private static readonly PathGrayscaleTupleComparer Comparer = new PathGrayscaleTupleComparer();

        /// <summary>
        /// Gets the difference between two images as a percentage
        /// </summary>
        /// <returns>The difference between the two images as a percentage</returns>
        /// <param name="image1Path">The path to the first image</param>
        /// <param name="image2Path">The path to the second image</param>
        /// <param name="threshold">How big a difference (out of 255) will be ignored - the default is 3.</param>
        /// <returns>The difference between the two images as a percentage</returns>
        public static float GetPercentageDifference(string image1Path, string image2Path, byte threshold = 3)
        {
            if (CheckIfFileExists(image1Path) && CheckIfFileExists(image2Path))
            {
                var img1 = Image.FromFile(image1Path);
                var img2 = Image.FromFile(image2Path);

                var difference = img1.PercentageDifference(img2, threshold);

                img1.Dispose();
                img2.Dispose();

                return difference;
            }
            else return -1;
        }

        /// <summary>
        /// Gets the difference between two images as a percentage
        /// </summary>
        /// <returns>The difference between the two images as a percentage</returns>
        /// <param name="image1Path">The path to the first image</param>
        /// <param name="image2Path">The path to the second image</param>
        /// <returns>The difference between the two images as a percentage</returns>
        public static float GetBhattacharyyaDifference(string image1Path, string image2Path)
        {
            if (CheckIfFileExists(image1Path) && CheckIfFileExists(image2Path))
            {
                var img1 = Image.FromFile(image1Path);
                var img2 = Image.FromFile(image2Path);

                var difference = img1.BhattacharyyaDifference(img2);

                img1.Dispose();
                img2.Dispose();

                return difference;
            }
            else return -1;
        }


        /// <summary>
        /// Find all duplicate images in a folder, and possibly subfolders
        /// IMPORTANT: this method assumes that all files in the folder(s) are images!
        /// </summary>
        /// <param name="folderPath">The folder to look for duplicates in</param>
        /// <param name="checkSubfolders">Whether to look in subfolders too</param>
        /// <returns>A list of all the duplicates found, collected in separate Lists (one for each distinct image found)</returns>
        public static List<List<string>> GetDuplicateImages(string folderPath, bool checkSubfolders)
        {
            var imagePaths = Directory.GetFiles(folderPath, "*.*", checkSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList();
            return GetDuplicateImages(imagePaths);
        }

        /// <summary>
        /// Find all duplicate images from in list
        /// </summary>
        /// <param name="pathsOfPossibleDuplicateImages">The paths to the images to check for duplicates</param>
        /// <returns>A list of all the duplicates found, collected in separate Lists (one for each distinct image found)</returns>
        public static List<List<string>> GetDuplicateImages(IEnumerable<string> pathsOfPossibleDuplicateImages)
        {
            var imagePathsAndGrayValues = GetSortedGrayscaleValues(pathsOfPossibleDuplicateImages);
            var duplicateGroups = GetDuplicateGroups(imagePathsAndGrayValues);

            var pathsGroupedByDuplicates = new List<List<string>>();
            foreach (var list in duplicateGroups)
            {
                pathsGroupedByDuplicates.Add(list.Select(tuple => tuple.Item1).ToList());
            }

            return pathsGroupedByDuplicates;
        }

        /// <summary>
        /// Find all duplicate images from in list
        /// </summary>
        /// <param name="pathsOfPossibleDuplicateImages">The paths to the images to check for duplicates</param>
        /// <param name="Tolerance">How big a difference (out of 255) will be ignored.</param>
        /// <returns>A list of all the duplicates found, collected in separate Lists (one for each distinct image found)</returns>
        public static List<List<string>> GetDuplicateImages(IEnumerable<string> pathsOfPossibleDuplicateImages, byte Tolerance)
        {
            var imagePathsAndGrayValues = GetSortedGrayscaleValues(pathsOfPossibleDuplicateImages);
            var duplicateGroups = GetDuplicateGroups(imagePathsAndGrayValues, Tolerance);

            var pathsGroupedByDuplicates = new List<List<string>>();
            foreach (var list in duplicateGroups)
            {
                pathsGroupedByDuplicates.Add(list.Select(tuple => tuple.Item1).ToList());
            }

            return pathsGroupedByDuplicates;
        }

        /// <summary>
        /// Find all duplicate images from in list
        /// </summary>
        /// <param name="pathsOfPossibleDuplicateImages">The paths to the images to check for duplicates</param>
        /// <param name="Tolerance">How big a difference (out of 255) will be ignored.</param>
        /// <param name="ProgressChanged">IProgress object used to report progress of greyscale conversion.</param>
        /// <returns>A list of all the duplicates found, collected in separate Lists (one for each distinct image found)</returns>
        public static async Task<List<List<string>>> GetDuplicateImagesAsync(IEnumerable<string> pathsOfPossibleDuplicateImages, byte Tolerance, IProgress<Tuple<int, int>> ProgressChanged = null)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            await Task.Run(() => { imagePathsAndGrayValues = GetSortedGrayscaleValues(pathsOfPossibleDuplicateImages, ProgressChanged); });
            var duplicateGroups = new List<List<Tuple<string, byte[,]>>>();
            await Task.Run(() => { duplicateGroups = GetDuplicateGroups(imagePathsAndGrayValues, Tolerance); });

            var pathsGroupedByDuplicates = new List<List<string>>();
            foreach (var list in duplicateGroups)
            {
                pathsGroupedByDuplicates.Add(list.Select(tuple => tuple.Item1).ToList());
            }

            return pathsGroupedByDuplicates;
        }

        /// <summary>
        /// Find all duplicate images from in list
        /// </summary>
        /// <param name="pathsOfPossibleDuplicateImages">The paths to the images to check for duplicates</param>
        /// <param name="Tolerance">How big a difference (out of 255) will be ignored.</param>
        /// <param name="ProgressChanged">An IProgress that updates progress of the image loading.</param>
        /// <returns>A list of all the duplicates found, collected in separate Lists (one for each distinct image found)</returns>
        public static async Task<List<List<string>>> GetDuplicateImagesMultithreadedAsync(IEnumerable<string> pathsOfPossibleDuplicateImages, byte Tolerance, IProgress<Tuple<int, int>> ProgressChanged = null)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            await Task.Run(() => { imagePathsAndGrayValues = GetSortedGrayscaleValuesMultithreaded(pathsOfPossibleDuplicateImages, ProgressChanged); });
            var duplicateGroups = new List<List<Tuple<string, byte[,]>>>();
            await Task.Run(() => { duplicateGroups = GetDuplicateGroups(imagePathsAndGrayValues, Tolerance); });

            var pathsGroupedByDuplicates = new List<List<string>>();
            foreach (var list in duplicateGroups)
            {
                pathsGroupedByDuplicates.Add(list.Select(tuple => tuple.Item1).ToList());
            }

            return pathsGroupedByDuplicates;
        }

        /// <summary>
        /// Find all duplicate images from in list
        /// </summary>
        /// <param name="pathsOfPossibleDuplicateImages">The paths to the images to check for duplicates</param>
        /// <param name="Tolerance">How big a difference (out of 255) will be ignored.</param>
        /// <param name="ProgressChanged">An IProgress that updates the progress of the image loading.</param>
        /// <param name="Cache">A dictionary that contains the cache for greyscale thumbnails. This method will add new entries to the cache.</param>
        /// <returns>A list of all the duplicates found, collected in separate Lists (one for each distinct image found)</returns>
        public static async Task<List<List<string>>> GetDuplicateImagesMultithreadedCacheAsync(IEnumerable<string> pathsOfPossibleDuplicateImages, byte Tolerance, Dictionary<string, byte[,]> Cache, IProgress<Tuple<int, int>> ProgressChanged = null)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            await Task.Run(() => { imagePathsAndGrayValues = GetSortedGrayscaleValuesMultithreadedCache(pathsOfPossibleDuplicateImages, ProgressChanged, Cache); });
            var duplicateGroups = new List<List<Tuple<string, byte[,]>>>();
            await Task.Run(() => { duplicateGroups = GetDuplicateGroups(imagePathsAndGrayValues, Tolerance); });

            var pathsGroupedByDuplicates = new List<List<string>>();
            foreach (var list in duplicateGroups)
            {
                pathsGroupedByDuplicates.Add(list.Select(tuple => tuple.Item1).ToList());
            }

            return pathsGroupedByDuplicates;
        }

        #region Helpermethods

        private static List<Tuple<string, byte[,]>> GetSortedGrayscaleValues(IEnumerable<string> pathsOfPossibleDuplicateImages)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            foreach (var imagePath in pathsOfPossibleDuplicateImages)
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    var grayValues = image.GetGrayScaleValues();
                    var tuple = new Tuple<string, byte[,]>(imagePath, grayValues);
                    imagePathsAndGrayValues.Add(tuple);
                }
            }

            imagePathsAndGrayValues.Sort(Comparer);
            return imagePathsAndGrayValues;
        }

        private static List<Tuple<string, byte[,]>> GetSortedGrayscaleValues(IEnumerable<string> pathsOfPossibleDuplicateImages, IProgress<Tuple<int, int>> ProgressChanged)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            var count = pathsOfPossibleDuplicateImages.Count();
            var current = 0;
            foreach (var imagePath in pathsOfPossibleDuplicateImages)
            {
                using (Image image = Image.FromFile(imagePath))
                {
                    var grayValues = image.GetGrayScaleValues();
                    var tuple = new Tuple<string, byte[,]>(imagePath, grayValues);
                    imagePathsAndGrayValues.Add(tuple);
                    ProgressChanged.Report(new Tuple<int, int>(++current, count));
                }
            }

            imagePathsAndGrayValues.Sort(Comparer);
            return imagePathsAndGrayValues;
        }

        private static List<Tuple<string, byte[,]>> GetSortedGrayscaleValuesMultithreaded(IEnumerable<string> pathsOfPossibleDuplicateImages, IProgress<Tuple<int, int>> ProgressChanged)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            var count = pathsOfPossibleDuplicateImages.Count();

            var workers = new Thread[Environment.ProcessorCount];
            var workerFinished = new bool[Environment.ProcessorCount];
            var workItems = new Queue<string>();
            var workerData = new List<Tuple<string, byte[,]>>[Environment.ProcessorCount];
            var completedThreads = 0;

            foreach (var imagePath in pathsOfPossibleDuplicateImages)
            {
                workItems.Enqueue(imagePath);
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var innerI = i;
                workers[i] = new Thread(() => GetSortedGrayscaleValuesWork(innerI, workItems, workerData, ProgressChanged, count, workerFinished));
                workers[i].Start();
            }

            while (completedThreads < Environment.ProcessorCount)
            {
                completedThreads = 0;
                foreach (bool thread in workerFinished)
                    if (thread)
                        completedThreads++;

                Thread.Sleep(100);
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                imagePathsAndGrayValues.AddRange(workerData[i]);
            }

            imagePathsAndGrayValues.Sort(Comparer);
            return imagePathsAndGrayValues;
        }

        private static List<Tuple<string, byte[,]>> GetSortedGrayscaleValuesMultithreadedCache(IEnumerable<string> pathsOfPossibleDuplicateImages, IProgress<Tuple<int, int>> ProgressChanged, Dictionary<string, byte[,]> Cache)
        {
            var imagePathsAndGrayValues = new List<Tuple<string, byte[,]>>();
            var count = pathsOfPossibleDuplicateImages.Count();

            var workers = new Thread[Environment.ProcessorCount];
            var workerFinished = new bool[Environment.ProcessorCount];
            var workItems = new Queue<string>();
            var workerData = new List<Tuple<string, byte[,]>>[Environment.ProcessorCount];
            var completedThreads = 0;

            foreach (var imagePath in pathsOfPossibleDuplicateImages)
            {
                workItems.Enqueue(imagePath);
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                var innerI = i;
                workers[i] = new Thread(() => GetSortedGrayscaleValuesCacheWork(innerI, workItems, workerData, ProgressChanged, count, workerFinished, Cache));
                workers[i].Start();
            }

            while (completedThreads < Environment.ProcessorCount)
            {
                completedThreads = 0;
                foreach (bool thread in workerFinished)
                    if (thread)
                        completedThreads++;

                Thread.Sleep(100);
            }

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                imagePathsAndGrayValues.AddRange(workerData[i]);
            }

            imagePathsAndGrayValues.Sort(Comparer);
            return imagePathsAndGrayValues;
        }

        private static void GetSortedGrayscaleValuesWork(int Id, Queue<string> WorkItems, List<Tuple<string, byte[,]>>[] WorkerData, IProgress<Tuple<int, int>> ProgressChanged, int TotalItems, bool[] WorkerFinished)
        {
            WorkerData[Id] = new List<Tuple<string, byte[,]>>();
            while (WorkItems.Count > 0)
            {
                QueueMutex.WaitOne();
                var currentWorkItem = WorkItems.Dequeue();
                QueueMutex.ReleaseMutex();
                using (Image image = Image.FromFile(currentWorkItem))
                {
                    var grayValues = image.GetGrayScaleValues();
                    var tuple = new Tuple<string, byte[,]>(currentWorkItem, grayValues);
                    WorkerData[Id].Add(tuple);
                    ProgressChanged.Report(new Tuple<int, int>(TotalItems - WorkItems.Count, TotalItems));
                }
            }
            WorkerFinished[Id] = true;
        }

        private static void GetSortedGrayscaleValuesCacheWork(int Id, Queue<string> WorkItems, List<Tuple<string, byte[,]>>[] WorkerData, IProgress<Tuple<int, int>> ProgressChanged, int TotalItems, bool[] WorkerFinished, Dictionary<string, byte[,]> Cache)
        {
            WorkerData[Id] = new List<Tuple<string, byte[,]>>();
            while (WorkItems.Count > 0)
            {
                QueueMutex.WaitOne();
                if (WorkItems.Count == 0)
                    break;
                var currentWorkItem = WorkItems.Dequeue();
                QueueMutex.ReleaseMutex();
                if (Cache.ContainsKey(currentWorkItem))
                {
                    var tuple = new Tuple<string, byte[,]>(currentWorkItem, Cache[currentWorkItem]);
                    WorkerData[Id].Add(tuple);
                    ProgressChanged.Report(new Tuple<int, int>(TotalItems - WorkItems.Count, TotalItems));
                }
                else
                {
                    using (Image image = Image.FromFile(currentWorkItem))
                    {
                        var grayValues = image.GetGrayScaleValues();
                        var tuple = new Tuple<string, byte[,]>(currentWorkItem, grayValues);
                        WorkerData[Id].Add(tuple);
                        Cache.Add(currentWorkItem, grayValues);
                        ProgressChanged.Report(new Tuple<int, int>(TotalItems - WorkItems.Count, TotalItems));
                    }
                }
            }
            WorkerFinished[Id] = true;
        }

        private static List<List<Tuple<string, byte[,]>>> GetDuplicateGroups(List<Tuple<string, byte[,]>> imagePathsAndGrayValues)
        {
            var duplicateGroups = new List<List<Tuple<string, byte[,]>>>();
            var currentDuplicates = new List<Tuple<string, byte[,]>>();

            foreach (Tuple<string, byte[,]> tuple in imagePathsAndGrayValues)
            {
                if (currentDuplicates.Any() && Comparer.Compare(currentDuplicates.First(), tuple) != 0)
                {
                    if (currentDuplicates.Count > 1)
                    {
                        duplicateGroups.Add(currentDuplicates);
                        currentDuplicates = new List<Tuple<string, byte[,]>>();
                    }
                    else
                    {
                        currentDuplicates.Clear();
                    }
                }

                currentDuplicates.Add(tuple);
            }
            if (currentDuplicates.Count > 1)
            {
                duplicateGroups.Add(currentDuplicates);
            }
            return duplicateGroups;
        }

        private static List<List<Tuple<string, byte[,]>>> GetDuplicateGroups(List<Tuple<string, byte[,]>> imagePathsAndGrayValues, byte Tolerance)
        {
            var duplicateGroups = new List<List<Tuple<string, byte[,]>>>();
            var currentDuplicates = new List<Tuple<string, byte[,]>>();

            foreach (Tuple<string, byte[,]> tuple in imagePathsAndGrayValues)
            {
                if (currentDuplicates.Any() && currentDuplicates.First().Compare(tuple, Tolerance) != 0)
                {
                    if (currentDuplicates.Count > 1)
                    {
                        duplicateGroups.Add(currentDuplicates);
                        currentDuplicates = new List<Tuple<string, byte[,]>>();
                    }
                    else
                    {
                        currentDuplicates.Clear();
                    }
                }

                currentDuplicates.Add(tuple);
            }
            if (currentDuplicates.Count > 1)
            {
                duplicateGroups.Add(currentDuplicates);
            }
            return duplicateGroups;
        }

        private static bool CheckIfFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File '" + filePath + "' not found!");
            }
            return true;
        }
        #endregion

    }
}