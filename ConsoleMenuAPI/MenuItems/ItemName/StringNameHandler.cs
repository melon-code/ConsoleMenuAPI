namespace ConsoleMenuAPI {
    public class StringNameHandler : INameHandler {
        readonly string name;

        public StringNameHandler(string itemName) {
            name = itemName;
        }

        public string GetName() {
            return name;
        }
    }
}
