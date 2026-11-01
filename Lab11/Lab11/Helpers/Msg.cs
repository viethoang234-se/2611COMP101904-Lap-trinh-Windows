namespace Lab11.Helpers;

public static class Msg
{
    private const string Caption = "Lab11";

    public static void Info(string text) =>
        MessageBox.Show(text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void Warn(string text) =>
        MessageBox.Show(text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static void Error(string text) =>
        MessageBox.Show(text, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

    public static bool Confirm(string text) =>
        MessageBox.Show(text, Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
}
