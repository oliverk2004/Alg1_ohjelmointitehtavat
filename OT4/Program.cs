using System;

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] taulukko = new int[20]; // Luodaan 20 alkion taulukko.

        for (int i = 0; i < taulukko.Length; i++)
        {
            taulukko[i] = rnd.Next(1, 50); // Arvotaan luvut väliltä 1-50 kokonaislukutaulukkoon.
        }

        Console.WriteLine(string.Join(", ", taulukko));
        LisaysLajittelu(taulukko);
        Console.WriteLine(string.Join(", ", taulukko));
    }



    public static void LisaysLajittelu(int[] taulukko)
    {
        for (int i = 1; i < taulukko.Length; i++) // Käydään läpi koko taulukko.
        {
            int edellinen = i - 1;
            int key = taulukko[i];
            
            while (edellinen >= 0 && taulukko[edellinen] > key)
            {
                taulukko[edellinen + 1] = taulukko[edellinen];
                edellinen--;
            }
            taulukko[edellinen + 1] = key;
        }
    }
}