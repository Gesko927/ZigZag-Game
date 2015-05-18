namespace ZigZag.DesktopUI.GameForms
{
    partial class ControlInstructuinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlInstructuinForm));
            this.ShiftDescriptionLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GoBackPcb = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShiftControlPcb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GoBackPcb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftControlPcb)).BeginInit();
            this.SuspendLayout();
            // 
            // ShiftDescriptionLbl
            // 
            this.ShiftDescriptionLbl.AutoSize = true;
            this.ShiftDescriptionLbl.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShiftDescriptionLbl.Location = new System.Drawing.Point(236, 111);
            this.ShiftDescriptionLbl.Name = "ShiftDescriptionLbl";
            this.ShiftDescriptionLbl.Size = new System.Drawing.Size(371, 36);
            this.ShiftDescriptionLbl.TabIndex = 1;
            this.ShiftDescriptionLbl.Text = "To  turn  on/off  sounds";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "To  control  the  ball";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "To  Quit";
            // 
            // GoBackPcb
            // 
            this.GoBackPcb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoBackPcb.Image = global::ZigZag.DesktopUI.Properties.Resources.back_arrow;
            this.GoBackPcb.Location = new System.Drawing.Point(550, 339);
            this.GoBackPcb.Name = "GoBackPcb";
            this.GoBackPcb.Size = new System.Drawing.Size(100, 101);
            this.GoBackPcb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GoBackPcb.TabIndex = 7;
            this.GoBackPcb.TabStop = false;
            this.GoBackPcb.Click += new System.EventHandler(this.GoBackPcb_Click);
            this.GoBackPcb.MouseEnter += new System.EventHandler(this.GoBackPcb_MouseEnter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ZigZag.DesktopUI.Properties.Resources.keycontrol_img;
            this.pictureBox3.Location = new System.Drawing.Point(127, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(409, 75);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ZigZag.DesktopUI.Properties.Resources.controlkey_esc;
            this.pictureBox2.Location = new System.Drawing.Point(80, 280);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 75);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZigZag.DesktopUI.Properties.Resources.controlkey_space;
            this.pictureBox1.Location = new System.Drawing.Point(56, 184);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 65);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ShiftControlPcb
            // 
            this.ShiftControlPcb.Image = global::ZigZag.DesktopUI.Properties.Resources.controlkey_shift;
            this.ShiftControlPcb.Location = new System.Drawing.Point(62, 104);
            this.ShiftControlPcb.Name = "ShiftControlPcb";
            this.ShiftControlPcb.Size = new System.Drawing.Size(141, 50);
            this.ShiftControlPcb.TabIndex = 0;
            this.ShiftControlPcb.TabStop = false;
            // 
            // ControlInstructuinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 452);
            this.Controls.Add(this.GoBackPcb);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ShiftDescriptionLbl);
            this.Controls.Add(this.ShiftControlPcb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlInstructuinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.GoBackPcb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftControlPcb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShiftControlPcb;
        private System.Windows.Forms.Label ShiftDescriptionLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox GoBackPcb;

    }
}