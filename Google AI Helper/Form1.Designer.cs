namespace Google_AI_Helper
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox operationComboBox;
        private System.Windows.Forms.Button sendButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            operationComboBox = new ComboBox();
            sendButton = new Button();
            responseTextBox = new RichTextBox();
            inputTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // operationComboBox
            // 
            operationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            operationComboBox.FormattingEnabled = true;
            operationComboBox.Location = new Point(572, 619);
            operationComboBox.Name = "operationComboBox";
            operationComboBox.Size = new Size(200, 28);
            operationComboBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(778, 618);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(105, 29);
            sendButton.TabIndex = 2;
            sendButton.Text = "Gönder";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // responseTextBox
            // 
            responseTextBox.Location = new Point(9, 311);
            responseTextBox.Name = "responseTextBox";
            responseTextBox.Size = new Size(874, 300);
            responseTextBox.TabIndex = 3;
            responseTextBox.Text = "";
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(8, 4);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(874, 301);
            inputTextBox.TabIndex = 4;
            inputTextBox.Text = "";
            // 
            // Form1
            // 
            AcceptButton = sendButton;
            ClientSize = new Size(895, 659);
            Controls.Add(inputTextBox);
            Controls.Add(responseTextBox);
            Controls.Add(sendButton);
            Controls.Add(operationComboBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Google AI Helper";
            ResumeLayout(false);
        }

        private RichTextBox responseTextBox;
        private RichTextBox inputTextBox;
    }
}
