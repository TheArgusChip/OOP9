using OOP9.DB;

namespace OOP9
{
    internal class Events
    {
        public Action<User> OnUserAdd;
        public Action<int> OnUserDelete;
        public Action<string, int, DataGridViewCellEventArgs> OnCellEdited;
    }
}
