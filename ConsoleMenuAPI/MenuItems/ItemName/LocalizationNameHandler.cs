namespace ConsoleMenuAPI {
    public class LocalizationNameHandler : INameHandler {
        readonly int key;

        public LocalizationNameHandler(int dictionaryKey) {
            key = dictionaryKey;
        }

        public string GetName() {
            return Localization.GetString(key);
        }
    }
}
