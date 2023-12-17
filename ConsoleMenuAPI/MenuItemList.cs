using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public class MenuItemList : IEnumerable<IMenuItem> {
        readonly IList<IMenuItem> items;

        public IMenuItem this[int index] => items[index];
        public int Count => items.Count;

        public MenuItemList(IList<IMenuItem> menuItems) {
            items = menuItems;
        }

        public MenuItemList(IList<IMenuItem> menuItems, string exitTitle) : this(menuItems) {
            items.Add(new ExitItem(exitTitle));
        }

        public MenuItemList(IList<IMenuItem> menuItems, int exitKey) : this(menuItems) {
            items.Add(new ExitItem(exitKey));
        }

        public MenuItemList(IList<IMenuItem> menuItems, string exitTitle, string continueTitle) : this(menuItems, exitTitle) {
            items.Insert(0, new ContinueItem(continueTitle));
        }

        public MenuItemList(IList<IMenuItem> menuItems, int exitKey, int continueKey) : this(menuItems, exitKey) {
            items.Insert(0, new ContinueItem(continueKey));
        }

        T GetValue<T, Type>(int index) where Type : IMenuValueItem<T> {
            var item = items[index];
            if (item is Type valueItem)
                return valueItem.Value;
            throw new ArgumentException();
        }

        public int GetInt(int index) {
            return GetValue<int, IMenuValueItem<int>>(index);
        }

        public bool GetBool(int index) {
            return GetValue<bool, BoolMenuItem>(index);
        }

        public ConsoleMenu GetInsertedMenu(int index) {
            return GetValue<ConsoleMenu, InsertedMenuItem>(index);
        }

        public IEnumerator<IMenuItem> GetEnumerator() {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}