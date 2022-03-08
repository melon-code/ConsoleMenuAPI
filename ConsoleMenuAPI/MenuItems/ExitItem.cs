using System;

namespace ConsoleMenuAPI {
    public class ExitItem : StringMenuItem {
        public ExitItem(string name) : base(name) {
        }

        public ExitItem(int localizationKey) : base(localizationKey) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }
    }
}
