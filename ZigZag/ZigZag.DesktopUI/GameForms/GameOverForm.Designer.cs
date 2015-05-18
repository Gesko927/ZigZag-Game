namespace ZigZag.DesktopUI.GameForms
{
    partial class GameOverForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
            this.ScoreDesctiptionLbl = new System.Windows.Forms.Label();
            this.ScoreValueLbl = new System.Windows.Forms.Label();
            this.GameOverPcb = new System.Windows.Forms.PictureBox();
            this.BackToMainMenuPcb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameOverPcb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackToMainMenuPcb)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreDesctiptionLbl
            // 
            this.ScoreDesctiptionLbl.AutoSize = true;
            this.ScoreDesctiptionLbl.Font = new System.Drawing.Font("Bradley Hand ITC", 33.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreDesctiptionLbl.Location = new System.Drawing.Point(27, 124);
            this.ScoreDesctiptionLbl.Name = "ScoreDesctiptionLbl";
            this.ScoreDesctiptionLbl.Size = new System.Drawing.Size(238, 56);
            this.ScoreDesctiptionLbl.TabIndex = 1;
            this.ScoreDesctiptionLbl.Text = "Your score:";
            // 
            // ScoreValueLbl
            // 
            this.ScoreValueLbl.Font = new System.Drawing.Font("Bradley Hand ITC", 33.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreValueLbl.Location = new System.Drawing.Point(271, 124);
            this.ScoreValueLbl.Name = "ScoreValueLbl";
            this.ScoreValueLbl.Size = new System.Drawing.Size(154, 56);
            this.ScoreValueLbl.TabIndex = 2;
            this.ScoreValueLbl.Text = "1";
            // 
            // GameOverPcb
            // 
            this.GameOverPcb.Image = global::ZigZag.DesktopUI.Properties.Resources.game_over_img;
            this.GameOverPcb.Location = new System.Drawing.Point(37, 12);
            this.GameOverPcb.Name = "GameOverPcb";
            this.GameOverPcb.Size = new System.Drawing.Size(388, 58);
            this.GameOverPcb.TabIndex = 0;
            this.GameOverPcb.TabStop = false;
            // 
            // BackToMainMenuPcb
            // 
            this.BackToMainMenuPcb.Image = global::ZigZag.DesktopUI.Properties.Resources.back_to_main_menu;
            this.BackToMainMenuPcb.Location = new System.Drawing.Point(73, 230);
            this.BackToMainMenuPcb.Name = "BackToMainMenuPcb";
            this.BackToMainMenuPcb.Size = new System.Drawing.Size(323, 40);
            this.BackToMainMenuPcb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BackToMainMenuPcb.TabIndex = 3;
            this.BackToMainMenuPcb.TabStop = false;
            this.BackToMainMenuPcb.Click += new System.EventHandler(this.BackToMainMenuPcb_Click);
            this.BackToMainMenuPcb.MouseEnter += new System.EventHandler(this.BackToMainMenuPcb_MouseEnter);
            this.BackToMainMenuPcb.MouseLeave += new System.EventHandler(this.BackToMainMenuPcb_MouseLeave);
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 434);
            this.Controls.Add(this.BackToMainMenuPcb);
            this.Controls.Add(this.ScoreValueLbl);
            this.Controls.Add(this.ScoreDesctiptionLbl);
            this.Controls.Add(this.GameOverPcb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Over";
            ((System.ComponentModel.ISupportInitialize)(this.GameOverPcb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackToMainMenuPcb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameOverPcb;
        private System.Windows.Forms.Label ScoreDesctiptionLbl;
        private System.Windows.Forms.Label ScoreValueLbl;
        private System.Windows.Forms.PictureBox BackToMainMenuPcb;
    }
}