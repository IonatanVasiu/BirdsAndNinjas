
namespace BirdsAndNinjas.Board
{
    partial class BoardForm
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
            this.TurnBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TurnBox
            // 
            this.TurnBox.Location = new System.Drawing.Point(13, 13);
            this.TurnBox.Name = "TurnBox";
            this.TurnBox.ReadOnly = true;
            this.TurnBox.Size = new System.Drawing.Size(100, 22);
            this.TurnBox.TabIndex = 0;
            // 
            // BoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 1055);
            this.Controls.Add(this.TurnBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHESS BIRDS AND NINJAS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TurnBox;
    }
}

