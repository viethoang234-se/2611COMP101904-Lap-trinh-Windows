using Lab11.Data;
using Lab11.Helpers;
using Lab11.Models;
using Microsoft.Data.SqlClient;

namespace Lab11.Forms;

public partial class FrmLop : Form
{
    private const int ForeignKeyViolation = 547;

    private readonly LopRepository _repository = new(DbConfig.ConnectionString);
    private string _selectedMaLop;

    public FrmLop()
    {
        InitializeComponent();
    }

    private void FrmLop_Load(object sender, EventArgs e) => Run(LoadData);

    private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvLop.Rows[e.RowIndex].DataBoundItem is not Lop lop)
        {
            return;
        }

        _selectedMaLop = lop.MaLop;
        txtMaLop.Text = lop.MaLop;
        txtTenLop.Text = lop.TenLop;
        txtMaLop.ReadOnly = true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (_selectedMaLop != null)
        {
            Msg.Warn("Vui lòng bấm Làm mới trước khi thêm lớp mới.");
            return;
        }

        string maLop = txtMaLop.Text.Trim();
        string tenLop = txtTenLop.Text.Trim();
        if (!IsValid(maLop, tenLop))
        {
            return;
        }

        Run(() =>
        {
            if (_repository.Exists(maLop))
            {
                Msg.Warn("Mã lớp đã tồn tại.");
                txtMaLop.Focus();
                return;
            }

            _repository.Insert(new Lop { MaLop = maLop, TenLop = tenLop });
            Msg.Info("Thêm lớp thành công.");
            ResetInput();
            LoadData();
        });
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaLop == null)
        {
            Msg.Warn("Vui lòng chọn lớp cần sửa.");
            return;
        }

        string tenLop = txtTenLop.Text.Trim();
        if (!IsValid(_selectedMaLop, tenLop))
        {
            return;
        }

        Run(() =>
        {
            if (!_repository.Update(new Lop { MaLop = _selectedMaLop, TenLop = tenLop }))
            {
                Msg.Warn("Lớp không còn tồn tại.");
                return;
            }

            Msg.Info("Cập nhật lớp thành công.");
            LoadData();
        });
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaLop == null)
        {
            Msg.Warn("Vui lòng chọn lớp cần xóa.");
            return;
        }

        Run(() =>
        {
            if (_repository.HasStudents(_selectedMaLop))
            {
                Msg.Warn("Không thể xóa lớp đang có sinh viên.");
                return;
            }

            if (!Msg.Confirm($"Bạn có chắc muốn xóa lớp \"{_selectedMaLop}\"?"))
            {
                return;
            }

            try
            {
                if (!_repository.Delete(_selectedMaLop))
                {
                    Msg.Warn("Lớp không còn tồn tại.");
                    return;
                }
            }
            catch (SqlException ex) when (ex.Number == ForeignKeyViolation)
            {
                Msg.Warn("Không thể xóa lớp vì đang được tham chiếu bởi dữ liệu khác.");
                return;
            }

            Msg.Info("Xóa lớp thành công.");
            ResetInput();
            LoadData();
        });
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtTimKiem.Clear();
        ResetInput();
        Run(LoadData);
    }

    private void btnTimKiem_Click(object sender, EventArgs e) => Run(LoadData);

    private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        e.SuppressKeyPress = true;
        Run(LoadData);
    }

    private void LoadData()
    {
        string keyword = txtTimKiem.Text.Trim();
        dgvLop.DataSource = keyword.Length == 0 ? _repository.GetAll() : _repository.Search(keyword);
        dgvLop.ClearSelection();
    }

    private bool IsValid(string maLop, string tenLop)
    {
        string error = LopValidator.Validate(maLop, tenLop);
        if (error == null)
        {
            return true;
        }

        Msg.Warn(error);
        (maLop.Length == 0 ? txtMaLop : txtTenLop).Focus();
        return false;
    }

    private void ResetInput()
    {
        _selectedMaLop = null;
        txtMaLop.Clear();
        txtTenLop.Clear();
        txtMaLop.ReadOnly = false;
        txtMaLop.Focus();
    }

    private static void Run(Action action)
    {
        try
        {
            action();
        }
        catch (SqlException ex)
        {
            Msg.Error($"Lỗi cơ sở dữ liệu: {ex.Message}");
        }
    }
}
