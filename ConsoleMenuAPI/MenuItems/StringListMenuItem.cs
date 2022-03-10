using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMenuAPI {
    public class StringListMenuItem : ValueBasedItem<IList<string>>, IMenuValueItem<IList<string>> {
        const int minIndex = 0;

        int currentIndex;
        int MaxIndex => Value.Count - 1;

        StringListMenuItem(ItemName name, IList<string> stringList, int startIndex) : base(name, stringList) {
            currentIndex = startIndex;
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
            return Name + GetBrackets(Value[currentIndex]);
        }

        public override void ProcessInput(ConsoleKey input) {
            if (input == ConsoleKey.LeftArrow && currentIndex > minIndex)
                currentIndex--;
            if (input == ConsoleKey.RightArrow && currentIndex < MaxIndex)
                currentIndex++;
        }
    }
}
