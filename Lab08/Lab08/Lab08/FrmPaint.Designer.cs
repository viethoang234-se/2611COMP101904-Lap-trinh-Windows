#nullable disable
namespace COMP1019_Lab08_SimplePaint
{
    partial class FrmPaint
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblMode = new Label();
            cboMode = new ComboBox();
            lblWidth = new Label();
            nudWidth = new NumericUpDown();
            btnColor = new Button();
            chkFill = new CheckBox();
            btnUndo = new Button();
            btnClear = new Button();
            btnSave = new Button();
            canvas = new DrawSurface();
            lblStatus = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudWidth).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(238, 247, 247);
            pnlTop.Controls.Add(lblMode);
            pnlTop.Controls.Add(cboMode);
            pnlTop.Controls.Add(lblWidth);
            pnlTop.Controls.Add(nudWidth);
            pnlTop.Controls.Add(btnColor);
            pnlTop.Controls.Add(chkFill);
            pnlTop.Controls.Add(btnUndo);
            pnlTop.Controls.Add(btnClear);
            pnlTop.Controls.Add(btnSave);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1000, 48);
            pnlTop.TabIndex = 0;
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Location = new Point(15, 16);
            lblMode.Name = "lblMode";
            lblMode.Text = "Mode";
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse" });
            cboMode.Location = new Point(70, 12);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(110, 23);
            cboMode.TabIndex = 0;
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Location = new Point(200, 16);
            lblWidth.Name = "lblWidth";
            lblWidth.Text = "Width";
            // 
            // nudWidth
            // 
            nudWidth.Location = new Point(250, 12);
            nudWidth.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWidth.Name = "nudWidth";
            nudWidth.Size = new Size(60, 23);
            nudWidth.TabIndex = 1;
            nudWidth.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnColor
            // 
            btnColor.Location = new Point(330, 10);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(80, 28);
            btnColor.TabIndex = 2;
            btnColor.Text = "Color";
            btnColor.UseVisualStyleBackColor = false;
            btnColor.BackColor = Color.Black;
            btnColor.ForeColor = Color.White;
            // 
            // chkFill
            // 
            chkFill.AutoSize = true;
            chkFill.Location = new Point(425, 14);
            chkFill.Name = "chkFill";
            chkFill.TabIndex = 3;
            chkFill.Text = "Fill";
            chkFill.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(485, 10);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(80, 28);
            btnUndo.TabIndex = 4;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(575, 10);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 28);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(665, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 28);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // canvas
            // 
            canvas.BackColor = Color.White;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 48);
            canvas.Name = "canvas";
            canvas.Size = new Size(1000, 548);
            canvas.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 596);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1000, 26);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmPaint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 622);
            Controls.Add(canvas);
            Controls.Add(lblStatus);
            Controls.Add(pnlTop);
            KeyPreview = true;
            MinimumSize = new Size(760, 400);
            Name = "FrmPaint";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMP1019 - Simple Paint";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudWidth).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblMode;
        private ComboBox cboMode;
        private Label lblWidth;
        private NumericUpDown nudWidth;
        private Button btnColor;
        private CheckBox chkFill;
        private Button btnUndo;
        private Button btnClear;
        private Button btnSave;
        private DrawSurface canvas;
        private Label lblStatus;
    }
}
