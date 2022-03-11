﻿using System;
using System.Text;

namespace ConsoleMenuAPI {
    public class ConsoleMenuDrawer {
        static string GetCleaner() {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < cursorMenuString.Length; i++)
                builder.Append(" ");
            return builder.ToString();
        }

        public static void DrawLine(bool drawCursor, string itemLine) {
            Console.Write(startTabString + (drawCursor ? cursorMenuString : "") + itemLine + GetCleaner() + endLineString);
        }

        public static void SetCursorToLeftTopCorner() {
            Console.SetCursorPosition(0, 0);
        }

        public static void ClearScreen() {
            Console.Clear();
        }

        const string cursorMenuString = "---> ";
        const string startTabString = "\t";
        const string endLineString = "\n\n";

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