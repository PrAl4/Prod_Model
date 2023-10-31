using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prod_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillTextBox();
            FillCheckBox();
        }

        //Предметы крафта
        string[] Elements = new string[120];

        //Готовые продукты
        string[] Products = new string[190];

        //Рецепты
        string[] Recepies = new string[200];


        //Функция заполнения массивов
        void FillElements()
        {
            int cp = 0;
            int ce = 0;
            StreamReader file = File.OpenText(@"D:\ISlabs\Prod_Model\Prod_Model\Prod_Model\Properties\elems.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] items = line.Split('.');
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == "" || items[i] == " ")
                    {
                        continue;
                    }
                    if (items[i].ToCharArray()[0] == '*')
                    {
                        Products[cp] = items[i].Substring(1);
                        cp++;
                    }
                    else if (items[i].ToCharArray()[0] == '^')
                    {
                        Products[cp] = items[i].Substring(1);
                        cp++;
                        Elements[ce] = items[i].Substring(1);
                        ce++;
                    }
                    else
                    {
                        Elements[ce] = items[i];
                        ce++;
                    }
                }
            }
            MessageBox.Show(cp.ToString());
            file.Close();
        }

        //Заполнение массива правилами
        void FillRulles()
        {
            int cr = 0;
            StreamReader file = File.OpenText(@"D:\ISlabs\Prod_Model\Prod_Model\Prod_Model\Properties\rules.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] items = line.Split('.');
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == "" || items[i] == " ")
                    {
                        continue;
                    }
                    Recepies[cr] = items[i];
                    cr++;
                }
            }
            file.Close();
        }

        //Функция заполнения 
        void FillCheckBox()
        {
            FillElements();
            for(int i = 0; i < Elements.Length; i++)
            {
                if (Elements[i] == null || Elements[i] == "")
                {
                    continue;
                }
                Check_elem.Items.Add(Elements[i]);
            }
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i] == null || Products[i] == "")
                {
                    continue;
                }
                resultes.Items.Add(Products[i]);
            }
        }

        //Заполнения текстбокса правилами
        void FillTextBox()
        {
            FillRulles();
            allRules.ScrollBars = ScrollBars.Vertical;
            for (int i = 0; i < Recepies.Length; i++)
            {
                if (Recepies[i] == null || Recepies[i] == "")
                {
                    continue;
                }
                allRules.AppendText(Recepies[i]);
                allRules.Text += Environment.NewLine + Environment.NewLine;
            }
        }

        //Кнопка очищение всего
        private void Clear_Click(object sender, EventArgs e)
        {
            Check_elem.ClearSelected();
            for(int i = 0; i < Check_elem.Items.Count; i++)
            {
                Check_elem.SetSelected(i, false);
                Check_elem.SetItemChecked(i, false);
            }
            resultes.ClearSelected(); 
            for (int i = 0; i < resultes.Items.Count; i++)
            {
                resultes.SetSelected(i, false);
                resultes.SetItemChecked(i, false);
            }
            outputPole.Clear();

        }

        //Парсер правил
        Dictionary<string, string> ParserRulles()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            for(int i =0; i < Recepies.Length; i++)
            {
                if (Recepies[i] != null)
                {
                    string[] temp = Recepies[i].Split(new string[] { " -> " }, StringSplitOptions.None);
                    d.Add(temp[1], temp[0]);
                }
            }
            return d;
        }

        void Direct_out()
        {

        }

        void Reverse_out()
        {

        }

        void Show_resultes()
        {

        }

        //Показать все правила
        private void All_rules_Click(object sender, EventArgs e)
        {
            allRules.Visible = true;
            text_rulles.Visible = true;
        }

        //Обратный вывод
        private void Reverse_output_Click(object sender, EventArgs e)
        {
            outputPole.Clear();

        }

        //Прямой вывод
        private void Direct_output_Click(object sender, EventArgs e)
        {
            outputPole.Clear();

        }

        //Скрыть все правила
        private void Close_rulles_Click(object sender, EventArgs e)
        {
            allRules.Visible = false;
            text_rulles.Visible = false;
        }

        private void resultes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(resultes.CheckedItems.Count > 0)
            {
                for (int i = 0; i < resultes.Items.Count; ++i)
                {
                    if(e.Index != i)
                    {
                        resultes.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void Show_all_resultes_Click(object sender, EventArgs e)
        {
            if (Check_elem.CheckedItems.Count == 0)
                MessageBox.Show("Ни один элемент не выбран!");
            else
            {

            }
        }
    }
}
