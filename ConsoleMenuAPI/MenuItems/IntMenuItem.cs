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
            return Name + string.Format(" < {0} >", Value);
        }

        public void IncrementValue() {
            if (Value < maxValue)
                Value++;
        }

        public void DecrementValue() {
            if (Value > minValue)
                Value--;
        }

        bool ValidateInteger(int number) {
            if (number >= minValue && number <= maxValue) {
                Value = number;
                return true;
            }
            return false;
        }

        public void InputValue() {
            Console.Clear();
            string input;
            bool isInputValid = false;
            do {
                Console.Write(Localization.InputNumber);
                input = Console.ReadLine();
                if (ValidateStringInput(input) && ValidateInteger(Convert.ToInt32(input)))
                    isInputValid = true;
            } while (!isInputValid);
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
