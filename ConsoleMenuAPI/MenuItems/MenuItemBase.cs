using System;

namespace ConsoleMenuAPI {
    public abstract class MenuItemBase : IMenuItem {
        public bool Visible { get; set; } = true;
        public bool Interactive { get; set; } = true;
        public string Name { get; private set; }

        protected MenuItemBase(string name) {
            Name = name;
        }

        public void ChangeName(string newName) {
            Name = newName;
        }

        public abstract string GetString();
        public abstract void ProcessInput(ConsoleKey input);
    }
}
