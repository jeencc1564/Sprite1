using System.Security.Policy;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sprite1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarJogo();
        }

        // Define a estrutura do Sprite (posição e tamanho)
        private Rectangle sprite;
        // Define a velocidade do movimento em pixels
        private int velocidade = 1;
        // Timer para controlar a taxa de atualização da tela
        private System.Windows.Forms.Timer gameTimer;

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}
        private void InicializarJogo()
        {
            // Configura a janela
            this.Text = "Movimentar Sprite";
            this.Width = 800;
            this.Height = 600;
            this.DoubleBuffered = true; // Evita que a tela pisque

            // Cria o sprite na posição inicial (X: 100, Y: 100) com tamanho 50x50
            sprite = new Rectangle(100, 100, 50, 50);

            // Vincula os eventos de desenho e teclado
            this.Paint += TextBox_Paint;
            this.KeyDown += TextBox_KeyDown;

            // Configura o Timer (60 atualizações por segundo)
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 16;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        // Executado a cada 16 milissegundos
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate(); // Força a tela a se redesenhar
        }

        // Desenha o sprite na tela
        private void TextBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Desenha o sprite como um quadrado vermelho
            g.FillRectangle(Brushes.Red, sprite);
        }

        // Detecta as teclas pressionadas e move o sprite
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int novoX = sprite.X;
            int novoY = sprite.Y;

            // Verifica qual tecla foi pressionada
            switch (e.KeyCode)
            {
                case Keys.Up:
                    novoY -= velocidade;
                    break;
                case Keys.Down:
                    novoY += velocidade;
                    break;
                case Keys.Left:
                    novoX -= velocidade;
                    break;
                case Keys.Right:
                    novoX += velocidade;
                    break;
            }

            // Atualiza a posição do sprite
            sprite.X = novoX;
            sprite.Y = novoY;
        }
    }
}
