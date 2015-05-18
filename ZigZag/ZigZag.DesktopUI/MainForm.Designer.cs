namespace ZigZag.DesktopUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.ScoreTitleLbl = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.GameBoardPnl = new System.Windows.Forms.Panel();
            this.SoundModePcb = new System.Windows.Forms.PictureBox();
            this.countPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.GameBoardPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundModePcb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ScoreLbl);
            this.panel1.Controls.Add(this.ScoreTitleLbl);
            this.panel1.Controls.Add(this.StopBtn);
            this.panel1.Controls.Add(this.ResumeBtn);
            this.panel1.Controls.Add(this.PauseBtn);
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Controls.Add(this.UserNameLbl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 61);
            this.panel1.TabIndex = 0;
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreLbl.Location = new System.Drawing.Point(755, 17);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(20, 24);
            this.ScoreLbl.TabIndex = 5;
            this.ScoreLbl.Text = "0";
            // 
            // ScoreTitleLbl
            // 
            this.ScoreTitleLbl.AutoSize = true;
            this.ScoreTitleLbl.Font = new System.Drawing.Font("Microsoft NeoGothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreTitleLbl.Location = new System.Drawing.Point(662, 15);
            this.ScoreTitleLbl.Name = "ScoreTitleLbl";
            this.ScoreTitleLbl.Size = new System.Drawing.Size(63, 26);
            this.ScoreTitleLbl.TabIndex = 4;
            this.ScoreTitleLbl.Text = "Score:";
            // 
            // StopBtn
            // 
            this.StopBtn.Enabled = false;
            this.StopBtn.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBtn.Location = new System.Drawing.Point(525, 5);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(110, 50);
            this.StopBtn.TabIndex = 2;
            this.StopBtn.TabStop = false;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            this.StopBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.Enabled = false;
            this.ResumeBtn.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeBtn.Location = new System.Drawing.Point(409, 5);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(110, 50);
            this.ResumeBtn.TabIndex = 3;
            this.ResumeBtn.TabStop = false;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.UseVisualStyleBackColor = true;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            this.ResumeBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Enabled = false;
            this.PauseBtn.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseBtn.Location = new System.Drawing.Point(293, 5);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(110, 50);
            this.PauseBtn.TabIndex = 2;
            this.PauseBtn.TabStop = false;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            this.PauseBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.Location = new System.Drawing.Point(177, 5);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(110, 50);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.TabStop = false;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            this.StartBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLbl.Location = new System.Drawing.Point(4, 20);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(0, 21);
            this.UserNameLbl.TabIndex = 0;
            // 
            // GameBoardPnl
            // 
            this.GameBoardPnl.Controls.Add(this.SoundModePcb);
            this.GameBoardPnl.Controls.Add(this.countPictureBox);
            this.GameBoardPnl.Location = new System.Drawing.Point(12, 79);
            this.GameBoardPnl.Name = "GameBoardPnl";
            this.GameBoardPnl.Size = new System.Drawing.Size(800, 445);
            this.GameBoardPnl.TabIndex = 1;
            this.GameBoardPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.GameBoardPnl_Paint);
            // 
            // SoundModePcb
            // 
            this.SoundModePcb.Image = global::ZigZag.DesktopUI.Properties.Resources.sound_on;
            this.SoundModePcb.Location = new System.Drawing.Point(755, 3);
            this.SoundModePcb.Name = "SoundModePcb";
            this.SoundModePcb.Size = new System.Drawing.Size(40, 40);
            this.SoundModePcb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SoundModePcb.TabIndex = 1;
            this.SoundModePcb.TabStop = false;
            this.SoundModePcb.Click += new System.EventHandler(this.SoundModePcb_Click);
            this.SoundModePcb.MouseEnter += new System.EventHandler(this.SoundModePcb_MouseEnter);
            // 
            // countPictureBox
            // 
            this.countPictureBox.Image = global::ZigZag.DesktopUI.Properties.Resources._3_number;
            this.countPictureBox.Location = new System.Drawing.Point(300, 122);
            this.countPictureBox.Name = "countPictureBox";
            this.countPictureBox.Size = new System.Drawing.Size(200, 200);
            this.countPictureBox.TabIndex = 0;
            this.countPictureBox.TabStop = false;
            this.countPictureBox.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 542);
            this.Controls.Add(this.GameBoardPnl);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZigZag";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GameBoardPnl.ResumeLayout(false);
            this.GameBoardPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundModePcb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.Label ScoreTitleLbl;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Panel GameBoardPnl;
        private System.Windows.Forms.PictureBox countPictureBox;
        private System.Windows.Forms.PictureBox SoundModePcb;
    }
}

