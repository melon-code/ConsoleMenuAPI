using System;

namespace ConsoleMenuAPI {
    public class ExitItem : StringMenuItem {
        public ExitItem(string name) : base(name) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }
    }
}
