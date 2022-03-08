using System;

namespace ConsoleMenuAPI {
    public class ContinueItem : StringMenuItem {
        public ContinueItem(string name) : base(name) {
        }

        public ContinueItem(int localizationKey) : base(localizationKey) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }
    }
}
