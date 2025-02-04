﻿//Wadiha Boat
//ST10303285
//GROUP 2 
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0163?f1url=%3FappId%3Droslyn%26k%3Dk(CS0163)
//https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1503?f1url=%3FappId%3Droslyn%26k%3Dk(CS1503)
//https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
//https://docs.github.com/en/get-started/using-git/pushing-commits-to-a-remote-repository
//https://www.w3schools.com/git/git_commit.asp?remote=github
//https://www.tutorialsteacher.com/csharp/csharp-delegates
//https://www.geeksforgeeks.org/c-sharp-delegates/
//https://www.c-sharpcorner.com/article/a-basic-introduction-of-unit-test-for-beginners/
//https://learn.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest
//https://wpf-tutorial.com/
//https://www.tutorialspoint.com/wpf/index.htm


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RecipeApplication.Model;


namespace RecipeApplicationWPF
{
    
    
    public partial class NewRecipeWindow : Window
    {
        private List<Ingredient> ingredients = new List<Ingredient>(); 
        private List<string> steps = new List<string>(); 

        public Recipe NewRecipe { get; private set; }//

        public NewRecipeWindow()
        {
            InitializeComponent();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text; // Get the name of the ingredient
            if (double.TryParse(IngredientQuantityTextBox.Text, out double quantity)) // Try to parse the quantity
            {
                string unit = IngredientUnitTextBox.Text;
                int calories= int.Parse(CaloriesTextBox.Text);

                string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();// Get the selected food group

                var ingredient = new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories= calories, FoodGroup=foodGroup};
                ingredients.Add(ingredient);
                IngredientsListBox.Items.Add($"{name}: {quantity} {unit} ( {calories}calories ,{foodGroup})");

                // Clear the textboxes
                IngredientNameTextBox.Clear();
                IngredientQuantityTextBox.Clear();
                IngredientUnitTextBox.Clear();
                CaloriesTextBox.Clear();
                FoodGroupComboBox.SelectedIndex = -1;// Clear the selected index
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e) // Add a step
        {
            string step = StepTextBox.Text;
            if (!string.IsNullOrWhiteSpace(step))
            {
                steps.Add(step);
                StepsListBox.Items.Add(step);

                // Clear the textbox
                StepTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid step.");
            }
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e) // Save the recipe
        {
            string title = TitleTextBox.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a recipe title.");
                return;
            }
            
               

            var recipe = new Recipe // Create a new recipe
            {
                Title = title,
                Ingredients = new List<Ingredient>(ingredients),
                Steps = new List<string>(steps)
            };

            
            NewRecipe = recipe;

            MessageBox.Show("Recipe saved successfully!");

            // Clear all fields
            TitleTextBox.Clear();
            IngredientsListBox.Items.Clear();
            StepsListBox.Items.Clear();
            ingredients.Clear();
            steps.Clear();

            // Set the dialog result to true and close the window
            this.DialogResult = true;
            this.Close();
        }
    }

         public class Ingredient
         {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public void Scale(double scalingFactor)
        {
            Quantity *= scalingFactor;
        }

    }

    public class Recipe
    {
        public string Title { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories * (int)ingredient.Quantity);
        }
    }

}
