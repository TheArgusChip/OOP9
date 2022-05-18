namespace OOP9.RemoveForm
{
    internal partial class RemoveUserForm : Form
    {
        private Events _events;
        public RemoveUserForm(Events events)
        {
            InitializeComponent();
            _events = events;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                Remove(id);   
            }
        }

        public void Remove(int id)
        {
            _events.OnUserDelete.Invoke(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
