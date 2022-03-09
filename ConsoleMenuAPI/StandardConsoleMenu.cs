using System;
using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public class StandardConsoleMenu : ConsoleMenu {
        public StandardConsoleMenu(IList<IMenuItem> menuItems) : base(menuItems) {
        }

        public StandardConsoleMenu(IList<IMenuItem> menuItems, string exitTitle) : base(menuItems, exitTitle) {
        }

        public StandardConsoleMenu(IList<IMenuItem> menuItems, string exitTitle, string continueTitle) : base(menuItems, exitTitle, continueTitle) {
        }

        public StandardConsoleMenu(IList<IMenuItem> menuItems, int exitKey) : base(menuItems, exitKey) {
        }

        public StandardConsoleMenu(IList<IMenuItem> menuItems, int exitKey, int continueKey) : base(menuItems, exitKey, continueKey) {
        }

        protected override void ProcessInput(ConsoleKey input) {
            ProcessInputByItem(input);
        }
    }
}