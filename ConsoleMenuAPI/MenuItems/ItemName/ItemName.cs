namespace ConsoleMenuAPI {
    public class ItemName {
        readonly INameHandler nameHandler;

        public string Value => nameHandler.GetName();

        public ItemName(int localizationKey) {
            nameHandler = new LocalizationNameHandler(localizationKey);
        }

        public ItemName(string name) {
            nameHandler = new StringNameHandler(name);
        }
    }
}
