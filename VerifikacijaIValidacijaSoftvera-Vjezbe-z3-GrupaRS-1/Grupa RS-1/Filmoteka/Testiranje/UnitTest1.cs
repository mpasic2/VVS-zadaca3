using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Filmoteka;
using System;

namespace Testiranje
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRadSaKorisnicima()
        {
            List<Gost> gosti = new List<Gost> { };
            Filmoteka.Filmoteka f = new Filmoteka.Filmoteka();
            for (int i = 0; i < 50000; i++)
            {
                gosti.Add(new Gost("himzopolovina", "HIMZOPOLOVINA", "Mujo", "Mujić"));
                gosti[i].Id = i.ToString();
            }
            int a = 0;
            for (int i = 0; i < 50000; i++)
            {
                f.RadSaKorisnicima4(gosti[i], 0);
            }
            int b = 0;
            Assert.IsTrue(true);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak()
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("", "");
        }
        [TestMethod]
        public void TestAutomatskiPodaci()
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("Duga", "Dugicki");
            Assert.IsTrue(tuple.Item1.Equals("dudugickiga"));
            Assert.AreEqual("DUDUGICKIGA", tuple.Item2);
        }
        [TestMethod]
        public void TestAutomatskiPodaciDugo()
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("HalimaHalima", "HalimicHalima");
            string ocekivano = "hahalimichalimalimah";
            Assert.IsTrue(tuple.Item1.Equals(ocekivano));
            Assert.AreEqual(ocekivano.ToUpper(), tuple.Item2);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak1()//ime = null, prezime  = null
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci(null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak2()//ime = ima brojeve, prezime  = slova
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("Mustafa245", "Mustafic");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak3()//ime = slova, prezime  = ima brojeve
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("Mustafa", "Mus25ic");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak4()//ime = ima brojeve, prezime  = ima brojeve
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("Mustafa02", "Pas48ic");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak5()//ime = slova, prezime  = null
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("Mustafa", null);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak6()//ime = ima brojeve, prezime  = null
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci("Mustafa54", null);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak7()//ime = null, prezime  = brojevi
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci(null, "Mustafic58");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAutomatskiPodaciIzuzetak8()//ime = null, prezime  = slova
        {

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci(null, "Mustafic");
        }
        [TestMethod]
        public void TestUnernamePasswordManjeOd20()
        {
            string ime = "Malo";
            string prezime = "Manjic";

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci(ime, prezime);
            Assert.AreEqual("mamanjiclo", tuple.Item1);
            Assert.AreEqual("MAMANJICLO", tuple.Item2);
        }
        [TestMethod]
        public void TestUnernamePasswordVeceOd20()
        {
            string ime = "Velikoimekorisnikaaplikacije";
            string prezime = "Velikoprezimekorisnikaaplikacije";

            Tuple<string, string> tuple = Gost.AutomatskiKorisničkiPodaci(ime, prezime);
            Assert.AreEqual("vevelikoprezimekoris", tuple.Item1);
            Assert.AreEqual("VEVELIKOPREZIMEKORIS", tuple.Item2);
        }
    }

}