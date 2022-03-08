using System.Collections.Generic;

namespace ConsoleMenuAPI {
    public class DependencyBoolMenuItem : BoolMenuItem {
        readonly IList<DependencyItem> items;

        DependencyBoolMenuItem(ItemName name, bool defaultValue, IList<DependencyItem> dependencyItems) : base(name, defaultValue) {
            items = dependencyItems;
            SyncDependency(defaultValue);
        }

        public DependencyBoolMenuItem(string name, bool defaultValue, IList<DependencyItem> dependencyItems) : this(new ItemName(name), defaultValue, dependencyItems) {
        }

        public DependencyBoolMenuItem(int localizationKey, bool defaultValue, IList<DependencyItem> dependencyItems) : this(new ItemName(localizationKey), defaultValue, dependencyItems) {
        }

        void SyncDependency(bool value) {
            foreach (var item in items)
                item.ChangeVisibility(value);
        }

        public override void ChangeValue() {
            base.ChangeValue();
            SyncDependency(Value);
        }
    }
}
