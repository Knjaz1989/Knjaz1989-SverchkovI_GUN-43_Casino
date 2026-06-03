namespace FinalTaskCasino.Inventory
{
    public class User
    {
        private readonly string _name;
        private uint _money = 1000;

        public string Name { get => _name; }
        public uint Money { 
            get => _money; 
            set
            {
                if (value <  0)
                {
                    _money = 0;
                }
                else
                {
                    _money = value;
                }
            }
        }

        public User(string name)
        {
            _name = name;
        }
    }
}
