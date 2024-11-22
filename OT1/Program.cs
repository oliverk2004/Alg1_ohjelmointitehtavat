using System;



class OT1
{
    public static void Main(string[] args)
    {
        Pino pino = new Pino(5);

        Console.WriteLine("Täytetään pino luvuilla (1,2,3,4,5), ja yritetään täyttää myös luvulla 6, mutta" +
                          "ohjelman pitäisi tulostaa, että pino on täynnä.");
        Console.WriteLine("Käytetään Push-komentoa täyttääksemme pino.");
        Console.WriteLine();
        pino.Push(1);
        pino.Tulosta();
        pino.Push(2);
        pino.Tulosta();
        pino.Push(3);
        pino.Tulosta();
        pino.Push(4);
        pino.Tulosta();
        pino.Push(5);
        pino.Tulosta();
        pino.Push(6); // Tässö konsoliin pitäisi tulla, että "Pino on täynnä!". 
        Console.WriteLine();
        Console.WriteLine("Poistetaan pinosta ylin alkio Pop-komennolla.");
        pino.Pop();
        pino.Tulosta();
        Console.WriteLine();

        Console.WriteLine("Käytetään Top-komentoa eli tulostetaan pinon ylin alkio: " + pino.Top());
        Console.WriteLine("Käytetään Size-komentoa eli tulostetaan pinon koko: " + pino.Size());
        Console.WriteLine("Onko pino tyhjä?: " + pino.isEmpty());
        Console.WriteLine();
        Console.WriteLine("Tyhjennetään sitten pino vielä.");
        pino.Pop();
        pino.Tulosta();
        pino.Pop();
        pino.Tulosta();
        pino.Pop();
        pino.Tulosta();
        pino.Pop();
        pino.Tulosta();
        pino.Pop(); // Pitäisi tulostaa, että "Pino on tyhjä!".
    }
    
}




public class Pino
{
    private int[] pino; // pino, johon alkiot tallennetaan
    private int top; // ylin kohta pinossa (OSOITIN)
    private int maksimikoko; // pinon maksimikoko

    public Pino(int koko)
    {
        pino = new int[koko];
        top = -1; // jotta pino asetetaan aluksi tyhjäksi. 
        maksimikoko = koko;
        
    }

    /// <summary>
    /// Lisää alkion pinon päällimmäiseksi.
    /// </summary>
    /// <param name="arvo">Siirrettävä luku</param>
    public void Push(int arvo)
    {
        if (top >= maksimikoko - 1)
        {
            Console.WriteLine("Pino on täynnä!");
            return;
        }

        top++;
        pino[top] = arvo;
    }


    /// <summary>
    /// Palauttaa ja poistaa pinon päällimmäisen alkion.
    /// </summary>
    /// <returns></returns>
    public int Pop()
    {
        if (isEmpty())
        {
            Console.WriteLine("Pino on tyhjä!");
            return -1;
        }
        
        int luku = pino[top]; // pinon ylin arvo
        pino[top] = 0;
        top--;

        return luku;
    }


    /// <summary>
    /// Palauttaa tiedon, onko pino tyhjä.
    /// </summary>
    /// <returns></returns>
    public bool isEmpty()
    {
        return top == -1;
    }


    
    /// <summary>
    /// Palauttaa pinon alkioiden lukumäärän.
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return top + 1;
    }


    
    /// <summary>
    /// Palauttaa pinon päällimmäisen alkion ilman, että se poistetaan pinosta.
    /// </summary>
    /// <returns></returns>
    public int Top()
    {
        if (isEmpty())
        {
            Console.WriteLine("Pino on tyhjä!");
            return -1;
        }
        
        return pino[top];
    }


    /// <summary>
    /// Tulostaa pinon konsoliin testauksessa.
    /// </summary>
    public void Tulosta()
    {
        Console.Write("Pino: ");
        for (int i = 0; i <= top; i++)
        {
            Console.Write(pino[i] + " ");
        }
        Console.WriteLine();
    }



}