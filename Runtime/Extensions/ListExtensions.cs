using System.Collections.Generic;
using UnityEngine;

namespace UnityUtilities
{
    public static class ListExtensions
    {
        /// <summary>
        /// Returns a random element from the list.
        /// </summary>
        public static T GetRandom<T>(this List<T> list) => list[Random.Range(0, list.Count)];

        /// <summary>
        /// Shuffles the elements of the input list in-place and returns the result.
        /// </summary>
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var count = list.Count;
            while (count > 1)
            {
                var index = Random.Range(0, count);
                count--;
                (list[index], list[count]) = (list[count], list[index]);
            }

            return list;
        }

        /// <summary>
        /// Returns a shuffled copy of the list.
        /// </summary>
        public static List<T> ShuffledCopy<T>(this List<T> list) => new List<T>(list).Shuffle();
    }
}
