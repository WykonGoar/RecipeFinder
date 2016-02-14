namespace RecipeFinderDatabase
{
    partial class NewRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRecipe));
            this.lMinutes = new System.Windows.Forms.Label();
            this.cbbCourse = new System.Windows.Forms.ComboBox();
            this.cbHide = new System.Windows.Forms.CheckBox();
            this.cbGlutenFree = new System.Windows.Forms.CheckBox();
            this.cbLacoseFree = new System.Windows.Forms.CheckBox();
            this.cbFavorite = new System.Windows.Forms.CheckBox();
            this.nudPersons = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPreperationTime = new System.Windows.Forms.NumericUpDown();
            this.nudPage = new System.Windows.Forms.NumericUpDown();
            this.lHide = new System.Windows.Forms.Label();
            this.lGlutenFree = new System.Windows.Forms.Label();
            this.lLactoseFree = new System.Windows.Forms.Label();
            this.lFavorite = new System.Windows.Forms.Label();
            this.lPersons = new System.Windows.Forms.Label();
            this.lMazPreperationTime = new System.Windows.Forms.Label();
            this.lCourse = new System.Windows.Forms.Label();
            this.tbKitchen = new System.Windows.Forms.TextBox();
            this.lKitchen = new System.Windows.Forms.Label();
            this.lPage = new System.Windows.Forms.Label();
            this.tbBook = new System.Windows.Forms.TextBox();
            this.lBook = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.bAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPreperationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage)).BeginInit();
            this.SuspendLayout();
            // 
            // lMinutes
            // 
            this.lMinutes.AutoSize = true;
            this.lMinutes.Location = new System.Drawing.Point(163, 140);
            this.lMinutes.Name = "lMinutes";
            this.lMinutes.Size = new System.Drawing.Size(44, 13);
            this.lMinutes.TabIndex = 70;
            this.lMinutes.Text = "minuten";
            // 
            // cbbCourse
            // 
            this.cbbCourse.FormattingEnabled = true;
            this.cbbCourse.Items.AddRange(new object[] {
            "Voorgerecht",
            "Hoofdgerecht",
            "Nagerecht",
            "Bijgerecht"});
            this.cbbCourse.Location = new System.Drawing.Point(87, 112);
            this.cbbCourse.Name = "cbbCourse";
            this.cbbCourse.Size = new System.Drawing.Size(149, 21);
            this.cbbCourse.TabIndex = 69;
            this.cbbCourse.Text = "Hoofdgerecht";
            // 
            // cbHide
            // 
            this.cbHide.AutoSize = true;
            this.cbHide.Location = new System.Drawing.Point(87, 275);
            this.cbHide.Name = "cbHide";
            this.cbHide.Size = new System.Drawing.Size(15, 14);
            this.cbHide.TabIndex = 68;
            this.cbHide.UseVisualStyleBackColor = true;
            // 
            // cbGlutenFree
            // 
            this.cbGlutenFree.AutoSize = true;
            this.cbGlutenFree.Location = new System.Drawing.Point(87, 251);
            this.cbGlutenFree.Name = "cbGlutenFree";
            this.cbGlutenFree.Size = new System.Drawing.Size(15, 14);
            this.cbGlutenFree.TabIndex = 67;
            this.cbGlutenFree.UseVisualStyleBackColor = true;
            // 
            // cbLacoseFree
            // 
            this.cbLacoseFree.AutoSize = true;
            this.cbLacoseFree.Location = new System.Drawing.Point(87, 225);
            this.cbLacoseFree.Name = "cbLacoseFree";
            this.cbLacoseFree.Size = new System.Drawing.Size(15, 14);
            this.cbLacoseFree.TabIndex = 66;
            this.cbLacoseFree.UseVisualStyleBackColor = true;
            // 
            // cbFavorite
            // 
            this.cbFavorite.AutoSize = true;
            this.cbFavorite.Location = new System.Drawing.Point(87, 200);
            this.cbFavorite.Name = "cbFavorite";
            this.cbFavorite.Size = new System.Drawing.Size(15, 14);
            this.cbFavorite.TabIndex = 65;
            this.cbFavorite.UseVisualStyleBackColor = true;
            // 
            // nudPersons
            // 
            this.nudPersons.Location = new System.Drawing.Point(87, 170);
            this.nudPersons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPersons.Name = "nudPersons";
            this.nudPersons.Size = new System.Drawing.Size(69, 20);
            this.nudPersons.TabIndex = 64;
            this.nudPersons.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMaxPreperationTime
            // 
            this.nudMaxPreperationTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxPreperationTime.Location = new System.Drawing.Point(87, 137);
            this.nudMaxPreperationTime.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.nudMaxPreperationTime.Name = "nudMaxPreperationTime";
            this.nudMaxPreperationTime.Size = new System.Drawing.Size(69, 20);
            this.nudMaxPreperationTime.TabIndex = 63;
            this.nudMaxPreperationTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudPage
            // 
            this.nudPage.Location = new System.Drawing.Point(87, 59);
            this.nudPage.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPage.Name = "nudPage";
            this.nudPage.Size = new System.Drawing.Size(69, 20);
            this.nudPage.TabIndex = 62;
            // 
            // lHide
            // 
            this.lHide.AutoSize = true;
            this.lHide.Location = new System.Drawing.Point(18, 275);
            this.lHide.Name = "lHide";
            this.lHide.Size = new System.Drawing.Size(59, 13);
            this.lHide.TabIndex = 61;
            this.lHide.Text = "Verbergen:";
            // 
            // lGlutenFree
            // 
            this.lGlutenFree.AutoSize = true;
            this.lGlutenFree.Location = new System.Drawing.Point(20, 251);
            this.lGlutenFree.Name = "lGlutenFree";
            this.lGlutenFree.Size = new System.Drawing.Size(57, 13);
            this.lGlutenFree.TabIndex = 60;
            this.lGlutenFree.Text = "Gluten vrij:";
            // 
            // lLactoseFree
            // 
            this.lLactoseFree.AutoSize = true;
            this.lLactoseFree.Location = new System.Drawing.Point(13, 225);
            this.lLactoseFree.Name = "lLactoseFree";
            this.lLactoseFree.Size = new System.Drawing.Size(64, 13);
            this.lLactoseFree.TabIndex = 59;
            this.lLactoseFree.Text = "Lactose vrij:";
            // 
            // lFavorite
            // 
            this.lFavorite.AutoSize = true;
            this.lFavorite.Location = new System.Drawing.Point(29, 200);
            this.lFavorite.Name = "lFavorite";
            this.lFavorite.Size = new System.Drawing.Size(48, 13);
            this.lFavorite.TabIndex = 58;
            this.lFavorite.Text = "Favoriet:";
            // 
            // lPersons
            // 
            this.lPersons.AutoSize = true;
            this.lPersons.Location = new System.Drawing.Point(22, 172);
            this.lPersons.Name = "lPersons";
            this.lPersons.Size = new System.Drawing.Size(55, 13);
            this.lPersons.TabIndex = 57;
            this.lPersons.Text = "Personen:";
            // 
            // lMazPreperationTime
            // 
            this.lMazPreperationTime.AutoSize = true;
            this.lMazPreperationTime.Location = new System.Drawing.Point(6, 134);
            this.lMazPreperationTime.Name = "lMazPreperationTime";
            this.lMazPreperationTime.Size = new System.Drawing.Size(71, 26);
            this.lMazPreperationTime.TabIndex = 56;
            this.lMazPreperationTime.Text = "Maximale\r\nbereidingstijd:";
            // 
            // lCourse
            // 
            this.lCourse.AutoSize = true;
            this.lCourse.Location = new System.Drawing.Point(29, 114);
            this.lCourse.Name = "lCourse";
            this.lCourse.Size = new System.Drawing.Size(48, 13);
            this.lCourse.TabIndex = 55;
            this.lCourse.Text = "Gerecht:";
            // 
            // tbKitchen
            // 
            this.tbKitchen.Location = new System.Drawing.Point(87, 85);
            this.tbKitchen.Name = "tbKitchen";
            this.tbKitchen.Size = new System.Drawing.Size(149, 20);
            this.tbKitchen.TabIndex = 54;
            // 
            // lKitchen
            // 
            this.lKitchen.AutoSize = true;
            this.lKitchen.Location = new System.Drawing.Point(30, 88);
            this.lKitchen.Name = "lKitchen";
            this.lKitchen.Size = new System.Drawing.Size(47, 13);
            this.lKitchen.TabIndex = 53;
            this.lKitchen.Text = "Keuken:";
            // 
            // lPage
            // 
            this.lPage.AutoSize = true;
            this.lPage.Location = new System.Drawing.Point(37, 61);
            this.lPage.Name = "lPage";
            this.lPage.Size = new System.Drawing.Size(40, 13);
            this.lPage.TabIndex = 52;
            this.lPage.Text = "Pagina";
            // 
            // tbBook
            // 
            this.tbBook.Location = new System.Drawing.Point(87, 33);
            this.tbBook.Name = "tbBook";
            this.tbBook.Size = new System.Drawing.Size(271, 20);
            this.tbBook.TabIndex = 51;
            // 
            // lBook
            // 
            this.lBook.AutoSize = true;
            this.lBook.Location = new System.Drawing.Point(42, 36);
            this.lBook.Name = "lBook";
            this.lBook.Size = new System.Drawing.Size(35, 13);
            this.lBook.TabIndex = 50;
            this.lBook.Text = "Boek:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(87, 7);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(271, 20);
            this.tbTitle.TabIndex = 49;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(47, 10);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(30, 13);
            this.lTitle.TabIndex = 48;
            this.lTitle.Text = "Titel:";
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(283, 266);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 71;
            this.bAdd.Text = "Toevoegen";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // NewRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 298);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lMinutes);
            this.Controls.Add(this.cbbCourse);
            this.Controls.Add(this.cbHide);
            this.Controls.Add(this.cbGlutenFree);
            this.Controls.Add(this.cbLacoseFree);
            this.Controls.Add(this.cbFavorite);
            this.Controls.Add(this.nudPersons);
            this.Controls.Add(this.nudMaxPreperationTime);
            this.Controls.Add(this.nudPage);
            this.Controls.Add(this.lHide);
            this.Controls.Add(this.lGlutenFree);
            this.Controls.Add(this.lLactoseFree);
            this.Controls.Add(this.lFavorite);
            this.Controls.Add(this.lPersons);
            this.Controls.Add(this.lMazPreperationTime);
            this.Controls.Add(this.lCourse);
            this.Controls.Add(this.tbKitchen);
            this.Controls.Add(this.lKitchen);
            this.Controls.Add(this.lPage);
            this.Controls.Add(this.tbBook);
            this.Controls.Add(this.lBook);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(384, 337);
            this.MinimumSize = new System.Drawing.Size(384, 337);
            this.Name = "NewRecipe";
            this.Text = "Nieuw recept";
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPreperationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lMinutes;
        private System.Windows.Forms.ComboBox cbbCourse;
        private System.Windows.Forms.CheckBox cbHide;
        private System.Windows.Forms.CheckBox cbGlutenFree;
        private System.Windows.Forms.CheckBox cbLacoseFree;
        private System.Windows.Forms.CheckBox cbFavorite;
        private System.Windows.Forms.NumericUpDown nudPersons;
        private System.Windows.Forms.NumericUpDown nudMaxPreperationTime;
        private System.Windows.Forms.NumericUpDown nudPage;
        private System.Windows.Forms.Label lHide;
        private System.Windows.Forms.Label lGlutenFree;
        private System.Windows.Forms.Label lLactoseFree;
        private System.Windows.Forms.Label lFavorite;
        private System.Windows.Forms.Label lPersons;
        private System.Windows.Forms.Label lMazPreperationTime;
        private System.Windows.Forms.Label lCourse;
        private System.Windows.Forms.TextBox tbKitchen;
        private System.Windows.Forms.Label lKitchen;
        private System.Windows.Forms.Label lPage;
        private System.Windows.Forms.TextBox tbBook;
        private System.Windows.Forms.Label lBook;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Button bAdd;
    }
}