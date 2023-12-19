namespace ConsoleMenuAPI {
    public class KeyStringToHash {
        public int this[string key] => key.GetHashCode();
    }
}