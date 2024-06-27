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
using System.Windows.Navigation;
using System.Windows.Shapes; 
using RecipeApplication.Model;
using RecipeApplicationWPF.Properties;


namespace RecipeApplicationWPF
{
   
    public partial class MainWindow : Window
    {

      
        List<Ingredient> ingredients = new List<Ingredient>(); // Initialize the ingredients list
        List<Recipe> recipes = new List<Recipe>();
        Dictionary<string, List<Ingredient>> originalIngredientsMap= new Dictionary<string, List<Ingredient>>();
        public Ingredient ingredient { get; private set; } // Initialize the ingredient object
//------------------------------------------------------------------------------------------------------------------------------
        public MainWindow() // Constructor
        {
            InitializeComponent();                                                                           
            recipes = new List<Recipe>(); // Initialize the recipes list
            originalIngredientsMap = new Dictionary<string, List<Ingredient>>(); // Initialize the dictionary

        }
 //------------------------------------------------------------------------------------------------------------------------------
        private void EnterNewRecipe_Click(object sender, RoutedEventArgs e) // Enter New Recipe
        {
            NewRecipeWindow newRecipeWindow = new NewRecipeWindow(); // Create a new instance of the NewRecipeWindow
            if (newRecipeWindow.ShowDialog() == true)
            {
                Recipe newRecipe = newRecipeWindow.NewRecipe;
                recipes.Add(newRecipe);
                originalIngredientsMap[newRecipe.Title] = new List<Ingredient>(newRecipe.Ingredients);
                
                if (recipes.Contains(newRecipe))
                {
                    
                    MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add recipe. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
//____________________________________________________________________________________________________________________________________________________

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e) // Display All Recipes
        {
            RecipesDataGrid.ItemsSource = recipes;
        }
 //------------------------------------------------------------------------------------------------------------------------------
        private void DisplayRecipeByName_Click(object sender, RoutedEventArgs e) // Display Recipe By Name
        {
            InputDialog inputDialog = new InputDialog(); // Create a new instance of the InputDialog
            if (inputDialog.ShowDialog() == true)
            {
                string recipeName = inputDialog.RecipeName;
                var recipe = recipes.FirstOrDefault(r => r.Title.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe != null)
                {
                    string recipeDetails = $"Title: {recipe.Title}\n\nIngredients:\n";
                    foreach (var ingredient in recipe.Ingredients)// Display the ingredients
                    {
                        recipeDetails += $"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit} ({ingredient.Calories} calories, {ingredient.FoodGroup})\n";
                    }

                    recipeDetails += "\nSteps:\n";// Display the steps
                    foreach (var step in recipe.Steps) // Display the steps
                    {
                        recipeDetails += $"{step}\n";
                    }

                    MessageBox.Show(recipeDetails, "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Recipe not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
//------------------------------------------------------------------------------------------------------------------------------
        private void ScaleRecipe_Click(object sender, RoutedEventArgs e) // Scale Recipe
        {
            // Step 1: Prompt user to select a recipe
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a dialog to select the recipe
            InputDialogScalingRecipe selectRecipeDialog = new InputDialogScalingRecipe();
            
            selectRecipeDialog.Message="Enter the recipe title to scale:"; // Prompt user to enter the recipe title
            if (selectRecipeDialog.ShowDialog() == true)
            {
                
                string recipeTitle = selectRecipeDialog.RecipeTitleInput;

                var recipe = recipes.FirstOrDefault(r => r.Title.Equals(recipeTitle, StringComparison.OrdinalIgnoreCase));

                if (recipe == null)
                {
                    MessageBox.Show("Recipe not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

               // Step 2: Prompt user to enter the scaling factor
                InputDialogScalingRecipe scaleFactorDialog = new InputDialogScalingRecipe();

               
                scaleFactorDialog.Message = "Enter the scaling factor (e.g., 2 for double, 0.5 for half):"; // Prompt user to enter the scaling factor
                if (scaleFactorDialog.ShowDialog() == true)
                {
                    
                    if (double.TryParse(scaleFactorDialog.ScalingFactorInput, out double scalingFactor))
                    {
                        // Step 3: Scale the ingredients
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            
                            ingredient.Scale(scalingFactor);
                        }

                        // Step 4: Update display
                        RecipesDataGrid.ItemsSource = null;
                        RecipesDataGrid.ItemsSource = recipes;

                        MessageBox.Show("Recipe scaled successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid scaling factor. Please enter a numeric value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

//------------------------------------------------------------------------------------------------------------------------------
        private void ResetRecipeQuantities_Click(object sender, RoutedEventArgs e)
        {
            // Step 1: Check if there are any recipes available
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available to reset quantities.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Step 2: Select a recipe to reset quantities
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                string recipeName = inputDialog.RecipeName;
                var recipe = recipes.FirstOrDefault(r => r.Title.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe != null)
                {
                    // Step 3: Reset quantities of all ingredients in the selected recipe
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        ingredient.Quantity = 0; // Reset to default value or original value
                    }

                    // Step 4: Update display
                    RecipesDataGrid.ItemsSource = null;
                    RecipesDataGrid.ItemsSource = recipes;

                    MessageBox.Show($"Quantities reset for recipe '{recipe.Title}' successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Recipe not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        
    }
//------------------------------------------------------------------------------------------------------------------------------
        private void ClearData_Click(object sender, RoutedEventArgs e) // Clear Data
        {
            recipes.Clear();
            RecipesDataGrid.ItemsSource = null;
            MessageBox.Show("Data cleared. You can enter a new recipe.");
        }
//------------------------------------------------------------------------------------------------------------------------------
        private void Exit_Click(object sender, RoutedEventArgs e) // Exit
        {
            Application.Current.Shutdown();
        }
//------------------------------------------------------------------------------------------------------------------------------
        private void FilterByIngredient_Click(object sender, RoutedEventArgs e) // Filter By Ingredient
        {
            string ingredient = IngredientFilterTextBox.Text.ToLower();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))).ToList();
            RecipesDataGrid.ItemsSource = filteredRecipes;
        }
//------------------------------------------------------------------------------------------------------------------------------
        private void FilterByFoodGroup_Click(object sender, RoutedEventArgs e) // Filter By Food Group
        {
            string foodGroup = (FoodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var filteredRecipes = recipes.Where(r => r.Ingredients.Any(i => i.FoodGroup == foodGroup)).ToList();
            RecipesDataGrid.ItemsSource = filteredRecipes;
        }
//------------------------------------------------------------------------------------------------------------------------------
        private void FilterByCalories_Click(object sender, RoutedEventArgs e) //    Filter By Calories
        {
            if (int.TryParse(MaxCaloriesTextBox.Text, out int maxCalories))
            {
                var filteredRecipes = recipes.Where(r => r.CalculateTotalCalories() <= maxCalories).ToList();
                RecipesDataGrid.ItemsSource = filteredRecipes;
            }
            else
            {
                MessageBox.Show("Please enter a valid number for calories.");
            }
        }
    }
}
