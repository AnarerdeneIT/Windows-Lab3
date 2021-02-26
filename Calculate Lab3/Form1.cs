using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate_Lab3
{
    public partial class Form1 : Form
    {
        private static double result = 0;
        private static bool clearResult = true;
        private static int id;
        public static Panel container;
        public static TableLayoutPanel tableLayoutPanel3;
        CalculatorBase calcBase = new CalculatorBase();
     

        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Тооны машин"; 
            TableLayoutPanel tableLayoutPanel3 = new TableLayoutPanel();
           tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top 
                | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));

            Button deleteButton = new Button();
            deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            deleteButton.ForeColor = System.Drawing.Color.White;
            deleteButton.Name = "delete";
            deleteButton.Size = new System.Drawing.Size(100, 33);
            deleteButton.TabIndex = 4;
            deleteButton.Location = new System.Drawing.Point(100, 100);
            deleteButton.Text = "DELETE";
            deleteButton.Click += new System.EventHandler(this.deleteAllMemory);

            // 
            // lbl_memory
            // 
            this.lbl_memory.AutoSize = true;
            this.lbl_memory.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_memory.ForeColor = System.Drawing.Color.White;
            this.lbl_memory.Location = new System.Drawing.Point(119, 0);
            this.lbl_memory.Name = "lbl_memory";
            this.lbl_memory.Size = new System.Drawing.Size(103, 73);
            this.lbl_memory.TabIndex = 0;
            this.lbl_memory.Text = "Санах Ой";

            // 
            // contain
            // 

       
            this.contain.Location = new System.Drawing.Point(394, 88);
            this.contain.Name = "contain";
            this.contain.Size = new System.Drawing.Size(400, 500);
            this.contain.TabIndex = 1;
            this.contain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));

            tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
          | System.Windows.Forms.AnchorStyles.Left)
          | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel3.ColumnCount = 1;

            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(this.lbl_memory, 0, 0);
            tableLayoutPanel3.Controls.Add(this.contain, 0, 1);
            tableLayoutPanel3.Controls.Add(deleteButton, 0, 2);
            tableLayoutPanel3.Location = new System.Drawing.Point(358, 12);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.65863F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.34136F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.34136F));
            tableLayoutPanel3.Size = new System.Drawing.Size(225, 499);
            tableLayoutPanel3.TabIndex = 1;

            this.Controls.Add(tableLayoutPanel3);
        }

        private void deleteAllMemory(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(334, 597);
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)));
            calcBase.deleteMemories();
        }

        private void btnNumberClick(object sender, EventArgs e)
        {
            if (clearResult)
            {
                textBox1.Text = "";
                clearResult = false;
            }
            textBox1.Text += ((Button)sender).Text;
        }

        private void btnOperatorClick(object sender, EventArgs e)
        {
            switch(((Button)sender).Text)
            {
                case "CE":
                    textBox1.Text = "0";
                    label1.Text = "";
                    result = 0;
                    clearResult = true;
                    break;
                case "C":
                    textBox1.Text = "0";
                    label1.Text = "";
                    result = 0;
                    clearResult = true;
                    break;
                case "X":
                    if (String.IsNullOrEmpty(textBox1.Text))
                    {
                        textBox1.Text = "0";
                        MessageBox.Show("hooson baina");
                    }
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1).ToString();
                    break;
                case "+":
                    label1.Text += textBox1.Text + "+";
                    result += int.Parse(textBox1.Text);
                    textBox1.Text = result.ToString();
                    clearResult = true;
                    break;
                case "-":
                    label1.Text += textBox1.Text + "-";
                    result -= int.Parse(textBox1.Text);
                    textBox1.Text = result.ToString();
                    clearResult = true;
                    break;
                case "=":
                    label1.Text += textBox1.Text;
                    textBox1.Text = (int.Parse(textBox1.Text) + result).ToString();
                    break;
                default:
                    MessageBox.Show("null");
                    break;
            }
        }
        private void createMemory(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(610, 503);
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            Memory newMemory = new Memory();
            calcBase.memories.Add(newMemory);
             id = calcBase.memories.Count;
            clearResult = true;
            buildEachMemory(0,id);
        }

        private void buildEachMemory(int too = 0,int id = 0)
        {
             container = new Panel();
            container.Name = id.ToString();
            container.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickPanel);
            Label memoryLbl = new Label();
            memoryLbl.Location = new System.Drawing.Point(140, 5);
            memoryLbl.Text = "0";
            FlowLayoutPanel rowContainer = new FlowLayoutPanel();


            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                memoryLbl.Text = textBox1.Text;
            }

            Button exampleButton1 = new Button();
            Button exampleButton2 = new Button();
            Button exampleButton3 = new Button();

            memoryLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            memoryLbl.AutoSize = true;
            memoryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            memoryLbl.ForeColor = System.Drawing.Color.White;

            memoryLbl.Name = "memorylbl" + id.ToString();
            memoryLbl.Tag = "memorylbl" + id.ToString();
            memoryLbl.Width = 120;
            memoryLbl.Size = new System.Drawing.Size(21, 24);
            memoryLbl.TabIndex = 0;

            exampleButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            exampleButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exampleButton1.ForeColor = System.Drawing.Color.White;
            exampleButton1.Name = id.ToString();
            exampleButton1.Size = new System.Drawing.Size(47, 33);
            exampleButton1.TabIndex = 4;
            exampleButton1.Text = "MC";
            exampleButton1.Click += new System.EventHandler(this.btnOperatormClear);

            exampleButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            exampleButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exampleButton2.ForeColor = System.Drawing.Color.White;
            exampleButton2.Name = id.ToString();
            exampleButton2.Size = new System.Drawing.Size(47, 33);
            exampleButton2.TabIndex = 4;
            exampleButton2.Text = "M+";
            exampleButton2.Click += new System.EventHandler(this.btnOperatormAdd);

            exampleButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            exampleButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exampleButton3.ForeColor = System.Drawing.Color.White;
            exampleButton3.Name = id.ToString();
            exampleButton3.Size = new System.Drawing.Size(47, 33);
            exampleButton3.TabIndex = 4;
            exampleButton3.Text = "M-";
            exampleButton3.Click += new System.EventHandler(this.btnOperatormMinus);
            //flow
            rowContainer.Location = new System.Drawing.Point(45, 50);
            rowContainer.Controls.Add(exampleButton1);
            rowContainer.Controls.Add(exampleButton2);
            rowContainer.Controls.Add(exampleButton3);
            rowContainer.Name = "containerExample";
            rowContainer.TabIndex = 4;

            //panel
            container.Controls.Add(memoryLbl);
            container.Controls.Add(rowContainer);


            this.contain.Controls.Add(container);
        }

        private void clickPanel(object sender, EventArgs e)
        {
             id = int.Parse(((Panel)sender).Name);
            ((Panel)sender).BackColor = System.Drawing.Color.Blue;
        }

   
        private void btnOperatormClear(object sender, EventArgs e)
        {
            calcBase.clearEachMemory(id);
            var cont = contain.Controls.Find("memorylbl" + id.ToString(), true);
            foreach (Control item in cont)
            {
                item.Text = calcBase.memories.ElementAt(id - 1).GetSetValue.ToString();
            }
            
        }

        private void btnOperatormAdd(object sender, EventArgs e)
        {

            if (calcBase.memories.Count == 0)
            {
                Memory newMemory = new Memory();
                calcBase.memories.Add(newMemory);
                buildEachMemory(int.Parse(textBox1.Text));
            }
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                calcBase.mAdd(int.Parse(textBox1.Text),id-1);
                var cont = contain.Controls.Find("memorylbl" + id.ToString(), true);
                foreach (Control item in cont)
                {

                    item.Text = calcBase.memories.ElementAt(id - 1).GetSetValue.ToString(); 
                }

                clearResult = true;
            }
        }
        private void btnOperatormMinus(object sender, EventArgs e)
        {
            if (calcBase.memories.Count == 0)
            {
                Memory newMemory = new Memory();
                calcBase.memories.Add(newMemory);
                buildEachMemory(int.Parse(textBox1.Text));
            }
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                calcBase.mMinus(int.Parse(textBox1.Text),id-1);
                var cont = contain.Controls.Find("memorylbl" + id.ToString(), true);
                foreach (Control item in cont)
                {
                    item.Text = calcBase.memories.ElementAt(id - 1).GetSetValue.ToString();
                }
                clearResult = true;
            }

        }

        private void mouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        }

     
    }
}
 