namespace ConsoleMenuAPI {
    public class ItemName {
        public INameHandler NameHandler { get; }

        public ItemName(int localizationKey) {
            NameHandler = new LocalizationNameHandler(localizationKey);
        }

        public ItemName(string name) {
            NameHandler = new StringNameHandler(name);
        }
    }
}
