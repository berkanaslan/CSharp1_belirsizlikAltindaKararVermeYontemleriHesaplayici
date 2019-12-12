using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kararVermeTeknikleriDersiProjesi
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Karar Verme Teknikleri dersi proje ödevi
             *  Belirsizlik altında karar verme yontemleri
             *  YAZARLAR:   Berkan ASLAN - 20174703014 | info@berkanaslan.com
             *              Büşra BOYACı - 20174753032 | 
             *              Rasim Umut Özkurt - 20164753056
             *              netpiksel.com
             */  

            Console.Write("Probleminizdeki OLAY (Alternatif Hareket Birimleri) sayısını giriniz: ");
            int olay = Convert.ToInt32(Console.ReadLine());

            Console.Write("Probleminizdeki STATE saysını giriniz: ");
            int state = Convert.ToInt32(Console.ReadLine());

            Console.Write("Alfa değerini giriniz: ");
            double alfa = Convert.ToDouble(Console.ReadLine());

            /* DEĞİŞKENLER */

            double eksiAlfa = 1 - alfa;
            int diziBuyuklugu = olay * state;
            double[,] matris = new double[olay, state];
            double[] maximax = new double[diziBuyuklugu];
            double[] minimax = new double[diziBuyuklugu];
            double ebState = 0, ekState = 0, pismanlikState = 0, huwState = 0;
            double esOlasilikToplami = 0;
            double[] esOlasiliklarDizisi = new double[diziBuyuklugu];

            double esOlasilikOrani = (1.00 / state);
            double[] pismanlikDizisi = new double[diziBuyuklugu];
            int pismanlikKonumu = 1;
            int ebStateSiraSayisi = 1;
            int ekStateSiraSayisi = 1;
            int esOlasilikSiraSayisi = 0;
            int hurSiraSayisi = 1;
            double[] hurwicsDizisi = new double[diziBuyuklugu];
            /* OLAY - STATE TABLOSU TASLAK GÖRÜNÜMÜ */

            Console.WriteLine();
            Console.WriteLine("------------- OLAY - STATE TABLO GÖRÜNÜMÜ -------------");
            Console.WriteLine();

            for (int i = 0; i < olay; i++)
            {
                Console.Write(i + 1 + ". Olay: ");
                for (int j = 0; j < state; j++)
                {
                    Console.Write(j + 1 + ". State Değeri -- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("------------- OLAY - STATE TABLO GÖRÜNÜMÜ -------------");

            Console.WriteLine();
            Console.WriteLine("------------- TABLO DOLDURMA -------------");
            Console.WriteLine();

            /* OLAYLAR İÇİN STATE DEĞERLERİ GİRİŞİ */

            for (int i = 0; i < olay; i++)
            {
                for (int j = 0; j < state; j++)
                {
                    Console.Write(i + 1 + ". Olayın " + (j + 1) + ". State değerini giriniz: ");
                     matris[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            Console.WriteLine();
            Console.WriteLine("------------- TABLO DOLDURMA -------------");

            /* OLAYLAR İÇİN STATE DEĞERLERİNİ EKRANA YAZDIRMAK */
            Console.WriteLine();
            Console.WriteLine("------------- VERİLERLE BİRLİKTE TABLO GÖRÜNÜMÜ -------------");
            Console.WriteLine();
            for (int i = 0; i < olay; i++)
            {
                Console.Write(i + 1 + ". Olay: --- ");
                for (int j = 0; j < state; j++)
                {
                    Console.Write(j + 1 + ". State Değeri: " + matris[i, j] + " --- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("------------- VERİLERLE BİRLİKTE TABLO GÖRÜNÜMÜ -------------");

            Console.WriteLine();
            Console.WriteLine("------------- HESAPLANAN DEĞERLER -------------");
            Console.WriteLine();

            /* MAXİMAX DEĞERİNİ BULMAK */

            for (int i = 0; i < olay; i++)
            {
                for (int j = 0; j < state; j++)
                {
                    if (maximax[i] < matris[i, j])
                    {
                        maximax[i] = matris[i, j];
                    }
                }
            }

            /* EN BÜYÜK STATE DEĞERİ VE KONUMU */
            ebState = maximax[0];
            for (int i = 0; i < olay; i++)
            {
                if (maximax[i] >= ebState)
                {
                    ebState = maximax[i];
                }
            }

            /* KONUMU */
            int maximaxKonum = Array.IndexOf(maximax, ebState);
            ebStateSiraSayisi = maximaxKonum + 1;

            /* SATIRLARIN EN YÜKSEK DEĞERLERİ */
            Console.WriteLine("------------- MAXİMAX -------------");
            for (int i = 0; i < olay; i++)
            {
                Console.WriteLine(i + 1 + ". OLAYIN en yüksek STATE değeri: " + maximax[i]);
            }
            Console.WriteLine("MAXIMAX yöntemine göre " + ebState + " STATE değeri ile " + ebStateSiraSayisi + ". olay seçilir.");

            /* MİNİMAX DEĞERİNİ BULMAK */
            for (int i = 0; i < olay; i++)
            {
                minimax[i] = matris[i, 0];

                for (int j = 1; j < state; j++)
                {
                    if (matris[i, j] < minimax[i])
                    {
                        minimax[i] = matris[i, j];
                    }
                }
            }

            /* EN KÜÇÜK İÇİNDEN EN BÜYÜK DEĞERİ BULMAK */
            ekState = minimax[0];
            for (int i = 0; i < olay; i++)
            {
                if (ekState < minimax[i])
                {
                    ekState = minimax[i];
                }
            }

            /* KONUMUNU BULMAK */
            int minimaxKonum = Array.IndexOf(minimax, ekState);
            ekStateSiraSayisi = minimaxKonum + 1;

            /* SATIRLARIN EN KÜÇÜK DEĞERLERİ */
            Console.WriteLine();
            Console.WriteLine("------------- MİNİMAX -------------");
            for (int i = 0; i < olay; i++)
            {
                Console.WriteLine(i + 1 + ". OLAYIN en küçük STATE değeri: " + minimax[i]);
            }
            Console.WriteLine("MINIMAX yöntemine göre " + ekState + " STATE değeri ile " + ekStateSiraSayisi + ". olay seçilir.");

            Console.WriteLine();

            /* EŞ OLASILIK HESAPLAMA */

            for (int i = 0; i < olay; i++)
            {
                for (int j = 0; j < state; j++)
                {
                    esOlasilikToplami += matris[i, j];               
                }
                esOlasiliklarDizisi[i] = esOlasilikToplami;
                esOlasilikToplami = 0;
            }

            /* EN YÜKSEK EŞ OLASILIK DEĞERİ */

            double esOlasilikKontrol = esOlasiliklarDizisi[0] * esOlasilikOrani;
            for (int i = 0; i < esOlasiliklarDizisi.Length; i++)
            {
                if (esOlasiliklarDizisi[i] * esOlasilikOrani >= esOlasilikKontrol)
                {
                    esOlasilikKontrol = esOlasiliklarDizisi[i] * esOlasilikOrani;
                }
            }

            esOlasilikSiraSayisi = Array.IndexOf(esOlasiliklarDizisi, esOlasilikKontrol * state);
            esOlasilikSiraSayisi = esOlasilikSiraSayisi + 1;

            /* EŞ OLASILIKLARI EKRANA YAZDIRMAK */
            Console.WriteLine("------------- EŞ OLASILIK -------------");
            for (int i=0; i < olay;i++)
            {
                Console.WriteLine(i + 1 + ". OLAY için EŞ OLASILIK değeri: " + esOlasiliklarDizisi[i] * esOlasilikOrani);
            }

            /* EŞ OLASILIK SONUCU YAZDIRMAK */
            Console.WriteLine("EŞ OLASILIK yöntemine göre en büyük STATE değeri olan " + esOlasilikKontrol + " değeri ile "+ esOlasilikSiraSayisi+". olay seçilir.");

            /* HURWİCS KRİTERİ */
            Console.WriteLine();
            Console.WriteLine("------------- HURWICS KRİTERİ -------------");

            Console.WriteLine("ALFA Değeri: "+alfa);
            Console.WriteLine("1-ALFA Değeri: " + eksiAlfa);
            for (int i=0; i < olay;i++)
            {
                hurwicsDizisi[i] = (maximax[i] * alfa) + (minimax[i] * eksiAlfa);
                Console.WriteLine(i + 1 + ". OLAY için HURWICS değeri: " + hurwicsDizisi[i]);
            }

            /* EN BÜYÜK HUWRICS DEĞERİ VE KONUMU */
            huwState = hurwicsDizisi[0];
            for (int i = 0; i < olay; i++)
            {
                if (hurwicsDizisi[i] >= huwState)
                {
                    huwState = hurwicsDizisi[i];
                }
            }

            /* KONUMU */
            int huwKonum = Array.IndexOf(hurwicsDizisi, huwState);
            hurSiraSayisi = huwKonum + 1;

            Console.WriteLine("HURWICS KRİTERİ yöntemine göre " + huwState + " değeri ile " + hurSiraSayisi + ". olay seçilir.");

            /* PİŞMANLIK KRİTERİ */
            Console.WriteLine();
            Console.WriteLine("------------- PİŞMANLIK KRİTERİ -------------");
            for (int i =0;i<olay;i++)
            {
                for (int j =0; j<state; j++)
                {
                    if (pismanlikDizisi[i] < matris[i, j])
                    {
                        pismanlikDizisi[i] = matris[i, j];
                    }
                }
            }

            /* SATIRLARIN EN BÜYÜK DEĞERLERİ */
            for (int i = 0; i < olay;i++)
            {
                Console.WriteLine(i + 1 + ". OLAYIN en yüksek STATE değeri: " + pismanlikDizisi[i]);
            }

            /* EN KÜÇÜK PİŞMANLIK DEĞERİ VE KONUMU */
            pismanlikState = pismanlikDizisi[0];
            for (int i = 0; i < olay; i++)
            {
                if (pismanlikDizisi[i] < pismanlikState)
                {
                    pismanlikState = pismanlikDizisi[i];
                }
            }

            /* KONUMUNU BULMA */
            int pismanlikSiraSayisi = Array.IndexOf(pismanlikDizisi, pismanlikState);
            pismanlikKonumu = pismanlikSiraSayisi + 1;


            /* PİŞMANLIK KRİTERİ SONUCU YAZDIRMAK */
            Console.WriteLine("PİŞMANLIK KRİTERİ yöntemine göre " + pismanlikState + " değeri ile " + pismanlikKonumu + ". olay seçilir.");

            Console.WriteLine();
            Console.WriteLine("------------- HESAPLANAN DEĞERLER -------------");



            Console.WriteLine("Berkan ASLAN - berkanaslan.com | netpiksel.com | info@berkanaslan.com");
            Console.ReadLine();
        }
}
    }