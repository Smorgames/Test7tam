using System.Text;
using UnityEngine;

namespace Utilities
{
    public static class Utils
    {
        public static void DebugTwoDimensionArray<T>(T[,] array)
        {
            var sb = new StringBuilder();

            for (var y = array.GetLength(1) - 1; y >= 0; y--)
            {
                sb.Clear();
                sb.Append('[');

                for (var x = 0; x < array.GetLength(0); x++)
                {
                    var line = x != array.GetLength(0) - 1 ? $"{array[x, y]} " : $"{array[x, y]}]";
                    sb.Append(line);
                }

                Debug.Log(sb);
            }
        }
    }
}