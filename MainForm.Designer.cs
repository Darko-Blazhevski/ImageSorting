namespace ImageSorting
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            copyLabel = new Label();
            pasteLabel = new Label();
            junkLabel = new Label();
            copyTextBox = new TextBox();
            pasteTextBox = new TextBox();
            junkTextBox = new TextBox();
            copyButton = new Button();
            pasteButton = new Button();
            junkButton = new Button();
            audioCheckBox = new CheckBox();
            imageCheckBox = new CheckBox();
            videoCheckBox = new CheckBox();
            runButton = new Button();
            progressBar = new ProgressBar();
            progressLabel = new Label();
            SuspendLayout();
            // 
            // copyLabel
            // 
            copyLabel.AutoSize = true;
            copyLabel.Location = new Point(64, 40);
            copyLabel.Name = "copyLabel";
            copyLabel.Size = new Size(67, 15);
            copyLabel.TabIndex = 0;
            copyLabel.Text = "Copy from:";
            // 
            // pasteLabel
            // 
            pasteLabel.AutoSize = true;
            pasteLabel.Location = new Point(64, 162);
            pasteLabel.Name = "pasteLabel";
            pasteLabel.Size = new Size(51, 15);
            pasteLabel.TabIndex = 1;
            pasteLabel.Text = "Paste in:";
            // 
            // junkLabel
            // 
            junkLabel.AutoSize = true;
            junkLabel.Location = new Point(64, 295);
            junkLabel.Name = "junkLabel";
            junkLabel.Size = new Size(67, 15);
            junkLabel.TabIndex = 2;
            junkLabel.Text = "Put junk in:";
            // 
            // copyTextBox
            // 
            copyTextBox.Location = new Point(41, 68);
            copyTextBox.Name = "copyTextBox";
            copyTextBox.Size = new Size(262, 23);
            copyTextBox.TabIndex = 3;
            // 
            // pasteTextBox
            // 
            pasteTextBox.Location = new Point(41, 191);
            pasteTextBox.Name = "pasteTextBox";
            pasteTextBox.Size = new Size(262, 23);
            pasteTextBox.TabIndex = 4;
            // 
            // junkTextBox
            // 
            junkTextBox.Location = new Point(41, 323);
            junkTextBox.Name = "junkTextBox";
            junkTextBox.Size = new Size(262, 23);
            junkTextBox.TabIndex = 5;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(228, 107);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(75, 23);
            copyButton.TabIndex = 6;
            copyButton.Text = "Open";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // pasteButton
            // 
            pasteButton.Location = new Point(228, 235);
            pasteButton.Name = "pasteButton";
            pasteButton.Size = new Size(75, 23);
            pasteButton.TabIndex = 9;
            pasteButton.Text = "Open";
            pasteButton.UseVisualStyleBackColor = true;
            pasteButton.Click += pasteButton_Click;
            // 
            // junkButton
            // 
            junkButton.Location = new Point(228, 368);
            junkButton.Name = "junkButton";
            junkButton.Size = new Size(75, 23);
            junkButton.TabIndex = 10;
            junkButton.Text = "Open";
            junkButton.UseVisualStyleBackColor = true;
            junkButton.Click += junkButton_Click;
            // 
            // audioCheckBox
            // 
            audioCheckBox.AutoSize = true;
            audioCheckBox.Location = new Point(388, 169);
            audioCheckBox.Name = "audioCheckBox";
            audioCheckBox.Size = new Size(58, 19);
            audioCheckBox.TabIndex = 11;
            audioCheckBox.Text = "Audio";
            audioCheckBox.UseVisualStyleBackColor = true;
            audioCheckBox.CheckedChanged += audioCheckBox_CheckedChanged;
            // 
            // imageCheckBox
            // 
            imageCheckBox.AutoSize = true;
            imageCheckBox.Location = new Point(388, 144);
            imageCheckBox.Name = "imageCheckBox";
            imageCheckBox.Size = new Size(64, 19);
            imageCheckBox.TabIndex = 12;
            imageCheckBox.Text = "Images";
            imageCheckBox.UseVisualStyleBackColor = true;
            imageCheckBox.CheckedChanged += imageCheckBox_CheckedChanged;
            // 
            // videoCheckBox
            // 
            videoCheckBox.AutoSize = true;
            videoCheckBox.Location = new Point(390, 194);
            videoCheckBox.Name = "videoCheckBox";
            videoCheckBox.Size = new Size(56, 19);
            videoCheckBox.TabIndex = 13;
            videoCheckBox.Text = "Video";
            videoCheckBox.UseVisualStyleBackColor = true;
            videoCheckBox.CheckedChanged += videoCheckBox_CheckedChanged;
            // 
            // runButton
            // 
            runButton.Location = new Point(585, 158);
            runButton.Name = "runButton";
            runButton.Size = new Size(75, 23);
            runButton.TabIndex = 14;
            runButton.Text = "Run!";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(390, 257);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(276, 23);
            progressBar.TabIndex = 15;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(398, 232);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(0, 15);
            progressLabel.TabIndex = 16;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 417);
            Controls.Add(progressLabel);
            Controls.Add(progressBar);
            Controls.Add(runButton);
            Controls.Add(videoCheckBox);
            Controls.Add(imageCheckBox);
            Controls.Add(audioCheckBox);
            Controls.Add(junkButton);
            Controls.Add(pasteButton);
            Controls.Add(copyButton);
            Controls.Add(junkTextBox);
            Controls.Add(pasteTextBox);
            Controls.Add(copyTextBox);
            Controls.Add(junkLabel);
            Controls.Add(pasteLabel);
            Controls.Add(copyLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Image Sorting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label copyLabel;
        private Label pasteLabel;
        private Label junkLabel;
        private TextBox copyTextBox;
        private TextBox pasteTextBox;
        private TextBox junkTextBox;
        private Button copyButton;
        private Button pasteButton;
        private Button junkButton;
        private CheckBox audioCheckBox;
        private CheckBox imageCheckBox;
        private CheckBox videoCheckBox;
        private Button runButton;
        private ProgressBar progressBar;
        private Label progressLabel;
    }
}