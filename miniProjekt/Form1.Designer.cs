namespace miniProjekt
{
    partial class Form1
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
            Startbutton = new Button();
            progressBar = new ProgressBar();
            resultTextBox = new TextBox();
            statusLabel = new Label();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // Startbutton
            // 
            Startbutton.Location = new Point(30, 254);
            Startbutton.Name = "Startbutton";
            Startbutton.Size = new Size(94, 29);
            Startbutton.TabIndex = 0;
            Startbutton.Text = "Start";
            Startbutton.UseVisualStyleBackColor = true;
            Startbutton.Click += Startbutton_ClickAsync;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(30, 199);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(125, 29);
            progressBar.TabIndex = 1;
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(224, 243);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(125, 27);
            resultTextBox.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(209, 289);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "label1";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(61, 314);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelButton);
            Controls.Add(statusLabel);
            Controls.Add(resultTextBox);
            Controls.Add(progressBar);
            Controls.Add(Startbutton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Startbutton;
        private ProgressBar progressBar;
        private TextBox resultTextBox;
        private Label statusLabel;
        private Button cancelButton;
    }
}