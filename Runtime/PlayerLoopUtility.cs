using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.LowLevel;

namespace UnityUtilities
{
    public static class PlayerLoopUtility
    {
        /// <summary>
        /// Tries to insert a PlayerLoopSystem into the <paramref name="loop"/>, at the given <paramref name="index"/>.
        /// </summary>
        /// <typeparam name="T">The player loop phase at which the <paramref name="systemToInsert"/> should run on.</typeparam>
        /// <param name="loop">The player loop that the <paramref name="systemToInsert"/> should be inserted into. Usually the CurrentPlayerLoop.</param>
        /// <param name="systemToInsert">The player loop system to be inserted.</param>
        /// <param name="index">The index at which the <paramref name="systemToInsert"/> should be inserted into.</param>
        /// <returns>True if the <paramref name="systemToInsert"/> was successfully inserted into the <paramref name="loop"/>, otherwise false.</returns>
        public static bool TryInsertSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToInsert, int index)
        {
            if (loop.type != typeof(T))
                return TryInsertSystemRecursive<T>(ref loop, systemToInsert, index);
            
            var playerLoopSystemList = new List<PlayerLoopSystem>();
            if (loop.subSystemList != null)
                playerLoopSystemList.AddRange(loop.subSystemList);

            playerLoopSystemList.Insert(index, systemToInsert);
            loop.subSystemList = playerLoopSystemList.ToArray();

            return true;
        }

        static bool TryInsertSystemRecursive<T>(ref PlayerLoopSystem loop, PlayerLoopSystem systemToInsert, int index)
        {
            if (loop.subSystemList == null) return false;

            for (int i = 0; i < loop.subSystemList.Length; i++)
                if (TryInsertSystem<T>(ref loop.subSystemList[i], in systemToInsert, index))
                    return true;

            return false;
        }

        /// <summary>
        /// Removes a PlayerLoopSystem from the <paramref name="loop"/>.
        /// </summary>
        /// <typeparam name="T">The player loop phase at which the <paramref name="systemToRemove"/> runs on.</typeparam>
        /// <param name="loop">The player loop that the <paramref name="systemToRemove"/> should be removed from. Usually the CurrentPlayerLoop.</param>
        /// <param name="systemToRemove">The PlayerLoopSystem to be removed.</param>
        public static void RemoveSystem<T>(ref PlayerLoopSystem loop, in PlayerLoopSystem systemToRemove)
        {
            if (loop.subSystemList == null) return;

            var playerLoopSystemList = new List<PlayerLoopSystem>(loop.subSystemList);
            for (int i = 0; i < playerLoopSystemList.Count; i++)
            {
                if (playerLoopSystemList[i].type == systemToRemove.type && playerLoopSystemList[i].updateDelegate == systemToRemove.updateDelegate)
                {
                    playerLoopSystemList.RemoveAt(i);
                    loop.subSystemList = playerLoopSystemList.ToArray();
                }
            }

            RemoveSystemRecursive<T>(ref loop, systemToRemove);
        }

        static void RemoveSystemRecursive<T>(ref PlayerLoopSystem loop, PlayerLoopSystem systemToRemove)
        {
            if (loop.subSystemList == null) return;

            for (int i = 0; i < loop.subSystemList.Length; i++)
                RemoveSystem<T>(ref loop.subSystemList[i], systemToRemove);
        }

        /// <summary>
        /// Prints out the provided PlayerLoop in the console. Useful for examaning all of the update phases in the PlayerLoop and debugging.
        /// </summary>
        /// <param name="loop"></param>
        public static void PrintPlayerLoop(PlayerLoopSystem loop)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Unity Player Loop");

            foreach (var subSystem in loop.subSystemList)
                PrintSubSystem(subSystem, sb, 0);

            Debug.Log(sb.ToString());
        }

        static void PrintSubSystem(PlayerLoopSystem system, StringBuilder sb, int level)
        {
            sb.Append(' ', level * 2).AppendLine(system.type.ToString());
            if (system.subSystemList == null || system.subSystemList.Length == 0) return;

            foreach (var subSystem in system.subSystemList)
                PrintSubSystem(subSystem, sb, level + 1);
        }

#if UNITY_EDITOR
        /// <summary>
        /// Shortcut to print out the current PlayerLoop in the console.
        /// </summary>
        [UnityEditor.MenuItem("Tools/Player Loop Utility/Print Current Player Loop")]
        static void PrintCurrentPlayerLoop() => PrintPlayerLoop(PlayerLoop.GetCurrentPlayerLoop());

        /// <summary>
        /// Shortcut to print out the default PlayerLoop in the console.
        /// </summary>
        [UnityEditor.MenuItem("Tools/Player Loop Utility/Print Default Player Loop")]
        static void PrintDefaultPlayerLoop() => PrintPlayerLoop(PlayerLoop.GetDefaultPlayerLoop());
#endif
    }
}
