namespace ConsoleMenuAPI {
    public struct ServiceItemsLocalization {
        public string OnTitle { get; }
        public string OffTitle { get; }
        public string InputNumber { get; }
        public string ExitString { get; }

        public ServiceItemsLocalization(string onTitle, string offTitle, string inputNumber, string exit) {
            OnTitle = onTitle;
            OffTitle = offTitle;
            InputNumber = inputNumber;
            ExitString = exit;
        }
    }
}