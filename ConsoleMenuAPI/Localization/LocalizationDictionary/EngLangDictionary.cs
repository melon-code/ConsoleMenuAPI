namespace ConsoleMenuAPI {
    public class EngLangDictionary : InternalLocalizationDicitonary {
        const string onTitle = "On";
        const string offTitle = "Off";
        const string inputNumber = "Input integer value: ";
        const string exitString = "Exit";

        public EngLangDictionary() : base(onTitle, offTitle, inputNumber, exitString) {
        }
    }
}
