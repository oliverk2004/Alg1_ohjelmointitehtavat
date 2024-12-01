using System;
using System.Xml.Serialization;

/// <summary>
/// Ohjelmointitehtävä 3
/// </summary>
class Program
{
    public static void Main(string[] args)
    {
        // Lähdetään muodostamaan puuta juuresta. 
        Solmu juuri = new Solmu(25);
        // Sitten lähdetään lisäämään lapsia. 
        // Lähdetään liikkeelle vasemmasta alipuusta. 
        juuri.Left = new Solmu(15);
        juuri.Left.Left = new Solmu(12);
        juuri.Left.Left.Right = new Solmu(13);
        juuri.Left.Right = new Solmu(20);
        juuri.Left.Right.Left = new Solmu(18);
        juuri.Left.Right.Right = new Solmu(21);
        // Tehdään sitten juuren oikea alipuu. 
        juuri.Right = new Solmu(27);
        juuri.Right.Right = new Solmu(30);
        juuri.Right.Right.Left = new Solmu(28);
        // Binääripuu on nyt siis muodostettu. 

        Console.WriteLine("Käydään seuraavaksi läpi tehtävänannon binääripuu: "); 
        Console.WriteLine("        25\n       /  \\\n     15    27\n    / \\      \\\n  12   20     30\n    \\  / \\    /\n    13 18 21 28"); 
        // Tämä binääripuun piirros konsoliin tehty tekoälyllä...
        
        
        // Puun pitäisi olla näin järjestäynyt:
        // Esijärjestyksessä: 25, 15, 12, 13, 20, 18, 21, 27, 30, 28
        Console.Write("Esijärjestyksessä: ");
        Esi(juuri);
        Console.WriteLine();
        // Sisäjärjestyksessä: 12, 13, 15, 18, 20, 21, 25, 27, 28, 30
        Console.Write("Sisäjärjestyksessä: ");
        Sisa(juuri);
        Console.WriteLine();
        // Jälkijärjestyksessä: 13, 12, 18, 21, 20, 15, 28, 30, 27, 25
        Console.Write("Jälkijärjestyksessä: ");
        Jalki(juuri);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Testataan sitten vielä toisella binääripuulla:");
        Console.WriteLine("        50\n       /  \\\n     30    70\n    / \\    / \\\n  20  40  60  80\n      /      \\\n     35       85");
        // Samoin tämä binääripuun piirto konsoliin on tehty tekoälyllä. 
        
        
        Solmu juuri2 = new Solmu(50);
        juuri2.Left = new Solmu(30);
        juuri2.Left.Left = new Solmu(20);
        juuri2.Left.Right = new Solmu(40);
        juuri2.Left.Right.Left = new Solmu(35);
        juuri2.Right = new Solmu(70);
        juuri2.Right.Right = new Solmu(80);
        juuri2.Right.Left = new Solmu(60);
        juuri2.Right.Right.Right = new Solmu(85);
        
        Console.Write("Esijärjestyksessä: ");
        Esi(juuri2);
        Console.WriteLine();
        
        Console.Write("Sisäjärjestyksessä: ");
        Sisa(juuri2);
        Console.WriteLine();
        
        Console.Write("Jälkijärjestyksessä: ");
        Jalki(juuri2);
        Console.WriteLine();
        
        
        
    }


    /// <summary>
    /// Luokka hakee binääripuusta halutut alkiot. 
    /// </summary>
    public class Solmu
    {
        public int Key;
        public Solmu Left;
        public Solmu Right;


        /// <summary>
        /// Jotta puu pystytään luomaan. 
        /// </summary>
        /// <param name="key"></param>
        public Solmu(int key)
        {
            this.Key = key;
            this.Left = null;
            this.Right = null;
        }
    }


    /// <summary>
    /// Aliohjelma, joka tulostaa binääripuun esijärjestyksessä. 
    /// </summary>
    /// <param name="juuri">juuri, jonka päälle on koottu binääripuu.</param>
    public static void Esi(Solmu juuri)
    {
        if (juuri == null) return; // Jos solmu, jonka kohdalla ollaan (alussa juurisolmu) on null, niin palataan
                                   // puun edelliseen tasoon ja jatkaa siitä eteenpäin. 
        Console.Write(juuri.Key + ","); // Tulostaa solmun arvon, jonka kohdalla ollaan.
        Esi(juuri.Left); // Siirrytään vasempaan alipuuhun. 
        Esi(juuri.Right); // Siirrytään oikeaan alipuuhun.
    }


    /// <summary>
    /// Aliohjelma, joka tulostaa binääripuun sisäjärjestyksessä. 
    /// </summary>
    /// <param name="juuri">juuri, jonka päälle on koottu binääripuu.</param>
    public static void Sisa(Solmu juuri)
    {
        if (juuri == null) return; // Jos solmu, jonka kohdalla ollaan (alussa juurisolmu) on null, niin palataan
                                   // puun edelliseen tasoon ja jatkaa siitä eteenpäin. 
        Sisa(juuri.Left); // Siirrytään vasempaan alipuuhun. 
        Console.Write(juuri.Key + ","); // Tulostaa solmun arvon, jonka kohdalla ollaan.
        Sisa(juuri.Right); // Siirrytään oikeaan alipuuhun. 
    }


    /// <summary>
    /// Aliohjelma, joka tulostaa binääripuun jälkijärjestyksessä. 
    /// </summary>
    /// <param name="juuri">juuri, jonka päälle on koottu binääripuu.</param>
    public static void Jalki(Solmu juuri)
    {
        if (juuri == null) return; // Jos solmu, jonka kohdalla ollaan (alussa juurisolmu) on null, niin palataan
                                   // puun edelliseen tasoon ja jatkaa siitä eteenpäin. 
        Jalki(juuri.Left); // Siirrytään vasempaan alipuuhun. 
        Jalki(juuri.Right); // Siirrytään oikeaan alipuuhun. 
        Console.Write(juuri.Key + ","); // Tulostaa solmun arvon, jonka kohdalla ollaan.
    }
}