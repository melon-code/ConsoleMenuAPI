using System;

namespace ConsoleMenuAPI {
    public abstract class MenuItemBase : IMenuItem {
        readonly ItemName name;

        public bool Visible { get; set; } = true;
        public bool Interactive { get; set; } = true;
        public string Name => name.Value;

        protected MenuItemBase(ItemName itemName) {
            name = itemName;
        }

        public abstract string GetString();
        public abstract void ProcessInput(ConsoleKey input);
    }
}
