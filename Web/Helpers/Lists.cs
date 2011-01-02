using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc {
    public static class ListExtensions {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (var item in collection) action(item);
            return collection;
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection) {
            return new SelectList(collection, "Key", "Value");
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection, string selectedValue) {
            return new SelectList(collection, "Key", "Value", selectedValue);
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection,
                             string dataValueField, string dataTextField) {
            return new SelectList(collection, dataValueField, dataTextField);
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection,
                             string dataValueField, string dataTextField, string selectedValue) {
            return new SelectList(collection, dataValueField, dataTextField, selectedValue);
        }
    }
}
