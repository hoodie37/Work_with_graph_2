using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СИАКОД_4_0
{
    class Dejkstra
    {
        public Node[] nodes;
        public Rebro[] rebra;
        public Node begin;

        public Dejkstra(Node[] n, Rebro[] r)
        {
            nodes  = n;
            rebra = r;
        }

        public void AlgoritmRun(Node beginp)
        {
            if (this.nodes.Count() == 0 || this.rebra.Count() == 0)
            {
                return;
            }
            else
            {
                beginp.ValueMetka = 0;
                begin = beginp;
                OneStep(beginp);
                foreach (Node point in nodes)
                {
                    Node anotherP = GetAnotherUncheckedPoint();
                    if (anotherP != null)
                    {
                        OneStep(anotherP);
                    }
                    else
                    {
                        break;
                    }

                }
            }

        }
      
        public void OneStep(Node beginpoint)
        {
            foreach (Node nextp in beginpoint.linkedN)
            {
                if (nextp.IsChecked == false)//не отмечена
                {
                    int newmetka = beginpoint.ValueMetka + GetMyRebro(nextp, beginpoint).Weight;
                    if (nextp.ValueMetka > newmetka)
                    {
                        nextp.ValueMetka = newmetka;
                        nextp.predPoint = beginpoint;
                    }
                    else
                    {

                    }
                }
            }
            beginpoint.IsChecked = true;
        }
        private Rebro GetMyRebro(Node n1, Node n2)
        {
            IEnumerable<Rebro> myr = from reb in rebra where ((reb.node1 == n1 & reb.node2 == n2) || (reb.node1 == n2 & reb.node2 == n1)) select reb;
            if (myr.Count() > 1 || myr.Count() == 0)
            {
                return null;
            }
            else
            {
                return myr.First();
            }
        }
        
        private Node GetAnotherUncheckedPoint()
        {
            IEnumerable<Node> pointsuncheck = from p in nodes where p.IsChecked == false select p;
            if (pointsuncheck.Count() != 0)
            {
                float minVal = pointsuncheck.First().ValueMetka;
                Node minPoint = pointsuncheck.First();
                foreach (Node p in pointsuncheck)
                {
                    if (p.ValueMetka < minVal)
                    {
                        minVal = p.ValueMetka;
                        minPoint = p;
                    }
                }
                return minPoint;
            }
            else
            {
                return null;
            }
        }

        public List<Node> MinPath1(Node end)
        {
            List<Node> listOfpoints = new List<Node>();
            Node tempp = new Node();
            tempp = end;
            while (tempp != this.begin)
            {
                listOfpoints.Add(tempp);
                tempp = tempp.predPoint;
            }

            return listOfpoints;
        }

    }
}
