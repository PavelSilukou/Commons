using System.Collections.Generic;
using JetBrains.Annotations;

namespace Commons
{
    [PublicAPI]
    public static class ListExtensions
    {
        public static List<TSource> RemoveAtAndReturn<TSource>(this List<TSource> list, int index)
        {
            list.RemoveAt(index);
            return list;
        }
        
        public static TSource PopAt<TSource>(this List<TSource> list, int index)
        {
            var element = list[index];
            list.RemoveAt(index);
            return element;
        }
        
        public static void RemoveLast<TSource>(this List<TSource> list)
        {
            list.RemoveAt(list.Count - 1);
        }
        
        public static void Move<TSource>(this List<TSource> list, int oldIndex, int newIndex)
        {
            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
        
        public static void Move<TSource>(this List<TSource> list, TSource item, int newIndex)
        {
            var oldIndex = list.IndexOf(item);
            list.RemoveAt(oldIndex);
            if (newIndex > oldIndex) newIndex--;
            list.Insert(newIndex, item);
        }
    }
}
