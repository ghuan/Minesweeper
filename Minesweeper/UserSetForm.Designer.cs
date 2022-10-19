
namespace Minesweeper
{
    partial class UserSetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSetForm));
            this.totalMinesNumberField = new System.Windows.Forms.NumericUpDown();
            this.xCountNumberField = new System.Windows.Forms.NumericUpDown();
            this.yCountNumberField = new System.Windows.Forms.NumericUpDown();
            this.yLabel = new System.Windows.Forms.Label();
            this.minesMapLabel = new System.Windows.Forms.Label();
            this.totalMinesLabel = new System.Windows.Forms.Label();
            this.userSetButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.totalMinesNumberField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCountNumberField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCountNumberField)).BeginInit();
            this.SuspendLayout();
            // 
            // totalMinesNumberField
            // 
            this.totalMinesNumberField.Location = new System.Drawing.Point(93, 49);
            this.totalMinesNumberField.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.totalMinesNumberField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.totalMinesNumberField.Name = "totalMinesNumberField";
            this.totalMinesNumberField.Size = new System.Drawing.Size(53, 21);
            this.totalMinesNumberField.TabIndex = 5;
            this.totalMinesNumberField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xCountNumberField
            // 
            this.xCountNumberField.Location = new System.Drawing.Point(93, 12);
            this.xCountNumberField.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.xCountNumberField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xCountNumberField.Name = "xCountNumberField";
            this.xCountNumberField.Size = new System.Drawing.Size(53, 21);
            this.xCountNumberField.TabIndex = 6;
            this.xCountNumberField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yCountNumberField
            // 
            this.yCountNumberField.Location = new System.Drawing.Point(197, 12);
            this.yCountNumberField.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.yCountNumberField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yCountNumberField.Name = "yCountNumberField";
            this.yCountNumberField.Size = new System.Drawing.Size(53, 21);
            this.yCountNumberField.TabIndex = 7;
            this.yCountNumberField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(161, 17);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(35, 12);
            this.yLabel.TabIndex = 8;
            this.yLabel.Text = "纵向:";
            // 
            // minesMapLabel
            // 
            this.minesMapLabel.AutoSize = true;
            this.minesMapLabel.Location = new System.Drawing.Point(3, 17);
            this.minesMapLabel.Name = "minesMapLabel";
            this.minesMapLabel.Size = new System.Drawing.Size(47, 12);
            this.minesMapLabel.TabIndex = 9;
            this.minesMapLabel.Text = "雷区数:";
            // 
            // totalMinesLabel
            // 
            this.totalMinesLabel.AutoSize = true;
            this.totalMinesLabel.Location = new System.Drawing.Point(43, 52);
            this.totalMinesLabel.Name = "totalMinesLabel";
            this.totalMinesLabel.Size = new System.Drawing.Size(47, 12);
            this.totalMinesLabel.TabIndex = 10;
            this.totalMinesLabel.Text = "地雷数:";
            // 
            // userSetButton
            // 
            this.userSetButton.Location = new System.Drawing.Point(152, 43);
            this.userSetButton.Name = "userSetButton";
            this.userSetButton.Size = new System.Drawing.Size(50, 30);
            this.userSetButton.TabIndex = 11;
            this.userSetButton.Text = "确定";
            this.userSetButton.UseVisualStyleBackColor = true;
            this.userSetButton.Click += new System.EventHandler(this.userSetButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(208, 43);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 30);
            this.closeButton.TabIndex = 12;
            this.closeButton.Text = "关闭";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(55, 17);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(35, 12);
            this.xLabel.TabIndex = 13;
            this.xLabel.Text = "横向:";
            // 
            // UserSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 81);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.userSetButton);
            this.Controls.Add(this.totalMinesLabel);
            this.Controls.Add(this.minesMapLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.yCountNumberField);
            this.Controls.Add(this.xCountNumberField);
            this.Controls.Add(this.totalMinesNumberField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserSetForm";
            this.Text = "设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UserSetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.totalMinesNumberField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCountNumberField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCountNumberField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown totalMinesNumberField;
        private System.Windows.Forms.NumericUpDown xCountNumberField;
        private System.Windows.Forms.NumericUpDown yCountNumberField;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label minesMapLabel;
        private System.Windows.Forms.Label totalMinesLabel;
        private System.Windows.Forms.Button userSetButton;
        public MinesweeperForm minesweeperForm;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label xLabel;
    }
}