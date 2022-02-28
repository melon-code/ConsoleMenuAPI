using System;

namespace ConsoleMenuAPI {
    public class InsertedMenuItem : StringMenuItem, IMenuValueItem<ConsoleMenu> {
        public ConsoleMenu Value { get; }

        public InsertedMenuItem(string name, ConsoleMenu insertedMenu) : base(name) {
            Value = insertedMenu;
        }

        public override void ProcessInput(ConsoleKey input) {
            if (input == ConsoleKey.Enter)
                Value.ShowDialog();
        }
    }
}
