namespace Lab11.Helpers;

public static class LopValidator
{
    public static string Validate(string maLop, string tenLop)
    {
        if (string.IsNullOrWhiteSpace(maLop))
        {
            return "Mã lớp không được để trống.";
        }

        if (string.IsNullOrWhiteSpace(tenLop))
        {
            return "Tên lớp không được để trống.";
        }

        return null;
    }
}
