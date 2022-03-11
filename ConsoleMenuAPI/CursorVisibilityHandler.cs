using System;

namespace ConsoleMenuAPI {
    public class CursorVisibilityHandler {
        const bool enable = true;
        const bool disable = false;
        const int coupleCount = 2;

        readonly bool initialValue;
        int callCount = 0;

        bool IsFirstCall => callCount == 0;
        bool CursorVisible { get { return Console.CursorVisible; } set { Console.CursorVisible = value; } }
        public bool Couple => callCount >= coupleCount;

        public CursorVisibilityHandler() {
            initialValue = CursorVisible;
        }

        void SyncChange(bool value) {
            if (IsFirstCall || initialValue == value)
                CursorVisible = value;
            callCount++;
        }

        public void EnableCursor() {
            SyncChange(enable);
        }

        public void DisableCursor() {
            SyncChange(disable);
        }
    }
}