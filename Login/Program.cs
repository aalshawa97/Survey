using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
public class app : Form
{
    Label log_name = new Label();
    TextBox logname = new TextBox();
    Label pass_name = new Label();
    TextBox passt_name = new TextBox();
    Button submit = new Button();
    int y = 150;
    int x = 100;
    int x1 = 225;

    public app()
    {
        this.IsMdiContainer = true; //this will allow multiple window to be display.
        this.Text = "Home Page";// This will set Title for application window
        this.Size = new Size(550, 400);
        this.MaximizeBox = false;//window can not be maximized by setting this property.
        this.BackColor = Color.Pink;
        this.AcceptButton = submit;
        this.StartPosition = FormStartPosition.CenterScreen;// set window in the middle of screen.
        this.FormBorderStyle = FormBorderStyle.Fixed3D;// setting this property window can not be resize. 
        this.AutoScroll = true;//Scroll bar is activated if component placing exceeds the form dimension

        textBox1();// this function will display Login Form for user
    }
    public void textBox1()
    {
        log_name.Text = "Login Id :";//set label text to be displayed
        log_name.Location = new Point(x, y); //place label at mention position in the Form
        log_name.Size = new Size(112, 23); //allocate space for label          
        log_name.Font = new Font("Verdana", 10);
        log_name.ForeColor = Color.Red; //setting  forecolor for lable               
        this.Controls.Add(log_name);//Adding label into the form               

        logname.TabIndex = 0;
        logname.Location = new Point(x1, y);
        logname.Size = new Size(150, 20);
        logname.Text = "amit";
        logname.Font = new Font("Arial", 10, FontStyle.Bold);
        logname.MaxLength = 15;// Only 15 or less than 15 characters can be enter in the textbox.
        logname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.Controls.Add(logname);

        //Last name
        pass_name.Text = "Password :";
        pass_name.Location = new Point(x, y + 50);
        pass_name.Size = new Size(112, 23);
        pass_name.Font = new Font("Verdana", 10);
        pass_name.ForeColor = Color.Red;
        this.Controls.Add(pass_name);

        passt_name.TabIndex = 1;
        passt_name.Location = new Point(x1, y + 50);
        passt_name.Size = new Size(150, 20);
        passt_name.PasswordChar = '*';//setting * to be displayed for the password charater entered by user
        passt_name.Text = "amit";
        passt_name.Font = new Font("Arial", 10, FontStyle.Bold);
        passt_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        passt_name.MaxLength = 15;
        this.Controls.Add(passt_name);

        Button submit = new Button();
        submit.Text = "Submit";
        submit.Location = new Point(200, y + 100);
        submit.Size = new Size(75, 25);
        submit.Font = new Font("verdana", 10, FontStyle.Bold);
        submit.BackColor = Color.Red;
        submit.ForeColor = Color.Yellow;
        submit.Click += new EventHandler(submit_click);
        this.Controls.Add(submit);

        Button reset = new Button();
        reset.Text = "Reset";
        reset.Location = new Point(300, y + 100);
        reset.Size = new Size(75, 25);
        reset.Font = new Font("verdana", 10, FontStyle.Bold);
        reset.ForeColor = Color.Yellow;
        reset.BackColor = Color.Red;
        reset.Click += new EventHandler(submit_click);
        this.Controls.Add(reset);

        Label Reg_name = new Label();
        Reg_name.Text = "For New Registration  :";
        Reg_name.Location = new Point(x1 - 25, y - 100); //Set label position
        Reg_name.Size = new Size(175, 23);
        Reg_name.Font = new Font("Verdana", 10);
        Reg_name.ForeColor = Color.Blue;
        this.Controls.Add(Reg_name);//Add

        Button Reg = new Button();
        Reg.Text = "Registration";
        Reg.Location = new Point(400, y - 100);
        Reg.Size = new Size(110, 25);
        Reg.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg.ForeColor = Color.Yellow;
        Reg.BackColor = Color.Red;
        Reg.Click += new EventHandler(submit_click);
        this.Controls.Add(Reg);
    }

    public void submit_click(object sender, EventArgs e)//this block of code will called when user clicked on the any button.
    {
        String b1 = ((Button)sender).Text;
        Console.WriteLine(" b1:" + b1);
        if (b1 == "Registration")
        {
            logname.Text = "";
            passt_name.Text = "";
            Console.WriteLine(" in side Registration");
            Client client1 = new Client(this);
            this.Hide();//this will hide login Form 
            client1.Show();// this will display Registration Form
        }

        if (b1 == "Submit")
        {
            //if login name and password are correct then allow user to move ahead.
            if ((logname.Text.Trim() == "amit") && (passt_name.Text.Trim() == "amit"))// will check login name and password
            {
                MessageBox.Show("Form has been submited Successfully ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                User frmTemp = new User(this, logname);//will display Category select Form, passing main Form (this) as object     
                frmTemp.Show();//this will Category select Form 
                this.Hide();//this will hide login Form                
            }
            else
            {
                MessageBox.Show("Please enter correct Login Id as amit and Password as amit", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logname.Focus();
                logname.Text = "";
            }
        }
        if (b1 == "Reset")//if user clicked on the reset this code will execute
        {
            logname.Text = "";//cleared all the field data
            passt_name.Text = "";
            logname.Focus();
        }

    }

    public static void Main()
    {
        Application.Run(new app());
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            try
            {

                MessageBox.Show("You are Closing this From ", "Alert Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception) { }
        }
        base.Dispose(disposing);
    }

}

// THIS CODE WILL DISPLAY CATEGORY FORM

public class User : Form
{
    Panel panel1 = new Panel();
    ComboBox cb1 = new ComboBox();

    Panel panel2 = new Panel();
    Panel panel3 = new Panel();
    Panel panel4 = new Panel();


    Label Reg_name = new Label();
    Form window1;
    TextBox s;
    bool isTrue;
    int scor = 0; //initialize score board variable.
    String s7 = "null";

    RadioButton radioButton1 = new RadioButton();
    RadioButton radioButton2 = new RadioButton();
    RadioButton radioButton3 = new RadioButton();

    RadioButton radioButton21 = new RadioButton();
    RadioButton radioButton22 = new RadioButton();
    RadioButton radioButton23 = new RadioButton();

    RadioButton radioButton31 = new RadioButton();
    RadioButton radioButton32 = new RadioButton();
    RadioButton radioButton33 = new RadioButton();


    public User(Form window, TextBox logname1)
    {
        Console.WriteLine(" in side user text box : " + s);

        window1 = window; //initializing variable send to this Form
        s = logname1;//initializing variable send to this Form

        this.Text = "Select Category";// This will set Title for application window
        this.Size = new Size(600, 500);
        this.MaximizeBox = false;//window can not be maximized by setting this property.
        this.BackColor = Color.Yellow;
        this.SuspendLayout();
        this.StartPosition = FormStartPosition.CenterScreen;// set window in the middle of screen.
        this.FormBorderStyle = FormBorderStyle.Fixed3D;// setting this property window can not be resize. 


        Reg_name.Text = "Hi Amit!";
        Reg_name.Location = new Point(10, 25); //Set label position
        Reg_name.Size = new Size(100, 25);
        Reg_name.Font = new Font("Verdana", 10, FontStyle.Bold);
        Reg_name.ForeColor = Color.Red;
        this.Controls.Add(Reg_name);


        panel1.Location = new Point(10, 60);//crating panel on the From
        panel1.Size = new Size(575, 300);
        panel1.BackColor = Color.Green;
        this.Controls.Add(panel1);// Add the Panel control to the form.

        Label l_cb = new Label();//ComboBox label
        l_cb.Text = " Category :";
        l_cb.Location = new Point(10, 25);
        l_cb.Size = new Size(100, 17);
        l_cb.Font = new Font("Verdana", 10);
        l_cb.ForeColor = Color.Blue;

        cb1.Location = new Point(125, 25);
        cb1.Size = new Size(232, 20);
        cb1.Font = new Font("Verdana", 10);
        cb1.Text = " Select One Option ";
        cb1.Items.Add(" Select One Option "); //Adding items in the ComboBox.
        cb1.Items.Add("Software");
        cb1.Items.Add("Hardware");
        cb1.Items.Add("General");
        cb1.Items.Add("Sports");
        cb1.Items.Add("Java");
        cb1.Items.Add("C#(Sharp)");
        cb1.Sorted = true;// setting sort property for ComboBox

        Button Reg1 = new Button();
        Reg1.Text = "Submit";
        Reg1.Location = new Point(250, 250);
        Reg1.Size = new Size(75, 25);
        Reg1.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg1.ForeColor = Color.Yellow;
        Reg1.BackColor = Color.Red;
        Reg1.Click += new EventHandler(submit1_click);

        Button bac = new Button();
        bac.Text = "Home Page";
        bac.Location = new Point(250, 425);
        bac.Size = new Size(125, 25);
        bac.Font = new Font("verdana", 10, FontStyle.Bold);
        bac.ForeColor = Color.Yellow;
        bac.BackColor = Color.Red;
        bac.Click += new EventHandler(submit1_click);// when user clicked on the button mentioned event will call
        this.Controls.Add(bac);

        // Add the Label and TextBox controls to the Panel.
        panel1.Controls.Add(l_cb);
        panel1.Controls.Add(cb1);
        panel1.Controls.Add(Reg1);


    }

    public void submit1_click(object sender, EventArgs e)// block of code will get call when user clicks on the submit
    {
        Boolean flag1 = true;

        String b1 = ((Button)sender).Text;
        s7 = cb1.Text;
        if (b1 == "Home Page")
        {
            this.Dispose();//Category Form will get dispose 
            window1.Show(); //Login form will get display, for this purpose i have passed (this) object to this constructor
            s.Focus();
            scor = 0;
            Console.WriteLine("Score board :" + scor);
        }
        else //when user clicked on th submit button 
        {
            if (s7 != "General")
            {
                MessageBox.Show("For Demo Please select only General Category ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag1 = false;
                cb1.Focus();
            }

            if (flag1) //is flag is true 
            {
                this.Controls.Remove(panel1); //this remove panel added previously on the Category Form  
                this.Controls.Remove(Reg_name); // remove top label form the Category Form  

                showdata(s7);
            }
        }

    }
    public void showdata(String str)
    {
        String b1 = str;

        this.Text = "View FAQS";//setting new title for Form
        Label wel = new Label();
        wel.Text = "Welcome to the Category : " + b1 + " !! ";
        wel.Location = new Point(100, 25); //Set label position
        wel.Size = new Size(350, 25);
        wel.Font = new Font("Verdana", 10, FontStyle.Bold);
        wel.ForeColor = Color.Red;
        this.Controls.Add(wel);

        showquestion();

    }
    /*
     *     public void showquestion()
    {
        panel2.Location = new Point(50, 60);
        panel2.Size = new Size(485, 320);
        panel2.BackColor = Color.Pink;
        this.Controls.Add(panel2);//newly created panel added to this Form

        Button Reg2 = new Button();
        Reg2.Text = "Next2";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit2_click);

        Label ques1 = new Label();
        ques1.Text = "Question 1: Who won the 1998 Soccer world Cup ?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(425, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;


        GroupBox groupBox1 = new GroupBox();//creating Group box for radio buttons
        groupBox1.Text = "Answer";
        groupBox1.Location = new Point(50, 60);
        groupBox1.Size = new Size(400, 175);


        radioButton1.Location = new Point(20, 25);
        radioButton1.Size = new Size(50, 25);
        radioButton1.CheckedChanged += new System.EventHandler(value);//Evwn will call when user select any check box

        Label ans1 = new Label();
        ans1.Text = " France ";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(100, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;


        radioButton2.Location = new Point(20, 75);
        radioButton2.Size = new Size(50, 25);
        radioButton2.CheckedChanged += new System.EventHandler(value);

        Label ans2 = new Label();
        ans2.Text = " Brazil ";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(100, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;


        radioButton3.Location = new Point(20, 125);
        radioButton3.Size = new Size(50, 25);
        radioButton3.CheckedChanged += new System.EventHandler(value);

        Label ans3 = new Label();
        ans3.Text = " Italy ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(100, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox1.Controls.Add(radioButton1);
        groupBox1.Controls.Add(radioButton2);
        groupBox1.Controls.Add(radioButton3);
        groupBox1.Controls.Add(ans1);
        groupBox1.Controls.Add(ans2);
        groupBox1.Controls.Add(ans3);

        // Add the GroupBox to the Form.
        Controls.Add(groupBox1);
        panel2.Controls.Add(Reg2);
        panel2.Controls.Add(ques1);
        panel2.Controls.Add(groupBox1);

    }
    public void submit2_click(object sender, EventArgs e)
    {

        if (isTrue) //if given answer is correct, flag will be true, and Score Board will be incremented
        {
            scor = scor + 1;
        }

        isTrue = false;
        Console.WriteLine(" value of score:" + scor);

        showquestion1();// this function will remove current pannel and insert new panel          

    }

    public void value(object sender, EventArgs e)
    {
        isTrue = radioButton1.Checked; //will set to true if correct answer checkbox is selected by user           

    }
     */

    public void showquestion()
    {
        panel2.Location = new Point(50, 60);
        panel2.Size = new Size(485, 320);
        panel2.BackColor = Color.Pink;
        this.Controls.Add(panel2);//newly created panel added to this Form

        Button Reg2 = new Button();
        Reg2.Text = "Next2";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit2_click);

        Label ques1 = new Label();
        ques1.Text = "Question 1: Who won the 1998 Soccer world Cup ?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(425, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;


        GroupBox groupBox1 = new GroupBox();//creating Group box for radio buttons
        groupBox1.Text = "Answer";
        groupBox1.Location = new Point(50, 60);
        groupBox1.Size = new Size(400, 175);


        radioButton1.Location = new Point(20, 25);
        radioButton1.Size = new Size(50, 25);
        radioButton1.CheckedChanged += new System.EventHandler(value);//Evwn will call when user select any check box

        Label ans1 = new Label();
        ans1.Text = " France ";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(100, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;


        radioButton2.Location = new Point(20, 75);
        radioButton2.Size = new Size(50, 25);
        radioButton2.CheckedChanged += new System.EventHandler(value);

        Label ans2 = new Label();
        ans2.Text = " Brazil ";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(100, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;


        radioButton3.Location = new Point(20, 125);
        radioButton3.Size = new Size(50, 25);
        radioButton3.CheckedChanged += new System.EventHandler(value);

        Label ans3 = new Label();
        ans3.Text = " Italy ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(100, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox1.Controls.Add(radioButton1);
        groupBox1.Controls.Add(radioButton2);
        groupBox1.Controls.Add(radioButton3);
        groupBox1.Controls.Add(ans1);
        groupBox1.Controls.Add(ans2);
        groupBox1.Controls.Add(ans3);

        // Add the GroupBox to the Form.
        Controls.Add(groupBox1);
        panel2.Controls.Add(Reg2);
        panel2.Controls.Add(ques1);
        panel2.Controls.Add(groupBox1);

    }
    public void submit2_click(object sender, EventArgs e)
    {

        if (isTrue) //if given answer is correct, flag will be true, and Score Board will be incremented
        {
            scor = scor + 1;
        }

        isTrue = false;
        Console.WriteLine(" value of score:" + scor);

        showquestion1();// this function will remove current pannel and insert new panel          

    }

    public void value(object sender, EventArgs e)
    {
        isTrue = radioButton1.Checked; //will set to true if correct answer checkbox is selected by user           

    }

    public void showquestion1()
    {
        panel2.Dispose(); //dispose current panel        


        panel3.Location = new Point(50, 60);//create new panel
        panel3.Size = new Size(485, 320);
        //panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        panel3.BackColor = Color.Orange;
        this.Controls.Add(panel3);//newly created panel added to Category Form

        Button Reg2 = new Button();
        Reg2.Text = "Next3";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit3_click);

        Label ques1 = new Label();
        ques1.Text = "Question 2: Which Country won the 1999 Cricket world Cup?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(425, 40);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;


        GroupBox groupBox2 = new GroupBox();
        groupBox2.Text = "Answer";
        groupBox2.Location = new Point(50, 60);
        groupBox2.Size = new Size(400, 175);

        radioButton21.Location = new Point(20, 25);
        radioButton21.Size = new Size(50, 25);
        radioButton21.CheckedChanged += new System.EventHandler(value2);

        Label ans1 = new Label();
        ans1.Text = " India ";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(100, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        radioButton22.Location = new Point(20, 75);
        radioButton22.Size = new Size(50, 25);
        radioButton22.CheckedChanged += new System.EventHandler(value2);

        Label ans2 = new Label();
        ans2.Text = " Australia ";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(100, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton23.Location = new Point(20, 125);
        radioButton23.Size = new Size(50, 25);
        radioButton23.CheckedChanged += new System.EventHandler(value2);

        Label ans3 = new Label();
        ans3.Text = " Pakistan ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(100, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox2.Controls.Add(radioButton21);
        groupBox2.Controls.Add(radioButton22);
        groupBox2.Controls.Add(radioButton23);
        groupBox2.Controls.Add(ans1);
        groupBox2.Controls.Add(ans2);
        groupBox2.Controls.Add(ans3);

        // Add the GroupBox to the Form.
        Controls.Add(groupBox2);
        panel3.Controls.Add(Reg2);
        panel3.Controls.Add(ques1);
        panel3.Controls.Add(groupBox2);

    }
    public void submit3_click(object sender, EventArgs e)
    {

        if (isTrue)
        {
            scor = scor + 1;
        }
        isTrue = false;
        Console.WriteLine(" value of score:" + scor);

        showquestion2();
    }

    public void value2(object source, EventArgs e)
    {
        isTrue = radioButton22.Checked;

    }

    public void showquestion2()
    {
        panel3.Dispose();

        Panel panel4 = new Panel();
        panel4.SuspendLayout();
        panel4.Location = new Point(50, 60);
        panel4.Size = new Size(485, 320);
        panel4.BackColor = Color.Orange;
        this.Controls.Add(panel4);

        Button Reg2 = new Button();
        Reg2.Text = "Next4";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit4_click);

        Label ques1 = new Label();
        ques1.Text = "Question 3: Who won the 20001 Wimbledon Grand Slam?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox3 = new GroupBox();
        groupBox3.Text = "Answer";
        groupBox3.Location = new Point(50, 60);
        groupBox3.Size = new Size(400, 175);

        radioButton31.Location = new Point(20, 25);
        radioButton31.Size = new Size(50, 25);
        radioButton31.CheckedChanged += new System.EventHandler(value3);

        Label ans1 = new Label();
        ans1.Text = " Andre Aggassi ";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        radioButton32.Location = new Point(20, 75);
        radioButton32.Size = new Size(50, 25);
        radioButton32.CheckedChanged += new System.EventHandler(value3);

        Label ans2 = new Label();
        ans2.Text = " Peat Sampras";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton33.Location = new Point(20, 125);
        radioButton33.Size = new Size(50, 25);
        radioButton33.CheckedChanged += new System.EventHandler(value3);

        Label ans3 = new Label();
        ans3.Text = " Goran Ivansevich ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox3.Controls.Add(radioButton31);
        groupBox3.Controls.Add(radioButton32);
        groupBox3.Controls.Add(radioButton33);
        groupBox3.Controls.Add(ans1);
        groupBox3.Controls.Add(ans2);
        groupBox3.Controls.Add(ans3);

        panel4.Controls.Add(Reg2);
        panel4.Controls.Add(ques1);
        panel4.Controls.Add(groupBox3);

    }
    public void submit4_click(object sender, EventArgs e)
    {
        if (isTrue)
        {
            scor = scor + 1;
        }

        isTrue = false;
        Console.WriteLine(" value of score:" + scor);

        User1 f1 = new User1(window1, s, scor, s7);//here new form is crated and passing some of the value to the constructor
        f1.Show();
        this.Hide();

    }

    public void value3(object source, EventArgs e)
    {
        isTrue = radioButton33.Checked;
    }
}


public class User1 : Form
{
    //initializing values
    Form dumwin;
    int scoreb;
    TextBox tb1;
    String s1;
    bool isTrue1;
    Panel panel1 = new Panel();
    Panel panel2 = new Panel();
    Panel panel3 = new Panel();
    Panel panel4 = new Panel();
    Panel panel5 = new Panel();
    Panel panel6 = new Panel();
    Panel panel7 = new Panel();

    RadioButton radioButton11 = new RadioButton();
    RadioButton radioButton12 = new RadioButton();
    RadioButton radioButton13 = new RadioButton();

    RadioButton radioButton21 = new RadioButton();
    RadioButton radioButton22 = new RadioButton();
    RadioButton radioButton23 = new RadioButton();

    RadioButton radioButton31 = new RadioButton();
    RadioButton radioButton32 = new RadioButton();
    RadioButton radioButton33 = new RadioButton();

    RadioButton radioButton41 = new RadioButton();
    RadioButton radioButton42 = new RadioButton();
    RadioButton radioButton43 = new RadioButton();

    RadioButton radioButton51 = new RadioButton();
    RadioButton radioButton52 = new RadioButton();
    RadioButton radioButton53 = new RadioButton();

    RadioButton radioButton61 = new RadioButton();
    RadioButton radioButton62 = new RadioButton();
    RadioButton radioButton63 = new RadioButton();

    RadioButton radioButton71 = new RadioButton();
    RadioButton radioButton72 = new RadioButton();
    RadioButton radioButton73 = new RadioButton();

    public User1(Form window2, TextBox tb, int sb, String s)
    {
        dumwin = window2;//assigning value to the variable on this New Form
        scoreb = sb;
        tb1 = tb;
        s1 = s;

        this.Text = "View FAQS";// This will set Title for application window
        this.Size = new Size(600, 500);
        this.MaximizeBox = false;//window can not be maximized by setting this property.
        this.BackColor = Color.Yellow;
        this.StartPosition = FormStartPosition.CenterScreen;// set window in the middle of screen.
        this.FormBorderStyle = FormBorderStyle.Fixed3D;// setting this property window can not be resize. 


        Label wel = new Label();
        wel.Text = "Wel Come to the Category : " + s1 + " !! ";
        wel.Location = new Point(100, 25); //Set label position
        wel.Size = new Size(350, 25);
        wel.Font = new Font("Verdana", 10, FontStyle.Bold);
        wel.ForeColor = Color.Red;
        this.Controls.Add(wel);

        Button bac = new Button();
        bac.Text = "Home Page";
        bac.Location = new Point(250, 425);
        bac.Size = new Size(125, 25);
        bac.Font = new Font("verdana", 10, FontStyle.Bold);
        bac.ForeColor = Color.Yellow;
        bac.BackColor = Color.Red;
        bac.Click += new EventHandler(submit1_click);
        this.Controls.Add(bac);

        showquest1();
    }

    public void showquest1()
    {

        panel1.SuspendLayout();
        panel1.Location = new Point(50, 60);
        panel1.Size = new Size(485, 320);
        panel1.BackColor = Color.Cyan;
        this.Controls.Add(panel1);

        Button Reg2 = new Button();
        Reg2.Text = "Next5";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit1_click);

        Label ques1 = new Label();
        ques1.Text = "Question 4: Who won the 20001 F1 Championship ?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton11.Location = new Point(20, 25);
        radioButton11.Size = new Size(50, 25);
        radioButton11.CheckedChanged += new System.EventHandler(value1);

        Label ans1 = new Label();
        ans1.Text = " David Coulthad ";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        radioButton12.Location = new Point(20, 75);
        radioButton12.Size = new Size(50, 25);
        radioButton12.CheckedChanged += new System.EventHandler(value1);

        Label ans2 = new Label();
        ans2.Text = " Michael Schumacher";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton13.Location = new Point(20, 125);
        radioButton13.Size = new Size(50, 25);
        radioButton13.CheckedChanged += new System.EventHandler(value1);

        Label ans3 = new Label();
        ans3.Text = " Ralf Schumacher ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.

        groupBox.Controls.Add(radioButton11);
        groupBox.Controls.Add(radioButton12);
        groupBox.Controls.Add(radioButton13);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel1.Controls.Add(Reg2);
        panel1.Controls.Add(ques1);
        panel1.Controls.Add(groupBox);

    }

    public void submit1_click(object sender, EventArgs e)
    {
        String b1 = ((Button)sender).Text;
        //Console.WriteLine(" b1:"+b1);

        if (b1 == "Home Page")
        {
            this.Dispose();
            //Console.WriteLine("after disposing");
            dumwin.Show();
            tb1.Focus();
            scoreb = 0;
            Console.WriteLine("Score board :" + scoreb);
        }

        if (isTrue1)
            scoreb = scoreb + 1;
        Console.WriteLine("Score board :" + scoreb);

        showquest2();

    }

    public void value1(object source, EventArgs e)
    {
        isTrue1 = radioButton12.Checked;
    }

    public void showquest2()
    {
        panel1.Dispose();

        panel2.Location = new Point(50, 60);
        panel2.Size = new Size(485, 320);
        panel2.BackColor = Color.Cyan;
        this.Controls.Add(panel2);

        Button Reg2 = new Button();
        Reg2.Text = "Next6";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit2_click);

        Label ques1 = new Label();
        ques1.Text = "Question 5: Select correct date for WTC Terrorist Attack?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton21.Location = new Point(20, 25);
        radioButton21.Size = new Size(50, 25);
        radioButton21.CheckedChanged += new System.EventHandler(value2);

        Label ans1 = new Label();
        ans1.Text = " 12 september";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        radioButton22.Location = new Point(20, 75);
        radioButton22.Size = new Size(50, 25);
        radioButton22.CheckedChanged += new System.EventHandler(value2);

        Label ans2 = new Label();
        ans2.Text = " 13 September";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton23.Location = new Point(20, 125);
        radioButton23.Size = new Size(50, 25);
        radioButton23.CheckedChanged += new System.EventHandler(value2);

        Label ans3 = new Label();
        ans3.Text = " 11 September ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox.Controls.Add(radioButton21);
        groupBox.Controls.Add(radioButton22);
        groupBox.Controls.Add(radioButton23);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel2.Controls.Add(Reg2);
        panel2.Controls.Add(ques1);
        panel2.Controls.Add(groupBox);

    }

    public void submit2_click(object sender, EventArgs e)
    {
        String b1 = ((Button)sender).Text;

        if (isTrue1)
            scoreb = scoreb + 1;
        isTrue1 = false;
        Console.WriteLine("Score board :" + scoreb);
        showquest3();

    }

    public void value2(object source, EventArgs e)
    {
        isTrue1 = radioButton23.Checked;
    }

    public void showquest3()
    {
        panel2.Dispose();

        panel3.Location = new Point(50, 60);
        panel3.Size = new Size(485, 320);
        panel3.BackColor = Color.Cyan;
        this.Controls.Add(panel3);

        Button Reg2 = new Button();
        Reg2.Text = "Next7";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit3_click);

        Label ques1 = new Label();
        ques1.Text = "Question 6: Which is the Capital of New Zealand?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton31.Location = new Point(20, 25);
        radioButton31.Size = new Size(50, 25);
        radioButton31.CheckedChanged += new System.EventHandler(value3);

        Label ans1 = new Label();
        ans1.Text = " Wellignton";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        radioButton32.Location = new Point(20, 75);
        radioButton32.Size = new Size(50, 25);
        radioButton32.CheckedChanged += new System.EventHandler(value3);

        Label ans2 = new Label();
        ans2.Text = " Auckland";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton33.Location = new Point(20, 125);
        radioButton33.Size = new Size(50, 25);
        radioButton33.CheckedChanged += new System.EventHandler(value3);

        Label ans3 = new Label();
        ans3.Text = " Canbera ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox.Controls.Add(radioButton31);
        groupBox.Controls.Add(radioButton32);
        groupBox.Controls.Add(radioButton33);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel3.Controls.Add(Reg2);
        panel3.Controls.Add(ques1);
        panel3.Controls.Add(groupBox);

    }

    public void submit3_click(object sender, EventArgs e)
    {

        String b1 = ((Button)sender).Text;

        if (isTrue1)
            scoreb = scoreb + 1;
        isTrue1 = false;
        Console.WriteLine("Score board :" + scoreb);
        showquest4();

    }

    public void value3(object source, EventArgs e)
    {
        isTrue1 = radioButton23.Checked;
    }

    public void showquest4()
    {

        panel3.Dispose();

        panel4.Location = new Point(50, 60);
        panel4.Size = new Size(485, 320);
        panel4.BackColor = Color.Cyan;
        this.Controls.Add(panel4);

        Button Reg2 = new Button();
        Reg2.Text = "Next8";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit4_click);

        Label ques1 = new Label();
        ques1.Text = "Question 7: Which is the Capital of India?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton41.Location = new Point(20, 25);
        radioButton41.Size = new Size(50, 25);
        radioButton41.CheckedChanged += new System.EventHandler(value4);

        Label ans1 = new Label();
        ans1.Text = " Delhi";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;


        radioButton42.Location = new Point(20, 75);
        radioButton42.Size = new Size(50, 25);
        radioButton42.CheckedChanged += new System.EventHandler(value4);

        Label ans2 = new Label();
        ans2.Text = " Mumbai";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton43.Location = new Point(20, 125);
        radioButton43.Size = new Size(50, 25);
        radioButton43.CheckedChanged += new System.EventHandler(value4);

        Label ans3 = new Label();

        ans3.Text = " Banglore ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox.Controls.Add(radioButton41);
        groupBox.Controls.Add(radioButton42);
        groupBox.Controls.Add(radioButton43);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel4.Controls.Add(Reg2);
        panel4.Controls.Add(ques1);
        panel4.Controls.Add(groupBox);

    }
    public void submit4_click(object sender, EventArgs e)
    {

        String b1 = ((Button)sender).Text;

        if (isTrue1)
            scoreb = scoreb + 1;
        isTrue1 = false;
        Console.WriteLine("Score board :" + scoreb);
        showquest5();

    }

    public void value4(object source, EventArgs e)
    {
        isTrue1 = radioButton41.Checked;
    }

    public void showquest5()
    {
        panel4.Dispose();

        panel5.Location = new Point(50, 60);
        panel5.Size = new Size(485, 320);
        panel5.BackColor = Color.Cyan;
        this.Controls.Add(panel5);

        Button Reg2 = new Button();
        Reg2.Text = "Next9";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit5_click);

        Label ques1 = new Label();
        ques1.Text = "Question 8: What is the date of Indian Parliament Attack?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 25);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton51.Location = new Point(20, 25);
        radioButton51.Size = new Size(50, 25);
        radioButton51.CheckedChanged += new System.EventHandler(value5);

        Label ans1 = new Label();
        ans1.Text = " 9 December ";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;


        radioButton52.Location = new Point(20, 75);
        radioButton52.Size = new Size(50, 25);
        radioButton52.CheckedChanged += new System.EventHandler(value5);

        Label ans2 = new Label();
        ans2.Text = " 11 December";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton53.Location = new Point(20, 125);
        radioButton53.Size = new Size(50, 25);
        radioButton53.CheckedChanged += new System.EventHandler(value5);

        Label ans3 = new Label();
        ans3.Text = " 13 December ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox.Controls.Add(radioButton51);
        groupBox.Controls.Add(radioButton52);
        groupBox.Controls.Add(radioButton53);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel5.Controls.Add(Reg2);
        panel5.Controls.Add(ques1);
        panel5.Controls.Add(groupBox);

    }

    public void submit5_click(object sender, EventArgs e)
    {

        String b1 = ((Button)sender).Text;

        if (isTrue1)
            scoreb = scoreb + 1;
        isTrue1 = false;
        Console.WriteLine("Score board :" + scoreb);
        showquest6();

    }

    public void value5(object source, EventArgs e)
    {
        isTrue1 = radioButton53.Checked;
    }

    public void showquest6()
    {

        panel5.Dispose();

        panel6.Location = new Point(50, 60);
        panel6.Size = new Size(485, 320);
        panel6.BackColor = Color.Cyan; this.Controls.Add(panel6);

        Button Reg2 = new Button();
        Reg2.Text = "Next10";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(75, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.ForeColor = Color.Yellow;
        Reg2.BackColor = Color.Red;
        Reg2.Click += new EventHandler(submit6_click);

        Label ques1 = new Label();
        ques1.Text = "Question 9:Who is Oscar winner this Year for the Best Actress?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 40);
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ques1.ForeColor = Color.Red;

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton61.Location = new Point(20, 25);
        radioButton61.Size = new Size(50, 25);
        radioButton61.CheckedChanged += new System.EventHandler(value6);

        Label ans1 = new Label();
        ans1.Text = " Catherina Zeta Jones";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;


        radioButton62.Location = new Point(20, 75);
        radioButton62.Size = new Size(50, 25);
        radioButton62.CheckedChanged += new System.EventHandler(value6);

        Label ans2 = new Label();
        ans2.Text = " Judie Foster";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton63.Location = new Point(20, 125);
        radioButton63.Size = new Size(50, 25);
        radioButton63.CheckedChanged += new System.EventHandler(value6);

        Label ans3 = new Label();
        ans3.Text = " Julie Robert ";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox.Controls.Add(radioButton61);
        groupBox.Controls.Add(radioButton62);
        groupBox.Controls.Add(radioButton63);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel6.Controls.Add(Reg2);
        panel6.Controls.Add(ques1);
        panel6.Controls.Add(groupBox);

    }

    public void submit6_click(object sender, EventArgs e)
    {

        String b1 = ((Button)sender).Text;

        if (isTrue1)
            scoreb = scoreb + 1;
        isTrue1 = false;
        Console.WriteLine("Score board :" + scoreb);
        showquest7();

    }

    public void value6(object source, EventArgs e)
    {
        isTrue1 = radioButton63.Checked;
    }

    public void showquest7()
    {

        panel6.Dispose();
        panel7.Location = new Point(50, 60);
        panel7.Size = new Size(485, 320);
        panel7.BackColor = Color.Cyan;
        this.Controls.Add(panel7);

        Button Reg2 = new Button();
        Reg2.Text = "Score Board";
        Reg2.Location = new Point(200, 270);
        Reg2.Size = new Size(125, 25);
        Reg2.Font = new Font("verdana", 10, FontStyle.Bold);
        Reg2.BackColor = Color.Red;
        Reg2.ForeColor = Color.Cyan;

        Reg2.Click += new EventHandler(submit7_click);

        Label ques1 = new Label();
        ques1.Text = "Question 10: Who is Oscar winner this Year for the Best Actor?";
        ques1.Location = new Point(10, 20); //Set label position
        ques1.Size = new Size(475, 40);
        ques1.ForeColor = Color.Red;
        ques1.Font = new Font("Verdana", 10, FontStyle.Bold);

        GroupBox groupBox = new GroupBox();
        groupBox.Text = "Answer";
        groupBox.Location = new Point(50, 60);
        groupBox.Size = new Size(400, 175);

        radioButton71.Location = new Point(20, 25);
        radioButton71.Size = new Size(50, 25);
        radioButton71.CheckedChanged += new System.EventHandler(value7);

        Label ans1 = new Label();
        ans1.Text = " Tom Hank";
        ans1.Location = new Point(75, 25); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        radioButton72.Location = new Point(20, 75);
        radioButton72.Size = new Size(50, 25);
        radioButton72.CheckedChanged += new System.EventHandler(value7);

        Label ans2 = new Label();
        ans2.Text = " Harison Ford ";
        ans2.Location = new Point(75, 75); //Set label position
        ans2.Size = new Size(250, 25);
        ans2.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans2.ForeColor = Color.Blue;

        radioButton73.Location = new Point(20, 125);
        radioButton73.Size = new Size(50, 25);
        radioButton73.CheckedChanged += new System.EventHandler(value7);

        Label ans3 = new Label();
        ans3.Text = "Russel Crow";
        ans3.Location = new Point(75, 125); //Set label position
        ans3.Size = new Size(250, 25);
        ans3.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans3.ForeColor = Color.Blue;

        // Add the RadioButtons to the GroupBox.
        groupBox.Controls.Add(radioButton71);
        groupBox.Controls.Add(radioButton72);
        groupBox.Controls.Add(radioButton73);
        groupBox.Controls.Add(ans1);
        groupBox.Controls.Add(ans2);
        groupBox.Controls.Add(ans3);

        panel7.Controls.Add(Reg2);
        panel7.Controls.Add(ques1);
        panel7.Controls.Add(groupBox);
    }

    public void submit7_click(object sender, EventArgs e)
    {
        String b1 = ((Button)sender).Text;
        if (isTrue1)
            scoreb = scoreb + 1;
        isTrue1 = false;
        Console.WriteLine("Score board :" + scoreb);
        scoreboard();
    }

    public void value7(object source, EventArgs e)
    {
        isTrue1 = radioButton73.Checked;
    }


    public void scoreboard()
    {
        panel7.Dispose();

        Label ans1 = new Label();
        ans1.Text = "Your Score is : " + scoreb;
        ans1.Location = new Point(200, 75); //Set label position
        ans1.Size = new Size(250, 25);
        ans1.Font = new Font("Verdana", 10, FontStyle.Bold);
        ans1.ForeColor = Color.Blue;

        this.Text = "Score Board";
        this.Controls.Add(ans1);
    }
}


public class Client : Form
{
    Form app1;
    TextBox Ft_name = new TextBox();
    TextBox Lt_name = new TextBox();
    TextBox emait = new TextBox();
    TextBox t_add = new TextBox();
    TextBox t_pass = new TextBox();
    TextBox t_pho = new TextBox();
    ComboBox cb = new ComboBox();
    Button submit = new Button();

    public Client(Form app)
    {
        app1 = app;

        this.Text = "Client GUI";// This will set Title for application window
        this.Size = new Size(400, 500);
        this.MaximizeBox = false;//window can not be maximized by setting this property.
        this.BackColor = Color.Pink;
        this.StartPosition = FormStartPosition.CenterScreen;// set window in the middle of screen.
        this.FormBorderStyle = FormBorderStyle.Fixed3D;// setting this property window can not be resize. 
        this.AutoScroll = true;
        this.AcceptButton = submit;

        textBox();
    }


    public void textBox()
    {
        Console.WriteLine("Inside textBox function");

        Label Fl_name = new Label();
        Fl_name.Text = "First Name :";
        Fl_name.Location = new Point(10, 10); //Set label position
        Fl_name.Size = new Size(112, 23);
        Fl_name.Font = new Font("Verdana", 10, FontStyle.Italic);
        Fl_name.ForeColor = Color.Red;
        this.Controls.Add(Fl_name);//Adding label into the form

        Ft_name.TabIndex = 0;
        Ft_name.Location = new Point(125, 10);
        Ft_name.Size = new Size(232, 20);
        Ft_name.Font = new Font("Arial", 10, FontStyle.Bold);
        Ft_name.MaxLength = 15;// Only 15 or less than 15 characyters can be enter in the textbox.
        Ft_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.Controls.Add(Ft_name);

        Label Ll_name = new Label();//Last name
        Ll_name.Text = "Last Name :";
        Ll_name.Location = new Point(10, 45);
        Ll_name.Size = new Size(112, 23);
        Ll_name.Font = new Font("Verdana", 10);
        Ll_name.ForeColor = Color.Red;
        this.Controls.Add(Ll_name);

        Lt_name.TabIndex = 1;
        Lt_name.Location = new Point(125, 45);
        Lt_name.Size = new Size(232, 20);
        Lt_name.Font = new Font("Arial", 10, FontStyle.Bold);
        Lt_name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        Lt_name.MaxLength = 15;
        this.Controls.Add(Lt_name);


        Label email = new Label();//Email
        email.Text = "Email ID :";
        email.Location = new Point(10, 75);
        email.Size = new Size(112, 23);
        email.Font = new Font("Verdana", 10);
        email.ForeColor = Color.Red;
        this.Controls.Add(email);

        emait.TabIndex = 2;
        emait.Location = new Point(125, 75);
        emait.Size = new Size(232, 20);
        emait.Font = new Font("Arial", 10, FontStyle.Bold);
        emait.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        emait.MaxLength = 40;
        this.Controls.Add(emait);


        Label l_add = new Label();//Address 
        l_add.Text = "Address :";
        l_add.Location = new Point(10, 110);
        l_add.Size = new Size(112, 23);
        l_add.Font = new Font("Verdana", 10);
        l_add.ForeColor = Color.Red;
        this.Controls.Add(l_add);


        t_add.TabIndex = 2;
        t_add.Location = new Point(125, 110);
        t_add.Size = new Size(232, 20);
        t_add.Font = new Font("Arial", 10, FontStyle.Bold);
        t_add.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        t_add.MaxLength = 50;
        this.Controls.Add(t_add);

        Label l_pass = new Label();//Password
        l_pass.Text = "Password :";
        l_pass.Location = new Point(10, 145);
        l_pass.Size = new Size(112, 23);
        l_pass.Font = new Font("Verdana", 10);
        l_pass.ForeColor = Color.Red;
        this.Controls.Add(l_pass);

        t_pass.TabIndex = 3;
        t_pass.Location = new Point(125, 145);
        t_pass.Size = new Size(232, 20);
        t_pass.Font = new Font("Arial", 10, FontStyle.Bold);
        t_pass.PasswordChar = '*';// setting "*" to display for entered data in the text box.
        t_pass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        t_pass.MaxLength = 12;
        this.Controls.Add(t_pass);

        Label l_pho = new Label();//Phone
        l_pho.Text = "Phone Number :";
        l_pho.Location = new Point(10, 180);
        l_pho.Size = new Size(118, 23);
        l_pho.Font = new Font("Verdana", 10);
        l_pho.ForeColor = Color.Red;
        this.Controls.Add(l_pho);

        t_pho.TabIndex = 4;
        t_pho.Location = new Point(125, 180);
        t_pho.Size = new Size(232, 20);
        t_pho.Font = new Font("Arial", 10, FontStyle.Bold);
        t_pho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        t_pho.MaxLength = 12;
        this.Controls.Add(t_pho);

        Label l_sub = new Label();//Check box label

        l_sub.Text = "Subcription :";
        l_sub.Location = new Point(10, 215);
        l_sub.Size = new Size(112, 23);
        l_sub.Font = new Font("Verdana", 10);
        l_sub.ForeColor = Color.Red;
        this.Controls.Add(l_sub);

        Label l_rb1 = new Label();// RadioButton 1 label
        l_rb1.Text = " Weekly ";
        l_rb1.Location = new Point(140, 230);
        l_rb1.Size = new Size(60, 17);
        l_rb1.Font = new Font("Verdana", 10);
        l_rb1.ForeColor = Color.Blue;
        this.Controls.Add(l_rb1);

        RadioButton rb1 = new RadioButton();
        rb1.TabIndex = 5;
        rb1.Location = new Point(205, 228);
        rb1.Checked = true;
        this.Controls.Add(rb1);

        Label l_rb2 = new Label();// RadioButton  2
        l_rb2.Text = " Monthly ";
        l_rb2.Location = new Point(140, 255);
        l_rb2.Size = new Size(66, 17);
        l_rb2.Font = new Font("Verdana", 10);
        l_rb2.ForeColor = Color.Blue;
        this.Controls.Add(l_rb2);

        RadioButton rb2 = new RadioButton();
        rb2.TabIndex = 6;
        rb2.Location = new Point(205, 255);
        this.Controls.Add(rb2);

        Label l_rb3 = new Label();// RadioButton 3
        l_rb3.Text = " Yearly ";
        l_rb3.Location = new Point(140, 285);
        l_rb3.Size = new Size(66, 17);
        l_rb3.Font = new Font("Verdana", 10);
        l_rb3.ForeColor = Color.Blue;
        this.Controls.Add(l_rb3);

        RadioButton rb3 = new RadioButton();
        rb3.TabIndex = 7;
        rb3.Location = new Point(205, 282);
        this.Controls.Add(rb3);

        Label l_tech = new Label();
        l_tech.Text = "Technology :";
        l_tech.Location = new Point(10, 310);
        l_tech.Size = new Size(112, 23);
        l_tech.Font = new Font("Verdana", 10);
        l_tech.ForeColor = Color.Red;
        this.Controls.Add(l_tech);

        Label l_chk1 = new Label();//Check box label
        l_chk1.Text = "Java ";
        l_chk1.Location = new Point(125, 325);
        l_chk1.Size = new Size(50, 17);
        l_chk1.Font = new Font("Verdana", 10);
        l_chk1.ForeColor = Color.Blue;
        this.Controls.Add(l_chk1);

        CheckBox chk1 = new CheckBox();
        chk1.TabIndex = 8;
        chk1.Location = new Point(185, 322);
        chk1.Width = 35;
        chk1.Checked = true;
        this.Controls.Add(chk1);

        Label l_chk2 = new Label();//Check box label--vertical
        l_chk2.Text = "C Sharp(C#) ";
        l_chk2.Location = new Point(125, 355);
        l_chk2.Size = new Size(60, 17);
        l_chk2.Font = new Font("Verdana", 10);
        l_chk2.ForeColor = Color.Blue;
        this.Controls.Add(l_chk2);

        CheckBox chk2 = new CheckBox();
        chk2.TabIndex = 9;
        chk2.Location = new Point(185, 352);
        chk2.Width = 35;
        this.Controls.Add(chk2);

        Label hl_chk1 = new Label();//Check box label--horizontal
        hl_chk1.Text = " ASP ";
        hl_chk1.Location = new Point(250, 325);
        hl_chk1.Size = new Size(60, 17);
        hl_chk1.Font = new Font("Verdana", 10);
        hl_chk1.ForeColor = Color.Blue;
        this.Controls.Add(hl_chk1);

        CheckBox chkh1 = new CheckBox();
        chkh1.TabIndex = 9;
        chkh1.Location = new Point(310, 322);
        chkh1.Width = 35;
        this.Controls.Add(chkh1);

        Label hl_chk2 = new Label();//Check box label--horizontal
        hl_chk2.Text = " VB ";
        hl_chk2.Location = new Point(250, 355);
        hl_chk2.Size = new Size(60, 17);
        hl_chk2.Font = new Font("Verdana", 10);
        hl_chk2.ForeColor = Color.Blue;
        this.Controls.Add(hl_chk2);

        CheckBox chkh2 = new CheckBox();
        chkh2.TabIndex = 10;
        chkh2.Location = new Point(310, 352);
        chkh2.Width = 35;
        this.Controls.Add(chkh2);

        Label l_cb = new Label();//ComboBox label
        l_cb.Text = " Experience :";
        l_cb.Location = new Point(10, 380);
        l_cb.Size = new Size(100, 17);
        l_cb.Font = new Font("Verdana", 10);
        l_cb.ForeColor = Color.Red;
        this.Controls.Add(l_cb);


        cb.Location = new Point(125, 380);
        cb.Size = new Size(232, 20);
        cb.Font = new Font("Verdana", 10);
        cb.Text = " Select One Option ";
        cb.Items.Add("Freshers");
        cb.Items.Add("Less than 6 Months");
        cb.Items.Add("From  6 Months To 2 Years");
        cb.Items.Add("From  2 Months To 5 Years");
        cb.Items.Add("From  5 Months To 10 Years");
        cb.Items.Add("Above 10 Years");
        this.Controls.Add(cb);


        submit.Text = "Submit";
        submit.Location = new Point(100, 430);
        submit.Size = new Size(75, 25);
        submit.Font = new Font("verdana", 10, FontStyle.Bold);
        submit.BackColor = Color.Red;
        submit.ForeColor = Color.Yellow;
        submit.Click += new EventHandler(submit_click);
        this.Controls.Add(submit);

        Button reset = new Button();
        reset.Text = " Reset";
        reset.Location = new Point(200, 430);
        reset.Size = new Size(75, 25);
        reset.Font = new Font("verdana", 10, FontStyle.Bold);
        reset.ForeColor = Color.Yellow;
        reset.BackColor = Color.Red;
        reset.Click += new EventHandler(reset_click);
        this.Controls.Add(reset);
    }

    public void submit_click(object sender, EventArgs e)
    {

        Boolean flag = true;

        String s = Ft_name.Text;
        if (s == "")
        {
            MessageBox.Show("Please enter First Name ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            flag = false;
            Ft_name.Focus();
        }
        else
        {
            String s1 = Lt_name.Text;

            if (s1 == "")
            {
                MessageBox.Show("Please enter Last Name ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flag = false;
                Lt_name.Focus();
            }
            else
            {
                String s2 = t_add.Text;

                if (s2 == "")
                {
                    MessageBox.Show("Please enter Address ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false;
                    t_add.Focus();
                }
                else
                {
                    String s3 = t_pass.Text;

                    if (s3 == "")
                    {
                        MessageBox.Show("Please enter Password ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = false;
                        t_pass.Focus();
                    }

                    else
                    {
                        String s4 = t_pho.Text;

                        if (s4 == "")
                        {
                            MessageBox.Show("Please enter Phone Number ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flag = false;
                            t_pho.Focus();
                        }
                        else
                        {
                            String s5 = emait.Text;

                            if (s5 == "")
                            {
                                MessageBox.Show("Please enter Email Id ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                flag = false;
                                emait.Focus();
                            }
                            else
                                    if (emait.Text.IndexOf(".") == -1 || emait.Text.IndexOf("@") == -1)
                            {
                                MessageBox.Show("Please check for . and @ in the Email Id ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                flag = false;
                                emait.Focus();
                            }
                            else
                            {
                                String s6 = cb.Text;

                                if (s6 == " Select One Option ")
                                {
                                    MessageBox.Show("Please select proper Experience  ", "Confirmation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    flag = false;
                                    cb.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        if (flag)
        {

            this.Dispose();
            Console.WriteLine("after disposing");
            app1.Show();
            Label message = new Label();
            message.Text = "Form has been submited Successfully :";
            message.Location = new Point(110, 5); //Set label position
            message.Size = new Size(300, 20);
            message.Font = new Font("Verdana", 10, FontStyle.Italic);
            message.ForeColor = Color.Green;
            app1.Controls.Add(message);//Adding label into the form          

        }
    }

    public void reset_click(object sender, EventArgs e)
    {
        Console.WriteLine(" In side Reset");
        Ft_name.Text = "";
        Lt_name.Text = "";
        emait.Text = "";
        t_add.Text = "";
        t_add.Text = "";
        t_pass.Text = "";
        t_pho.Text = "";
        cb.Text = "Select One Option";
        Ft_name.Focus();
    }

}