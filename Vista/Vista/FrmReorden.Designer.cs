namespace Vista
{
    partial class FrmReorden
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
            this.dgvReorden = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReorden)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReorden
            // 
            this.dgvReorden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReorden.Location = new System.Drawing.Point(39, 79);
            this.dgvReorden.Name = "dgvReorden";
            this.dgvReorden.RowHeadersWidth = 51;
            this.dgvReorden.RowTemplate.Height = 24;
            this.dgvReorden.Size = new System.Drawing.Size(622, 333);
            this.dgvReorden.TabIndex = 0;
            // 
            // FrmReorden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.dgvReorden);
            this.Name = "FrmReorden";
            this.Text = "Consulta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReorden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReorden;
    }
}