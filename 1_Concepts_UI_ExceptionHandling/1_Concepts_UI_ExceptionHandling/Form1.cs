/*
 * Luke Coddington
 * 4/23/22
 * Description:
 *      Final
 *      Time Predicted: 30mins
 *      Time Elapsed: 30mins
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
                    string[] images = { "Dungeon_1.jpg", "Dungeon_2.jpg", "Dungeon_3.jpg", "Dungeon_4.jpg", "Loss.jpg", "Dungeon_6.jpg", "Dungeon_7.jpg", "Dungeon_8.jpg", "Dungeon_9.jpg", "Dungeon_10.jpg", "End.jpg" };
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
                mainForm.Narator.Text = "You continue down the hallway, there are three other cells with prisoners in them, do you free the prisoners or keep going?";
                string[] room4_options = { "Continue down the hallway", "Release the Prisonsers" };
                ResetActions(room4_options);
            }

            public void ReleasePrisoners()
            {
                mainForm.Narator.Text = "You release the prisoners! You now have a squad to take on the dungeon! It's good to have friends. At the end you come to a large ornate door, do you go through?";
                this.SetImage(6);
                string[] room4_options = { "Go through the fancy door", "Open the smaller wooden door off to the side" };
                ResetActions(room4_options);
            }

            public void ContinueHallway()
            {
                mainForm.Narator.Text = "You continue down the hallway. All alone. A lone lonely loner. At the end you come to a large ornate door, do you go through?";
                this.SetImage(7);
                string[] room4_options = { "Go through the fancy door", "Open the smaller wooden door off to the side" };
                ResetActions(room4_options);
            }
        }

        class Room4 : Dungeon
        {
            public void FancyDoor()
            {
                mainForm.Narator.Text = "You open the fancy door and interupt a surprise goblin dungeon instpection team! They present you with 10lbs of paperwork and NDAs about your esacpe. Do you sign the paperwork or kill everone?";
                string[] room4_options_1 = { "Sign Paperwork", "Kill Everyone" };
                ResetActions(room4_options_1);
                this.SetImage(9);
            }

            public void SideDoor()
            {
                mainForm.Narator.Text = "You discover a midevil janitors closet. You suit up and armed with a mop you go through the fancy door. You open the fancy door and interupt a surprise goblin dungeon instpection team! They tell to continue on, do you kill everyone or exit the room?";
                this.SetImage(9);
                string[] room4_options_1 = { "Exit Room", "Kill Everyone" };
                ResetActions(room4_options_1);
            }

            public void KillEveryone()
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
                    this.mainForm.Narator.Text = "You destroy the goblins and exit the dungeon, the world awaits";
                }
                else
                {
                    this.mainForm.Narator.Text = "You barely defeat the goblins, badly wounded you exit the dungeon, the world awaits";
                }
                this.SetImage(11);
                string[] end = { "Exit" };
                ResetActions(end);
            }

            public void SignPaperwork()
            {
                mainForm.Narator.Text = "You sign the paperwork and walk free! The world awaits";
                this.SetImage(11);
                string[] end = { "Exit" };
                ResetActions(end);
            }

            public void ExitRoom()
            {
                mainForm.Narator.Text = "You exit the dungeon, the world awaits";
                this.SetImage(11);
                string[] end = { "Exit" };
                ResetActions(end);
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
                Room4 room4 = new Room4();

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
                else if (SelectionText == "Release the Prisonsers")
                {
                    room3.ReleasePrisoners();
                }
                else if (SelectionText == "Continue down the hallway")
                {
                    room3.ContinueHallway();
                }
                else if (SelectionText == "Go through the fancy door")
                {
                    room4.FancyDoor();
                }
                else if (SelectionText == "Open the smaller wooden door off to the side")
                {
                    room4.SideDoor();
                }
                else if (SelectionText == "Kill Everyone")
                {
                    room4.KillEveryone();
                }
                else if (SelectionText == "Exit Room")
                {
                    room4.ExitRoom();
                }
                else if (SelectionText == "Sign Paperwork")
                {
                    room4.SignPaperwork();
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