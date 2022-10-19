using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class UserSetObservable
    {
        private List<UserSetObserver> observers = new List<UserSetObserver>();
        public void addObserver(UserSetObserver observer) {
            this.observers.Add(observer);
        }

        public void notify() {
            foreach (UserSetObserver ob in observers) {
                ob.update();
            }
        }
    }
}
