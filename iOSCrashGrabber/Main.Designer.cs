namespace Rico
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.stepPictureBox = new System.Windows.Forms.PictureBox();
            this.nextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stepPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // stepPictureBox
            // 
            this.stepPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.stepPictureBox.Location = new System.Drawing.Point(0, 0);
            this.stepPictureBox.Name = "stepPictureBox";
            this.stepPictureBox.Size = new System.Drawing.Size(414, 237);
            this.stepPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.stepPictureBox.TabIndex = 0;
            this.stepPictureBox.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(170, 243);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(80, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 285);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.stepPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Rico";
            ((System.ComponentModel.ISupportInitialize)(this.stepPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox stepPictureBox;
        private System.Windows.Forms.Button nextButton;

    }
}

