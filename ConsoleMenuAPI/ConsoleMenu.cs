using System;
using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public abstract class ConsoleMenu {
        const string cursorMenuString = "\t---> ";

        readonly bool hasContinueItem = false;
        readonly bool hasExitItem = false;

        bool IsExitSelected => hasExitItem && CurrentItem is ExitItem;
        bool IsContinueSelected => hasContinueItem && CurrentItem is ContinueItem;
        int ItemsCount { get { return Items.Count; } }
        protected IList<IMenuItem> Items { get; }
        protected bool IsEnd { get; set; }
        protected int CurrentPosition { get; private set; } = 0;
        protected IMenuItem CurrentItem => Items[CurrentPosition];
        public MenuEndResult EndResult { get; protected set; }

        protected ConsoleMenu(IList<IMenuItem> menuItems) {
            Items = menuItems;
        }

        protected ConsoleMenu(IList<IMenuItem> menuItems, string exitTitle) : this(menuItems) {
            Items.Add(new ExitItem(exitTitle));
            hasExitItem = true;
        }

        protected ConsoleMenu(IList<IMenuItem> menuItems, string exitTitle, string continueTitle) : this(menuItems, exitTitle) {
            Items.Insert(0, new ContinueItem(continueTitle));
            hasContinueItem = true;
        }

        public void UpdateItemsNames(IList<string> updatedNames) { // todo
            for (int i = 0; i < updatedNames.Count; i++)
                Items[i].ChangeName(updatedNames[i]);
            if (hasExitItem)
                Items[ItemsCount - 1].ChangeName(Localization.ExitString);
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
            if (Console.KeyAvailable)
                Console.ReadKey(true);
            do {
                Draw();
            } while (Navigation(Console.ReadKey(true)) && !IsEnd);
            return EndResult;
        }

        public void DrawMenu() {
            for (int i = 0; i < ItemsCount; i++) {
                if (i == CurrentPosition)
                    Console.Write(cursorMenuString);
                if (Items[i].Visible)
                    Items[i].Draw();
            }
        }

        protected virtual void Draw() {
            Console.Clear();
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
                        ExitMenu(MenuEndResult.Exit);
                    if (IsContinueSelected)
                        ExitMenu(MenuEndResult.Further);
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

    public class StandardConsoleMenu : ConsoleMenu {
        public StandardConsoleMenu(IList<IMenuItem> menuItems) : base(menuItems) {
        }

        protected override void ProcessInput(ConsoleKey input) {
            ProcessInputByItem(input);
        }
    }
}
