using System;

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] lisaysLajittelunTaulukko = new int[20]; // Luodaan 20 alkion taulukko.
        int[] valintaLajittelunTaulukko = new int[20]; // Luodaan 20 alkion taulukko.
        for (int i = 0; i < lisaysLajittelunTaulukko.Length; i++)
        {
            lisaysLajittelunTaulukko[i] = rnd.Next(1, 50); // Arvotaan luvut väliltä 1-50 kokonaislukutaulukkoon.
        }
        for (int i = 0; i < valintaLajittelunTaulukko.Length; i++)
        {
            valintaLajittelunTaulukko[i] = rnd.Next(1, 50); // Arvotaan luvut väliltä 1-50 kokonaislukutaulukkoon.
        }
        Console.WriteLine("Taulukko ennen lisäyslajittelua: " + string.Join(", ", lisaysLajittelunTaulukko));
        LisaysLajittelu(lisaysLajittelunTaulukko);
        Console.WriteLine("Lisäyslajittelun jälkeen: " + string.Join(", ", lisaysLajittelunTaulukko));

        Console.WriteLine("Taulukko ennen valintalajittelua: " + string.Join(", ", valintaLajittelunTaulukko));
        ValintaLajittelu(valintaLajittelunTaulukko);
        Console.WriteLine("Valintalajittelun jälkeen: " + string.Join(", ", valintaLajittelunTaulukko));
    }



    public static void LisaysLajittelu(int[] taulukko)
    {
        for (int i = 1; i < taulukko.Length; i++) // Käydään läpi koko taulukko. Aloitetaan indeksi i
                                                  // taulukon toisesta alkiosta. 
        {
            int edellinen = i - 1; // taulukon i:tä edeltävä alkio. 
            int key = taulukko[i]; // Asetetaan osoitin nykyiseen taulukon alkioon, jota verrataan edellisiin alkioihin.
            
            while (edellinen >= 0 && taulukko[edellinen] > key) // silmukka vertaukseen onko edellinen alkio suurempi
                                                                // kuin nykyinen alkio (key). 
                                                                // Jos näin on niin siirrytään silmukkaan, jossa
                                                                // edellinen alkio "työnnetään" ylemmäs taulukossa
                                                                // suuruusjärjestyksen näkökulmasta.
            {
                taulukko[edellinen + 1] = taulukko[edellinen]; // tässä kohtaa taulukossa on kaksi kertaa sama alkio.
                                                               // Siirrettävä alkio siis pysyy key-muistipaikassa.
                edellinen--;                                   // Siirrytään taulukossa taaksepäin.
            }
            taulukko[edellinen + 1] = key;                     // Kun silmukka päättyy eli edeltävä alkio ei ole enää
                                                               // suurempi kuin nykyinen niin silloin lisäyslajittelu
                                                               // on key:n kohdalla saatu päätöksen. 
                                                               // Siirrytään siis seuravaan läpikäytävään alkioon
                                                               // taulukossa.
        }
        
        
    }


    public static void ValintaLajittelu(int[] taulukko)
    {

        for (int i = 0; i < taulukko.Length - 1; i++) // Silmukka käy läpi koko taulukon. 
        {
            int pienin = i; // Asetetaan taulukon arvo i pienimmäksi, jotta voidaan verrata seuraaviin alkiohin. 

            for (int j = i+1; j < taulukko.Length; j++) // j lähtee i:n seuraavasta alkiosta. 
            {
                if (taulukko[j] < taulukko[pienin]) // Jos seuraava alkio taulukossa on pienempi kuin edellinen pienin
                                                    // arvo niin...
                {
                    pienin = j; //... muutetaan seuraava alkio pienimmäksi ja jatketaan koko taulukon läpi (silmukka). 
                }
            }
            
            (taulukko[pienin], taulukko[i]) = (taulukko[i], taulukko[pienin]); // Kun pienimmän alkion indeksi on
                                                                               // löytynyt, niin vaihdetaan aluksi
                                                                               // lähdetyn i alkion kanssa se päittäin. 
        } // Näin ohjelma käy läpi kaikki taulukon alkiot.  
    }
}