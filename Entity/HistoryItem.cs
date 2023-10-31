using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFwiz.Entity
{
    [Serializable]
    internal class HistoryItem
    {
        private int _id;
        private string _name;
        private string _path;
        private System.Drawing.Icon _image;
        private DateTime _datetime;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Path { get { return _path; } set { _path = value; } }
        public System.Drawing.Icon Image { get { return _image; } set { _image = value; } }
        public DateTime Date { get { return _datetime; } set { _datetime = value; } }

    }
}
