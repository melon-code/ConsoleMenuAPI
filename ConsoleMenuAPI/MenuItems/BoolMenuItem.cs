using System;

namespace ConsoleMenuAPI {
    public class BoolMenuItem : ValueBasedItem<bool>, IMenuValueItem<bool> {
        static int GetTitleLength(bool value) {
            return value ? Localization.OnTitle.Length : Localization.OffTitle.Length;
        }

        int LengthDiff => GetTitleLength(!Value) - GetTitleLength(Value);

        protected BoolMenuItem(ItemName name, bool defaultValue) : base(name, defaultValue) {
        }

        public BoolMenuItem(string name, bool defaultValue) : base(name, defaultValue) {
        }

        public BoolMenuItem(int localizationKey, bool defaultValue) : base(localizationKey, defaultValue) {
        }

        public override string GetString() {
            return Name + GetBrackets(Value ? Localization.OnTitle : Localization.OffTitle) + cleaner;
        }

        public virtual void ChangeValue() {
            UpdateCleaner(LengthDiff);
            Value = !Value;
        }

        public override void ProcessInput(ConsoleKey input) {
            if (input == ConsoleKey.Enter || input == ConsoleKey.LeftArrow || input == ConsoleKey.RightArrow)
                ChangeValue();
        }
    }
}
