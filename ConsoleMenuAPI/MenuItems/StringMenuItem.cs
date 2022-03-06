using System;

namespace ConsoleMenuAPI {
    public abstract class StringMenuItem : MenuItemBase {
        public StringMenuItem(string name) : base(name) {
        }

        public override string GetString() {
            return Name;
        }
    }
}
