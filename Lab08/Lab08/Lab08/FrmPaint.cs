using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace COMP1019_Lab08_SimplePaint
{
    public partial class FrmPaint : Form
    {
        private readonly List<DrawItem> items = new List<DrawItem>();
        private DrawItem? currentItem;
        private bool isDrawing = false;
        private Color currentColor = Color.Black;

        public FrmPaint()
        {
            InitializeComponent();
            cboMode.SelectedIndex = 0;
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;

            btnColor.Click += BtnColor_Click;
            btnUndo.Click += BtnUndo_Click;
            btnClear.Click += BtnClear_Click;
            btnSave.Click += BtnSave_Click;
            KeyDown += FrmPaint_KeyDown;
        }

        private DrawMode CurrentMode
        {
            get
            {
                string mode = cboMode.SelectedItem?.ToString() ?? "Pen";
                return Enum.TryParse(mode, out DrawMode result) ? result : DrawMode.Pen;
            }
        }

        // ===== Nút lệnh =====
        private void BtnColor_Click(object? sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = dialog.Color;
                btnColor.BackColor = currentColor;
                btnColor.ForeColor = currentColor.GetBrightness() < 0.5f ? Color.White : Color.Black;
            }
        }

        private void BtnUndo_Click(object? sender, EventArgs e)
        {
            if (items.Count == 0) return;

            items.RemoveAt(items.Count - 1);
            canvas.Invalidate();
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            if (items.Count == 0) return;

            DialogResult result = MessageBox.Show("Xóa toàn bộ vùng vẽ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                items.Clear();
                canvas.Invalidate();
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG image|*.png";
            dialog.FileName = "paint.png";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
                using Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                RenderItems(g);
                bmp.Save(dialog.FileName, ImageFormat.Png);
                MessageBox.Show("Đã lưu ảnh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lưu được ảnh: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPaint_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                e.SuppressKeyPress = true;
                btnUndo.PerformClick();
            }
        }

        // ===== Chuột =====
        private void Canvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            isDrawing = true;
            currentItem = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = currentColor,
                Width = (float)nudWidth.Value,
                Fill = chkFill.Checked
            };

            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);
        }

        private void Canvas_MouseMove(object? sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X = {e.X}, Y = {e.Y}, Items = {items.Count}";

            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;
            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);

            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;
            items.Add(currentItem);

            currentItem = null;
            isDrawing = false;
            canvas.Invalidate();
        }

        // ===== Vẽ =====
        private void Canvas_Paint(object? sender, PaintEventArgs e)
        {
            RenderItems(e.Graphics);
        }

        private void RenderItems(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (DrawItem item in items)
                DrawOneItem(g, item);

            if (currentItem != null)
                DrawOneItem(g, currentItem);
        }

        private void DrawOneItem(Graphics g, DrawItem item)
        {
            using Pen pen = new Pen(item.Color, item.Width);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;

            Rectangle rect = GetRectangle(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    DrawFreePen(g, pen, item);
                    break;
                case DrawMode.Line:
                    g.DrawLine(pen, item.Start, item.End);
                    break;
                case DrawMode.Rectangle:
                    if (item.Fill)
                    {
                        using SolidBrush brush = new SolidBrush(item.Color);
                        g.FillRectangle(brush, rect);
                    }
                    g.DrawRectangle(pen, rect);
                    break;
                case DrawMode.Ellipse:
                    if (item.Fill)
                    {
                        using SolidBrush brush = new SolidBrush(item.Color);
                        g.FillEllipse(brush, rect);
                    }
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void DrawFreePen(Graphics g, Pen pen, DrawItem item)
        {
            List<Point> points = item.Points;

            if (points.Count == 1)
            {
                // Click không kéo: vẽ một chấm tròn
                using SolidBrush dot = new SolidBrush(item.Color);
                float r = item.Width / 2f;
                g.FillEllipse(dot, points[0].X - r, points[0].Y - r, item.Width, item.Width);
                return;
            }

            for (int i = 1; i < points.Count; i++)
                g.DrawLine(pen, points[i - 1], points[i]);
        }

        // Xử lý kéo chuột theo mọi hướng
        private static Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);

            return new Rectangle(x, y, width, height);
        }
    }
}
