using System;

namespace ConsoleMenuAPI {
    public class NotNull<T> {
        public T Value { get; }
        
        public NotNull(T checkingValue) {
            Value = checkingValue;
        }

        public NotNull<V> Check<V>(Func<T, V> getValue, ArgumentException exception) {
            var next = getValue(Value);
            if (next == null)
                throw exception;
            return new NotNull<V>(next);
        }
    }
}