namespace hexadecimal
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
            generatehash = new Button();
            key = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dechiffre = new Button();
            chiffrer = new Button();
            textToChiffr = new RichTextBox();
            hashbox = new RichTextBox();
            SuspendLayout();
            // 
            // generatehash
            // 
            generatehash.Location = new Point(294, 24);
            generatehash.Name = "generatehash";
            generatehash.Size = new Size(117, 51);
            generatehash.TabIndex = 0;
            generatehash.Text = "Générer hash";
            generatehash.UseVisualStyleBackColor = true;
            generatehash.Click += generatehash_Click;
            // 
            // key
            // 
            key.Location = new Point(145, 39);
            key.Name = "key";
            key.Size = new Size(100, 23);
            key.TabIndex = 1;
            key.TextChanged += key_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 42);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 2;
            label1.Text = "Clé de chiffrement :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 110);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 4;
            label2.Text = "Hash généré: ";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 205);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 5;
            label3.Text = "Texte Chiffré / Déchiffré: ";
            // 
            // dechiffre
            // 
            dechiffre.Location = new Point(319, 516);
            dechiffre.Name = "dechiffre";
            dechiffre.Size = new Size(102, 39);
            dechiffre.TabIndex = 6;
            dechiffre.Text = "Déchiffrer";
            dechiffre.UseVisualStyleBackColor = true;
            dechiffre.Click += dechiffre_Click;
            // 
            // chiffrer
            // 
            chiffrer.Location = new Point(56, 516);
            chiffrer.Name = "chiffrer";
            chiffrer.Size = new Size(93, 39);
            chiffrer.TabIndex = 7;
            chiffrer.Text = "Chiffrer";
            chiffrer.UseVisualStyleBackColor = true;
            chiffrer.Click += chiffrer_Click;
            // 
            // textToChiffr
            // 
            textToChiffr.Location = new Point(28, 258);
            textToChiffr.Name = "textToChiffr";
            textToChiffr.Size = new Size(398, 237);
            textToChiffr.TabIndex = 8;
            textToChiffr.Text = "";
            textToChiffr.TextChanged += textToChiffr_TextChanged;
            // 
            // hashbox
            // 
            hashbox.Location = new Point(128, 107);
            hashbox.Name = "hashbox";
            hashbox.Size = new Size(283, 80);
            hashbox.TabIndex = 9;
            hashbox.Text = "";
            hashbox.TextChanged += hashbox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 611);
            Controls.Add(hashbox);
            Controls.Add(textToChiffr);
            Controls.Add(chiffrer);
            Controls.Add(dechiffre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(key);
            Controls.Add(generatehash);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generatehash;
        private TextBox key;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button dechiffre;
        private Button chiffrer;
        private RichTextBox textToChiffr;
        private RichTextBox hashbox;
    }
}
