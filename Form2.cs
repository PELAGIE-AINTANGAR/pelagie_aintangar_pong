using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using System.Diagnostics;

namespace Pong2
{
    public partial class Form2 : Form
    {

        public Form1 gameForm;

        public Form2()
        {
            InitializeComponent();

            // le gestionnaire d'événements Click au bouton "Démarrer le jeu"
            button1.Click += btnStart_Click;

            // le gestionnaire d'événements Click au bouton "Quitter"
            button2.Click += btnQuit_Click;


        }
        public void comboboxDifficulter()
        {
            comboBox1.Items.Add("Facile");
            comboBox1.Items.Add("Moyen");
            comboBox1.Items.Add("difficile");
            comboBox1.Items.Add("Expert");

            comboBox1.SelectedIndex = 1;

        }
        public void comboBoxIA()
        {
            comboBox2.Items.Add("OUI");
            comboBox2.Items.Add("NON");
        }

        public string GetSelectedDifficulty()
        {
            return comboBox1.SelectedItem.ToString();
        }
        //public string GetSelectedIA() {
        //    return comboBox2.SelectedItem.ToString();
        //}
        private void Form2_Load(object? sender, EventArgs e)
        {
            comboboxDifficulter();
            comboBoxIA();
        }
        public void btnStart_Click(object? sender, EventArgs e)
        {
                    // Récupérez la difficulté sélectionnée
            string selectedDifficulty = comboBox1.SelectedItem.ToString();
            string selectedIA = comboBox2.SelectedItem.ToString();
            
            // Créez une instance de Form1 en passant la difficulté sélectionnée
            gameForm = new Form1(selectedDifficulty, selectedIA);
            gameForm.gameDifficulter = selectedDifficulty;
            gameForm.gameDifficulterIA = selectedIA;

            // Affichez Form1 et masquez Form2
            gameForm.Show();
                    // Masquez l'écran de démarrage
            this.Hide();

        }

        private void btnQuit_Click(object? sender, EventArgs e)
        {

            // Lorsque le bouton "QUITTER" est cliqué, fermez l'application
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}




