namespace ConsoleMenuAPI {
    public class KeyStringToHashArray {
        readonly string[] keys;

        public int this[int ind] => keys[ind].GetHashCode();

        public KeyStringToHashArray(string[] stringKeys) {
            keys = stringKeys;
        }
    }
}