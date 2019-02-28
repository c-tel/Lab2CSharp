using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Telizhenko.Models
{
    public class Storage
    {
        public event Action<UserData> UserDataChanged;

        public UserData CurrentUserData { get; private set; }

        public void SetUserData(UserData nextData)
        {
            CurrentUserData = nextData;
            UserDataChanged?.Invoke(CurrentUserData);
        }

    }
}
