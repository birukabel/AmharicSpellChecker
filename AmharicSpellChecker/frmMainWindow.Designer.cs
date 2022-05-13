namespace AmharicSpellChecker
{
    partial class frmMainWindow
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
            this.richTxtInput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTxtInput
            // 
            this.richTxtInput.Font = new System.Drawing.Font("Nyala", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxtInput.Location = new System.Drawing.Point(17, 16);
            this.richTxtInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTxtInput.Name = "richTxtInput";
            this.richTxtInput.Size = new System.Drawing.Size(844, 475);
            this.richTxtInput.TabIndex = 0;
            this.richTxtInput.Text = "";
            this.richTxtInput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextInput_MouseDown);
            this.richTxtInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.richTextInput_PreviewKeyDown);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 515);
            this.Controls.Add(this.richTxtInput);
            this.Font = new System.Drawing.Font("Nyala", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "የአማርኛ ቃላት መፃፊያ ሶፍትዌር";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTxtInput;
    }
}

