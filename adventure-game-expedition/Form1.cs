using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adventure_game_expedition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }



        private void swordPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                swordPictureBox.BorderStyle = BorderStyle.FixedSingle;
                bowPictureBox.BorderStyle = BorderStyle.None;
                macePictureBox.BorderStyle = BorderStyle.None;
                bluePotionPictureBox.BorderStyle = BorderStyle.None;
                redPotionPictureBox.BorderStyle = BorderStyle.None;
            }
        }

        private void bowPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                game.Equip("Bow");
                swordPictureBox.BorderStyle = BorderStyle.None;
                bowPictureBox.BorderStyle = BorderStyle.FixedSingle;
                macePictureBox.BorderStyle = BorderStyle.None;
                bluePotionPictureBox.BorderStyle = BorderStyle.None;
                redPotionPictureBox.BorderStyle = BorderStyle.None;
            }
        }

        private void macePictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                swordPictureBox.BorderStyle = BorderStyle.None;
                bowPictureBox.BorderStyle = BorderStyle.None;
                macePictureBox.BorderStyle = BorderStyle.FixedSingle;
                bluePotionPictureBox.BorderStyle = BorderStyle.None;
                redPotionPictureBox.BorderStyle = BorderStyle.None;
            }
        }

        private void bluePotionPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue potion"))
            {
                game.Equip("Blue potion");
                swordPictureBox.BorderStyle = BorderStyle.None;
                bowPictureBox.BorderStyle = BorderStyle.None;
                macePictureBox.BorderStyle = BorderStyle.None;
                bluePotionPictureBox.BorderStyle = BorderStyle.FixedSingle;
                redPotionPictureBox.BorderStyle = BorderStyle.None;

                upAttackButton.Width = 34;
                upAttackButton.Text = "Use";
                downAttackButton.Visible = false;
                rightAttackButton.Visible = false;
                leftAttackButton.Visible = false;
            }
        }

        private void redPotionPictureBox_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red potion"))
            {
                game.Equip("Red potion");
                swordPictureBox.BorderStyle = BorderStyle.None;
                bowPictureBox.BorderStyle = BorderStyle.None;
                macePictureBox.BorderStyle = BorderStyle.None;
                bluePotionPictureBox.BorderStyle = BorderStyle.None;
                redPotionPictureBox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void upMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void downMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void rightMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void leftMoveButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void upAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void downAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void rightAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void leftAttackButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }
    }
}
