using System;
using System.Windows.Forms;

namespace Array
{
    public partial class Form1 : Form
    {
        public int[,] A;
        public int N, M;
        public int[] F;

        public Form1()
        {
            InitializeComponent();
        }

        private void sortArray(int[] Arr)
        {
            int temp;
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                for (int j = i + 1; j < Arr.Length; j++)
                {
                    if (Arr[i] > Arr[j])
                    {
                        temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = temp;
                    }
                }
            }
        }

        public Boolean checkValue(string _N, string _M)
        {
            try
            {
                N = Int32.Parse(_N);
                M = Int32.Parse(_M);
                if (N <= 0 || M <= 0)
                {
                    MessageBox.Show("Размеры матрицы должны быть целым положительным числом");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Задайте размерность матрицы");
                return false;
            }
            return true;
        }

        public void numericInput(KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericInput(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            numericInput(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!checkValue(textBox1.Text, textBox2.Text)) return;

            A = new int[N, M];

            Random rand = new Random();

            for( int i = 0; i < N; i++)
            {
                for( int j = 0; j < M; j++)
                {
                    int a = rand.Next(1,100);
                    A[i, j] = a;
                }              
            }

            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView2.Items.Clear();

            for (int i = 0; i < M; i++)
            {
                listView1.Columns.Add(i.ToString());
            }
            for( int i = 0; i < N; i++)
            {
                ListViewItem row = new ListViewItem(A[i, 0].ToString());
                for( int j = 1; j < M; j++)
                {
                    row.SubItems.Add(A[i, j].ToString());
                }
                listView1.Items.Add(row);
            }

            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] A1 = new int[M];
            int[] F = new int[N];
            listView2.Items.Clear();
            for( int i = 0; i < N; i++)
            {
                for( int j = 0; j < M; j++)
                {
                    A1[j] = A[i, j];
                }
                sortArray(A1);
                F[i] = A1[A1.Length - 1];                       
            }

            for( int i = 0; i < N; i++)
            {
                listView2.Items.Add(F[i].ToString());
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void maxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arraySize ArraySizeForm = new arraySize();
            ArraySizeForm.Owner = this;
            if(ArraySizeForm.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = N.ToString();
                textBox2.Text = M.ToString();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тюрин А.В\nПБЗП-72");
        }
    }
}
