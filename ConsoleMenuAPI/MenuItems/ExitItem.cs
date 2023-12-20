using System;

namespace ConsoleMenuAPI {
    public class ExitItem : StringMenuItem {
        readonly bool defaultName = false;

        public ExitItem() : base(Localization.ExitString) {
            defaultName = true;
        }
        
        public ExitItem(string name) : base(name) {
        }

        public ExitItem(int localizationKey) : base(localizationKey) {
        }

        public override void ProcessInput(ConsoleKey input) {
        }

        public override string GetString() {
            return defaultName ? Localization.ExitString : base.GetString();
        }
    }
}
