using System.Text.RegularExpressions;
using Lab07.Data;
using Lab07.Helpers;
using Lab07.Models;

namespace Lab07.Forms;

public partial class FrmCustomer : Form
{
    private static readonly Regex PhonePattern = new(@"^0\d{9,10}$");

    public FrmCustomer()
    {
        InitializeComponent();
    }

    private void FrmCustomer_Load(object sender, EventArgs e) => LoadGrid();

    private void btnAdd_Click(object sender, EventArgs e)
    {
        Customer customer = ReadInput();
        if (customer == null)
        {
            return;
        }

        if (Find(customer.Id) != null)
        {
            Msg.Warn("Mã khách hàng đã tồn tại.");
            txtId.Focus();
            return;
        }

        DataStore.Customers.Add(customer);
        LoadGrid();
        ClearInput();
        Msg.Info("Thêm khách hàng thành công.");
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        Customer input = ReadInput();
        if (input == null)
        {
            return;
        }

        Customer customer = Find(input.Id);
        if (customer == null)
        {
            Msg.Warn("Không tìm thấy khách hàng. Vui lòng chọn khách hàng trong danh sách để sửa.");
            return;
        }

        customer.FullName = input.FullName;
        customer.Phone = input.Phone;
        customer.Type = input.Type;
        LoadGrid();
        Msg.Info("Cập nhật khách hàng thành công.");
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        Customer customer = Find(txtId.Text.Trim());
        if (customer == null)
        {
            Msg.Warn("Vui lòng chọn khách hàng cần xóa.");
            return;
        }

        if (!Msg.Confirm($"Bạn có chắc muốn xóa khách hàng \"{customer.FullName}\"?"))
        {
            return;
        }

        DataStore.Customers.Remove(customer);
        LoadGrid();
        ClearInput();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        txtSearch.Clear();
        ClearInput();
        LoadGrid();
    }

    private void btnSearch_Click(object sender, EventArgs e) => LoadGrid();

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        e.SuppressKeyPress = true;
        LoadGrid();
    }

    private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvCustomers.Rows[e.RowIndex].DataBoundItem is not Customer customer)
        {
            return;
        }

        txtId.Text = customer.Id;
        txtFullName.Text = customer.FullName;
        txtPhone.Text = customer.Phone;
        cboType.SelectedItem = customer.Type;
    }

    private void LoadGrid()
    {
        string keyword = txtSearch.Text.Trim();
        dgvCustomers.DataSource = DataStore.Customers
            .Where(c => Matches(c.Id, keyword) || Matches(c.FullName, keyword) || Matches(c.Phone, keyword))
            .ToList();
    }

    private static bool Matches(string value, string keyword) =>
        value.Contains(keyword, StringComparison.OrdinalIgnoreCase);

    private static Customer Find(string id) =>
        DataStore.Customers.FirstOrDefault(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

    private Customer ReadInput()
    {
        string id = txtId.Text.Trim();
        string fullName = txtFullName.Text.Trim();
        string phone = txtPhone.Text.Trim();

        if (id.Length == 0)
        {
            return Invalid("Vui lòng nhập mã khách hàng.", txtId);
        }
        if (fullName.Length == 0)
        {
            return Invalid("Vui lòng nhập họ tên.", txtFullName);
        }
        if (!PhonePattern.IsMatch(phone))
        {
            return Invalid("Số điện thoại phải bắt đầu bằng 0 và có 10 hoặc 11 chữ số.", txtPhone);
        }
        if (cboType.SelectedIndex < 0)
        {
            return Invalid("Vui lòng chọn loại khách hàng.", cboType);
        }

        return new Customer
        {
            Id = id,
            FullName = fullName,
            Phone = phone,
            Type = cboType.SelectedItem.ToString()
        };
    }

    private static Customer Invalid(string message, Control control)
    {
        Msg.Warn(message);
        control.Focus();
        return null;
    }

    private void ClearInput()
    {
        txtId.Clear();
        txtFullName.Clear();
        txtPhone.Clear();
        cboType.SelectedIndex = -1;
        txtId.Focus();
    }
}
