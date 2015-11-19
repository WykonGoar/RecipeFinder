namespace RecipeFinderDatabase
{
    partial class RecipeFinderDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecipeFinderDatabase));
            this.lbRecipes = new System.Windows.Forms.ListBox();
            this.lRecipes = new System.Windows.Forms.Label();
            this.tcEditor = new System.Windows.Forms.TabControl();
            this.tpRecipeEditor = new System.Windows.Forms.TabPage();
            this.bDeleteRecipe = new System.Windows.Forms.Button();
            this.lMinutes = new System.Windows.Forms.Label();
            this.bSaveRecipe = new System.Windows.Forms.Button();
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
            this.tpIngredientEditor = new System.Windows.Forms.TabPage();
            this.bDeleteIngredient = new System.Windows.Forms.Button();
            this.bNewIngredient = new System.Windows.Forms.Button();
            this.bSaveIngredient = new System.Windows.Forms.Button();
            this.tbMeasure = new System.Windows.Forms.TextBox();
            this.lMeasure = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lAmount = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.lIngredients = new System.Windows.Forms.Label();
            this.lbIngredients = new System.Windows.Forms.ListBox();
            this.lRecipeTitle = new System.Windows.Forms.Label();
            this.bNewRecipe = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importeerReceptenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporteerReceptenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcEditor.SuspendLayout();
            this.tpRecipeEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPreperationTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage)).BeginInit();
            this.tpIngredientEditor.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRecipes
            // 
            this.lbRecipes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRecipes.FormattingEnabled = true;
            this.lbRecipes.HorizontalScrollbar = true;
            this.lbRecipes.Location = new System.Drawing.Point(12, 43);
            this.lbRecipes.Name = "lbRecipes";
            this.lbRecipes.Size = new System.Drawing.Size(217, 303);
            this.lbRecipes.TabIndex = 0;
            this.lbRecipes.SelectedIndexChanged += new System.EventHandler(this.lbRecipes_SelectedIndexChanged);
            // 
            // lRecipes
            // 
            this.lRecipes.AutoSize = true;
            this.lRecipes.Location = new System.Drawing.Point(12, 24);
            this.lRecipes.Name = "lRecipes";
            this.lRecipes.Size = new System.Drawing.Size(54, 13);
            this.lRecipes.TabIndex = 1;
            this.lRecipes.Text = "Recepten";
            // 
            // tcEditor
            // 
            this.tcEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcEditor.Controls.Add(this.tpRecipeEditor);
            this.tcEditor.Controls.Add(this.tpIngredientEditor);
            this.tcEditor.Enabled = false;
            this.tcEditor.Location = new System.Drawing.Point(249, 43);
            this.tcEditor.Name = "tcEditor";
            this.tcEditor.SelectedIndex = 0;
            this.tcEditor.Size = new System.Drawing.Size(375, 345);
            this.tcEditor.TabIndex = 2;
            // 
            // tpRecipeEditor
            // 
            this.tpRecipeEditor.Controls.Add(this.bDeleteRecipe);
            this.tpRecipeEditor.Controls.Add(this.lMinutes);
            this.tpRecipeEditor.Controls.Add(this.bSaveRecipe);
            this.tpRecipeEditor.Controls.Add(this.cbbCourse);
            this.tpRecipeEditor.Controls.Add(this.cbHide);
            this.tpRecipeEditor.Controls.Add(this.cbGlutenFree);
            this.tpRecipeEditor.Controls.Add(this.cbLacoseFree);
            this.tpRecipeEditor.Controls.Add(this.cbFavorite);
            this.tpRecipeEditor.Controls.Add(this.nudPersons);
            this.tpRecipeEditor.Controls.Add(this.nudMaxPreperationTime);
            this.tpRecipeEditor.Controls.Add(this.nudPage);
            this.tpRecipeEditor.Controls.Add(this.lHide);
            this.tpRecipeEditor.Controls.Add(this.lGlutenFree);
            this.tpRecipeEditor.Controls.Add(this.lLactoseFree);
            this.tpRecipeEditor.Controls.Add(this.lFavorite);
            this.tpRecipeEditor.Controls.Add(this.lPersons);
            this.tpRecipeEditor.Controls.Add(this.lMazPreperationTime);
            this.tpRecipeEditor.Controls.Add(this.lCourse);
            this.tpRecipeEditor.Controls.Add(this.tbKitchen);
            this.tpRecipeEditor.Controls.Add(this.lKitchen);
            this.tpRecipeEditor.Controls.Add(this.lPage);
            this.tpRecipeEditor.Controls.Add(this.tbBook);
            this.tpRecipeEditor.Controls.Add(this.lBook);
            this.tpRecipeEditor.Controls.Add(this.tbTitle);
            this.tpRecipeEditor.Controls.Add(this.lTitle);
            this.tpRecipeEditor.Location = new System.Drawing.Point(4, 22);
            this.tpRecipeEditor.Name = "tpRecipeEditor";
            this.tpRecipeEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tpRecipeEditor.Size = new System.Drawing.Size(367, 319);
            this.tpRecipeEditor.TabIndex = 0;
            this.tpRecipeEditor.Text = "Recept aanpassen";
            this.tpRecipeEditor.UseVisualStyleBackColor = true;
            // 
            // bDeleteRecipe
            // 
            this.bDeleteRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeleteRecipe.Location = new System.Drawing.Point(152, 289);
            this.bDeleteRecipe.Name = "bDeleteRecipe";
            this.bDeleteRecipe.Size = new System.Drawing.Size(75, 23);
            this.bDeleteRecipe.TabIndex = 48;
            this.bDeleteRecipe.Text = "Verwijder";
            this.bDeleteRecipe.UseVisualStyleBackColor = true;
            this.bDeleteRecipe.Click += new System.EventHandler(this.bDeleteRecipe_Click);
            // 
            // lMinutes
            // 
            this.lMinutes.AutoSize = true;
            this.lMinutes.Location = new System.Drawing.Point(166, 139);
            this.lMinutes.Name = "lMinutes";
            this.lMinutes.Size = new System.Drawing.Size(44, 13);
            this.lMinutes.TabIndex = 47;
            this.lMinutes.Text = "minuten";
            // 
            // bSaveRecipe
            // 
            this.bSaveRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSaveRecipe.Location = new System.Drawing.Point(286, 289);
            this.bSaveRecipe.Name = "bSaveRecipe";
            this.bSaveRecipe.Size = new System.Drawing.Size(75, 23);
            this.bSaveRecipe.TabIndex = 46;
            this.bSaveRecipe.Text = "Opslaan";
            this.bSaveRecipe.UseVisualStyleBackColor = true;
            this.bSaveRecipe.Click += new System.EventHandler(this.bSaveRecipe_Click);
            // 
            // cbbCourse
            // 
            this.cbbCourse.FormattingEnabled = true;
            this.cbbCourse.Items.AddRange(new object[] {
            "Voorgerecht",
            "Hoofdgerecht",
            "Nagerecht",
            "Bijgerecht"});
            this.cbbCourse.Location = new System.Drawing.Point(90, 111);
            this.cbbCourse.Name = "cbbCourse";
            this.cbbCourse.Size = new System.Drawing.Size(149, 21);
            this.cbbCourse.TabIndex = 45;
            // 
            // cbHide
            // 
            this.cbHide.AutoSize = true;
            this.cbHide.Location = new System.Drawing.Point(90, 274);
            this.cbHide.Name = "cbHide";
            this.cbHide.Size = new System.Drawing.Size(15, 14);
            this.cbHide.TabIndex = 44;
            this.cbHide.UseVisualStyleBackColor = true;
            // 
            // cbGlutenFree
            // 
            this.cbGlutenFree.AutoSize = true;
            this.cbGlutenFree.Location = new System.Drawing.Point(90, 250);
            this.cbGlutenFree.Name = "cbGlutenFree";
            this.cbGlutenFree.Size = new System.Drawing.Size(15, 14);
            this.cbGlutenFree.TabIndex = 43;
            this.cbGlutenFree.UseVisualStyleBackColor = true;
            // 
            // cbLacoseFree
            // 
            this.cbLacoseFree.AutoSize = true;
            this.cbLacoseFree.Location = new System.Drawing.Point(90, 224);
            this.cbLacoseFree.Name = "cbLacoseFree";
            this.cbLacoseFree.Size = new System.Drawing.Size(15, 14);
            this.cbLacoseFree.TabIndex = 42;
            this.cbLacoseFree.UseVisualStyleBackColor = true;
            // 
            // cbFavorite
            // 
            this.cbFavorite.AutoSize = true;
            this.cbFavorite.Location = new System.Drawing.Point(90, 199);
            this.cbFavorite.Name = "cbFavorite";
            this.cbFavorite.Size = new System.Drawing.Size(15, 14);
            this.cbFavorite.TabIndex = 41;
            this.cbFavorite.UseVisualStyleBackColor = true;
            // 
            // nudPersons
            // 
            this.nudPersons.Location = new System.Drawing.Point(90, 169);
            this.nudPersons.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPersons.Name = "nudPersons";
            this.nudPersons.Size = new System.Drawing.Size(69, 20);
            this.nudPersons.TabIndex = 40;
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
            this.nudMaxPreperationTime.Location = new System.Drawing.Point(90, 136);
            this.nudMaxPreperationTime.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.nudMaxPreperationTime.Name = "nudMaxPreperationTime";
            this.nudMaxPreperationTime.Size = new System.Drawing.Size(69, 20);
            this.nudMaxPreperationTime.TabIndex = 39;
            this.nudMaxPreperationTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudPage
            // 
            this.nudPage.Location = new System.Drawing.Point(90, 58);
            this.nudPage.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudPage.Name = "nudPage";
            this.nudPage.Size = new System.Drawing.Size(69, 20);
            this.nudPage.TabIndex = 38;
            // 
            // lHide
            // 
            this.lHide.AutoSize = true;
            this.lHide.Location = new System.Drawing.Point(21, 274);
            this.lHide.Name = "lHide";
            this.lHide.Size = new System.Drawing.Size(59, 13);
            this.lHide.TabIndex = 37;
            this.lHide.Text = "Verbergen:";
            // 
            // lGlutenFree
            // 
            this.lGlutenFree.AutoSize = true;
            this.lGlutenFree.Location = new System.Drawing.Point(23, 250);
            this.lGlutenFree.Name = "lGlutenFree";
            this.lGlutenFree.Size = new System.Drawing.Size(57, 13);
            this.lGlutenFree.TabIndex = 36;
            this.lGlutenFree.Text = "Gluten vrij:";
            // 
            // lLactoseFree
            // 
            this.lLactoseFree.AutoSize = true;
            this.lLactoseFree.Location = new System.Drawing.Point(16, 224);
            this.lLactoseFree.Name = "lLactoseFree";
            this.lLactoseFree.Size = new System.Drawing.Size(64, 13);
            this.lLactoseFree.TabIndex = 35;
            this.lLactoseFree.Text = "Lactose vrij:";
            // 
            // lFavorite
            // 
            this.lFavorite.AutoSize = true;
            this.lFavorite.Location = new System.Drawing.Point(32, 199);
            this.lFavorite.Name = "lFavorite";
            this.lFavorite.Size = new System.Drawing.Size(48, 13);
            this.lFavorite.TabIndex = 34;
            this.lFavorite.Text = "Favoriet:";
            // 
            // lPersons
            // 
            this.lPersons.AutoSize = true;
            this.lPersons.Location = new System.Drawing.Point(25, 171);
            this.lPersons.Name = "lPersons";
            this.lPersons.Size = new System.Drawing.Size(55, 13);
            this.lPersons.TabIndex = 33;
            this.lPersons.Text = "Personen:";
            // 
            // lMazPreperationTime
            // 
            this.lMazPreperationTime.AutoSize = true;
            this.lMazPreperationTime.Location = new System.Drawing.Point(9, 133);
            this.lMazPreperationTime.Name = "lMazPreperationTime";
            this.lMazPreperationTime.Size = new System.Drawing.Size(71, 26);
            this.lMazPreperationTime.TabIndex = 32;
            this.lMazPreperationTime.Text = "Maximale\r\nbereidingstijd:";
            // 
            // lCourse
            // 
            this.lCourse.AutoSize = true;
            this.lCourse.Location = new System.Drawing.Point(32, 113);
            this.lCourse.Name = "lCourse";
            this.lCourse.Size = new System.Drawing.Size(48, 13);
            this.lCourse.TabIndex = 30;
            this.lCourse.Text = "Gerecht:";
            // 
            // tbKitchen
            // 
            this.tbKitchen.Location = new System.Drawing.Point(90, 84);
            this.tbKitchen.Name = "tbKitchen";
            this.tbKitchen.Size = new System.Drawing.Size(149, 20);
            this.tbKitchen.TabIndex = 29;
            // 
            // lKitchen
            // 
            this.lKitchen.AutoSize = true;
            this.lKitchen.Location = new System.Drawing.Point(33, 87);
            this.lKitchen.Name = "lKitchen";
            this.lKitchen.Size = new System.Drawing.Size(47, 13);
            this.lKitchen.TabIndex = 28;
            this.lKitchen.Text = "Keuken:";
            // 
            // lPage
            // 
            this.lPage.AutoSize = true;
            this.lPage.Location = new System.Drawing.Point(40, 60);
            this.lPage.Name = "lPage";
            this.lPage.Size = new System.Drawing.Size(40, 13);
            this.lPage.TabIndex = 27;
            this.lPage.Text = "Pagina";
            // 
            // tbBook
            // 
            this.tbBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBook.Location = new System.Drawing.Point(90, 32);
            this.tbBook.Name = "tbBook";
            this.tbBook.Size = new System.Drawing.Size(271, 20);
            this.tbBook.TabIndex = 26;
            // 
            // lBook
            // 
            this.lBook.AutoSize = true;
            this.lBook.Location = new System.Drawing.Point(45, 35);
            this.lBook.Name = "lBook";
            this.lBook.Size = new System.Drawing.Size(35, 13);
            this.lBook.TabIndex = 25;
            this.lBook.Text = "Boek:";
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Location = new System.Drawing.Point(90, 6);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(271, 20);
            this.tbTitle.TabIndex = 24;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(50, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(30, 13);
            this.lTitle.TabIndex = 23;
            this.lTitle.Text = "Titel:";
            // 
            // tpIngredientEditor
            // 
            this.tpIngredientEditor.Controls.Add(this.bDeleteIngredient);
            this.tpIngredientEditor.Controls.Add(this.bNewIngredient);
            this.tpIngredientEditor.Controls.Add(this.bSaveIngredient);
            this.tpIngredientEditor.Controls.Add(this.tbMeasure);
            this.tpIngredientEditor.Controls.Add(this.lMeasure);
            this.tpIngredientEditor.Controls.Add(this.tbAmount);
            this.tpIngredientEditor.Controls.Add(this.lAmount);
            this.tpIngredientEditor.Controls.Add(this.tbName);
            this.tpIngredientEditor.Controls.Add(this.lName);
            this.tpIngredientEditor.Controls.Add(this.lIngredients);
            this.tpIngredientEditor.Controls.Add(this.lbIngredients);
            this.tpIngredientEditor.Location = new System.Drawing.Point(4, 22);
            this.tpIngredientEditor.Name = "tpIngredientEditor";
            this.tpIngredientEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tpIngredientEditor.Size = new System.Drawing.Size(367, 319);
            this.tpIngredientEditor.TabIndex = 1;
            this.tpIngredientEditor.Text = "Ingredienten aanpassen";
            this.tpIngredientEditor.UseVisualStyleBackColor = true;
            // 
            // bDeleteIngredient
            // 
            this.bDeleteIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeleteIngredient.Location = new System.Drawing.Point(285, 272);
            this.bDeleteIngredient.Name = "bDeleteIngredient";
            this.bDeleteIngredient.Size = new System.Drawing.Size(75, 23);
            this.bDeleteIngredient.TabIndex = 49;
            this.bDeleteIngredient.Text = "Verwijder";
            this.bDeleteIngredient.UseVisualStyleBackColor = true;
            this.bDeleteIngredient.Click += new System.EventHandler(this.bDeleteIngredient_Click);
            // 
            // bNewIngredient
            // 
            this.bNewIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bNewIngredient.Location = new System.Drawing.Point(10, 273);
            this.bNewIngredient.Name = "bNewIngredient";
            this.bNewIngredient.Size = new System.Drawing.Size(117, 23);
            this.bNewIngredient.TabIndex = 48;
            this.bNewIngredient.Text = "Nieuw";
            this.bNewIngredient.UseVisualStyleBackColor = true;
            this.bNewIngredient.Click += new System.EventHandler(this.bNewIngredient_Click);
            // 
            // bSaveIngredient
            // 
            this.bSaveIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSaveIngredient.Enabled = false;
            this.bSaveIngredient.Location = new System.Drawing.Point(285, 108);
            this.bSaveIngredient.Name = "bSaveIngredient";
            this.bSaveIngredient.Size = new System.Drawing.Size(75, 23);
            this.bSaveIngredient.TabIndex = 47;
            this.bSaveIngredient.Text = "Opslaan";
            this.bSaveIngredient.UseVisualStyleBackColor = true;
            this.bSaveIngredient.Click += new System.EventHandler(this.bSaveIngredient_Click);
            // 
            // tbMeasure
            // 
            this.tbMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMeasure.Enabled = false;
            this.tbMeasure.Location = new System.Drawing.Point(211, 82);
            this.tbMeasure.Name = "tbMeasure";
            this.tbMeasure.Size = new System.Drawing.Size(149, 20);
            this.tbMeasure.TabIndex = 35;
            // 
            // lMeasure
            // 
            this.lMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lMeasure.AutoSize = true;
            this.lMeasure.Location = new System.Drawing.Point(152, 85);
            this.lMeasure.Name = "lMeasure";
            this.lMeasure.Size = new System.Drawing.Size(51, 13);
            this.lMeasure.TabIndex = 34;
            this.lMeasure.Text = "Maatstaf:";
            // 
            // tbAmount
            // 
            this.tbAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmount.Enabled = false;
            this.tbAmount.Location = new System.Drawing.Point(211, 56);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(149, 20);
            this.tbAmount.TabIndex = 33;
            // 
            // lAmount
            // 
            this.lAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lAmount.AutoSize = true;
            this.lAmount.Location = new System.Drawing.Point(133, 59);
            this.lAmount.Name = "lAmount";
            this.lAmount.Size = new System.Drawing.Size(70, 13);
            this.lAmount.TabIndex = 32;
            this.lAmount.Text = "Hoeveelheid:";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Enabled = false;
            this.tbName.Location = new System.Drawing.Point(211, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(149, 20);
            this.tbName.TabIndex = 31;
            // 
            // lName
            // 
            this.lName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(165, 33);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 13);
            this.lName.TabIndex = 30;
            this.lName.Text = "Naam:";
            // 
            // lIngredients
            // 
            this.lIngredients.AutoSize = true;
            this.lIngredients.Location = new System.Drawing.Point(7, 11);
            this.lIngredients.Name = "lIngredients";
            this.lIngredients.Size = new System.Drawing.Size(66, 13);
            this.lIngredients.TabIndex = 1;
            this.lIngredients.Text = "Ingredienten";
            // 
            // lbIngredients
            // 
            this.lbIngredients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIngredients.FormattingEnabled = true;
            this.lbIngredients.HorizontalScrollbar = true;
            this.lbIngredients.Location = new System.Drawing.Point(7, 30);
            this.lbIngredients.Name = "lbIngredients";
            this.lbIngredients.Size = new System.Drawing.Size(120, 238);
            this.lbIngredients.TabIndex = 0;
            this.lbIngredients.SelectedIndexChanged += new System.EventHandler(this.lbIngredients_SelectedIndexChanged);
            // 
            // lRecipeTitle
            // 
            this.lRecipeTitle.AutoSize = true;
            this.lRecipeTitle.Location = new System.Drawing.Point(249, 23);
            this.lRecipeTitle.Name = "lRecipeTitle";
            this.lRecipeTitle.Size = new System.Drawing.Size(0, 13);
            this.lRecipeTitle.TabIndex = 3;
            // 
            // bNewRecipe
            // 
            this.bNewRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bNewRecipe.Location = new System.Drawing.Point(11, 361);
            this.bNewRecipe.Name = "bNewRecipe";
            this.bNewRecipe.Size = new System.Drawing.Size(218, 23);
            this.bNewRecipe.TabIndex = 49;
            this.bNewRecipe.Text = "Nieuw";
            this.bNewRecipe.UseVisualStyleBackColor = true;
            this.bNewRecipe.Click += new System.EventHandler(this.bNewRecipe_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importeerReceptenToolStripMenuItem,
            this.exporteerReceptenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 50;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // importeerReceptenToolStripMenuItem
            // 
            this.importeerReceptenToolStripMenuItem.Name = "importeerReceptenToolStripMenuItem";
            this.importeerReceptenToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.importeerReceptenToolStripMenuItem.Text = "Importeer recepten";
            this.importeerReceptenToolStripMenuItem.Click += new System.EventHandler(this.importeerReceptenToolStripMenuItem_Click);
            // 
            // exporteerReceptenToolStripMenuItem
            // 
            this.exporteerReceptenToolStripMenuItem.Name = "exporteerReceptenToolStripMenuItem";
            this.exporteerReceptenToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.exporteerReceptenToolStripMenuItem.Text = "Exporteer recepten";
            this.exporteerReceptenToolStripMenuItem.Click += new System.EventHandler(this.exporteerReceptenToolStripMenuItem_Click);
            // 
            // RecipeFinderDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 394);
            this.Controls.Add(this.bNewRecipe);
            this.Controls.Add(this.lRecipeTitle);
            this.Controls.Add(this.tcEditor);
            this.Controls.Add(this.lRecipes);
            this.Controls.Add(this.lbRecipes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RecipeFinderDatabase";
            this.Text = "RecipeFinderDatabase";
            this.tcEditor.ResumeLayout(false);
            this.tpRecipeEditor.ResumeLayout(false);
            this.tpRecipeEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPreperationTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage)).EndInit();
            this.tpIngredientEditor.ResumeLayout(false);
            this.tpIngredientEditor.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRecipes;
        private System.Windows.Forms.Label lRecipes;
        private System.Windows.Forms.TabControl tcEditor;
        private System.Windows.Forms.TabPage tpRecipeEditor;
        private System.Windows.Forms.TabPage tpIngredientEditor;
        private System.Windows.Forms.Label lRecipeTitle;
        private System.Windows.Forms.Button bSaveRecipe;
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
        private System.Windows.Forms.Label lIngredients;
        private System.Windows.Forms.ListBox lbIngredients;
        private System.Windows.Forms.Button bSaveIngredient;
        private System.Windows.Forms.TextBox tbMeasure;
        private System.Windows.Forms.Label lMeasure;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lAmount;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lMinutes;
        private System.Windows.Forms.Button bNewIngredient;
        private System.Windows.Forms.Button bNewRecipe;
        private System.Windows.Forms.Button bDeleteIngredient;
        private System.Windows.Forms.Button bDeleteRecipe;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem importeerReceptenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporteerReceptenToolStripMenuItem;
    }
}

