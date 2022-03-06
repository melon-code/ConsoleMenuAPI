namespace ConsoleMenuAPI {
    public class RusLangDictionary : LocalizationDictionary {
        const string onTitle = "Да";
        const string offTitle = "Нет";
        const string inputNumber = "Введите числовое значение: ";
        const string exitString = "Выход";

        public RusLangDictionary() : base(onTitle, offTitle, inputNumber, exitString) {
        }
    }
}
