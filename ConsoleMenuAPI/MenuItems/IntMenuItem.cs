using System;

namespace ConsoleMenuAPI {
    public class IntMenuItem : ValueBasedItem<int>, IMenuValueItem<int> {
        static bool ValidateStringInput(string str) {
            if (string.IsNullOrEmpty(str))
                return false;
            bool valid = true;
            foreach (var item in str)
                if (!char.IsNumber(item))
                    valid = false;
            return valid;
        }

        readonly int minValue;
        readonly int maxValue;

        IntMenuItem(ItemName name, int defaultValue, int minLimit, int maxLimit) : base(name, defaultValue) {
            minValue = minLimit;
            maxValue = maxLimit;
        }

        public IntMenuItem(string name, int defaultValue, int minLimit, int maxLimit) : this(new ItemName(name), defaultValue, minLimit, maxLimit) {
        }

        public IntMenuItem(int localizationKey, int defaultValue, int minLimit, int maxLimit) : this(new ItemName(localizationKey), defaultValue, minLimit, maxLimit) {
        }

        public IntMenuItem(string name, int defaultValue) : this(name, defaultValue, int.MinValue, int.MaxValue) {
        }

        public IntMenuItem(int localizationKey, int defaultValue) : this(localizationKey, defaultValue, int.MinValue, int.MaxValue) {
        }

        public override string GetString() {
            return Name + GetBrackets(Value) + cleaner;
        }

        public void IncrementValue() {
            if (Value < maxValue)
                Value++;
        }

        public void DecrementValue() {
            if (Value > minValue)
                Value--;
        }

        bool ValidateAndSetInteger(int number) {
            if (number >= minValue && number <= maxValue) {
                cleaner = ConsoleMenuDrawer.GetCleaner(number.ToString().Length - Value.ToString().Length);
                Value = number;
                return true;
            }
            return false;
        }

        public void InputValue() {
            ConsoleMenuDrawer drawer = new ConsoleMenuDrawer();
            ConsoleMenuDrawer.ClearScreen();
            drawer.EnableCursor();
            string input;
            do {
                Console.Write(Localization.InputNumber);
                input = Console.ReadLine();
            } while (!ValidateStringInput(input) || !ValidateAndSetInteger(Convert.ToInt32(input)));
            drawer.DisableCursor();
            ConsoleMenuDrawer.ClearScreen();
        }

        public override void ProcessInput(ConsoleKey input) {
            switch (input) {
                case ConsoleKey.Enter:
                    InputValue();
                    GetString();
                    break;
                case ConsoleKey.LeftArrow:
                    DecrementValue();
                    break;
                case ConsoleKey.RightArrow:
                    IncrementValue();
                    break;
            }
        }
    }
}
