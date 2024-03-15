namespace CS161_FinalProject_MovieTheaterManager.Views
{
    partial class SecurityView
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
            panel1 = new Panel();
            enter_Button = new Button();
            groupBox1 = new GroupBox();
            password_TextBox = new TextBox();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(enter_Button);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 119);
            panel1.TabIndex = 0;
            // 
            // enter_Button
            // 
            enter_Button.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            enter_Button.BackColor = Color.SteelBlue;
            enter_Button.ForeColor = SystemColors.ControlLightLight;
            enter_Button.Location = new Point(18, 83);
            enter_Button.Name = "enter_Button";
            enter_Button.Size = new Size(348, 23);
            enter_Button.TabIndex = 3;
            enter_Button.Text = "Enter";
            enter_Button.UseVisualStyleBackColor = false;
            enter_Button.Click += enter_Button_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(password_TextBox);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 65);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter Passcode";
            // 
            // password_TextBox
            // 
            password_TextBox.Location = new Point(6, 22);
            password_TextBox.Name = "password_TextBox";
            password_TextBox.Size = new Size(348, 23);
            password_TextBox.TabIndex = 0;
            password_TextBox.UseSystemPasswordChar = true;
            // 
            // SecurityView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 47, 47);
            ClientSize = new Size(385, 119);
            Controls.Add(panel1);
            Name = "SecurityView";
            Text = "SecurityView";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button enter_Button;
        private GroupBox groupBox1;
        private TextBox password_TextBox;
    }
}