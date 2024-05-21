using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PoolTable : INotifyPropertyChanged
    {
        private int height;
        private int width;

        public PoolTable(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }
    }
}
