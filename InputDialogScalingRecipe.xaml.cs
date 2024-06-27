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
  
    public partial class InputDialogScalingRecipe : Window
    {
        public InputDialogScalingRecipe()
        {
            InitializeComponent();
            
        }
        
          public string Message
         {
                 get { return MessageLabel.Content.ToString(); }
                 set { MessageLabel.Content = value; }
         }  

         public string Input { get; private set; }  
         private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Input = InputTextBox.Text;
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string RecipeTitleInput
        {
            get { return InputTextBox.Text; }
        }

        public string ScalingFactorInput
        {
            get { return InputTextBox.Text; }
        }

    }
}
