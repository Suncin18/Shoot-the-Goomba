using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoombasShoot
{
    public partial class Form1 : Form
    {
        int time = 60, point = 0;
        Boolean A = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(time == 0) //Verificamos que el timer haya llegado o no a 0
            {
                timer1.Stop(); //Lo detenemos
                timer2.Stop();//Detenemos el Goomba
                MessageBox.Show("Score: "+ point); //Mostramos la puntuación alcanzada
                point = 0;//Reiniciamos las variables
                time = 60;
                lblScore.Text = "Score "+ point;//También el label
                timer1.Start(); //Comenzamos a disminuir el tiempo desde 60
                timer2.Start();
            }
            else{
                time = time - 1; //Sino entonces restamos el tiempo de 1 en 1
                lblTime.Text = "Time: " + time; //Y mostramos el tiempo en todo momento
            }
        }

        private void imgGoomba_Click(object sender, EventArgs e)
        {
         if(A == false)
            {
                point = point + 1;
                lblScore.Text = "Score " + point;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            moveGoomba();
        }

        private void moveGoomba() //Con esto haremos que Goomba recorra la pantalla
        {
            Random position = new Random();
            imgGoomba.Location = new Point(position.Next(700),position.Next(382));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (A == false)
            {
                timer1.Stop(); //Lo detenemos
                timer2.Stop();//Detenemos el Goomba
                button2.Text = "Restart";
                A = true;
            }else{
                timer1.Start();
                timer2.Start();
                button2.Text = "Stop";
                A = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
