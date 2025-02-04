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
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RecipeApplicationWPF.Converters
{
    public class StringIsEmptyConverter : IValueConverter // Convert a string to a boolean
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue)// If the value is a boolean and is true
                return Visibility.Visible;// Return visible
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)// Convert back
        {
            throw new NotImplementedException();
        }
    }
}
