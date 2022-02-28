using System;

namespace ConsoleMenuAPI {
    public class ContinueItem : StringMenuItem {
        public ContinueItem(string name) : base(name) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }
    }
}
