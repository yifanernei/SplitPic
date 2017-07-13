namespace SplitPic
{
    partial class SubImgForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_right01 = new System.Windows.Forms.Button();
            this.bt_left01 = new System.Windows.Forms.Button();
            this.bt_180 = new System.Windows.Forms.Button();
            this.bt_right = new System.Windows.Forms.Button();
            this.bt_left = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_save);
            this.panel2.Controls.Add(this.bt_right01);
            this.panel2.Controls.Add(this.bt_left01);
            this.panel2.Controls.Add(this.bt_180);
            this.panel2.Controls.Add(this.bt_right);
            this.panel2.Controls.Add(this.bt_left);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(889, 57);
            this.panel2.TabIndex = 1;
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(787, 18);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 2;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_right01
            // 
            this.bt_right01.Location = new System.Drawing.Point(364, 18);
            this.bt_right01.Name = "bt_right01";
            this.bt_right01.Size = new System.Drawing.Size(88, 23);
            this.bt_right01.TabIndex = 0;
            this.bt_right01.Tag = "-0.1";
            this.bt_right01.Text = "右转0.1度(&E)";
            this.bt_right01.UseVisualStyleBackColor = true;
            this.bt_right01.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // bt_left01
            // 
            this.bt_left01.Location = new System.Drawing.Point(276, 18);
            this.bt_left01.Name = "bt_left01";
            this.bt_left01.Size = new System.Drawing.Size(88, 23);
            this.bt_left01.TabIndex = 0;
            this.bt_left01.Tag = "0.1";
            this.bt_left01.Text = "左转0.1度(&Q)";
            this.bt_left01.UseVisualStyleBackColor = true;
            this.bt_left01.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // bt_180
            // 
            this.bt_180.Location = new System.Drawing.Point(188, 18);
            this.bt_180.Name = "bt_180";
            this.bt_180.Size = new System.Drawing.Size(88, 23);
            this.bt_180.TabIndex = 0;
            this.bt_180.Tag = "180";
            this.bt_180.Text = "180度(&W)";
            this.bt_180.UseVisualStyleBackColor = true;
            this.bt_180.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // bt_right
            // 
            this.bt_right.Location = new System.Drawing.Point(100, 18);
            this.bt_right.Name = "bt_right";
            this.bt_right.Size = new System.Drawing.Size(88, 23);
            this.bt_right.TabIndex = 0;
            this.bt_right.Tag = "-90";
            this.bt_right.Text = "右转(&D)";
            this.bt_right.UseVisualStyleBackColor = true;
            this.bt_right.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // bt_left
            // 
            this.bt_left.Location = new System.Drawing.Point(12, 18);
            this.bt_left.Name = "bt_left";
            this.bt_left.Size = new System.Drawing.Size(88, 23);
            this.bt_left.TabIndex = 0;
            this.bt_left.Tag = "90";
            this.bt_left.Text = "左转(&A)";
            this.bt_left.UseVisualStyleBackColor = true;
            this.bt_left.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 531);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(889, 531);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SubImgForm
            // 
            this.AcceptButton = this.bt_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 588);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SubImgForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SubImgForm";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubImgForm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_right;
        private System.Windows.Forms.Button bt_left;
        private System.Windows.Forms.Button bt_180;
        private System.Windows.Forms.Button bt_left01;
        private System.Windows.Forms.Button bt_right01;
        private System.Windows.Forms.Button bt_save;
        public System.Windows.Forms.PictureBox pictureBox1;

    }
}