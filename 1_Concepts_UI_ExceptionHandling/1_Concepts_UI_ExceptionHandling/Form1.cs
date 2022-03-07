/*
 * Luke Coddington
 * 3/6/22
 * Description:
 *      Assignment 1 - This program is designed to demonstrate basic error handling.
 *      Time Predicted: 1hr
 *      Time Elapsed: 20mins
 */


namespace _1_Concepts_UI_ExceptionHandling
{
    public partial class Dungeon_Crawler : Form
    {
        public Dungeon_Crawler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //user clicked the submit button
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            //get the dropdown selected
            object selection = UserActions.SelectedItem;
            
            try
            {
                //try to convert the item to a string
                var SelectionText = Convert.ToString(selection);
                
                string resultString = "";

                //display the correct text to the user
                if (SelectionText == "Yes")
                {
                    resultString = "Thank you very much!";
                }
                else if(SelectionText == "")
                {
                    // failed to convert, user did not select anything
                    resultString = "Please Select an option!";
                }
                else
                {
                    resultString = "How rude.";
                }
                MessageBox.Show(resultString);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to parse result!");
            }
        }

        //text box text was changed
        private void Narator_TextChanged(object sender, EventArgs e)
        {
            //text was changed, update the text
            Narator.Text = "You can change the text! \n Do you like this Program? Use the User Actions dropdown and then select submit";
        }
    }
}