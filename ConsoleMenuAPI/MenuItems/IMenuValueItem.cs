namespace ConsoleMenuAPI {
    public interface IMenuValueItem<T> : IMenuItem {
        T Value { get; }
    }
}
