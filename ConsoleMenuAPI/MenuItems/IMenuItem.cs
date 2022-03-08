using System;

namespace ConsoleMenuAPI {
    public interface IMenuItem {
        bool Visible { get; set; }
        bool Interactive { get; set; }
        string Name { get; }

        string GetString();
        void ProcessInput(ConsoleKey input);
    }
}
