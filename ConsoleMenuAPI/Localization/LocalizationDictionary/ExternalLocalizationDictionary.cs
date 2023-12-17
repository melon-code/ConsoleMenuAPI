using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public class ExternalLocalizationDictionary : LocalizationDictionary {
        public const string OnTitleKey = "onTitle";
        public const string OffTitleKey = "offTitle";
        public const string InputNumberKey = "inputNumber";
        public const string ExitStringKey = "exit";

        public override ServiceItemsLocalization ServiceLocalization { get; }

        public ExternalLocalizationDictionary(Dictionary<int, string> dictionary) : base(dictionary) {
            ServiceLocalization = new ServiceItemsLocalization(
                GetServiceString(OnTitleKey), GetServiceString(OffTitleKey), GetServiceString(InputNumberKey), GetServiceString(ExitStringKey));
        }

        string GetServiceString(string key) {
            if (dictionary.TryGetValue(key.GetHashCode(), out string value))
                return value;
            throw LocalizationErrors.NoMenuItemsLocalization;
        }
    }
}