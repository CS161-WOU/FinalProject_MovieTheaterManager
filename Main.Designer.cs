namespace CS161_FinalProject_MovieTheaterManager
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitleLabel = new Label();
            MainPanel = new Panel();
            managerButton = new Button();
            getMoviesButton = new Button();
            exitButton = new Button();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Copperplate Gothic Bold", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(111, 23);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(424, 21);
            TitleLabel.TabIndex = 2;
            TitleLabel.Text = "Totally Real Movie Theater Solutions";
            // 
            // MainPanel
            // 
            MainPanel.Anchor = AnchorStyles.None;
            MainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MainPanel.BackColor = Color.FromArgb(47, 47, 47);
            MainPanel.Controls.Add(managerButton);
            MainPanel.Controls.Add(getMoviesButton);
            MainPanel.Controls.Add(exitButton);
            MainPanel.Controls.Add(TitleLabel);
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(627, 255);
            MainPanel.TabIndex = 4;
            // 
            // managerButton
            // 
            managerButton.BackColor = Color.DimGray;
            managerButton.FlatStyle = FlatStyle.Flat;
            managerButton.ForeColor = SystemColors.Control;
            managerButton.Location = new Point(232, 144);
            managerButton.Name = "managerButton";
            managerButton.Size = new Size(182, 37);
            managerButton.TabIndex = 7;
            managerButton.Text = "Manager View";
            managerButton.UseVisualStyleBackColor = false;
            managerButton.Click += managerButton_Click;
            // 
            // getMoviesButton
            // 
            getMoviesButton.BackColor = Color.DimGray;
            getMoviesButton.FlatStyle = FlatStyle.Flat;
            getMoviesButton.ForeColor = SystemColors.Control;
            getMoviesButton.Location = new Point(232, 80);
            getMoviesButton.Name = "getMoviesButton";
            getMoviesButton.Size = new Size(182, 37);
            getMoviesButton.TabIndex = 6;
            getMoviesButton.Text = "Get Movie Tickets";
            getMoviesButton.UseVisualStyleBackColor = false;
            getMoviesButton.Click += getMoviesButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Tomato;
            exitButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.Control;
            exitButton.Location = new Point(274, 200);
            exitButton.Margin = new Padding(3, 2, 3, 2);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(99, 25);
            exitButton.TabIndex = 5;
            exitButton.Text = "EXIT";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 47, 47);
            ClientSize = new Size(627, 255);
            Controls.Add(MainPanel);
            Name = "Main";
            Text = "Main";
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label TitleLabel;
        private Panel MainPanel;
        private Button exitButton;
        private Button managerButton;
        private Button getMoviesButton;
    }
}
