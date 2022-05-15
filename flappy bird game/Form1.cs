using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bird_game
{
    public partial class gamee : Form
    {
        int pipespeed = 8;
        int gravity = 15;
        int score = 0;

        public gamee()
        {
            InitializeComponent();
        }
        
        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }
           private void endGame ()
            {
            timer1.Stop();
            scoretext.Text += "game over";
            
        }
        private void gametimerevent(object sender, EventArgs e)
        {
            bird.Top += gravity;
            ground.Left -= pipespeed;
            pipedown.Left -= pipespeed;
            scoretext.Text = "score: " + score;
            if (pipeup.Left < -150)
            {
                pipeup.Left = 800;
                score++;
            }
            if (pipedown.Left < -180)
            {
                pipedown.Left = 950;
                score++;
            }
            if (bird.Bounds.IntersectsWith(pipeup.Bounds) || bird.Bounds.IntersectsWith(pipedown.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds) || bird.Top < -25)

            {
                endGame();
            }
            if (score > 5)
            {
                pipespeed = 15;
            }
            
        }
    }
}
