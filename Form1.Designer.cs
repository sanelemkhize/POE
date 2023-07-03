using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace RecipeApplication
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCreateRecipe;
        private System.Windows.Forms.Button btnSearchRecipe;
        private System.Windows.Forms.TextBox txtSearchRecipe;
        private System.Windows.Forms.Button btnDisplayRecipes;


        protected void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
        }

        private void InitializeComponent()
        {
            this.btnCreateRecipe = new System.Windows.Forms.Button();
            this.btnSearchRecipe = new System.Windows.Forms.Button();
            this.txtSearchRecipe = new System.Windows.Forms.TextBox();
            this.btnDisplayRecipes = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnCreateRecipe
            this.btnCreateRecipe.Location = new System.Drawing.Point(50, 50);
            this.btnCreateRecipe.Name = "btnCreateRecipe";
            this.btnCreateRecipe.Size = new System.Drawing.Size(150, 50);
            this.btnCreateRecipe.Text = "Create Recipe";
            this.btnCreateRecipe.Click += new System.EventHandler(this.btnCreateRecipe);

            // btnSearchRecipe
            this.btnSearchRecipe.Location = new System.Drawing.Point(50, 150);
            this.btnSearchRecipe.Name = "btnSearchRecipe";
            this.btnSearchRecipe.Size = new System.Drawing.Size(150, 50);
            this.btnSearchRecipe.Text = "Search Recipe";
            this.btnSearchRecipe.Click += new System.EventHandler(this.btnSearchRecipe_Click);

            // txtSearchRecipe
            this.txtSearchRecipe.Location = new System.Drawing.Point(220, 160);
            this.txtSearchRecipe.Name = "txtSearchRecipe";
            this.txtSearchRecipe.Size = new System.Drawing.Size(200, 20);

            // btnDisplayRecipes
            this.btnDisplayRecipes.Location = new System.Drawing.Point(50, 250);
            this.btnDisplayRecipes.Name = "btnDisplayRecipes";
            this.btnDisplayRecipes.Size = new System.Drawing.Size(150, 50);
            this.btnDisplayRecipes.Text = "Display Recipes";
            this.btnDisplayRecipes.Click += new System.EventHandler(this.btnDisplayRecipes_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnCreateRecipe);
            this.Controls.Add(this.btnSearchRecipe);
            this.Controls.Add(this.txtSearchRecipe);
            this.Controls.Add(this.btnDisplayRecipes);
            this.Name = "MainForm";
            this.Text = "Recipe Application";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}

public partial class MainForm : Form
{
    private Dictionary<string, Recipe> recipeDictionary;

    public MainForm()
    {
        InitializeComponent();
        recipeDictionary = new Dictionary<string, Recipe>();
    }

    private void btnCreateRecipe_Click(object sender, EventArgs e)
    {
        RecipeForm recipeForm = new RecipeForm(recipeDictionary);
        recipeForm.ShowDialog();
    }

    private void btnSearchRecipe_Click(object sender, EventArgs e)
    {
        string recipeName = txtSearchRecipe.Text;
        if (recipeDictionary.ContainsKey(recipeName))
        {
            Recipe recipe = recipeDictionary[recipeName];
            MessageBox.Show(recipe.ToString(), "Recipe Details");
        }
        else
        {
            MessageBox.Show("Recipe not found.", "Error");
        }
    }

    private void btnDisplayRecipes_Click(object sender, EventArgs e)
    {
        RecipeListForm recipeListForm = new RecipeListForm(recipeDictionary);
        recipeListForm.ShowDialog();
    }
}

public class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> Steps { get; set; }

    public override string ToString()
    {
        string recipeString = $"Recipe Name: {Name}\n\nIngredients:\n";
        foreach (string ingredient in Ingredients)
        {
            recipeString += $"- {ingredient}\n";
        }
        recipeString += "\nSteps:\n";
        for (int i = 0; i < Steps.Count; i++)
        {
            recipeString += $"{i + 1}. {Steps[i]}\n";
        }
        return recipeString;
    }
}

partial class RecipeForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtRecipeName;
    private System.Windows.Forms.ListBox lstIngredients;
    private System.Windows.Forms.TextBox txtIngredient;
    private System.Windows.Forms.Button btnAddIngredient;
    private System.Windows.Forms.Button btnRemoveIngredient;
    private System.Windows.Forms.ListBox lstSteps;
    private System.Windows.Forms.TextBox txtStep;
    private System.Windows.Forms.Button btnAddStep;
    private System.Windows.Forms.Button btnRemoveStep;
    private System.Windows.Forms.Button btnSaveRecipe;
    private System.Windows.Forms.Button btnCancel;

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
        this.txtRecipeName = new System.Windows.Forms.TextBox();
        this.lstIngredients = new System.Windows.Forms.ListBox();
        this.txtIngredient = new System.Windows.Forms.TextBox();
        this.btnAddIngredient = new System.Windows.Forms.Button();
        this.btnRemoveIngredient = new System.Windows.Forms.Button();
        this.lstSteps = new System.Windows.Forms.ListBox();
        this.txtStep = new System.Windows.Forms.TextBox();
        this.btnAddStep = new System.Windows.Forms.Button();
        this.btnRemoveStep = new System.Windows.Forms.Button();
        this.btnSaveRecipe = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // txtRecipeName
        this.txtRecipeName.Location = new System.Drawing.Point(50, 50);
        this.txtRecipeName.Name = "txtRecipeName";
        this.txtRecipeName.Size = new System.Drawing.Size(200, 20);

        // lstIngredients
        this.lstIngredients.FormattingEnabled = true;
        this.lstIngredients.Location = new System.Drawing.Point(50, 100);
        this.lstIngredients.Name = "lstIngredients";
        this.lstIngredients.Size = new System.Drawing.Size(200, 95);

        // txtIngredient
        this.txtIngredient.Location = new System.Drawing.Point(50, 210);
        this.txtIngredient.Name = "txtIngredient";
        this.txtIngredient.Size = new System.Drawing.Size(200, 20);

        // btnAddIngredient
        this.btnAddIngredient.Location = new System.Drawing.Point(50, 240);
        this.btnAddIngredient.Name = "btnAddIngredient";
        this.btnAddIngredient.Size = new System.Drawing.Size(95, 30);
        this.btnAddIngredient.Text = "Add";
        this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);

        // btnRemoveIngredient
        this.btnRemoveIngredient.Location = new System.Drawing.Point(155, 240);
        this.btnRemoveIngredient.Name = "btnRemoveIngredient";
        this.btnRemoveIngredient.Size = new System.Drawing.Size(95, 30);
        this.btnRemoveIngredient.Text = "Remove";
        this.btnRemoveIngredient.Click += new System.EventHandler(this.btnRemoveIngredient_Click);

        // lstSteps
        this.lstSteps.FormattingEnabled = true;
        this.lstSteps.Location = new System.Drawing.Point(300, 100);
        this.lstSteps.Name = "lstSteps";
        this.lstSteps.Size = new System.Drawing.Size(200, 95);

        // txtStep
        this.txtStep.Location = new System.Drawing.Point(300, 210);
        this.txtStep.Name = "txtStep";
        this.txtStep.Size = new System.Drawing.Size(200, 20);

        // btnAddStep
        this.btnAddStep.Location = new System.Drawing.Point(300, 240);
        this.btnAddStep.Name = "btnAddStep";
        this.btnAddStep.Size = new System.Drawing.Size(95, 30);
        this.btnAddStep.Text = "Add";
        this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);

        // btnRemoveStep
        this.btnRemoveStep.Location = new System.Drawing.Point(405, 240);
        this.btnRemoveStep.Name = "btnRemoveStep";
        this.btnRemoveStep.Size = new System.Drawing.Size(95, 30);
        this.btnRemoveStep.Text = "Remove";
        this.btnRemoveStep.Click += new System.EventHandler(this.btnRemoveStep_Click);

        // btnSaveRecipe
        this.btnSaveRecipe.Location = new System.Drawing.Point(200, 300);
        this.btnSaveRecipe.Name = "btnSaveRecipe";
        this.btnSaveRecipe.Size = new System.Drawing.Size(95, 30);
        this.btnSaveRecipe.Text = "Save";
        this.btnSaveRecipe.Click += new System.EventHandler(this.btnSaveRecipe_Click);

        // btnCancel
        this.btnCancel.Location = new System.Drawing.Point(305, 300);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(95, 30);
        this.btnCancel.Text = "Cancel";
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        // RecipeForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(554, 361);
        this.Controls.Add(this.txtRecipeName);
        this.Controls.Add(this.lstIngredients);
        this.Controls.Add(this.txtIngredient);
        this.Controls.Add(this.btnAddIngredient);
        this.Controls.Add(this.btnRemoveIngredient);
        this.Controls.Add(this.lstSteps);
        this.Controls.Add(this.txtStep);
        this.Controls.Add(this.btnAddStep);
        this.Controls.Add(this.btnRemoveStep);
        this.Controls.Add(this.btnSaveRecipe);
        this.Controls.Add(this.btnCancel);
        this.Name = "RecipeForm";
        this.Text = "Recipe Form";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

public partial class RecipeForm : Form
{
    private Dictionary<string, Recipe> recipeDictionary;

    public RecipeForm(Dictionary<string, Recipe> recipeDict)
    {
        InitializeComponent();
        recipeDictionary = recipeDict;
    }

    private void btnAddIngredient_Click(object sender, EventArgs e)
    {
        string ingredient = txtIngredient.Text;
        if (!string.IsNullOrEmpty(ingredient))
        {
            lstIngredients.Items.Add(ingredient);
            txtIngredient.Text = string.Empty;
        }
    }

    private void btnRemoveIngredient_Click(object sender, EventArgs e)
    {
        if (lstIngredients.SelectedIndex != -1)
        {
            lstIngredients.Items.RemoveAt(lstIngredients.SelectedIndex);
        }
    }

    private void btnAddStep_Click(object sender, EventArgs e)
    {
        string step = txtStep.Text;
        if (!string.IsNullOrEmpty(step))
        {
            lstSteps.Items.Add(step);
            txtStep.Text = string.Empty;
        }
    }

    private void btnRemoveStep_Click(object sender, EventArgs e)
    {
        if (lstSteps.SelectedIndex != -1)
        {
            lstSteps.Items.RemoveAt(lstSteps.SelectedIndex);
        }
    }

    private void btnSaveRecipe_Click(object sender, EventArgs e)
    {
        string recipeName = txtRecipeName.Text;
        if (!string.IsNullOrEmpty(recipeName))
        {
            Recipe newRecipe = new Recipe
            {
                Name = recipeName,
                Ingredients = new List<string>(),
                Steps = new List<string>()
            };

            foreach (string ingredient in lstIngredients.Items)
            {
                newRecipe.Ingredients.Add(ingredient);
            }

            foreach (string step in lstSteps.Items)
            {
                newRecipe.Steps.Add(step);
            }

            recipeDictionary.Add(recipeName, newRecipe);
            MessageBox.Show("Recipe saved successfully.", "Success");
            this.Close();
        }
        else
        {
            MessageBox.Show("Please enter a recipe name.", "Error");
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}

partial class RecipeListForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ListBox lstRecipes;
    private System.Windows.Forms.Button btnClose;

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
        this.lstRecipes = new System.Windows.Forms.ListBox();
        this.btnClose = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // lstRecipes
        this.lstRecipes.FormattingEnabled = true;
        this.lstRecipes.Location = new System.Drawing.Point(50, 50);
        this.lstRecipes.Name = "lstRecipes";
        this.lstRecipes.Size = new System.Drawing.Size(400, 200);

        // btnClose
        this.btnClose.Location = new System.Drawing.Point(200, 275);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(95, 30);
        this.btnClose.Text = "Close";
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

        // RecipeListForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(484, 361);
        this.Controls.Add(this.lstRecipes);
        this.Controls.Add(this.btnClose);
        this.Name = "RecipeListForm";
        this.Text = "Recipe List";
        this.ResumeLayout(false);
    }
}

public partial class RecipeListForm : Form
{
    private Dictionary<string, Recipe> recipeDictionary;

    public RecipeListForm(Dictionary<string, Recipe> recipeDict)
    {
        InitializeComponent();
        recipeDictionary = recipeDict;
        PopulateRecipeList();
    }

    private void PopulateRecipeList()
    {
        lstRecipes.Items.Clear();
        foreach (KeyValuePair<string, Recipe> recipeEntry in recipeDictionary)
        {
            lstRecipes.Items.Add(recipeEntry.Key);
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}