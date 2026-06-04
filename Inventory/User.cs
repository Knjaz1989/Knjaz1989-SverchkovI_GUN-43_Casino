using FinalTaskCasino.Utils;

namespace FinalTaskCasino.Inventory
{
    public class User
    {
        private readonly string _name;
        private uint _money = GameConstants.UserStartMoney;
        private uint _maxMoney = GameConstants.UserMaxMoney;

        public string Name { get => _name; }
        public uint Money { 
            get => _money; 
            set
            {
                if (value <  0)
                {
                    _money = 0;
                }
                else if (value > _maxMoney)
                {
                    _money = value / 2;
                    Console.WriteLine("You wasted half of your bank money in casino’s bar");
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
