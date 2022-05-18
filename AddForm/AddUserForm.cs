using OOP9.DB;

namespace OOP9.AddForm
{
    internal partial class AddUserForm : Form
    {
        private Events _events;
        
        public AddUserForm(Events events)
        {
            InitializeComponent();
            _events = events;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = nameBox.Text,
                Surname = surnameBox.Text,
                LastName = lastnameBox.Text,
                Phone = Convert.ToInt64(phoneBox.Text)
            };

            Add(user);
        }

        private void Add(User user)
        {
            _events.OnUserAdd.Invoke(user);
        }
    }
}
