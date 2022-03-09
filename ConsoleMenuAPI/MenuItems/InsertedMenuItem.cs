using System;

namespace ConsoleMenuAPI {
    public class InsertedMenuItem : StringMenuItem, IMenuValueItem<ConsoleMenu> {
        public ConsoleMenu Value { get; }

        InsertedMenuItem(ItemName name, ConsoleMenu insertedMenu) : base(name) {
            Value = insertedMenu;
        }

        public InsertedMenuItem(string name, ConsoleMenu insertedMenu) : this(new ItemName(name), insertedMenu) {
        }

        public InsertedMenuItem(int localizationKey, ConsoleMenu insertedMenu) : this(new ItemName(localizationKey), insertedMenu) {
        }

        public override void ProcessInput(ConsoleKey input) {
            if (input == ConsoleKey.Enter) {
                Value.ShowDialog();
                Console.Clear();
            }
        }
    }
}
