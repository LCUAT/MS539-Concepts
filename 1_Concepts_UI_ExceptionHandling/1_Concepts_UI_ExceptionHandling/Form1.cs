/*
 * Luke Coddington
 * 4/16/22
 * Description:
 *      Assignment 5 - UI
 *      Time Predicted: 20mins
 *      Time Elapsed: 20mins
 */


namespace _1_Concepts_UI_ExceptionHandling
{
    
    public partial class Dungeon_Crawler : Form
    {
        class Dungeon
        {
            public Dungeon_Crawler mainForm;
            public Dungeon()
            {
              mainForm= (Dungeon_Crawler)Application.OpenForms[0];
            }
            public void SetImage(int picture)
            {
                try
                {
                    string[] images = { "Dungeon_1.jpg", "Dungeon_2.jpg", "Dungeon_3.jpg", "Dungeon_4.jpg", "Dungeon_5.jpg" };
                    string imagePath = "./Images/";
                    imagePath = imagePath + images[picture - 1];
                    mainForm.ImageBox.Image = Image.FromFile(imagePath);
                    mainForm.ImageBox.Tag = images[picture - 1].ToUpper();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            public int RoleDice()
            {
                Random rnd = new Random();
                int num = rnd.Next(1, 20);
                return num;
            }

            public void ResetActions(string[] actions)
            {
                mainForm.UserActions.Items.Clear();
                mainForm.UserActions.Items.AddRange(actions);
            }

            public void Retreat(string msg)
            {
                this.mainForm.Narator.Text = msg;
                string[] exit = { "Exit" };
                SetImage(5);
                ResetActions(exit);
            }
        }

        class Room1 : Dungeon
        {
            public void GoOutDoor()
            {
                this.mainForm.Narator.Text = "You successfully get out the door! You exit the cell and are confronted by a guard, what do you do?";
                SetImage(2);
            }

            public void GrabTorch()
            {
                int userRole = RoleDice();
                int otherRole = RoleDice();
                while (userRole == otherRole)
                {
                    userRole = RoleDice();
                }

                this.mainForm.Narator.Text = "User Role: " + userRole;
                this.mainForm.Narator.AppendText(Environment.NewLine);
                this.mainForm.Narator.AppendText("Other Role: " + otherRole);
                this.mainForm.Narator.AppendText(Environment.NewLine);

                if (userRole > otherRole)
                {
                    this.mainForm.Narator.AppendText("You grab the torch and successfully get out the door! You exit the cell and are confronted by a guard, what do you do?");
                }
                else
                {
                    this.mainForm.Narator.AppendText("The torch is mounted on the wall, you can't pull it off. You go out the door and You exit the cell and are confronted by a guard, what do you do?");
                }
                SetImage(2);
            }

            public void SitAndWait()
            {
                this.mainForm.Narator.Text = "You sit and wait... Wow this is boring";
            }

        }

        class Room2 : Dungeon
        {
            public void GuardFight()
            {
                SetImage(2);
                int userRole = RoleDice();
                int otherRole = RoleDice();
                while (userRole == otherRole)
                {
                    userRole = RoleDice();
                }
                this.mainForm.Narator.Text = "User Role: " + userRole;
                this.mainForm.Narator.AppendText(Environment.NewLine);
                this.mainForm.Narator.AppendText("Other Role: " + otherRole);
                this.mainForm.Narator.AppendText(Environment.NewLine);

                if (userRole > otherRole)
                {
                    this.mainForm.Narator.AppendText("You fight the guard and knock him out! You are now faced with an empty hallway, do you continue or stay?");
                    SetImage(4);
                    string[] room3_options = { "Continue", "Stay" };
                    ResetActions(room3_options);
                }
                else
                {
                    this.mainForm.Narator.AppendText("The Guard is pretty tough and beats you up, What do you do?");
                    string[] Options2 = { "Continue to Fight", "Run Back to Cell", "Exit" };
                    ResetActions(Options2);
                }

            }

        }

        class Room3 : Dungeon
        {
            public void Continue()
            {
                mainForm.Narator.Text = "You continue down the hallway and that's as far as this program goes...";
                this.SetImage(5);
            }
        }

        public Dungeon_Crawler()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            //get the dropdown selected
            object selection = UserActions.SelectedItem;
            
            try
            {
                Room1 room1 = new Room1();
                Room2 room2 = new Room2(); 
                Room3 room3 = new Room3();

                //try to convert the item to a string
                var SelectionText = Convert.ToString(selection);
                
                
                if (SelectionText == "Go out the door")
                {
                    room1.GoOutDoor();
                    string[] Options2 = { "Fight the guard", "Run Back to Cell", "Exit" };
                    room1.ResetActions(Options2);
                }
                else if(SelectionText == "Grab the torch and go out the door")
                {
                    room1.GrabTorch();
                    string[] Options2 = { "Fight the guard", "Run Back to Cell", "Exit" };
                    room1.ResetActions(Options2);
                }
                else if(SelectionText == "Stay where you are and wait")
                {
                    room1.SitAndWait();
                    string[] exit = { "Exit" };
                    room1.SetImage(4);
                    room1.ResetActions(exit);
                }
                else if(SelectionText == "Exit")
                {
                    this.Close();
                }
                else if(SelectionText == "Continue to Fight" || SelectionText == "Fight the guard")
                {
                    room2.GuardFight();
                }
                else if(SelectionText == "Run Back to Cell")
                {
                    room2.Retreat("You cowardly retreat and are struck down!");
                }
                else if(SelectionText == "Continue")
                {
                    room3.Continue();
                }
                else
                {
                    Narator.Text = "Invalid Option!!";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to parse result: "+ex);
            }
        }


        //On hover display the correct tool tip
        private void SubmitBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(SubmitBtn, "User the User Actions Menu and then click this button");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label2, "Select character action and select submit");
        }

        private void UserActions_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(UserActions, "Select character action and select submit");
        }

        private void Narator_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Narator, "Automated Dungeon Master");
        }

        private void ImageBox_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(ImageBox, "Visual Rendering of Senario");
        }
    }
}