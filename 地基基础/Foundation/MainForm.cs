using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Foundation
{
    public partial class MainForm : Form
    {
        XmlDocument xmlDocCon = new XmlDocument();
        XmlNodeList conNodeList;
        XmlNodeList fcList;
        XmlNodeList ftList;
        XmlNodeList fckList;
        XmlNodeList ftkList;
        XmlDocument xmlDocSteel = new XmlDocument();
        XmlNodeList steelNodeList;
        List<Concrete> conList = new List<Concrete>();

        XmlNodeList fyList;
        XmlNodeList fykList;
        XmlNodeList fstkList;
        XmlNodeList fypList;
        List<Steel> steelList = new List<Steel>();

        public MainForm()
        {
            InitializeComponent();
            xmlDocCon.Load("Concrete.XML");
            conNodeList = xmlDocCon.GetElementsByTagName("ConcreteGrade");
            fcList = xmlDocCon.GetElementsByTagName("fc");
            ftList = xmlDocCon.GetElementsByTagName("ft");
            fckList = xmlDocCon.GetElementsByTagName("fck");
            ftkList = xmlDocCon.GetElementsByTagName("ftk");
            for (int i = 0; i < conNodeList.Count; i++)
            {
                comboBoxConcrete.Items.Add(conNodeList[i].Attributes["name"].Value);
                Concrete con = new Concrete();
                con.Name = conNodeList[i].Attributes["name"].Value;
                con.Fc = Convert.ToDouble (fcList[i].InnerText);
                con.Ft = Convert.ToDouble(ftList[i].InnerText);
                con.Fck = Convert.ToDouble(fckList[i].InnerText);
                con.Ftk= Convert.ToDouble(ftkList[i].InnerText);
                conList.Add(con);
                
            }
            xmlDocSteel.Load(@"Steel.XML");
            steelNodeList = xmlDocSteel.GetElementsByTagName("SteelGrade");
            fyList = xmlDocSteel.GetElementsByTagName("fy");
            fypList = xmlDocSteel.GetElementsByTagName("fyp");
            fykList = xmlDocSteel.GetElementsByTagName("fyk");
            fstkList = xmlDocSteel.GetElementsByTagName("fstk");
            for (int i = 0; i < steelNodeList.Count; i++)
            {
                comboBoxSteel.Items.Add(steelNodeList[i].Attributes["name"].Value);
                Steel steel = new Steel();
                steel.Name = steelNodeList[i].Attributes["name"].Value;
                steel.Fy = Convert.ToDouble(fyList[i].InnerText);
                steel.Fyp = Convert.ToDouble(fypList[i].InnerText);
                steel.Fyk = Convert.ToDouble(fykList[i].InnerText);
                steel.Fstk = Convert.ToDouble(fstkList[i].InnerText);
                steelList.Add(steel);
            }
        }
        private void buttonRock_Click(object sender, EventArgs e)
        {
            double frk = Convert.ToDouble(textBoxFrk.Text);
            RockType rt = new RockType(frk);
            string str = rt.GetRockType();
            MessageBox.Show("岩石的坚硬程度为："+str);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double vt = Convert.ToDouble(textBoxVt.Text);
            double vk = Convert.ToDouble(textBoxVk.Text);
            RockCompletity rc = new RockCompletity(vt, vk);
            string str = rc.JudgeCompletity();
            MessageBox.Show("岩体完整程度：" + str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double W = Convert.ToDouble(textBoxW.Text);
            double WL = Convert.ToDouble(textBoxWL.Text);
            double Wp = Convert.ToDouble(textBoxWP.Text);
            SoilIL sl = new SoilIL(W, Wp, WL);
            string str = sl.JudgeSolid();
            MessageBox.Show("液性指数IL=" + sl.IL + ",粘性土的状态为：" + str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double E1 = Convert.ToDouble(textBoxE1.Text);
            double E2 = Convert.ToDouble(textBoxE2.Text);
            SoilEp sep = new SoilEp(E1, E2);
            string str = sep.GetA12();
            MessageBox.Show("a1-2=" + sep.A12 + "MPa-1"+",土的压缩性为：" + str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double B = Convert.ToDouble(textBoxb.Text);
            double d = Convert.ToDouble(textBoxd.Text);
            double fak = Convert.ToDouble(textBoxFak.Text);
            double nb = Convert.ToDouble(textBoxnb.Text);
            double nd = Convert.ToDouble(textBoxnd.Text);
            double r = Convert.ToDouble(textBoxr.Text);
            double rm = Convert.ToDouble(textBoxrm.Text);
            BaseFAK f = new BaseFAK(fak,nb,nd,B,r,rm,d);
            MessageBox.Show("修正后地基承载力："+f.CalFa1()+"Kpa");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double b = Convert.ToDouble(textBoxbb.Text);
            double d = Convert.ToDouble(textBoxbd.Text);
            double mb = Convert.ToDouble(textBoxmb.Text);
            double md = Convert.ToDouble(textBoxmd.Text);
            double mc = Convert.ToDouble(textBoxmc.Text);
            double r = Convert.ToDouble(textBoxr.Text);
            double rm = Convert.ToDouble(textBoxrm.Text);
            double faik = Convert.ToDouble(textBoxfaik.Text);
            double ck = Convert.ToDouble(textBoxck.Text);
            BaseFAK f = new BaseFAK(mb, md, mc, b, r, rm, d,ck, 15);
            MessageBox.Show("地基承载力：" + f.CalFa2(b) + "Kpa");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double psir = Convert.ToDouble(textBoxpsir.Text);
            double frk = Convert.ToDouble(textBoxbfrk.Text);
            BaseFAK f = new BaseFAK(psir, frk);
            MessageBox.Show("地基承载力：" + f.CalFa3() + "Kpa");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double fk = Convert.ToDouble(textBoxpfk.Text);
            double vk = Convert.ToDouble(textBoxpvk.Text);
            double mk = Convert.ToDouble(textBoxpmk.Text);
            double l = Convert.ToDouble(textBoxplx.Text);
            double b = Convert.ToDouble(textBoxpb.Text);
            double d = Convert.ToDouble(textBoxpd.Text);
            double rm = Convert.ToDouble(textBoxprm.Text);
            BasePk bpk=new BasePk (b,l,d,fk,vk,mk,rm);
            textBoxpgk.Text = bpk.Gk.ToString();
           // MessageBox.Show("Pmaxk：" + bpk.CalPmaxk() + "Kpa;" + "Pmink：" + bpk.CalPmink() + "Kpa;");
            if (bpk.E0 <= bpk.L / 6)
            {
                textBoxEL.Text = "e<=L/6";
            }
            else
            {
                textBoxEL.Text = "e>L/6";
            }
            textBoxpmaxk.Text = bpk.CalPmaxk() + "";
            textBoxpmink.Text = bpk.CalPmink() + "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBoxTa.Text);
            double b = Convert.ToDouble(textBoxTb.Text);
            double h = Convert.ToDouble(textBoxTh.Text);
            Shape t = new Shape(a, b, h);
            MessageBox.Show("形心x,y:" + t.Cx + "," + t.Cy+";面积为:"+t.Area);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double fai = Convert.ToDouble(textBoxspfai.Text);
            SoilPress sp = new SoilPress(0, fai);
            textBoxspk0.Text = sp.K0.ToString();
            textBoxspka.Text = sp.Ka.ToString();
            textBoxspkp.Text = sp.Kp.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double alfa = Convert.ToDouble(textBoxalfa.Text);
            double beta = Convert.ToDouble(textBoxbeta.Text);
            double psi = Convert.ToDouble(textBoxpsi.Text);
            double sita = Convert.ToDouble(textBoxsita.Text);
            double sr = Convert.ToDouble(textBoxsr.Text);
            double sh = Convert.ToDouble(textBoxsh.Text);
            double sc = Convert.ToDouble(textBoxsc.Text);
            double q = Convert.ToDouble(textBoxsq.Text);
            SoilPress sp=new SoilPress (alfa,beta,psi,sita,sr,sh,sc,q);
            textBoxskq.Text = sp.Kq.ToString();
            textBoxsyt.Text = sp.Yita.ToString();
            textBoxska.Text = sp.CalSoilKa().ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            double fl = Convert.ToDouble(textBoxFl.Text);
            double um= Convert.ToDouble(textBoxum.Text);
            double h0 = Convert.ToDouble(textBoxh0.Text);
            double fas = Convert.ToDouble(textBoxfas.Text);
            double cab = Convert.ToDouble(textBoxcab.Text);
            double Is = Convert.ToDouble(textBoxis.Text);
            double munb = Convert.ToDouble(textBoxmunb.Text);
            Plate plate = new Plate(fl, um, h0, fas, cab, Is,munb);
            MessageBox.Show("最大剪应力：" + plate.GetTaoMax()+"Kpa");
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double a1 = Convert.ToDouble(textBoxma1.Text);
            double l = Convert.ToDouble(textBoxml.Text);
            double b = Convert.ToDouble(textBoxmbb.Text);
            double ap = Convert.ToDouble(textBoxmap.Text);
            double bp = Convert.ToDouble(textBoxmbp.Text);
            double pmax = Convert.ToDouble(textBoxmpmax.Text);
            double pmin = Convert.ToDouble(textBoxmpmin.Text);
            double Gk = Convert.ToDouble(textBoxmgk.Text);
            BaseMoment bm = new BaseMoment(a1,b, l, bp, ap, pmax, pmin,Gk);
            textBoxmp1.Text = bm.P1.ToString();
            textBoxmarea.Text = bm.Area.ToString();
            textBoxmm1.Text = bm.M1().ToString();
            textBoxmm2.Text = bm.M2().ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string str = this.comboBoxConcrete.SelectedItem.ToString();
             for (int i = 0; i < conList.Count; i++)
             {
                 if (str == conList[i].Name)
                 {
                     textBoxfc.Text = conList[i].Fc.ToString();
                     textBoxftk.Text = conList[i].Ftk.ToString();
                 }
             }
           
        }

        private void comboBoxSteel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = this.comboBoxSteel.SelectedItem.ToString();
            for (int i = 0; i < steelList.Count; i++)
            {
                if (str == steelList[i].Name)
                {
                    textBoxpilefy.Text = steelList[i].Fy.ToString();
                    textBoxGfy.Text = steelList[i].Fy.ToString(); ;
                    textBoxSfyk.Text = steelList[i].Fyk.ToString();
                }
            }
        }

        private void buttonpilegz_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBoxpilen.Text);
            int d = Convert.ToInt32(textBoxpileasd.Text);
            Steel steel = new Steel();
            steel.N = n;
            steel.D = d;
            textBoxpileas.Text = steel.AllArea.ToString();

            double dia = Convert.ToDouble(textBoxpiled.Text);
            Pile p = new Pile(dia);
            double pv =Math.Round(steel.AllArea / p.Area*100,4);
            MessageBox.Show("计算配筋率%："+pv+",插值配筋率%："+p.GetDemandPv()+",钢筋净距为mm："+p.GetSn(steel.N,steel.D));
                
        }

        private void buttonpileself_Click(object sender, EventArgs e)
        {
            double dia = Convert.ToDouble(textBoxpiled.Text);
            double fc = Convert.ToDouble(textBoxfc.Text);
            double fy = Convert.ToDouble(textBoxpilefy.Text);
            int n = Convert.ToInt32(textBoxpilen.Text);
            int d = Convert.ToInt32(textBoxpileasd.Text);
            double SteelAs = 3.14 * d * d / 4 * n;
            textBoxpileas.Text = SteelAs.ToString();
            double fai = Convert.ToDouble(textBoxpilefaic.Text);
            Pile p = new Pile(dia, fc, fy, SteelAs, fai);
            MessageBox.Show("已知配筋求得压力设计值为KN："+Math.Round(p.GetP()/1000,3));
        }

        private void buttonpilew_Click(object sender, EventArgs e)
        {
            double dia = Convert.ToDouble(textBoxpiled.Text);
            double ftk = Convert.ToDouble(textBoxftk.Text);
            double fy = Convert.ToDouble(textBoxpilefy.Text);
            double Qk = Convert.ToDouble(textBoxpileq.Text);
            int n = Convert.ToInt32(textBoxpilen.Text);
            int d = Convert.ToInt32(textBoxpileasd.Text);
            double SteelAs = 3.14 * d * d / 4 * n;
            textBoxpileas.Text = SteelAs.ToString();
            double cover = Convert.ToInt32(textBoxCover.Text);
            Pile pile=new Pile(dia);
            double stress = Qk * 1000 / 1.3 / SteelAs;
            Concrete concrete = new Concrete(ftk, stress, n, 0, d, 0, cover,pile.Area);
            textBoxRa.Text = Math.Round(Qk / 1.3, 3).ToString();
            MessageBox.Show("裂缝(mm):"+concrete.CalWma(2.7,200000));
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double Ra = Convert.ToDouble(textBoxGRa.Text);
            double fy=Convert.ToDouble(textBoxGfy.Text);
            double As = Ra * 1.30 * 1000 / fy;
            MessageBox.Show("As2：" + As+"，抗拔工程桩桩身配筋取Max{As1，As2}");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double Nk = Convert.ToDouble(textBoxNk.Text);
            double fyk = Convert.ToDouble(textBoxSfyk.Text);
            double As = Nk * 1.25 * 1000 / fyk;
            MessageBox.Show("As：" + As+"，抗拔试桩桩身配筋取As");
        }


    }
}
