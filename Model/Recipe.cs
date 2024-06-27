//Wadiha Boat
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Model
{
    public class Recipe //  class Recipe
    {
        public string Title { get; set; }
        public List<Ingredient> Ingredients { get; set; }  // List of Ingredients
        public List<Step> Steps { get; set; }

        public delegate void CalorieAlert(string message); // Delegate for the CalorieAlert event
        public event CalorieAlert onCalorieAlert;

        //------------------------------------------------------------------------------------------------------------

        private int ingredientCount;
        private int stepCount;

        //------------------------------------------------------------------------------------------------------------
        public Recipe(string title) // Constructor
        {

            Title = title;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();

            ingredientCount = 0; // Initialize ingredient count to 0
            stepCount = 0; // Initialize step count to 0
        }
        //------------------------------------------------------------------------------------------------------------

        public Recipe(Recipe otherRecipe) // Copy Constructor
        {
            if (otherRecipe == null) // Check if otherRecipe is null
                throw new ArgumentNullException(nameof(otherRecipe), "Other recipe cannot be null.");

            Title = otherRecipe.Title; // Copy the title

            Ingredients = new List<Ingredient>(otherRecipe.Ingredients.Count); // Copy the ingredients

            for (int i = 0; i < otherRecipe.Ingredients.Count; i++) // Loop through the ingredients
            {
                if (otherRecipe.Ingredients[i] == null) // Check if the ingredient is null
                {
                    Ingredients[i] = new Ingredient(otherRecipe.Ingredients[i].Name, otherRecipe.Ingredients[i].Quantity, otherRecipe.Ingredients[i].Unit, otherRecipe.Ingredients[i].Calories, otherRecipe.Ingredients[i].FoodGroup);
                }

            }

            Steps = new List<Step>(otherRecipe.Steps); // Copy the steps

            for (int i = 0; i < otherRecipe.Steps.Count; i++) // Loop through the steps
            {
                if (otherRecipe.Steps[i] == null) // Check if the step is null
                {
                    Steps[i] = otherRecipe.Steps[i]; // Copy the step
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------

        public void AddIngredient(Ingredient ingredient) // Method to add an ingredient
        {
            
            Ingredients.Add(ingredient);
            
        }

        //------------------------------------------------------------------------------------------------------------
        public void AddStep(Step step) // Method to add a step
        {
            
            Steps.Add(step);
            
        }
        //------------------------------------------------------------------------------------------------------------

        public void Display() // Method to display the recipe
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nRecipe: {Title}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nIngredients:");
            Console.ResetColor();

            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"-{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}({ingredient.Calories}calories,{ingredient.FoodGroup})"); // Display the ingredient

            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSteps:");
            Console.ResetColor();

            for (int i = 0; i < stepCount; i++) // Loop through the steps
            {
                Console.WriteLine($"\n{i + 1}.{Steps[i].Description}"); // Display the step
            }

            int totalCalories = CalculateTotalCalories(); // Calculate the total calories
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTotal Calories: {totalCalories}");
            Console.ResetColor();

            if (totalCalories < 200)
            {
                Console.WriteLine("This recipe is low in calories, suitable for a snack.");
            }
            else if (totalCalories <= 500)
            {
                Console.WriteLine("This recipe has moderate calories, suitable for a balanced meal.");
            }
            else
            {
                Console.WriteLine("This recipe is high in calories and should be consumed sparingly.");
            }

            if (totalCalories > 300) // Check if the total calories exceed 300
            {
                onCalorieAlert?.Invoke($"Warning! The total calories of the recipe '{Title}' exceed 300!"); // Raise the event
            }
        }
        //------------------------------------------------------------------------------------------------------------

        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }

        //------------------------------------------------------------------------------------------------------------

        public void Scale(double factor) // Method to scale the recipe
        {
            foreach (var ingredient in Ingredients) // Loop through the ingredients
            {
                ingredient.Scale(factor); // Scale the quantity of the ingredient
            }
        }
        //------------------------------------------------------------------------------------------------------------

        public void Reset(List<Ingredient> originalIngredients) // Method to reset the recipe quantities
        {
            Ingredients = new List<Ingredient>(originalIngredients); // Reset the ingredients
            Console.WriteLine("Recipe quantities have been reset to original ");
           

        }

    }
}



