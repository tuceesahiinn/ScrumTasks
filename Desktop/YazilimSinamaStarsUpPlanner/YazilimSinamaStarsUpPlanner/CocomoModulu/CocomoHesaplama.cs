using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazilimSinamaStarsUpPlanner.CocomoModulu
{
    public class CocomoHesaplama
    {
        //projedeki toplam kod satırını analyze->calculate code metrics->for solution->açılan pencerede lines of source code toplam kod sayısını buldum.
        //İş Gücü (K) K= a x S^b
        //Zaman(T) T= c x K^d
        //Yarı – Gömülü Projeler İçin: a=3,0 , b=1,12 , c=2,5 , d= 0,35
        //S: Bin tipinde satır sayısı(4 tane yapılacak iş textboxı olduğu için 4 alarak aldık) 4
        public double IsGucuHesaplama()
        {
            double ust = Math.Pow(4, 1.12);
            double isGucu = 3.0 * ust;
            return isGucu;
        }
        
        public double ZamanHesaplama()
        {
            double c = IsGucuHesaplama();
            double ust = Math.Pow(c, 0.35);
            double zaman = 2.5 * ust;
            return zaman;

        }
    }
}