namespace RecipeFinderDatabase
{
    partial class NewIngredient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewIngredient));
            this.bAdd = new System.Windows.Forms.Button();
            this.tbMeasure = new System.Windows.Forms.TextBox();
            this.lMeasure = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lAmount = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(160, 90);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 54;
            this.bAdd.Text = "Toevoegen";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tbMeasure
            // 
            this.tbMeasure.Location = new System.Drawing.Point(86, 64);
            this.tbMeasure.Name = "tbMeasure";
            this.tbMeasure.Size = new System.Drawing.Size(149, 20);
            this.tbMeasure.TabIndex = 53;
            // 
            // lMeasure
            // 
            this.lMeasure.AutoSize = true;
            this.lMeasure.Location = new System.Drawing.Point(27, 67);
            this.lMeasure.Name = "lMeasure";
            this.lMeasure.Size = new System.Drawing.Size(51, 13);
            this.lMeasure.TabIndex = 52;
            this.lMeasure.Text = "Maatstaf:";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(86, 38);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(149, 20);
            this.tbAmount.TabIndex = 51;
            // 
            // lAmount
            // 
            this.lAmount.AutoSize = true;
            this.lAmount.Location = new System.Drawing.Point(8, 41);
            this.lAmount.Name = "lAmount";
            this.lAmount.Size = new System.Drawing.Size(70, 13);
            this.lAmount.TabIndex = 50;
            this.lAmount.Text = "Hoeveelheid:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(86, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(149, 20);
            this.tbName.TabIndex = 49;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(40, 15);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 13);
            this.lName.TabIndex = 48;
            this.lName.Text = "Naam:";
            // 
            // NewIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 122);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.tbMeasure);
            this.Controls.Add(this.lMeasure);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.lAmount);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 161);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 161);
            this.Name = "NewIngredient";
            this.Text = "Nieuw ingredient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tbMeasure;
        private System.Windows.Forms.Label lMeasure;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lAmount;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
    }
}