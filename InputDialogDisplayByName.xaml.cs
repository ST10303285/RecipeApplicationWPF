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

namespace RecipeApplicationWPF
{
    
    public partial class InputDialog : Window
    {
        public string RecipeName { get; private set; }
        public InputDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            RecipeName = RecipeNameTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
