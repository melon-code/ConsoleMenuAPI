using System;

namespace ConsoleMenuAPI {
    public abstract class StringMenuItem : MenuItemBase {
        protected StringMenuItem(ItemName name) : base(name) {
        }

        protected StringMenuItem(string name) : base(new ItemName(name)) {
        }

        protected StringMenuItem(int localizationKey) : base(new ItemName(localizationKey)) {
        }

        public override string GetString() {
            return Name;
        }
    }
}
