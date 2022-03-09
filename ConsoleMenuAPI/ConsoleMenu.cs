using System;
using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public abstract class ConsoleMenu {
        bool IsExitSelected => CurrentItem is ExitItem;
        bool IsContinueSelected => CurrentItem is ContinueItem;
        int ItemsCount { get { return Items.Count; } }
        protected ConsoleMenuDrawer Drawer { get; }
        protected IList<IMenuItem> Items { get; }
        protected bool IsEnd { get; set; }
        protected int CurrentPosition { get; private set; } = 0;
        protected IMenuItem CurrentItem => Items[CurrentPosition];
        public MenuEndResult EndResult { get; protected set; }

        protected ConsoleMenu(IList<IMenuItem> menuItems) {
            Items = menuItems;
            Drawer = new ConsoleMenuDrawer();
        }

        protected ConsoleMenu(IList<IMenuItem> menuItems, string exitTitle) : this(menuItems) {
            AddExitItem(() => new ExitItem(exitTitle));
        }

        protected ConsoleMenu(IList<IMenuItem> menuItems, int exitKey) : this(menuItems) {
            AddExitItem(() => new ExitItem(exitKey));
        }

        protected ConsoleMenu(IList<IMenuItem> menuItems, string exitTitle, string continueTitle) : this(menuItems, exitTitle) {
            AddContinueItem(() => new ContinueItem(continueTitle));
        }

        protected ConsoleMenu(IList<IMenuItem> menuItems, int exitKey, int continueKey) : this(menuItems, exitKey) {
            AddContinueItem(() => new ContinueItem(continueKey));
        }

        void AddExitItem(Func<ExitItem> createExitItem) {
            Items.Add(createExitItem());
        }

        void AddContinueItem(Func<ContinueItem> createContinueItem) {
            Items.Insert(0, createContinueItem());
        }

        protected T GetValue<T, Type>(int index) where Type : IMenuValueItem<T> {
            var item = Items[index];
            if (item is Type)
                return ((Type)item).Value;
            throw new ArgumentException();
        }

        protected int GetInt(int index) {
            return GetValue<int, IntMenuItem>(index);
        }

        protected bool GetBool(int index) {
            return GetValue<bool, BoolMenuItem>(index);
        }

        protected ConsoleMenu GetInsertedMenu(int index) {
            return GetValue<ConsoleMenu, InsertedMenuItem>(index);
        }

        public MenuEndResult ShowDialog() {
            IsEnd = false;
            EndResult = MenuEndResult.Further;
            Drawer.PrepareConsole();
            do {
                Draw();
            } while (Navigation(Console.ReadKey(true)) && !IsEnd);
            Drawer.EnableCursor();
            return EndResult;
        }

        public void DrawMenu() {
            for (int i = 0; i < ItemsCount; i++) 
                if (Items[i].Visible)
                    ConsoleMenuDrawer.DrawLine(i == CurrentPosition, Items[i].GetString());
        }

        protected virtual void Draw() {
            ConsoleMenuDrawer.SetCursorToLeftTopCorner();
            DrawMenu();
        }

        void ChangeCurrentPosition(bool increase) {
            int iterations = 0;
            do {
                CurrentPosition = increase ? CurrentPosition + 1 : ItemsCount + CurrentPosition - 1;
                CurrentPosition %= ItemsCount;
                iterations++;
            } while (iterations != ItemsCount && !CurrentItem.Visible);
        }

        void IncreaseCurrentPosition() {
            ChangeCurrentPosition(true);
        }

        void DecreaseCurrentPosition() {
            ChangeCurrentPosition(false);
        }

        void CheckInteractivityAndProcessInput(ConsoleKey input) {
            if (CurrentItem.Interactive)
                ProcessInput(input);
        }

        protected bool Navigation(ConsoleKeyInfo info) {
            switch (info.Key) {
                case ConsoleKey.DownArrow:
                    IncreaseCurrentPosition();
                    break;
                case ConsoleKey.UpArrow:
                    DecreaseCurrentPosition();
                    break;
                case ConsoleKey.Enter:
                    if (IsExitSelected) 
                        return ExitMenu(MenuEndResult.Exit);
                    if (IsContinueSelected)
                        return ExitMenu(MenuEndResult.Further);
                    CheckInteractivityAndProcessInput(info.Key);
                    break;
                case ConsoleKey.Escape:
                    return ExitMenu(MenuEndResult.Exit);
                default:
                    CheckInteractivityAndProcessInput(info.Key);
                    break;
            }
            return true;
        }

        bool ExitMenu(MenuEndResult endResult) {
            EndResult = endResult;
            return false;
        }

        protected void ProcessInputByItem(ConsoleKey input) {
            CurrentItem.ProcessInput(input);
        }

        protected abstract void ProcessInput(ConsoleKey input);
    }
}