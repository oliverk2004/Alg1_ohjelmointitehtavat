using System;


class OT2
{
    public static void Main(string[] args) 
    {   
        Random rnd = new Random();
        int[] taulukko = new int[10]; // Luodaan kymmenenalkion taulukko.

        for (int i = 0; i < taulukko.Length; i++)
        {
            taulukko[i] = rnd.Next(1, 50); // Arvotaan luvut väliltä 1-50 kokonaislukutaulukkoon.
        }
        Array.Sort(taulukko); // Järjestetään taulukko suuruusjärjestykseen.
        Console.WriteLine("Taulukko (suuruus: " + taulukko.Length + " alkiota): " + string.Join(",", taulukko));
        Console.WriteLine();
        
        Binaarihaku(taulukko, 10);
        Binaarihaku(taulukko, 20);
        Binaarihaku(taulukko, 30);
        Binaarihaku(taulukko, 40);
        
        // TODO: Tämä ok nyt pienellä taulukolla, mutta toteuta vielä isommalla taulukolla.

        int[] taulukkoSataAlkiota = new int[rnd.Next(50,100)];

        for (int i = 0; i < taulukkoSataAlkiota.Length; i++)
        {
            taulukkoSataAlkiota[i] = rnd.Next(1, 50);
        }
        Array.Sort(taulukkoSataAlkiota);
        Console.WriteLine("Taulukko (suuruus: " + taulukkoSataAlkiota.Length + " alkiota)");


    }

    public static void Binaarihaku(int[] taulukko, int haettavaAlkio)
    {
        int i = -1; // Indeksi alkaa arvosta -1 eli heti taulukon ensimmäisen paikan vasemmalta puolelta ja kasvaa
                    // kohti isompia indeksejä. 
        int j = taulukko.Length; // Indeksi alkaa taulukon viimeisen paikan oikealta puolelta, ja se pienenee
                                 // kohti pienempiä indeksejä. 
        // Haettava alkio pidetään siis koko ajan näiden indeksien välissä ja kun algoritmi päättyy,
        // alkio löytyy paikasta j.
        int vertailuopertaatiot = 0;

        while (j-i > 1)
        {
            vertailuopertaatiot++;
            int k = (i+j) / 2;
            if (haettavaAlkio <= taulukko[k])
            {
                j = k;
            }
            else
            {
                i = k;
            }
        }

        if (j < taulukko.Length && haettavaAlkio == taulukko[j])
        {
            Console.WriteLine("Alkio " + haettavaAlkio + " löytyi paikasta: " + j);
            Console.WriteLine("Vertailuopertaatioita tehtiin: " + vertailuopertaatiot);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Haettu alkio: " + haettavaAlkio + " ei ole taulukossa.");
            Console.WriteLine("Vertailuopertaatioita tehtiin: " + vertailuopertaatiot);
            Console.WriteLine();
        }
    }
}