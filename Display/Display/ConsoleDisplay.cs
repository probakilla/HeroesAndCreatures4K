using System;

namespace Display {
    public class ProgramDisplay {
        private static ProgramDisplay INSTANCE;
        public static ProgramDisplay Instance {
            get {
                if (INSTANCE == null) {
                    INSTANCE = new ProgramDisplay();
                }
                return INSTANCE;
            }
            private set { INSTANCE = value; }
        }

        private ProgramDisplay() { }

        public void Launch() {
            DisplayTitleScreen();
        }

        private void DisplayTitleScreen() {
            string titleScreen = ConsoleDisplay.TitleScreen();
            Console.WriteLine(titleScreen);
            Console.ReadKey();
            Console.Clear();
        }
    }
}