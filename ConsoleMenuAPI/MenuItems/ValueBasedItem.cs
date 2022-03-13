namespace ConsoleMenuAPI {
    public abstract class ValueBasedItem<T> : MenuItemBase {
        protected static string GetBrackets(object insideValue) {
            return string.Format(" < {0} >", insideValue);
        }

        protected string cleaner = string.Empty;

        protected int AcceptedDiff => ConsoleMenuDrawer.CursorLength;

        public T Value { get; protected set; }

        protected ValueBasedItem(ItemName name, T defaultValue) : base(name) {
            Value = defaultValue;
        }

        protected ValueBasedItem(string name, T defaultValue) : this(new ItemName(name), defaultValue) {
        }

        protected ValueBasedItem(int localizationKey, T defaultValue) : this(new ItemName(localizationKey), defaultValue) {
        }

        protected void UpdateCleaner(int lengthDifference) {
            if (lengthDifference > AcceptedDiff)
                cleaner = ConsoleMenuDrawer.GetCleaner(lengthDifference);
        }
    }
}
