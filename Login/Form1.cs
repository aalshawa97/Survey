namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Logged in!");
            // replace with the actual login
            if (textBoxUsername.Text == "my user" && textBoxPassword.Text == "my pass")
            {
                // save the user has logged in somewhere
                // set the dialog result to ok
                this.DialogResult = DialogResult.OK;
                // close the dialog
                this.Close();

                //Open TANF dialog
            }
            else
            {
                // login failed
                MessageBox.Show("Login failed");
                // do not close the window
            }
        }
    }
}