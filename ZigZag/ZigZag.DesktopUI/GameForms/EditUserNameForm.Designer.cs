namespace ZigZag.DesktopUI.GameForms
{
    partial class EditUserNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUserNameForm));
            this.InputUserNamePcb = new System.Windows.Forms.PictureBox();
            this.InputUserNameTxBx = new System.Windows.Forms.TextBox();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InputUserNamePcb)).BeginInit();
            this.SuspendLayout();
            // 
            // InputUserNamePcb
            // 
            this.InputUserNamePcb.Image = global::ZigZag.DesktopUI.Properties.Resources.typing_un;
            this.InputUserNamePcb.Location = new System.Drawing.Point(78, 27);
            this.InputUserNamePcb.Name = "InputUserNamePcb";
            this.InputUserNamePcb.Size = new System.Drawing.Size(355, 94);
            this.InputUserNamePcb.TabIndex = 0;
            this.InputUserNamePcb.TabStop = false;
            // 
            // InputUserNameTxBx
            // 
            this.InputUserNameTxBx.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputUserNameTxBx.Location = new System.Drawing.Point(78, 149);
            this.InputUserNameTxBx.Name = "InputUserNameTxBx";
            this.InputUserNameTxBx.Size = new System.Drawing.Size(355, 45);
            this.InputUserNameTxBx.TabIndex = 1;
            this.InputUserNameTxBx.Text = "Player";
            this.InputUserNameTxBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptBtn.Location = new System.Drawing.Point(78, 219);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(133, 56);
            this.AcceptBtn.TabIndex = 2;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(300, 219);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(133, 56);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // EditUserNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(511, 302);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.InputUserNameTxBx);
            this.Controls.Add(this.InputUserNamePcb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditUserNameForm";
            this.Text = "Change user name";
            ((System.ComponentModel.ISupportInitialize)(this.InputUserNamePcb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox InputUserNamePcb;
        private System.Windows.Forms.TextBox InputUserNameTxBx;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}