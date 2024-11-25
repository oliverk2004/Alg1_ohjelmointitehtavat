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

        Console.WriteLine("--------------------------------------------------------------------------------");

        int[] taulukkoSataAlkiota = new int[rnd.Next(50,100)]; // Luodaan taulukko, jonka suuruus on 50-100 alkion väliltä. 

        for (int i = 0; i < taulukkoSataAlkiota.Length; i++)
        {
            taulukkoSataAlkiota[i] = rnd.Next(1, 50); // Arvotaan luvut väliltä 1-50 kokonaislukutaulukkoon.
        }
        Array.Sort(taulukkoSataAlkiota); // Järjestetään taulukko suuruusjärjestykseen.
        Console.WriteLine("Taulukko (suuruus: " + taulukkoSataAlkiota.Length + " alkiota).");
        Console.WriteLine();
        
        Binaarihaku(taulukkoSataAlkiota, 10);
        Binaarihaku(taulukkoSataAlkiota, 20);
        Binaarihaku(taulukkoSataAlkiota, 30);
        Binaarihaku(taulukkoSataAlkiota, 40);


    }

    public static void Binaarihaku(int[] taulukko, int haettavaAlkio)
    {
        int i = -1; // Indeksi alkaa arvosta -1 eli heti taulukon ensimmäisen paikan vasemmalta puolelta ja kasvaa
                    // kohti isompia indeksejä. 
        int j = taulukko.Length; // Indeksi alkaa taulukon viimeisen paikan oikealta puolelta, ja se pienenee
                                 // kohti pienempiä indeksejä. 
        // Haettava alkio pidetään siis koko ajan näiden indeksien välissä ja kun algoritmi päättyy,
        // alkio löytyy paikasta j.
        int vertailuopertaatiot = 0; // tallennetaan vertailuoperaatioiden lukumäärä. 

        while (j-i > 1) // while-silmukka jatkaa kunnes taulukossa ei ole alkiota eli näiden erotus on < 1. 
        {
            vertailuopertaatiot++;
            int k = (i+j) / 2; // Selvitetään taulukon keskikohta. 
            if (haettavaAlkio <= taulukko[k]) // Jos haettava alkio on pienempi kuin taulukon keskikohta.
            {
                j = k; // Siirretään indeksi j taulukon keskikohtaan, jolloin käsitellään taulukon alkioita, jotka
                       // ovat pienempiä kuin taulukon keskikohta (binäärihaussa juuri). 
            }
            else // Jos taas suurempi, niin...
            {
                i = k; //... Siirretään indeksi i keskikohtaan, jolloin käsitellään taulukon alkoita, jotka
                       //ovat suurempia kuin taulukon "juuri". 
            }
        }

        if (j < taulukko.Length && haettavaAlkio == taulukko[j]) // Jos j on taulukon "sisällä" ja haettavaAlkio löytyy.
        {
            Console.WriteLine("Alkio " + haettavaAlkio + " löytyi paikasta: " + j);
            Console.WriteLine("Vertailuopertaatioita tehtiin: " + vertailuopertaatiot);
            Console.WriteLine();
        }
        else // Jos haettavaAlkio ei löytynyt niin.
        {
            Console.WriteLine("Haettu alkio: " + haettavaAlkio + " ei ole taulukossa.");
            Console.WriteLine("Vertailuopertaatioita tehtiin: " + vertailuopertaatiot);
            Console.WriteLine();
        }
    }
}