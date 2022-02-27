using System;

namespace ConsoleMenuAPI {
    public abstract class StringMenuItem : MenuItemBase {
        public StringMenuItem(string name) : base(name) {
        }

        public override void Draw() {
            Console.Write("\t" + Name + "\n\n");
        }
    }

    public class InsertedMenuItem : StringMenuItem {
        public InsertedMenuItem(string name) : base(name) {
        }

        public override void ProcessInput(ConsoleKey input) {
            //mb add inside menus
        }
    }

    public class ContinueItem : StringMenuItem {
        public ContinueItem(string name) : base(name) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }
    }

    public class ExitItem : StringMenuItem {
        public ExitItem(string name) : base(name) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }
    }
}
