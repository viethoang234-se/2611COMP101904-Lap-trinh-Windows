using Lab07.Data;
using Lab07.Helpers;
using Lab07.Models;

namespace Lab07.Forms;

public partial class FrmProduct : Form
{
    public FrmProduct()
    {
        InitializeComponent();
    }

    private void FrmProduct_Load(object sender, EventArgs e) => LoadGrid();

    private void btnAdd_Click(object sender, EventArgs e)
    {
        Product product = ReadInput();
        if (product == null)
        {
            return;
        }

        if (Find(product.Id) != null)
        {
            Msg.Warn("Mã sản phẩm đã tồn tại.");
            txtId.Focus();
            return;
        }

        DataStore.Products.Add(product);
        LoadGrid();
        ClearInput();
        Msg.Info("Thêm sản phẩm thành công.");
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        Product input = ReadInput();
        if (input == null)
        {
            return;
        }

        Product product = Find(input.Id);
        if (product == null)
        {
            Msg.Warn("Không tìm thấy sản phẩm. Vui lòng chọn sản phẩm trong danh sách để sửa.");
            return;
        }

        product.Name = input.Name;
        product.Category = input.Category;
        product.Price = input.Price;
        product.Quantity = input.Quantity;
        LoadGrid();
        Msg.Info("Cập nhật sản phẩm thành công.");
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        Product product = Find(txtId.Text.Trim());
        if (product == null)
        {
            Msg.Warn("Vui lòng chọn sản phẩm cần xóa.");
            return;
        }

        if (!Msg.Confirm($"Bạn có chắc muốn xóa sản phẩm \"{product.Name}\"?"))
        {
            return;
        }

        DataStore.Products.Remove(product);
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

    private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvProducts.Rows[e.RowIndex].DataBoundItem is not Product product)
        {
            return;
        }

        txtId.Text = product.Id;
        txtName.Text = product.Name;
        cboCategory.SelectedItem = product.Category;
        txtPrice.Text = product.Price.ToString();
        txtQuantity.Text = product.Quantity.ToString();
    }

    private void LoadGrid()
    {
        string keyword = txtSearch.Text.Trim();
        dgvProducts.DataSource = DataStore.Products
            .Where(p => Matches(p.Id, keyword) || Matches(p.Name, keyword) || Matches(p.Category, keyword))
            .ToList();
    }

    private static bool Matches(string value, string keyword) =>
        value.Contains(keyword, StringComparison.OrdinalIgnoreCase);

    private static Product Find(string id) =>
        DataStore.Products.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

    private Product ReadInput()
    {
        string id = txtId.Text.Trim();
        string name = txtName.Text.Trim();

        if (id.Length == 0)
        {
            return Invalid("Vui lòng nhập mã sản phẩm.", txtId);
        }
        if (name.Length == 0)
        {
            return Invalid("Vui lòng nhập tên sản phẩm.", txtName);
        }
        if (cboCategory.SelectedIndex < 0)
        {
            return Invalid("Vui lòng chọn loại sản phẩm.", cboCategory);
        }
        if (!decimal.TryParse(txtPrice.Text, out decimal price))
        {
            return Invalid("Đơn giá không hợp lệ.", txtPrice);
        }
        if (price < 0)
        {
            return Invalid("Đơn giá không được âm.", txtPrice);
        }
        if (!int.TryParse(txtQuantity.Text, out int quantity))
        {
            return Invalid("Số lượng không hợp lệ.", txtQuantity);
        }
        if (quantity < 0)
        {
            return Invalid("Số lượng không được âm.", txtQuantity);
        }

        return new Product
        {
            Id = id,
            Name = name,
            Category = cboCategory.SelectedItem.ToString(),
            Price = price,
            Quantity = quantity
        };
    }

    private static Product Invalid(string message, Control control)
    {
        Msg.Warn(message);
        control.Focus();
        return null;
    }

    private void ClearInput()
    {
        txtId.Clear();
        txtName.Clear();
        txtPrice.Clear();
        txtQuantity.Clear();
        cboCategory.SelectedIndex = -1;
        txtId.Focus();
    }
}
