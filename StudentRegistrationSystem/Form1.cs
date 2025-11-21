using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentRegistrationSystem
{
    public partial class Form1 : Form
    {
        private TextBox txtName = null!;
        private TextBox txtFacultyNumber = null!;
        private TextBox txtMajor = null!;
        private TextBox txtGrade = null!;
        private Button btnAdd = null!;
        private ListBox listBoxStudents = null!;

        private List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            AddControls();
        }

        private void AddControls()
        {
            // Label-и и TextBox-и
            Label lblName = new Label() { Text = "Име:", Left = 20, Top = 20, Width = 80 };
            txtName = new TextBox() { Left = 120, Top = 20, Width = 200 };

            Label lblFN = new Label() { Text = "ФАкултетен №:", Left = 20, Top = 60, Width = 80 };
            txtFacultyNumber = new TextBox() { Left = 120, Top = 60, Width = 200 };

            Label lblMajor = new Label() { Text = "Специалност:", Left = 20, Top = 100, Width = 80 };
            txtMajor = new TextBox() { Left = 120, Top = 100, Width = 200 };

            Label lblGrade = new Label() { Text = "Оценка:", Left = 20, Top = 140, Width = 80 };
            txtGrade = new TextBox() { Left = 120, Top = 140, Width = 200 };

            // Button Adder
            btnAdd = new Button() { Text = "Добави", Left = 120, Top = 180, Width = 100 };
            btnAdd.Click += BtnAdd_Click;
            // Button Remover
            Button btnRemove = new Button() { Text = "Изтрий избран", Left = 250, Top = 180, Width = 120 };
            btnRemove.Click += BtnRemove_Click;
            this.Controls.Add(btnRemove);


            // ListBox
            listBoxStudents = new ListBox() { Left = 20, Top = 230, Width = 440, Height = 150 };

            // Добавяне на контролите във формата
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblFN);
            this.Controls.Add(txtFacultyNumber);
            this.Controls.Add(lblMajor);
            this.Controls.Add(txtMajor);
            this.Controls.Add(lblGrade);
            this.Controls.Add(txtGrade);
            this.Controls.Add(btnAdd);
            this.Controls.Add(listBoxStudents);
        }
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            string name = txtName.Text;
            string fn = txtFacultyNumber.Text;
            string major = txtMajor.Text;
            if (!double.TryParse(txtGrade.Text, out double grade))
            {
                MessageBox.Show("Невалиден среден успех!");
                return;
            }

            // Проверка за дублиране по фак. номер
            if (students.Any(s => s.FacultyNumber == fn))
            {
                MessageBox.Show("Студент с този факултетен номер вече съществува!");
                return;
            }

            Student s = new Student(name, fn, major, grade);
            students.Add(s);

            listBoxStudents.Items.Add(s.ToString());

            // Изчистване на полетата след добавяне
            txtName.Clear();
            txtFacultyNumber.Clear();
            txtMajor.Clear();
            txtGrade.Clear();
        }
       

        private void BtnRemove_Click(object? sender, EventArgs e)
        {   
            
            
            if (listBoxStudents.SelectedIndex == -1 || listBoxStudents.SelectedItem == null)
            {
                MessageBox.Show("Моля, изберете студент за изтриване.");
                return;
            }

            // Вземаме избрания студент
            string? selected = listBoxStudents.SelectedItem?.ToString();
            if (selected == null) return;
            // Намираме фак. номер от текста (защото ToString() съдържа и името, и фак. номер)
            int start = selected.IndexOf('(') + 1;
            int end = selected.IndexOf(')');
            string fn = selected.Substring(start, end - start);

            // Премахваме от списъка
            var selectedItem = listBoxStudents.SelectedItem;
            if (selectedItem == null) return; // няма избран студент

            listBoxStudents.Items.Remove(selectedItem!);
        }

    }
}