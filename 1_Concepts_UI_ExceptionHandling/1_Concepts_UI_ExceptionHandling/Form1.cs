/*
 * Luke Coddington
 * 3/20/22
 * Description:
 *      Assignment 2 - 
 *      Time Predicted: 20mins
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

        public void GoOutDoor()
        {
            Narator.Text = "You successfully get out the door! That's as far as this program goes...";
        }

        // simulate a d20 role
        public int RoleDice()
        {
            Random rnd = new Random();
            int num = rnd.Next(1,20);
            return num;
        }

        public void ResetActions(string[] actions)
        {
            UserActions.Items.Clear();
            UserActions.Items.AddRange(actions);
        }

        public void GrabTorch()
        {
            int userRole = RoleDice();
            int otherRole = RoleDice();
            while (userRole == otherRole)
            {
                userRole = RoleDice();
            }

            Narator.Text = "User Role: " + userRole;
            Narator.AppendText(Environment.NewLine);
            Narator.AppendText("Other Role: " + otherRole);
            Narator.AppendText(Environment.NewLine);

            if (userRole > otherRole)
            {
                Narator.AppendText("You grab the torch and successfully get out the door! That's as far as this program goes...");
            }
            else
            {
                Narator.AppendText("The torch is mounted on the wall, you can't pull it off. You go out the door and that's as far as this program goes...");
            }
        }

        public void SitAndWait()
        {
            Narator.Text = "You sit and wait... Wow this is boring";
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
                
                if (SelectionText == "Go out the door")
                {
                    GoOutDoor();
                }
                else if(SelectionText == "Grab the torch and go out the door")
                {
                    GrabTorch();
                }
                else if(SelectionText == "Stay where you are and wait")
                {
                    SitAndWait();
                }
                else if(SelectionText == "Exit")
                {
                    this.Close();
                }
                else
                {
                    Narator.Text = "Invalid Option!!";
                }
                string[] exit = {"Exit"};
                ResetActions(exit);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to parse result!");
            }
        }
    }
}