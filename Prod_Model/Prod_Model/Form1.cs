using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
                    if (!d.ContainsKey(temp[1]))
                        d.Add(temp[1], temp[0]);
                }
            }
            return d;
        }

        List<string> DirectHelper(string final, ref List<string> facts, Dictionary<string, string> d)
        {
            //создать целевой список и контейнер для вариантов
            List<string> res = new List<string>();
            bool flag_final = false;
            //Идем по списку всех правил
            foreach(var rule in d)
            {
                if (flag_final)
                    break;
                 //список фактов рассматриваемого правила
                 List<string> temp_for_res = new List<string>();
                 var fcts_in_rule = rule.Value.Split(new string[] { " + " }, StringSplitOptions.None);
                 foreach(var fact in fcts_in_rule)
                 {
                     //если факты не содержат элемента в правиле, то сразу переходим к следующему
                     //или если левая часть правила содержит целевой фактор, то переходим к следующему
                     if (!facts.Contains(fact) || fcts_in_rule.Contains(final))
                     {
                        break;
                     }
                     //если содержат, то добавляем факт во временный список
                     else
                     {
                         temp_for_res.Add(fact);
                     }
                 }
                 //если список добавленных фактов равен длине фактов левой части правила, то ок
                 if(temp_for_res.Count == fcts_in_rule.Length)
                 {
                     //Добавляем правило в результат
                     res.Add(rule.Value + " -> " + rule.Key);
                    if(rule.Key == final)
                    {
                        flag_final = true;
                        break;
                    }
                     //Обновляем факты фактами, которые еще не добавлены
                     if (!facts.Contains(rule.Key))
                     {
                         facts.Add(rule.Key);
                     }
                 }
            }
            int c = 0;
            foreach(var fact in res)
            {
                var fcts_in_rule = fact.Split(new string[] { " -> " }, StringSplitOptions.None);
                if (fcts_in_rule[1].Equals(final))
                {
                    c++;
                }
            }
            if(c == 0)
            {
                res.Clear();
                outputPole.AppendText("Не выводимо.");
            }
            return res;
        }

        void Direct_out()
        {
            Dictionary<string, string> d = ParserRulles();
            string final = "";
            outputPole.ScrollBars = ScrollBars.Vertical;
            List<string> fasct = new List<string>();
            for (int i = 0; i < Check_elem.CheckedItems.Count; i++)
            {
                fasct.Add(Check_elem.CheckedItems[i].ToString());
            }
            for (int i = 0; i < resultes.CheckedItems.Count; i++)
            {
                final = resultes.CheckedItems[i].ToString();
            }
            List<string> rules = DirectHelper(final, ref fasct, d);
            for (int i = 0; i < rules.Count; i++)
            {
                outputPole.AppendText(rules[i]);
                outputPole.Text += Environment.NewLine + Environment.NewLine;
            }
        }

        List<string> ReverseHelper(string start, Dictionary<string, string> d)
        {
            //создаем стэк, куда будем запихивать всю историю
            Stack<string> s = new Stack<string>();
            List<string> res = new List<string>();
            List<string> checked_l = new List<string>();
            //добавляем в лист путей и в стек первое значение - правило, от которого будем шагать 
            foreach(var r in d)
            {
                if(r.Key == start)
                {
                    s.Push(r.Value + " -> " + r.Key);
                    res.Add(r.Value + " -> " + r.Key);
                    break;
                }
            }
            for (int i = 0; i < Check_elem.CheckedItems.Count; i++)
            {
                checked_l.Add(Check_elem.CheckedItems[i].ToString());
            }
            bool end = false;
            //идем по стеку, пока тот не пустой
            while (s.Count != 0)
            {
                if (end)
                    break;
                //Достаем из стека элемент 
                string tmp = s.Pop();
                //Надо проверить, есть ли в правиле элементы, которые можно реализовать
                var rule = tmp.Split(new string[] { " -> " }, StringSplitOptions.None);
                var facts = rule[0].Split(new string[] { " + " }, StringSplitOptions.None);
                //Проходимся по фактам
                foreach(var value in facts)
                {
                    //можно ли скрафтить?
                    if (Products.Contains(value))
                    {
                        if(value == start)
                        {
                            end = true;
                            outputPole.AppendText("Не выводимо.");
                            res.Clear();
                            break;
                        }
                        bool flag_for_d = false;
                        //проходимся по словарю всех правил и ищем правило крафта
                        foreach(var v in d)
                        {
                            if (flag_for_d)
                            {
                                break;
                            }

                            //нашли нужное правило
                            if(v.Key == value)
                            {
                                if (checked_l.Contains(value))
                                {
                                    res.Add(v.Value + " -> " + v.Key);
                                }
                                else
                                {
                                    //парсим правило и проверяем, можно ли скрафтить это из наших фактов
                                    var pars_temp = v.Value.Split(new string[] { " + " }, StringSplitOptions.None);
                                    foreach (var par in pars_temp)
                                    {
                                        //если факты не содержат хотя бы один аргумент, то добавляем в стек правило
                                        if (!checked_l.Contains(par))
                                        {
                                            flag_for_d = true;
                                            s.Push(v.Value + " -> " + v.Key);
                                        }
                                    }
                                    //если флаг остался false, то добавляем правило в список результатов
                                    //поскольку его можно скрафтить из наших фактов
                                    if (!flag_for_d)
                                    {
                                        res.Add(v.Value + " -> " + v.Key);
                                        flag_for_d = true;
                                    }
                                }
                               
                            }
                        }
                    }
                    else
                    {
                        if (!checked_l.Contains(value))
                        {
                            res.Clear();
                            outputPole.AppendText("Не выводимо.");
                            end = true;
                            break;
                        }
                    }
                }
            }

            return res;
        }

        void Reverse_out()
        {
            Dictionary<string, string> res = ParserRulles();
            //Необходимая цель
            string checked_it = "";
            outputPole.ScrollBars = ScrollBars.Vertical;
            //Находим цель
            for (int i = 0; i < resultes.CheckedItems.Count; i++)
            {
                checked_it = resultes.CheckedItems[i].ToString();
            }
            //Находим цель в списке всех правил и добавляем правило в массив пути
            List<string> rules = ReverseHelper(checked_it, res);
            for(int i = rules.Count - 1; i >=0; i--)
            {
                outputPole.AppendText(rules[i]);
                outputPole.Text += Environment.NewLine + Environment.NewLine;
            }
        }

        //Случай, когда важен хотя бы один элемент
        void Show_resultes1()
        {
            Dictionary<string, string> res = ParserRulles();
            List<string> checked_it = new List<string>();
            outputPole.ScrollBars = ScrollBars.Vertical;
            //Сначала заполняем лист всех выделенных элементов
            for (int i = 0; i < Check_elem.CheckedItems.Count; i++)
            {
                checked_it.Add(Check_elem.CheckedItems[i].ToString());
            }
            //Проходимся по всем значениям в словаре правил
            foreach(var values in res)
            {
                //Парсим значения и ищем совпадение между листом отмеченных и листом всех элементов
                string[] temp = values.Value.Split(new string[] { " + " }, StringSplitOptions.None);
                //Добавляем в текстбокс правила
                foreach(string s in temp)
                {
                    if (checked_it.Contains(s))
                    {
                        outputPole.AppendText(values.Value);
                        outputPole.AppendText(" -> ");
                        outputPole.AppendText(values.Key);
                        outputPole.Text += Environment.NewLine + Environment.NewLine;
                    }
                }

            }
        }

        //Случай, когда необходимо, чтобы в крафте присутствовали только отмеченные элементы
        void Show_resultes2()
        {
            Dictionary<string, string> res = ParserRulles();
            List<string> checked_it = new List<string>();
            outputPole.ScrollBars = ScrollBars.Vertical;
            //Сначала заполняем лист всех выделенных элементов
            for (int i = 0; i < Check_elem.CheckedItems.Count; i++)
            {
                checked_it.Add(Check_elem.CheckedItems[i].ToString());
            }
            //Проходимся по всем значениям в словаре правил
            foreach (var values in res)
            {
                //Парсим значения и ищем совпадение между листом отмеченных и листом всех элементов
                string[] temp = values.Value.Split(new string[] { " + " }, StringSplitOptions.None);
                int count = 0;
                //Добавляем в текстбокс правила
                foreach (string s in temp)
                {
                    if (checked_it.Contains(s))
                    {
                        count++;
                    }
                }
                if(count == temp.Length)
                {

                    outputPole.AppendText(values.Value);
                    outputPole.AppendText(" -> ");
                    outputPole.AppendText(values.Key);
                    outputPole.Text += Environment.NewLine + Environment.NewLine;
                }
            }
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
            if (resultes.CheckedItems.Count == 0)
                MessageBox.Show("Ни один исход не выбран!");
            if (Check_elem.CheckedItems.Count == 0)
                MessageBox.Show("Ни один элемент не выбран!");
            else
            {
                outputPole.Clear();
                Reverse_out();
            }

        }

        //Прямой вывод
        private void Direct_output_Click(object sender, EventArgs e)
        {
            if (Check_elem.CheckedItems.Count == 0)
                MessageBox.Show("Ни один элемент не выбран!"); 
            if (resultes.CheckedItems.Count == 0)
                MessageBox.Show("Ни один исход не выбран!");
            else
            {
                outputPole.Clear();
                Direct_out();
            }

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
                outputPole.Clear();
                //Show_resultes1();
                Show_resultes2();
            }
        }
    }
}
