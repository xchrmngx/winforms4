using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Weapon___personage
{
    public partial class Form1 : Form
    {

        private List<Weapon> weaponsList = new List<Weapon>();    
        private Weapon currentWeapon;
        private Personage currentPersonage;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //добавление элементов в cb
            comboBox4.Items.Add("Ствол");
            comboBox4.Items.Add("Палка");
            comboBox4.Items.Add("Копалка");
            comboBox4.Items.Add("Камень");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Weapon weapon = new Weapon();
                //ввод данных о персонаже
                currentPersonage = new Personage(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text), comboBox1.SelectedItem.ToString());
                currentPersonage.CharacterWeapon = currentWeapon;
                string stroke = $"Имя:{currentPersonage.Name} Уровень:{currentPersonage.Level} Скорость: {currentPersonage.Strength} Ловкость: {currentPersonage.Dexterity} Интеллект:{currentPersonage.Intellect} Оружие:{currentPersonage.weaponType}";
                listBox2.Items.Add(stroke);

                int power = currentPersonage.CalculatePower();//вычисление мощности 
                label2.Text = $"Мощность: {power}";//вывод мощности
                string characterTitle = currentPersonage.GetCharacterTitle();//выбор звания
                label1.Text = characterTitle;//вывод звания
            }

            catch
            {
                MessageBox.Show("Вы не ввели ифнормацию");//предупреждение
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ввод характеристик оружия
            currentWeapon = new Weapon(textBox6.Text, int.Parse(textBox7.Text), int.Parse(textBox8.Text), comboBox4.SelectedItem.ToString());
            weaponsList.Add(currentWeapon);
            //вывод строки с характеристиками оружия в listBox1
            string newLine = $"{currentWeapon.TypeWeapon} {currentWeapon.Name} lvl: {currentWeapon.Level} damage:{currentWeapon.Damage} ";
            listBox1.Items.Add(newLine);//вывод оружия в listBox1
            comboBox1.Items.Add(newLine);
            comboBox2.Items.Add(newLine);
            comboBox3.Items.Add(newLine);

            //очистка textBox'ов после заполнения характеристика одного из оружий.
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();


        }

        private void button3_Click(object sender, EventArgs e)
        {

            Weapon weapon1 = currentWeapon; // Текущее оружие хранится в переменной currentWeapon
            Weapon weapon2 = listBox1.SelectedItem as Weapon; // Извлекаем выбранное оружие из listBox1

            try
            {
                //блок улучшения оружия
                Weapon upgradedWeapon = weapon1 + weapon2;
                string UpWeap = ($"{upgradedWeapon.TypeWeapon} {upgradedWeapon.Name} lvl: {upgradedWeapon.Level} damage:{upgradedWeapon.Damage}");
                listBox1.Items.Add(UpWeap);
                comboBox1.Items.Add(UpWeap);
                comboBox3.Items.Add(UpWeap);
            }
            catch 
            {
                MessageBox.Show("что-то не так");
            }
        }


            private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Блок загрузки фото 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    // Создайте объект Image из выбранного файла
                    Image selectedImage = Image.FromFile(selectedImagePath);
                    pictureBox1.Image = selectedImage;
                }
            }
        }
    }
}
