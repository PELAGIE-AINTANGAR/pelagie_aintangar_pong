namespace Pong2
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AccessibleName = "strat";
            button1.BackColor = Color.WhiteSmoke;
            button1.Location = new Point(94, 282);
            button1.Name = "button1";
            button1.Size = new Size(141, 54);
            button1.TabIndex = 0;
            button1.Text = "START";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.AccessibleName = "quiter";
            button2.BackColor = Color.WhiteSmoke;
            button2.Location = new Point(418, 282);
            button2.Name = "button2";
            button2.Size = new Size(141, 54);
            button2.TabIndex = 1;
            button2.Text = "QUITTER";
            button2.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.AccessibleName = "comboBox1";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(38, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(231, 28);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Niveau";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.AccessibleName = "comboBox2";
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(470, 38);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(170, 28);
            comboBox2.TabIndex = 3;
            comboBox2.Text = "Jouer avec l'IA?";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(682, 393);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        public ComboBox comboBox1;
        public ComboBox comboBox2;
    }
}
