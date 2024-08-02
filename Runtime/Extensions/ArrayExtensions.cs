using UnityEngine;

namespace UnityUtilities
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns a random element from the array.
        /// </summary>
        public static T GetRandom<T>(this T[] array) => array[Random.Range(0, array.Length)];

        /// <summary>
        /// Shuffles the elements of the input array in-place and returns the result.
        /// </summary>
        public static T[] Shuffle<T>(this T[] array)
        {
            var count = array.Length;
            while (count > 1)
            {
                var index = Random.Range(0, count);
                count--;
                (array[index], array[count]) = (array[count], array[index]);
            }

            return array;
        }

        /// <summary>
        /// Returns a shuffled copy of the array.
        /// </summary>
        public static T[] ShuffledCopy<T>(this T[] array)
        {
            var result = new T[array.Length];
            System.Array.Copy(array, result, array.Length);

            return result.Shuffle();
        }
    }
}
