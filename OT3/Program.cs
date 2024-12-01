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
        
        // TODO: Korjaa nämä koska nämä edellisestä demotehtävästä ja pitää muokata tähän tehtävään sopivaksi.
        // Seuraavaksi käytetään Solmu-luokkaa tulostaakseemme juurisolmun oikean puoleisen lapsisolmun arvon. 
        Console.WriteLine("Juurisolmun oikeanpuoleisen lapsisolmun arvo on: " + juuri.Right.Key);
        // Sitten vielä tulostetaan äsken tulostetun solmun vasemmanpuoleisen lapsisolmun arvo.
        Console.WriteLine("Edellä tulostetun oikeanpuoleisen lapsisolmun arvo on: " + juuri.Right.Right.Key);
        
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


    public static void Esi(Solmu juuri)
    {
        if (juuri == null) return;
        Console.Write(juuri.Key + ",");
        Esi(juuri.Left);
        Esi(juuri.Right);
    }


    
    public static void Sisa(Solmu juuri)
    {
        if (juuri == null) return;
        Sisa(juuri.Left);
        Console.Write(juuri.Key + ",");
        Sisa(juuri.Right);
    }


    public static void Jalki(Solmu juuri)
    {
        if (juuri == null) return;
        Jalki(juuri.Left);
        Jalki(juuri.Right);
        Console.Write(juuri.Key + ",");
    }
}