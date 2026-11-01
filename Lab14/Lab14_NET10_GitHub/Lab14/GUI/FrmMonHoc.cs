using Lab14.BLL;
using Lab14.Models;

namespace Lab14.GUI;

/// <summary>
/// Giao diện chỉ tiếp nhận dữ liệu, gọi BLL và hiển thị kết quả.
/// </summary>
public class FrmMonHoc : Form
{
    private readonly MonHocBLL _bll;
    private readonly TextBox txtMaMonHoc = new();
    private readonly TextBox txtTenMonHoc = new();
    private readonly NumericUpDown nudSoTinChi = new();
    private readonly CheckBox chkTrangThai = new();
    private readonly TextBox txtTimKiem = new();
    private readonly DataGridView dgvMonHoc = new();
    private readonly Button btnThem = new();
    private readonly Button btnSua = new();
    private readonly Button btnXoa = new();
    private readonly Button btnLamMoi = new();
    private readonly Button btnTimKiem = new();

    public FrmMonHoc(MonHocBLL bll)
    {
        _bll = bll;
        InitializeForm();
        Load += (_, _) => LoadData();
    }

    private void InitializeForm()
    {
        Text = "EduManager - Quản lý môn học";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(900, 600);
        Size = new Size(1050, 680);
        Font = new Font("Segoe UI", 10F);

        var title = new Label
        {
            Text = "QUẢN LÝ MÔN HỌC",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(25, 20)
        };

        var inputGroup = new GroupBox
        {
            Text = "Thông tin môn học",
            Location = new Point(25, 70),
            Size = new Size(475, 220),
            Anchor = AnchorStyles.Top | AnchorStyles.Left
        };

        AddLabel(inputGroup, "Mã môn học:", 20, 35);
        txtMaMonHoc.SetBounds(145, 32, 300, 30);
        AddLabel(inputGroup, "Tên môn học:", 20, 78);
        txtTenMonHoc.SetBounds(145, 75, 300, 30);
        AddLabel(inputGroup, "Số tín chỉ:", 20, 121);
        nudSoTinChi.SetBounds(145, 118, 100, 30);
        nudSoTinChi.Minimum = 1;
        nudSoTinChi.Maximum = 6;
        nudSoTinChi.Value = 3;
        chkTrangThai.Text = "Còn sử dụng";
        chkTrangThai.Checked = true;
        chkTrangThai.SetBounds(145, 160, 180, 30);

        inputGroup.Controls.AddRange(new Control[]
        {
            txtMaMonHoc, txtTenMonHoc, nudSoTinChi, chkTrangThai
        });

        ConfigureButton(btnThem, "Thêm", 25, 305);
        ConfigureButton(btnSua, "Sửa", 125, 305);
        ConfigureButton(btnXoa, "Xóa", 225, 305);
        ConfigureButton(btnLamMoi, "Làm mới", 325, 305);

        var searchLabel = new Label { Text = "Tìm kiếm:", AutoSize = true, Location = new Point(25, 370) };
        txtTimKiem.SetBounds(110, 365, 330, 32);
        ConfigureButton(btnTimKiem, "Tìm kiếm", 455, 363, 110);

        dgvMonHoc.SetBounds(25, 415, 980, 205);
        dgvMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvMonHoc.ReadOnly = true;
        dgvMonHoc.AllowUserToAddRows = false;
        dgvMonHoc.AllowUserToDeleteRows = false;
        dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMonHoc.MultiSelect = false;
        dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMonHoc.RowHeadersVisible = false;
        dgvMonHoc.SelectionChanged += DgvMonHoc_SelectionChanged;

        Controls.AddRange(new Control[]
        {
            title, inputGroup, btnThem, btnSua, btnXoa, btnLamMoi,
            searchLabel, txtTimKiem, btnTimKiem, dgvMonHoc
        });

        btnThem.Click += (_, _) => ExecuteAction(() =>
        {
            _bll.Add(ReadForm());
            MessageBox.Show("Thêm môn học thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearForm();
        });

        btnSua.Click += (_, _) => ExecuteAction(() =>
        {
            _bll.Update(ReadForm());
            MessageBox.Show("Cập nhật môn học thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        });

        btnXoa.Click += (_, _) =>
        {
            string code = txtMaMonHoc.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                ShowError("Vui lòng chọn môn học cần xóa.");
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa môn học {code}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            ExecuteAction(() =>
            {
                _bll.Delete(code);
                MessageBox.Show("Xóa môn học thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            });
        };

        btnLamMoi.Click += (_, _) =>
        {
            ClearForm();
            LoadData();
        };

        btnTimKiem.Click += (_, _) => ExecuteAction(() =>
        {
            dgvMonHoc.DataSource = _bll.Search(txtTimKiem.Text);
        });

        txtTimKiem.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
                e.SuppressKeyPress = true;
            }
        };
    }

    private static void AddLabel(Control parent, string text, int x, int y)
    {
        parent.Controls.Add(new Label
        {
            Text = text,
            AutoSize = true,
            Location = new Point(x, y + 5)
        });
    }

    private static void ConfigureButton(Button button, string text, int x, int y, int width = 90)
    {
        button.Text = text;
        button.SetBounds(x, y, width, 36);
        button.Cursor = Cursors.Hand;
    }

    private MonHoc ReadForm() => new()
    {
        MaMonHoc = txtMaMonHoc.Text,
        TenMonHoc = txtTenMonHoc.Text,
        SoTinChi = (int)nudSoTinChi.Value,
        TrangThai = chkTrangThai.Checked
    };

    private void LoadData()
    {
        ExecuteAction(() => dgvMonHoc.DataSource = _bll.GetAll());
    }

    private void DgvMonHoc_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvMonHoc.CurrentRow?.DataBoundItem is not MonHoc selected) return;

        txtMaMonHoc.Text = selected.MaMonHoc;
        txtTenMonHoc.Text = selected.TenMonHoc;
        nudSoTinChi.Value = selected.SoTinChi;
        chkTrangThai.Checked = selected.TrangThai;
    }

    private void ClearForm()
    {
        txtMaMonHoc.Clear();
        txtTenMonHoc.Clear();
        txtTimKiem.Clear();
        nudSoTinChi.Value = 3;
        chkTrangThai.Checked = true;
        txtMaMonHoc.Focus();
    }

    private void ExecuteAction(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private void ShowError(string message)
    {
        MessageBox.Show(message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
