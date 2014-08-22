using System;
using System.Collections.Generic;
using System.Linq;

namespace WuxiPostal
{
    public class Group<T> : List<T>
    {
        public Group(string name, IEnumerable<T> items)
            : base(items)
        {
            this.Key = name;
        }

        public string Key
        {
            get;
            set;
        }

        public static List<Group<T>> GetItemGroups<T>(IEnumerable<T> itemList, Func<T, string> getKeyFunc)
        {
            IEnumerable<Group<T>> groupList = from item in itemList
                                              group item by getKeyFunc(item) into g
                                              orderby g.Key
                                              select new Group<T>(g.Key, g);

            return groupList.ToList();
        }
    }
}