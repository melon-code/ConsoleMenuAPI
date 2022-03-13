using System;
using System.Text;

namespace ConsoleMenuAPI {
    public class ConsoleMenuDrawer {
        public static string GetCleaner(int length) {
            if (length <= 0)
                return string.Empty;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
                builder.Append(space);
            return builder.ToString();
        }

        public static void DrawLine(bool drawCursor, string itemLine) {
            Console.Write(startTabString + (drawCursor ? cursorMenuString : "") + itemLine + GetCleaner(cursorMenuString.Length) + endLineString);
        }

        public static void SetCursorToLeftTopCorner() {
            Console.SetCursorPosition(0, 0);
        }

        public static void ClearScreen() {
            Console.Clear();
        }

        const string space = " ";
        const string cursorMenuString = "---> ";
        const string startTabString = "\t";
        const string endLineString = "\n\n";

        public static int CursorLength => cursorMenuString.Length;

        CursorVisibilityHandler cursorVisibility;

        void ChangeCursorVisibility(Action change) {
            if (cursorVisibility == null || cursorVisibility.Couple)
                cursorVisibility = new CursorVisibilityHandler();
            change();
        }

        public void DisableCursor() {
            ChangeCursorVisibility(() => cursorVisibility.DisableCursor());
        }

        public void EnableCursor() {
            ChangeCursorVisibility(() => cursorVisibility.EnableCursor());
        }

        public void PrepareConsole() {
            ClearScreen();
            DisableCursor();
            while (Console.KeyAvailable) {
                Console.ReadKey(true);
            }
        }
    }
}