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

namespace RecipeApplicationWPF
{
  
    public partial class InputDialogScalingRecipe : Window //This class is used to create a dialog box for the user to input the scaling factor for the recipe
    {
        public InputDialogScalingRecipe() //Constructor for the class
        {
            InitializeComponent();
            
        }
        
          public string Message
         {
                 get { return MessageLabel.Content.ToString(); }//This property is used to get the message that is displayed in the dialog box
                 set { MessageLabel.Content = value; }//This property is used to set the message that is displayed in the dialog box
         }  

         public string Input { get; private set; }  //This property is used to get the input from the user
         private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Input = InputTextBox.Text;
            DialogResult = true;//This property is used to set the dialog result to true
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) //This method is used to close the dialog box
        {
            DialogResult = false;
        }

        public string RecipeTitleInput //This property is used to get the input from the user
        {
            get { return InputTextBox.Text; }
        }

        public string ScalingFactorInput //This property is used to get the input from the user
        {
            get { return InputTextBox.Text; }
        }

    }
}
