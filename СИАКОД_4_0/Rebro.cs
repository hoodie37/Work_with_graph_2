using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СИАКОД_4_0
{
    class Rebro
    {
        public Node node1;
        public Node node2;
        public bool visited;
        public int Weight;

        public Rebro(Node n1,Node n2)
        {
            visited = false;
            node1 = n1;
            node2 = n2;
        }

        

        public void draw(Graphics g)
        {
            Pen pen;
            Font f = new Font("Arial", 10); ;
            Brush b = new SolidBrush(Color.Black);
            pen = new Pen(Brushes.Black);
                pen.Width = 2;

            g.DrawLine(pen, node1.x, node1.y, node2.x, node2.y);
            int x = 0;
            int y = 0;
            if (node1.x > node2.x)
            {
                 x = (node1.x - node2.x) / 2 + node2.x;
            }
            else
            {
                 x = (node2.x - node1.x) / 2 + node1.x;
            }
            if (node1.y > node2.y)
            {
                y = (node1.y - node2.y) / 2 + node2.y;
            }
            else
            {
                y = (node2.y - node1.y) / 2 + node1.y;
            }
            g.DrawString(Weight.ToString(), f, b,x , y);
        }

    }
}
