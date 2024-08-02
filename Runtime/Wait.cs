using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtilities
{
    public static class Wait
    {
        const int DefaultDictionaryCapacity = 100;

        static readonly WaitForEndOfFrame s_forEndOfFrame = new();
        static readonly WaitForFixedUpdate s_forFixedUpdate = new();
        static readonly Dictionary<float, WaitForSeconds> s_waitForSecondsDict = new(DefaultDictionaryCapacity, new FloatComparer());
        static readonly Dictionary<float, WaitForSecondsRealtime> s_waitForSecondsRealtimeDict = new(DefaultDictionaryCapacity, new FloatComparer());
        static readonly Dictionary<Func<bool>, WaitUntil> s_waitUntilDict = new(DefaultDictionaryCapacity);
        static readonly Dictionary<Func<bool>, WaitWhile> s_waitWhileDict = new(DefaultDictionaryCapacity);

        /// <summary>
        /// Suspends the coroutine execution until the end of the frame after Unity has rendered every Camera and GUI, just before displaying the frame on screen.
        /// </summary>
        public static WaitForEndOfFrame ForEndOfFrame => s_forEndOfFrame;
        
        /// <summary>
        /// Suspends the coroutine execution until the next FixedUpdate call.
        /// </summary>
        public static WaitForFixedUpdate ForFixedUpdate => s_forFixedUpdate;

        /// <summary>
        /// Suspends the coroutine execution for the given amount of <paramref name="seconds"/> using scaled time.
        /// </summary>
        /// <param name="seconds">The duration in seconds to wait.</param>
        /// <returns>
        /// A WaitForSeconds object with the supplied duration.
        /// Null if <paramref name="seconds"/> is less than the duration of a single frame, based on the application's target framerate.
        /// </returns>
        public static WaitForSeconds ForSeconds(float seconds)
        {
            if (seconds < 1f / Application.targetFrameRate) return null;

            if (!s_waitForSecondsDict.TryGetValue(seconds, out var waitForSeconds))
            {
                waitForSeconds = new WaitForSeconds(seconds);
                s_waitForSecondsDict[seconds] = waitForSeconds;
            }

            return waitForSeconds;
        }

        /// <summary>
        /// Suspends the coroutine execution for the given amount of <paramref name="seconds"/> using unscaled time.
        /// </summary>
        /// <param name="seconds">The duration in seconds to wait.</param>
        /// <returns>
        /// A WaitForSecondsRealtime object with the supplied duration.
        /// Null if <paramref name="seconds"/> is less than the duration of a single frame, based on the application's target framerate.
        /// </returns>
        public static WaitForSecondsRealtime ForSecondsRealtime(float seconds)
        {
            if (seconds < 1f / Application.targetFrameRate) return null;

            if (!s_waitForSecondsRealtimeDict.TryGetValue(seconds, out var waitForSecondsRealtime))
            {
                waitForSecondsRealtime = new WaitForSecondsRealtime(seconds);
                s_waitForSecondsRealtimeDict[seconds] = waitForSecondsRealtime;
            }
            
            return waitForSecondsRealtime;
        }

        /// <summary>
        /// Suspends the coroutine execution until the supplied delegate evaluates to true.
        /// </summary>
        /// <param name="predicate">The delegate to evaluate.</param>
        /// <returns>A WaitUntil object with the supplied delegate.</returns>
        public static WaitUntil Until(Func<bool> predicate)
        {
            if (predicate == null) return null;

            if (!s_waitUntilDict.TryGetValue(predicate, out var waitUntil))
            {
                waitUntil = new WaitUntil(predicate);
                s_waitUntilDict[predicate] = waitUntil;
            }

            return waitUntil;
        }

        /// <summary>
        /// Suspends the coroutine execution until the supplied delegate evaluates to false.
        /// </summary>
        /// <param name="predicate">The delegate to evaluate.</param>
        /// <returns>A WaitWhile object with the supplied delegate.</returns>
        public static WaitWhile While(Func<bool> predicate)
        {
            if (predicate == null) return null;

            if (!s_waitWhileDict.TryGetValue(predicate, out var waitWhile))
            {
                waitWhile = new WaitWhile(predicate);
                s_waitWhileDict[predicate] = waitWhile;
            }

            return waitWhile;
        }

        /// <summary>
        /// Equality comparer used by the WaitForSeconds and WaitForSecondsRealtime dictionaries.
        /// </summary>
        class FloatComparer : IEqualityComparer<float>
        {
            public bool Equals(float x, float y) => Mathf.Abs(x - y) <= Mathf.Epsilon;
            public int GetHashCode(float obj) => obj.GetHashCode();
        }
    }
}
