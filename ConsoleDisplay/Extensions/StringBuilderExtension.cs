using System.Text;

namespace ConsoleDisplay.Extensions {
    public static class StringBuilderExtension {
        public static void JumpTwoLines (this StringBuilder builder) {
            builder.AppendLine().AppendLine();
        }
    }
}
