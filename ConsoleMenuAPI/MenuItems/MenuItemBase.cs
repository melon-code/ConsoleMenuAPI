using System;

namespace ConsoleMenuAPI {
    public abstract class MenuItemBase : IMenuItem {
        readonly INameHandler nameHandler;

        public bool Visible { get; set; } = true;
        public bool Interactive { get; set; } = true;
        public string Name => nameHandler.GetName();

        protected MenuItemBase(ItemName name) {
            nameHandler = name.NameHandler;
        }

        public abstract string GetString();
        public abstract void ProcessInput(ConsoleKey input);
    }
}
