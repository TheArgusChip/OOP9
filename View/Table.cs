using OOP9.DB;

namespace OOP9.View
{
    internal class Table
    {
        private DataGridView _target;
        private UserService _userService;
        private string _oldValue;

        public Table(DataGridView dataGridView, Events events, UserService service)
        { 
            _target = dataGridView;
            events.OnUserDelete += Remove;
            events.OnUserAdd += Add;
            events.OnCellEdited += CheckCellValue;
            _userService = service;
        }

        public void Add(User user)
        {
            _target.Rows.Add(user.ID, user.Surname, user.Name, user.LastName, user.Phone);
        }

        public void Remove(int id)
        {
            int index = -1;
            for (int i = 0; i < _target.Rows.Count; i++)
            {
                int current = Convert.ToInt32(_target[0, i].Value);
                if (current == id)
                {
                    index = i;
                }
            }

            if (index != -1)
            {
                _target.Rows.RemoveAt(index);
            }
        }

        internal void CheckCellValue(string value, int _, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && long.TryParse(value, out long t) == false)
            {
                _target[e.ColumnIndex, e.RowIndex].Value = _oldValue;
            }
        }

        internal void FillFromDatabase()
        {
            var allUsers = _userService.PhoneBooks;
            foreach (var user in allUsers)
            {
                Add(user);
            }
        }

        internal void SetBeginValue(DataGridViewCellCancelEventArgs e)
        {
            _oldValue = Convert.ToString(_target[e.ColumnIndex, e.RowIndex].Value);
        }
    }
}
