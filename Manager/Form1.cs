using Manager.Data.EF;
using Manager.Data.Entity;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadClassRoomToSelect();
            loadStudent();
            //loadClassRoom();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void loadStudent()
        {
            tableStudents.Rows.Clear();
            List<Student> students = AppDbContext.Instance().Students.Include(item => item.ClassRoom).Where(item => item.IsDeleted == false).ToList();
            students.ForEach(student => tableStudents.Rows.Add(student.Id, student.Name, student.Age.ToString(), student.ClassRoom.Name));
        }

        public void loadClassRoomToSelect()
        {
            cbClassRoom.Items.Clear();
            List<ClassRoom> classRooms = AppDbContext.Instance().ClassRoom.ToList();
            classRooms.ForEach(classRoom =>
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = classRoom.Name;
                item.Value = classRoom.Id;
                cbClassRoom.Items.Add(item);
            });

            cbClassRoom.SelectedIndex = 0;
        }

        public void clearInputTextStudent()
        {
            txtName.Text = "";
            txtAge.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;

            if (isNumber(txtAge.Text) == false)
            {
                MessageBox.Show("Tuổi phải là một số");
                return;
            }
            int Age = Convert.ToInt32(txtAge.Text);
            long classRoomId = Convert.ToInt64(((ComboboxItem)cbClassRoom.SelectedItem).Value);

            AppDbContext.Instance().Students.Add(new Student() { Name = Name, Age = Age, ClassRoomId = classRoomId });
            AppDbContext.Instance().SaveChanges();
            clearInputTextStudent();
            loadStudent();
        }

        private bool isNumber(string input)
        {
            int number = 0;
            return int.TryParse(input, out number);
        }

        private void tableStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tableStudents.CurrentRow.Selected = true;
                txtName.Text = tableStudents.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                txtAge.Text = tableStudents.Rows[e.RowIndex].Cells["colAge"].Value.ToString();
                cbClassRoom.SelectedIndex = cbClassRoom.FindString(tableStudents.Rows[e.RowIndex].Cells["colClass"].Value.ToString());
            } catch(Exception ex)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearInputTextStudent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(tableStudents.CurrentRow.Cells["colId"].Value);
            var student = AppDbContext.Instance().Students.FirstOrDefault(item => item.Id == id);
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes && student != null)
            {
                student.IsDeleted = false;

                AppDbContext.Instance().Students.Update(student);
                AppDbContext.Instance().SaveChanges();
                clearInputTextStudent();
            }
            loadStudent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(tableStudents.CurrentRow.Cells["colId"].Value);
            var student = AppDbContext.Instance().Students.FirstOrDefault(item => item.Id == id);
            var confirmResult = MessageBox.Show("Are you sure to update this item ??",
                                     "Confirm Update!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes && student != null)
            {
                string Name = txtName.Text;

                if (isNumber(txtAge.Text) == false)
                {
                    MessageBox.Show("Tuổi phải là một số");
                    return;
                }
                int Age = Convert.ToInt32(txtAge.Text);
                long classRoomId = Convert.ToInt64(((ComboboxItem)cbClassRoom.SelectedItem).Value);

                student.Name = Name;
                student.Age = Age;
                student.ClassRoomId = classRoomId;
                AppDbContext.Instance().Students.Update(student);
                AppDbContext.Instance().SaveChanges();
            }
            loadStudent();
        }

        public void loadClassRoom()
        {
            tableClassRoom.Rows.Clear();

            List<ClassRoom> classRooms = AppDbContext.Instance().ClassRoom.Where(item => item.IsDeleted == false).ToList();
            classRooms.ForEach(c => tableClassRoom.Rows.Add(c.Id, c.Name));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                loadStudent();
                loadClassRoomToSelect();
            } else
            {
                loadClassRoom();
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            string name = txtClassRoomName.Text;

            AppDbContext.Instance().ClassRoom.Add(new ClassRoom() { Name = name });
            AppDbContext.Instance().SaveChanges();
            txtClassRoomName.Text = "";
            loadClassRoom();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            tableStudents.Rows.Clear();
            List<Student> students = AppDbContext.Instance().Students.Include(item => item.ClassRoom).Where(item => item.Name.Contains(keyword) && item.IsDeleted == false).ToList();
            students.ForEach(student => tableStudents.Rows.Add(student.Id, student.Name, student.Age.ToString(), student.ClassRoom.Name));
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(tableClassRoom.CurrentRow.Cells["colRoomId"].Value);

            var classRoom = AppDbContext.Instance().ClassRoom.Include(item => item.Students).FirstOrDefault(item => item.Id == id);

            if (classRoom != null)
            {
                int count = classRoom.Students.Count;
                if (count > 0)
                {
                    MessageBox.Show($"Lớp này đang có {count} học sinh");
                } else
                {
                    var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Update!!",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        classRoom.IsDeleted = true;

                        AppDbContext.Instance().ClassRoom.Update(classRoom);
                        AppDbContext.Instance().SaveChanges();
                        loadClassRoom();
                    }
                }
            }
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(tableClassRoom.CurrentRow.Cells["colRoomId"].Value);
            var classRoom = AppDbContext.Instance().ClassRoom.FirstOrDefault(item => item.Id == id);
            if (classRoom != null)
            {
                string name = txtClassRoomName.Text;

                classRoom.Name = name;
                AppDbContext.Instance().ClassRoom.Update(classRoom);
                AppDbContext.Instance().SaveChanges();
                loadClassRoom();
            }
        }

        private void tableClassRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClassRoomName.Text = tableClassRoom.Rows[e.RowIndex].Cells["colClassRoomName"].Value.ToString();
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtClassRoomName.Text = "";
        }
    }
}