using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AliceChess
{

    public partial class defaultForm : Form
    {


        gameForm gameForm = new gameForm();
        public defaultForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            gameForm.Closed += (s, args) => this.Close();
            gameForm.Show();
        }

        
    }
}
