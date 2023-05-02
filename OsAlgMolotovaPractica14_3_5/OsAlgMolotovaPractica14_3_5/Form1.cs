using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;


namespace OsAlgMolotovaPractica14_3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Задание 3
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int n = Convert.ToInt32(numericUpDown1.Value);
            Queue numbers= new Queue();
            for(int i = 1; i <= n; i++)
            {
                numbers.Enqueue(i);
            }
            while(numbers.Count > 0)
            {
                int number = Convert.ToInt32(numbers.Dequeue());
                listBox1.Items.Add(number);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int n = Convert.ToInt32(numericUpDown2.Value);
            Queue young = new Queue();
            Queue old = new Queue();

            using (StreamReader sr = new StreamReader("people.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    string lastName = parts[0];
                    string firstName = parts[1];
                    string middleName = parts[2];
                    int age = int.Parse(parts[3]);
                    int weight = int.Parse(parts[4]);

                    if (age < n) { young.Enqueue($"{lastName} {firstName} {middleName}, возраст: {age}, вес: {weight}"); }
                    else { old.Enqueue($"{lastName} {firstName} {middleName}, возраст: {age}, вес: {weight}"); }
                }
            }
            foreach (string person in young) { listBox2.Items.Add(person); }
            listBox2.Items.Add(" ");
            foreach (string person in old) { listBox2.Items.Add(person); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Queue<string> people = new Queue<string>();
            listBox3.Items.Clear();

            using (StreamReader sr = new StreamReader("people.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null) { people.Enqueue(line); }
            }

            people = new Queue<string>(people.OrderBy(p => int.Parse(p.Split()[3])));
            Queue sortedPeople = new Queue();

            foreach (string person in people)
            {
                string[] parts = person.Split();
                sortedPeople.Enqueue($"{parts[0]} {parts[1]} {parts[2]}, возраст: {parts[3]}, вес: {parts[4]}");
            }
            foreach (string person in sortedPeople) { listBox3.Items.Add(person); }
        }
    }
}
