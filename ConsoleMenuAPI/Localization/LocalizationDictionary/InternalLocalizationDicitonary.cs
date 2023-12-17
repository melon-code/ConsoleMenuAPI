namespace ConsoleMenuAPI {
    public class InternalLocalizationDicitonary : LocalizationDictionary {
        public const int OnTitleKey = 1;
        public const int OffTitleKey = 2;
        public const int InputNumberKey = 3;
        public const int ExitStringKey = 4;

        public override ServiceItemsLocalization ServiceLocalization { get; }

        protected InternalLocalizationDicitonary(string onTitle, string offTitle, string inputNumber, string exitString) {
            ServiceLocalization = new ServiceItemsLocalization(onTitle, offTitle, inputNumber, exitString);
        }
    }
}
