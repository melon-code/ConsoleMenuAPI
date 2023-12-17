namespace ConsoleMenuAPI {
    public interface ILocalizationDictionary {
        ServiceItemsLocalization ServiceLocalization { get; }
        
        string GetItem(int key);
    }
}