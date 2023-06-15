namespace SteganografijaWinForms
{
    partial class Steganografija
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Steganografija));
            this.skrijButton = new System.Windows.Forms.Button();
            this.naloziSlikoButton = new System.Windows.Forms.Button();
            this.shraniSlikoButton = new System.Windows.Forms.Button();
            this.podatkiText = new System.Windows.Forms.TextBox();
            this.pridobiButton = new System.Windows.Forms.Button();
            this.slikaBox = new System.Windows.Forms.PictureBox();
            this.gesloCheckBox = new System.Windows.Forms.CheckBox();
            this.gesloText = new System.Windows.Forms.TextBox();
            this.besedilo = new System.Windows.Forms.Label();
            this.enkripcijaBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.slikaBox)).BeginInit();
            this.enkripcijaBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // skrijButton
            // 
            this.skrijButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skrijButton.Location = new System.Drawing.Point(12, 426);
            this.skrijButton.Name = "skrijButton";
            this.skrijButton.Size = new System.Drawing.Size(180, 40);
            this.skrijButton.Text = "Skrij besedilo";
            this.skrijButton.UseVisualStyleBackColor = true;
            this.skrijButton.Click += new System.EventHandler(this.SkrijBesediloClick);
            // 
            // naloziSlikoButton
            // 
            this.naloziSlikoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naloziSlikoButton.Location = new System.Drawing.Point(410, 426);
            this.naloziSlikoButton.Name = "naloziSlikoButton";
            this.naloziSlikoButton.Size = new System.Drawing.Size(180, 40);
            this.naloziSlikoButton.Text = "Naloži sliko";
            this.naloziSlikoButton.UseVisualStyleBackColor = true;
            this.naloziSlikoButton.Click += new System.EventHandler(this.NaloziSlikoClick);
            // 
            // shraniSlikoButton
            // 
            this.shraniSlikoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shraniSlikoButton.Location = new System.Drawing.Point(596, 426);
            this.shraniSlikoButton.Name = "shraniSlikoButton";
            this.shraniSlikoButton.Size = new System.Drawing.Size(180, 40);
            this.shraniSlikoButton.Text = "Shrani sliko";
            this.shraniSlikoButton.UseVisualStyleBackColor = true;
            this.shraniSlikoButton.Click += new System.EventHandler(this.ShraniSlikoClick);
            // 
            // podatkiText
            // 
            this.podatkiText.Font = new System.Drawing.Font("Tahoma", 12F);
            this.podatkiText.Location = new System.Drawing.Point(399, 27);
            this.podatkiText.Multiline = true;
            this.podatkiText.Name = "podatkiText";
            this.podatkiText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.podatkiText.Size = new System.Drawing.Size(374, 281);
            // 
            // pridobiButton
            // 
            this.pridobiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pridobiButton.Location = new System.Drawing.Point(198, 426);
            this.pridobiButton.Name = "pridobiButton";
            this.pridobiButton.Size = new System.Drawing.Size(180, 40);
            this.pridobiButton.Text = "Pridobi podatke";
            this.pridobiButton.UseVisualStyleBackColor = true;
            this.pridobiButton.Click += new System.EventHandler(this.PridobiPodatkeClick);
            // 
            // slikaBox
            // 
            this.slikaBox.Image = ((System.Drawing.Image)(resources.GetObject("slika")));
            this.slikaBox.Location = new System.Drawing.Point(12, 27);
            this.slikaBox.Name = "slikaBox";
            this.slikaBox.Size = new System.Drawing.Size(374, 281);
            this.slikaBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.slikaBox.TabStop = false;
            // 
            // gesloCheckBox
            // 
            this.gesloCheckBox.AutoSize = true;
            this.gesloCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gesloCheckBox.Location = new System.Drawing.Point(19, 29);
            this.gesloCheckBox.Name = "gesloCheckBox";
            this.gesloCheckBox.Size = new System.Drawing.Size(149, 24);
            this.gesloCheckBox.Text = "Uporabite geslo?";
            this.gesloCheckBox.UseVisualStyleBackColor = true;
            // 
            // gesloText
            // 
            this.gesloText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gesloText.Location = new System.Drawing.Point(356, 30);
            this.gesloText.Name = "gesloText";
            this.gesloText.PasswordChar = '*';
            this.gesloText.Size = new System.Drawing.Size(352, 26);
            // 
            // besedilo
            // 
            this.besedilo.AutoSize = true;
            this.besedilo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.besedilo.Location = new System.Drawing.Point(283, 33);
            this.besedilo.Name = "besedilo";
            this.besedilo.Size = new System.Drawing.Size(55, 20);
            this.besedilo.Text = "Geslo:";
            // 
            // enkripcijaBox
            // 
            this.enkripcijaBox.Controls.Add(this.besedilo);
            this.enkripcijaBox.Controls.Add(this.gesloText);
            this.enkripcijaBox.Controls.Add(this.gesloCheckBox);
            this.enkripcijaBox.Location = new System.Drawing.Point(12, 314);
            this.enkripcijaBox.Name = "enkripcijaBox";
            this.enkripcijaBox.Size = new System.Drawing.Size(761, 85);
            this.enkripcijaBox.TabStop = false;
            this.enkripcijaBox.Text = "Enkripcija";
            // 
            // Steganografija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 490);
            this.Controls.Add(this.enkripcijaBox);
            this.Controls.Add(this.slikaBox);
            this.Controls.Add(this.pridobiButton);
            this.Controls.Add(this.naloziSlikoButton);
            this.Controls.Add(this.shraniSlikoButton);
            this.Controls.Add(this.podatkiText);
            this.Controls.Add(this.skrijButton);
            this.MaximizeBox = false;
            this.Name = "Steganografija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steganografija";
            ((System.ComponentModel.ISupportInitialize)(this.slikaBox)).EndInit();
            this.enkripcijaBox.ResumeLayout(false);
            this.enkripcijaBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button skrijButton;
        private System.Windows.Forms.TextBox podatkiText;
        private System.Windows.Forms.Button pridobiButton;
        private System.Windows.Forms.Button naloziSlikoButton;
        private System.Windows.Forms.Button shraniSlikoButton;
        private System.Windows.Forms.PictureBox slikaBox;
        private System.Windows.Forms.CheckBox gesloCheckBox;
        private System.Windows.Forms.TextBox gesloText;
        private System.Windows.Forms.Label besedilo;
        private System.Windows.Forms.GroupBox enkripcijaBox;
    }
}

