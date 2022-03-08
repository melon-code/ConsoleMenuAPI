namespace ConsoleMenuAPI {
    public abstract class ValueBasedItem<T> : MenuItemBase {
        public T Value { get; protected set; }

        protected ValueBasedItem(ItemName name, T defaultValue) : base(name) {
            Value = defaultValue;
        }

        protected ValueBasedItem(string name, T defaultValue) : this(new ItemName(name), defaultValue) {
        }

        protected ValueBasedItem(int localizationKey, T defaultValue) : this(new ItemName(localizationKey), defaultValue) {
        }
    }
}
