namespace _1_Concepts_UI_ExceptionHandling
{
    partial class Dungeon_Crawler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dungeon_Crawler));
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.Narator = new System.Windows.Forms.TextBox();
            this.UserActions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(1580, 1028);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(282, 103);
            this.SubmitBtn.TabIndex = 0;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.Image = ((System.Drawing.Image)(resources.GetObject("ImageBox.Image")));
            this.ImageBox.Location = new System.Drawing.Point(12, 12);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(2259, 544);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBox.TabIndex = 1;
            this.ImageBox.TabStop = false;
            // 
            // Narator
            // 
            this.Narator.Location = new System.Drawing.Point(12, 562);
            this.Narator.Multiline = true;
            this.Narator.Name = "Narator";
            this.Narator.ReadOnly = true;
            this.Narator.Size = new System.Drawing.Size(2259, 420);
            this.Narator.TabIndex = 2;
            this.Narator.Text = "You wake up in a dark dungeon, there is a torch on the wall and a door. What do y" +
    "ou do?";
            // 
            // UserActions
            // 
            this.UserActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserActions.FormattingEnabled = true;
            this.UserActions.Items.AddRange(new object[] {
            "Go out the door",
            "Grab the torch and go out the door",
            "Stay where you are and wait",
            "Exit"});
            this.UserActions.Location = new System.Drawing.Point(244, 1046);
            this.UserActions.Name = "UserActions";
            this.UserActions.Size = new System.Drawing.Size(302, 49);
            this.UserActions.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 1049);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Actions:";
            // 
            // Dungeon_Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2289, 1196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserActions);
            this.Controls.Add(this.Narator);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.SubmitBtn);
            this.Name = "Dungeon_Crawler";
            this.Text = "Dungeon Crawler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SubmitBtn;
        private PictureBox ImageBox;
        private TextBox Narator;
        private ComboBox UserActions;
        private Label label2;
    }
}