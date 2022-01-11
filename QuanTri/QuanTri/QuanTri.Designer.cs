
namespace QuanTri
{
    partial class QuanTri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccMan = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblNoti = new System.Windows.Forms.Label();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelSideMenu.BackgroundImage = global::QuanTri.Properties.Resources.Untitled_2;
            this.panelSideMenu.Controls.Add(this.btnExit);
            this.panelSideMenu.Controls.Add(this.btnAccMan);
            this.panelSideMenu.Controls.Add(this.btnSanPham);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(250, 673);
            this.panelSideMenu.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(12, 632);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAccMan
            // 
            this.btnAccMan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAccMan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccMan.FlatAppearance.BorderSize = 0;
            this.btnAccMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAccMan.Location = new System.Drawing.Point(0, 210);
            this.btnAccMan.Name = "btnAccMan";
            this.btnAccMan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAccMan.Size = new System.Drawing.Size(250, 45);
            this.btnAccMan.TabIndex = 2;
            this.btnAccMan.Text = "Lịch sử sản phẩm";
            this.btnAccMan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccMan.UseVisualStyleBackColor = false;
            this.btnAccMan.Click += new System.EventHandler(this.btnAccMan_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSanPham.Location = new System.Drawing.Point(0, 165);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSanPham.Size = new System.Drawing.Size(250, 45);
            this.btnSanPham.TabIndex = 1;
            this.btnSanPham.Text = "Sản phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.UseVisualStyleBackColor = false;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.BackgroundImage = global::QuanTri.Properties.Resources.Flower;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLogo.Controls.Add(this.lblNoti);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 165);
            this.panelLogo.TabIndex = 0;
            // 
            // lblNoti
            // 
            this.lblNoti.AutoSize = true;
            this.lblNoti.ForeColor = System.Drawing.Color.Red;
            this.lblNoti.Location = new System.Drawing.Point(12, 84);
            this.lblNoti.Name = "lblNoti";
            this.lblNoti.Size = new System.Drawing.Size(0, 20);
            this.lblNoti.TabIndex = 0;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(250, 0);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(1012, 673);
            this.pnlChildForm.TabIndex = 3;
            // 
            // QuanTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.panelSideMenu);
            this.Name = "QuanTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanTri";
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAccMan;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblNoti;
        private System.Windows.Forms.Panel pnlChildForm;
    }
}