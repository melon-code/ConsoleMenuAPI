using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMenuAPI {
    public class StringListMenuItem : ValueBasedItem<int>, IMenuValueItem<int> {
        const int minIndex = 0;

        readonly IList<string> list;

        int MaxIndex => list.Count - 1;

        StringListMenuItem(ItemName name, IList<string> stringList, int startIndex) : base(name, startIndex) {
            list = stringList;
        }

        public StringListMenuItem(string name, IList<string> stringList) : this(new ItemName(name), stringList, minIndex) {
        }

        public StringListMenuItem(string name, IList<string> stringList, int startIndex) : this(new ItemName(name), stringList, startIndex) {
        }

        public StringListMenuItem(int localizationKey, IList<string> stringList) : this(new ItemName(localizationKey), stringList, minIndex) {
        }

        public StringListMenuItem(int localizationKey, IList<string> stringList, int startIndex) : this(new ItemName(localizationKey), stringList, startIndex) {
        }

        public override string GetString() {
            return Name + GetBrackets(list[Value]) + cleaner;
        }

        public override void ProcessInput(ConsoleKey input) {
            if (input == ConsoleKey.LeftArrow && Value > minIndex)
                UpdateCleaner(Value, --Value);
            if (input == ConsoleKey.RightArrow && Value < MaxIndex)
                UpdateCleaner(Value, ++Value);
        }

        void UpdateCleaner(int currentIndex, int nextIndex) {
            UpdateCleaner(list[currentIndex].Length - list[nextIndex].Length);
        }
    }
}
