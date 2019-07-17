using System.Text;

namespace Display.Extensions {
    public static class StringBuilderExtension {
        public static void JumpTwoLines (this StringBuilder builder) {
            builder.AppendLine().AppendLine();
        }
    }
}
