using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;

namespace WpfDbApplication.Stores
{
    class AccountStore
    {

        public event Action<string> uuidSelected;

        public void SelectedUuid(string uuid)
        {
            uuidSelected?.Invoke(uuid);
        }

    }
}
