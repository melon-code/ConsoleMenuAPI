using System;

namespace ConsoleMenuAPI {
    public abstract class StringMenuItem : MenuItemBase {
        public StringMenuItem(string name) : base(name) {
        }

        public override void Draw() {
            Console.Write("\t" + Name + "\n\n");
        }
    }
}
