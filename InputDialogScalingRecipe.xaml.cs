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
