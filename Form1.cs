using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2labac_
{
    public partial class Form1 : Form
    {
        MyMatrix matrixObject = new MyMatrix();
        public Form1()
        {
            InitializeComponent();
            matrixObject.FillMatrix();
            DisplayMatrixInGridView();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matrixObject.FillMatrix();
            DisplayMatrixInGridView();
        }
        private void DisplayMatrixInGridView()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < matrixObject.RowCount; i++)
            {
                dataGridView1.Columns.Add("Колонка" + i, "Колонка" + i);
            }
            for (int i = 0; i < matrixObject.RowCount; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                for (int j = 0; j < matrixObject.ColCount; j++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = matrixObject.matrix[i, j] });
                }

                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowsWithZero = CountRowsWithZeroElement();
            if (rowsWithZero > 0)
            {
                textBox1.Text = rowsWithZero.ToString();
            }
            else
            {
                MessageBox.Show("Error: No rows contain zero element.");
            }
        }
        private int CountRowsWithZeroElement()
        {
            int count = 0;
            for (int i = 0; i < matrixObject.RowCount; i++)
            {
                bool rowContainsZero = false;
                for (int j = 0; j < matrixObject.ColCount; j++)
                {
                    if (matrixObject.matrix[i, j] == 0)
                    {
                        rowContainsZero = true;
                        break; 
                    }
                }
                if (rowContainsZero)
                {
                    count++;
                }
            }
            return count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int maxColumn = ColWithMax();
            textBox2.Text = maxColumn.ToString();
        }
        private int ColWithMax()
        {
            int maxColumn = -1;
            int maxCount = 0;

            for (int j = 0; j < matrixObject.ColCount; j++)
            {
                Dictionary<int, int> countDict = new Dictionary<int, int>();

                // Підрахунок кількості кожного елементу у стовпці
                for (int i = 0; i < matrixObject.RowCount; i++)
                {
                    int element = matrixObject.matrix[i, j];
                    if (!countDict.ContainsKey(element))
                        countDict[element] = 0;
                    countDict[element]++;
                }

                // Знаходження максимальної кількості однакових елементів у стовпці
                foreach (var kvp in countDict)
                {
                    if (kvp.Value > maxCount)
                    {
                        maxCount = kvp.Value;
                        maxColumn = j;
                    }
                }
            }

            return maxColumn;
        }
    }
}
