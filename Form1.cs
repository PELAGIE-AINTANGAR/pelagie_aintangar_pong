
using System.Diagnostics;
using System.DirectoryServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;


namespace Pong2
{
    public partial class Form1 : Form
    {

        int ballX = 352; // Position initiale de la balle
        int ballY = 342;
        int ballSpeedX; // Vitesse de la balle en pixels par d�placement
        int ballSpeedY;
        int BalSpeedX;
        int BalSpeedY;

        int scorePlayer1 = 0;
        int scorePlayer2 = 0;
        int computerPaddleSpeed;
        private bool isGamePaused = false;
        public string gameDifficulter;
        public string gameDifficulterIA;
        int VitesseIA;
        public int BallSpeedX { get; set; }
        public int BallSpeedY { get; set; }


        //private System.ComponentModel.IContainer components = null;
        /* private System.Windows.Forms.Timer timer1; */// D�claration du timer ici

        public Form1(string difficulter, string difffulterIA)
        {
            InitializeComponent();
            this.gameDifficulter = difficulter;
            this.gameDifficulterIA = difffulterIA;
            /* this.playWithAI = playWithAI*/
            ;
        }
        public void SetBallSpeed(int speedX, int speedY)
        {
            BallSpeedX = speedX;
            BallSpeedY = speedY;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            //Initialiser la position de d�part de la balle
            pictureBox3.Location = new Point(ballX, ballY);
            this.DoubleBuffered = true;

            // D�marrer la minuterie pour mettre � jour le jeu
            timer1.Interval = 30; // D�finissez l'intervalle en millisecondes
            timer1.Tick += UpdateGame;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            int ballSpeedX, ballSpeedY;
            GetBallSpeedFromDifficulty(out ballSpeedX, out ballSpeedY);

            //SetBallSpeed(ballSpeedX, ballSpeedY);
            comboboxdifficulty_selectedindexchanged();
            BalSpeedX = ballSpeedX;
            BalSpeedY = ballSpeedY;

            //VitesseIA = computerPaddleSpeed;


        }

        private void UpdateGame(object? sender, EventArgs e)
        {
            // Mettre � jour la position de la balle
            //Debug.WriteLine(BalSpeedX);
            ballX += BalSpeedX;
            ballY += BalSpeedY;
            

            

            // G�rer les collisions avec les bords de l'�cran
            if (ballY <= 0 || ballY + pictureBox3.Height >= ClientSize.Height)
            {
                // La balle touche le haut ou le bas de l'�cran, inverser la direction verticale
                BalSpeedY = -BalSpeedY;
            }

            // G�rer les collisions avec les raquettes
            if (pictureBox3.Bounds.IntersectsWith(pictureBox1.Bounds) || pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                // La balle touche une raquette, inverser la direction horizontale
                BalSpeedX = -BalSpeedX;
                if (pictureBox3.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    ballX = pictureBox1.Right + 1;
                }
                else
                {
                    ballX = pictureBox2.Left - pictureBox3.Width - 1;
                }

            }
            //Debug.WriteLine(ballX.ToString());
            if (ballX < 0)
            {
                // La balle sort � gauche, le joueur 2 marque un point
                scorePlayer2++;
                ballX = ClientSize.Width / 2; // R�initialiser la position de la balle au centre
                ballY = ClientSize.Height / 2;
                ballSpeedX = 5; // R�initialiser la vitesse de la balle
                ballSpeedY = 5;
            }
            else if (ballX + pictureBox3.Width > ClientSize.Width)
            {
                // La balle sort � droite, le joueur 1 marque un point
                scorePlayer1++;
                ballX = ClientSize.Width / 2; // R�initialiser la position de la balle au centre
                ballY = ClientSize.Height / 2;
                ballSpeedX = -5; // R�initialiser la vitesse de la balle
                ballSpeedY = 5;
            }
            // Mettre � jour la position de la balle sur l'interface utilisateur
            pictureBox3.Location = new Point(ballX, ballY);

            // Mettre � jour l'affichage des scores
            label1.Text = scorePlayer1.ToString();
            label2.Text = scorePlayer2.ToString();


            int maxPointWin = 10;

            // V�rifier la condition de victoire lorsque la balle est au centre
            if (ballX == ClientSize.Width / 2 && ballY == ClientSize.Height / 2)
            {
                if (scorePlayer1 >= maxPointWin)
                {
                    MessageBox.Show("Joueur 1 a gagn� !", "Fin du jeu");
                    ResetGame(); // R�initialiser le jeu
                    timer1.Enabled = false;
                }
                else if ((scorePlayer2 >= maxPointWin))
                {

                    MessageBox.Show("Jour 2 a gagn� !", "Fin du jeu");
                    ResetGame();
                    timer1.Enabled = false;
                }
            }
            if (gameDifficulterIA == "OUI")
            {
                movecomputerpaddle();
            }

        }
        private void movecomputerpaddle()
        {
            // calculer la diff�rence entre la position verticale actuelle de la balle et la position de la raquette de l'ia
            int ballcentery = ballY + pictureBox3.Height / 2;
            int paddlecentery = pictureBox2.Top + pictureBox2.Height / 2;
            int deltay = ballcentery - paddlecentery;


            // d�placer la raquette de l'ia vers la position de la balle (avec une certaine vitesse)
            if (deltay > 0)
            {
                // la balle est plus basse que la raquette, d�placez la raquette vers le bas
                pictureBox2.Top += computerPaddleSpeed;

            }
            else if (deltay < 0)
            {
                // la balle est plus haute que la raquette, d�placez la raquette vers le haut
                pictureBox2.Top -= computerPaddleSpeed;
            }
        }

        private void ResetGame()
        {
            // R�initialiser la position de la balle au centre
            ballX = ClientSize.Width / 2;
            ballY = ClientSize.Height / 2;

            // R�initialiser la vitesse de la balle
            ballSpeedX = 5;
            ballSpeedY = 5;

            // R�initialiser les scores
            scorePlayer1 = 0;
            scorePlayer2 = 0;

            // Mettre � jour l'affichage des scores
            label1.Text = scorePlayer1.ToString();
            label2.Text = scorePlayer2.ToString();
            timer1.Enabled = true;
        }



        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            // Touche S : d�placer la raquette du joueur 1 vers le haut
            if (e.KeyCode == Keys.S)
            {
                if (pictureBox1.Top > 0)
                {
                    pictureBox1.Top -= 10; // Ajustez la valeur pour la vitesse de d�placement
                }

            }

            // Touche W : d�placer la raquette du joueur 1 vers le bas
            if (e.KeyCode == Keys.W)
            {
                if (pictureBox1.Bottom < ClientSize.Height)
                {
                    pictureBox1.Top += 10; // Ajustez la valeur pour la vitesse de d�placement
                }
            }

            // Touche fl�che Haut : d�placer la raquette du joueur 2 vers le haut
            if (e.KeyCode == Keys.Up)
            {
                if (pictureBox2.Top > 0)
                {
                    pictureBox2.Top -= 10; // Ajustez la valeur pour la vitesse de d�placement
                }
            }

            // Touche fl�che Bas : d�placer la raquette du joueur 2 vers le bas
            if (e.KeyCode == Keys.Down)
            {
                if (pictureBox2.Bottom < ClientSize.Height)
                {
                    pictureBox2.Top += 10; // Ajustez la valeur pour la vitesse de d�placement
                }
            }
            //gerer la pause
            if (e.KeyCode == Keys.P)
            {

                if (isGamePaused)
                {
                    timer1.Start(); // Reprendre la minuterie
                }
                else
                {
                    timer1.Stop(); // Mettre en pause la minuterie
                }
                isGamePaused = !isGamePaused;


            }
            //quiter le jeu
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        public void comboboxdifficulty_selectedindexchanged()
        {
            // mettez � jour la vitesse de la raquette de l'ordinateur en fonction du niveau de difficult�
            Debug.WriteLine(gameDifficulterIA);
            switch (gameDifficulter) 
            {
                case "facile":
                    if (gameDifficulterIA == "OUI")
                    {
                        computerPaddleSpeed = 7;
                    }
                    break;
                case "Moyen":
                    if (gameDifficulterIA == "OUI")
                    {
                        computerPaddleSpeed = 9;
                    }
                    break;
                case "difficile":
                    if (gameDifficulterIA == "OUI")
                    {
                        computerPaddleSpeed = 14;
                    }
                    
                    break;
                case "Expert":
                    if (gameDifficulterIA == "OUI")
                    {
                        computerPaddleSpeed = 20;
                    }
                    
                    break;
                default:
                    computerPaddleSpeed = 6; // niveau normal par d�faut
                    break;


            }
            BalSpeedX = computerPaddleSpeed; // Vous pouvez ajuster la logique ici en fonction de vos besoins
            BalSpeedY = computerPaddleSpeed;
        }
        public void GetBallSpeedFromDifficulty(out int ballSpeedX, out int ballSpeedY)
        {
           
            switch (gameDifficulter)
            {
                case "Facile":
                    //Debug.WriteLine(gameDifficulter);
                    ballSpeedX = 6; // Mettez la vitesse de la balle souhait�e ici
                    ballSpeedY = 6;
                    break;
                case "Moyen":
                    ballSpeedX = 8;
                    ballSpeedY = 8;
                    break;
                case "difficile":
                    ballSpeedX = 12;
                    ballSpeedY = 12;
                    break;
                case "Expert":
                    ballSpeedX = 18;
                    ballSpeedY = 18;
                    break;
                default:
                    ballSpeedX = 4; // Vitesse de la balle par d�faut
                    ballSpeedY = 4;
                    break;
            }
        }

        // ...





        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}