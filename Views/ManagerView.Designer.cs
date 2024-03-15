namespace CS161_FinalProject_MovieTheaterManager.Views
{
    partial class ManagerView
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
            tableLayoutPanel1 = new TableLayoutPanel();
            TitleLabel = new Label();
            exitButton = new Button();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            movieShowtimes_Label = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(TitleLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(exitButton, 9, 0);
            tableLayoutPanel1.Controls.Add(button1, 7, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(1132, 696);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TitleLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(TitleLabel, 5);
            TitleLabel.Font = new Font("Copperplate Gothic Bold", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            TitleLabel.ForeColor = Color.White;
            TitleLabel.Location = new Point(6, 6);
            TitleLabel.Margin = new Padding(6);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(553, 57);
            TitleLabel.TabIndex = 7;
            TitleLabel.Text = "Totally Real Movie Theater Solutions";
            TitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Right;
            exitButton.BackColor = Color.Tomato;
            exitButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            exitButton.ForeColor = SystemColors.Control;
            exitButton.Location = new Point(1029, 18);
            exitButton.Margin = new Padding(6);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(97, 33);
            exitButton.TabIndex = 8;
            exitButton.Text = "Close";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.LightSeaGreen;
            tableLayoutPanel1.SetColumnSpan(button1, 2);
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(807, 16);
            button1.Margin = new Padding(16);
            button1.Name = "button1";
            button1.Size = new Size(194, 37);
            button1.TabIndex = 9;
            button1.Text = "Make Shit Up";
            button1.UseVisualStyleBackColor = false;
            button1.Click += makeShitUp;
            // 
            // flowLayoutPanel1
            // 
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(10, 79);
            flowLayoutPanel1.Margin = new Padding(10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            tableLayoutPanel1.SetRowSpan(flowLayoutPanel1, 9);
            flowLayoutPanel1.Size = new Size(319, 607);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(movieShowtimes_Label);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(316, 47);
            panel1.TabIndex = 0;
            // 
            // movieShowtimes_Label
            // 
            movieShowtimes_Label.BackColor = Color.FromArgb(64, 64, 64);
            movieShowtimes_Label.Dock = DockStyle.Fill;
            movieShowtimes_Label.Font = new Font("Engravers MT", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            movieShowtimes_Label.ForeColor = SystemColors.ControlLightLight;
            movieShowtimes_Label.Location = new Point(10, 10);
            movieShowtimes_Label.Margin = new Padding(10);
            movieShowtimes_Label.Name = "movieShowtimes_Label";
            movieShowtimes_Label.Size = new Size(296, 27);
            movieShowtimes_Label.TabIndex = 15;
            movieShowtimes_Label.Text = "Movies";
            movieShowtimes_Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ManagerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 47, 47);
            ClientSize = new Size(1132, 696);
            Controls.Add(tableLayoutPanel1);
            Name = "ManagerView";
            Text = "ManagerView";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label TitleLabel;
        private Button exitButton;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label movieShowtimes_Label;
    }
}