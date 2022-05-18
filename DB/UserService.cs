namespace OOP9.DB
{
    internal class UserService
    {
        private UserContext _context;

        public UserService(Events events)
        {
            _context = new UserContext();
            events.OnUserAdd += Add;
            events.OnUserDelete += RemoveBy;
            events.OnCellEdited += Edit;
        }

        public List<User> PhoneBooks => _context.PhoneBooks.ToList();

        internal void Add(User user)
        {
            _context.PhoneBooks.Add(user);
            _context.SaveChanges();
        }

        internal void Edit(string value, int id, DataGridViewCellEventArgs e)
        {
            var user = _context.PhoneBooks.Where(x => x.ID == id).FirstOrDefault();
            if (e.ColumnIndex < 4)
            {
                user[e.ColumnIndex] = value;
            }
            else if (long.TryParse(value, out long t))
            {
                user[e.ColumnIndex] = value;
            }
            _context.SaveChanges();
        }

        internal void SetInfo(object sender, DataGridViewCellEventArgs e)
        {
            string value;
            DataGridView table;
            try
            {
                table = (DataGridView)sender;
                value = Convert.ToString(table[e.ColumnIndex, e.RowIndex].Value);
            }
            catch
            {
                return;
            }

            int id = Convert.ToInt32(table[0, e.RowIndex].Value);
            var user = _context.PhoneBooks.Where(x => x.ID == id).FirstOrDefault();

            user[e.ColumnIndex] = value;
            _context.SaveChanges();
        }

        internal void RemoveBy(int id)
        {
            var user = _context.PhoneBooks.Where(x => x.ID == id).FirstOrDefault();

            if (user != null)
            {
                _context.PhoneBooks.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
