using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Giáo dục Tiểu học");
            cboKhoa.Items.Add("Hóa học");
            cboKhoa.Items.Add("Vật lý");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtNamSinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtNamSinh.Text, out int namSinh) || namSinh < 1900 || namSinh > DateTime.Now.Year)
            {
                MessageBox.Show("Năm sinh phải là số và từ 1900 đến năm hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Phải chọn giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn khoa hoặc lớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string khoa = cboKhoa.SelectedItem.ToString();
            int tuoi = DateTime.Now.Year - namSinh;

            string thongTin = $"THÔNG TIN SINH VIÊN\nHọ tên: {txtHoTen.Text}\nTuổi: {tuoi}\nEmail: {txtEmail.Text}\nGiới tính: {gioiTinh}\nKhoa/Lớp: {khoa}";
            MessageBox.Show(thongTin, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1;
            cboKhoa.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}