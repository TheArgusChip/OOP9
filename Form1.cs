using OOP9.AddForm;
using OOP9.RemoveForm;
using OOP9.DB;
using OOP9.View;

namespace OOP9
{
    public partial class OOP : Form
    {
        private UserService _service;
        private Table _table;
        private AddUserForm _addForm;
        private RemoveUserForm _removeForm;
        private Events _events;

        public OOP()
        {
            InitializeComponent();
            _events = new Events();
            _service = new UserService(_events);
            _table = new Table(dataGridView1, _events, _service);
            _addForm = new AddUserForm(_events);
            _removeForm = new RemoveUserForm(_events);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _table.FillFromDatabase();
        } 

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            string value = Convert.ToString(dataGridView[e.ColumnIndex, e.RowIndex].Value);

            int id = Convert.ToInt32(dataGridView[0, e.RowIndex].Value);
            _events.OnCellEdited.Invoke(value, id, e);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _addForm.ShowDialog();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _removeForm.ShowDialog();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _table.SetBeginValue(e);
        }
    }
}