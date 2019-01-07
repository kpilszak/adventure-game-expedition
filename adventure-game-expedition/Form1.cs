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
            CenterToScreen();
        }

        private Game game;
        private Random random = new Random();

        private void Form1_Load_1(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }
        
        public void UpdateCharacters()
        {
            playerIcon.Location = game.PlayerLocation;
            playerIcon.Visible = true;
            playerHitPointsLabel.Text = game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batIcon.Location = enemy.Location;
                    batHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghost)
                {
                    ghostIcon.Location = enemy.Location;
                    ghostHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghoul)
                {
                    ghoulIcon.Location = enemy.Location;
                    ghoulHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }

            if (!showBat)
            {
                batIcon.Visible = false;
                batLabel.Text = "";
                batHitPointsLabel.Text = "";
            }
            else
            {
                batIcon.Visible = true;
                batLabel.Text = "Bat";
            }
            if (!showGhost)
            {
                ghostIcon.Visible = false;
                ghostLabel.Text = "";
                ghostHitPointsLabel.Text = "";
            }
            else
            {
                ghostIcon.Visible = true;
                ghostLabel.Text = "Ghost";
            }
            if (!showGhoul)
            {
                ghoulIcon.Visible = false;
                ghoulLabel.Text = "";
                ghoulHitPointsLabel.Text = "";
            }
            else
            {
                ghoulIcon.Visible = true;
                ghoulLabel.Text = "Ghoul";
            }

            swordIcon.Visible = false;
            bowIcon.Visible = false;
            maceIcon.Visible = false;
            bluePotionIcon.Visible = false;
            redPotionIcon.Visible = false;

            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = swordIcon;
                    break;
                case "Bow":
                    weaponControl = bowIcon;
                    break;
                case "Mace":
                    weaponControl = maceIcon;
                    break;
                case "Blue potion":
                    weaponControl = bluePotionIcon;
                    break;
                case "Red potion":
                    weaponControl = redPotionIcon;
                    break;
                default:
                    break;
            }            
            weaponControl.Visible = true;

            if (game.CheckPlayerInventory("Sword"))
                swordPictureBox.Visible = true;
            else
                swordPictureBox.Visible = false;
            if (game.CheckPlayerInventory("Bow"))
                bowPictureBox.Visible = true;
            else
                bowPictureBox.Visible = false;
            if (game.CheckPlayerInventory("Mace"))
                macePictureBox.Visible = true;
            else
                macePictureBox.Visible = false;
            if (game.CheckPlayerInventory("Blue potion"))
                bluePotionPictureBox.Visible = true;
            else
                bluePotionPictureBox.Visible = false;
            if (game.CheckPlayerInventory("Red potion"))
                redPotionPictureBox.Visible = true;
            else
                redPotionPictureBox.Visible = false;

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
            
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
