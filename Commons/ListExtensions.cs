using System.Collections.Generic;
using JetBrains.Annotations;

namespace Commons
{
    [PublicAPI]
    public static class ListExtensions
    {
        public static List<T> RemoveAtAndReturn<T>(this List<T> list, int index)
        {
            list.RemoveAt(index);
            return list;
        }
        
        public static T PopAt<T>(this List<T> list, int index)
        {
            var element = list[index];
            list.RemoveAt(index);
            return element;
        }
        
        public static void RemoveLast<T>(this List<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }
        
        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {
            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
        
        public static void Move<T>(this List<T> list, T item, int newIndex)
        {
            var oldIndex = list.IndexOf(item);
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
    }
}
