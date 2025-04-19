//VOID
using System;
using System.IO;
string[] RiempiVocabolario(char[,] puzzle, Random rnd, string vocali, string consonanti)
{
    string percorso = @"../../../../paroleItaliane.txt";
    int r, c, Nparole=rnd.Next(5,puzzle.GetLength(0)), verso;
    bool scrivi=true;
    string[] linea = File.ReadAllLines(percorso);
    string[] usate=new string[Nparole];
    string parola;
    //AGIUNGO LE PAROLE
    for (int k = 0; k < usate.Length; k++)
    {
        parola = linea[rnd.Next(0, linea.Length)];
        r = rnd.Next(0, puzzle.GetLength(0));
        c = rnd.Next(0, puzzle.GetLength(0));
        verso = rnd.Next(0, 8);
        if (parola.Length < 4||parola.Length>puzzle.GetLength(0))
        {
            scrivi = false;
        }
        foreach (string x in usate)
        {
            if (x == null)
            {
                break;
            }
            if (x == parola||parola.Contains(x)||x.Contains(parola))
            {
                scrivi = false;
            }
        }
        if (scrivi)
        {
            switch (verso)
            {
                //ORIZZ
                case 0:
                    if (parola.Length <= puzzle.GetLength(0) - c - 1)
                    {
                        for (int i = c; i < parola.Length + c; i++)
                        {
                            if (puzzle[r, i] != '\0' && puzzle[r, c] != parola[i - c])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                c++;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //ORIZZ INV
                case 4:
                    if (parola.Length <= c)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r, c - i] != '\0' && puzzle[r, c - i] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                c--;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //VERT
                case 1:
                    if (parola.Length <= puzzle.GetLength(0) - r - 1)
                    {
                        for (int i = r; i < parola.Length + r; i++)
                        {
                            if (puzzle[i, c] != '\0' && parola[i - r] != puzzle[i, c])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                r++;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //VERT INV
                case 5:
                    if (parola.Length <= r)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r - i, c] != '\0' && puzzle[r - i, c] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                r--;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //OBL1
                case 2:
                    if (parola.Length <= puzzle.GetLength(0) - Math.Max(r, c))
                    {
                        for(int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r + i, c + i] != '\0' && puzzle[r + i, c + i] != parola[i])
                            {
                                scrivi = false;
                            }
                        }
                        if (scrivi)
                        {
                            for(int i=0;i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                r++;
                                c++;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //OBL1 INV
                case 6:
                    if (parola.Length <= Math.Min(r,c)+1)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r - i, c - i] != '\0' && puzzle[r - i, c - i] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                r--;
                                c--;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //OBL2
                case 3:
                    if (parola.Length <= Math.Min(puzzle.GetLength(0)-1-r, c)+1)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r+i,c-i] != '\0' && puzzle[r+i,c-i] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, c] = parola[i];
                                r++;
                                c--;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //OBL2 INV
                case 7:
                    if(parola.Length <= Math.Min(r,5-c)+1)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r-i,c+i] != '\0' && puzzle[r - i, c+i] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for(int i=0; i < parola.Length; i++)
                            {
                                puzzle[r,c]=parola[i];
                                r--;
                                c++;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
            }
        }
        if (scrivi)
        {
            usate[k] = parola;
        }
        if (!scrivi)
        {
            scrivi = true;
            k--;
        }
    }
    //CONTROLLO GLI SPAZI BIANCHI
    riempiPuzzle(vocali, consonanti, puzzle, rnd);
    return linea;
}
void riempiPuzzle(string vocali, string consonanti, char[,] puzzle, Random rnd)
{
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        for (int j = 0; j < puzzle.GetLength(1); j++)
        {
            if (puzzle[i, j] == '\0')
            {
                if (rnd.Next(0, 2) == 0)
                {
                    puzzle[i, j] = vocali[rnd.Next(0, vocali.Length)];
                }
                else
                {
                    puzzle[i, j] = consonanti[rnd.Next(0, consonanti.Length)];
                }
            }
        }
    }
}
void scriviPuzzle(char[,] puzzle, char[,] colori)
{
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        for (int j = 0; j < puzzle.GetLength(1); j++)
        {
            Console.Write("[");
            if (colori[i, j] == '\0')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(puzzle[i, j]);
            if (puzzle[i, j] == '\0')
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");
        }
        Console.WriteLine();
    }
}
bool inserimento(char[,] puzzle, string parola, ref string usate,string[] paroleDaIndovinare, char[,] colori)
{
    int giuste = 0, errore = 0, riga=0,colonna=0, bloccoR, bloccoC;
    //CONTROLLO PAROLA
    if (parola.Length > puzzle.GetLength(0) || parola.Length < 2 || usate.Contains(parola[0]+parola.Substring(1).ToUpper()))
    {
        Console.WriteLine("La parola è di lunghezza sbagliata o è gia stata usata");
        return false;
    }
    usate += parola[0]+parola.Substring(1).ToUpper();
    foreach(string x in paroleDaIndovinare)
    {
        if (parola == x)
        {
            break;
        }
        else if (x == paroleDaIndovinare[paroleDaIndovinare.Length-1])
        {
            return false;
        }
    }
    //CONTROLLO PAROLA ORIZ
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        for (int j = 0; j < puzzle.GetLength(0); j++)
        {
            if (parola[j - errore] == puzzle[i, j])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = j + 1;
            }
            if (giuste == parola.Length)
            {
                for (int k = giuste; k >0; k--)
                {
                    colori[i, j-k+1] = 'r';
                }
                return true;
            }
        }
        errore = giuste = 0;
    }
    //CONTROLLO PAROLA ORIZZONTALE INV
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        for (int j = puzzle.GetLength(0) - 1; j >= 0; j--)
        {
            if (parola[puzzle.GetLength(0) - j - 1 - errore] == puzzle[i, j])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = puzzle.GetLength(0) - j;
            }
            if (giuste == parola.Length)
            {
                for(int k=giuste; k >0; k--)
                {
                    colori[i, j + k-1] = 'r';
                }
                return true;
            }
        }
        errore = giuste = 0;
    }
    //CONTROLLO PAROLA VERT
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        for (int j = 0; j < puzzle.GetLength(0); j++)
        {
            if (parola[j - errore] == puzzle[j, i])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = j + 1;
            }
            if (giuste == parola.Length)
            {
                for(int k = giuste; k > 0; k--)
                {
                    colori[j-k+1, i] = 'r';
                }
                return true;
            }
        }
        errore = giuste = 0;
    }
    //CONTROLLO PAROLA VERTICALE INV
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        for (int j = puzzle.GetLength(0) - 1; j >= 0; j--)
        {
            if (parola[puzzle.GetLength(0) - 1 - j - errore] == puzzle[j, i])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = puzzle.GetLength(0) - j;
            }
            if (giuste == parola.Length)
            {
                for (int k = giuste; k > 0; k--)
                {
                    colori[j+k-1,i] = 'r';
                }
                return true;
            }
        }
        errore = giuste = 0;
    }
    //CONTROLLO PAROLA OBL
    //OBL1
    for (int i = 1; i < (puzzle.GetLength(0)*2)-2; i++)
    {
        riga= i < puzzle.GetLength(0) - 1 ? 0 : i + 1 - puzzle.GetLength(0);
        colonna = i < puzzle.GetLength(0) - 1 ? puzzle.GetLength(0) - 1 - i : 0;
        errore = giuste = 0;
        bloccoR = riga;
        bloccoC = colonna;
        for (int j = 0; j < puzzle.GetLength(0) - Math.Max(bloccoR,bloccoC); j++)
        {
            if (parola[j - errore] == puzzle[riga,colonna])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = j + 1;
            }
            if (giuste == parola.Length)
            {
                for(int k = giuste-1; k > 0; k--)
                {
                    colori[riga - k, colonna - k] = 'r';
                }
                return true;
            }
            riga++;
            colonna++;
        }
    }
    //OBL1 INV
    for (int i = 1; i <(puzzle.GetLength(0)*2)-2; i++)
    {
        riga=i<puzzle.GetLength(0)? puzzle.GetLength(0)-1 :i-puzzle.GetLength(0)+1;
        colonna= i < puzzle.GetLength(0) ? i : puzzle.GetLength(0)-1;
        giuste = errore = 0;
        bloccoR = riga;
        bloccoC = colonna;
        for (int j = 0; j < Math.Min(bloccoR,bloccoC)+1; j++)
        {
            if (parola[j - errore] == puzzle[riga, colonna])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = j+1;
            }
            if (giuste == parola.Length)
            {
                for(int k = giuste-1; k >= 0; k--)
                {
                    colori[riga + k, colonna + k] = 'r';
                }
                return true;
            }
            riga--;
            colonna--;
        }
        errore = giuste = 0;
    }
    //CONTROLLO PAROLA OBL2
    //OBL2
    for(int i = 1; i < (puzzle.GetLength(0) * 2) - 2; i++)
    {
        colonna=i<puzzle.GetLength(0)? i  :puzzle.GetLength(0)-1;
        riga = i < puzzle.GetLength(0) ? 0 : i - puzzle.GetLength(0) + 1;
        bloccoR = riga;
        bloccoC = colonna;
        for(int j = 0; j < Math.Max(bloccoR, bloccoC) - Math.Min(bloccoR, bloccoC) + 1; j++)
        {
            if (parola[j - errore] == puzzle[riga, colonna])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = j + 1;
            }
            if (giuste == parola.Length)
            {
                for (int k = giuste - 1; k >= 0; k--)
                {
                    colori[riga - k, colonna + k] = 'r';
                }
                return true;
            }
            riga++;
            colonna--;
        }
        errore = giuste = 0;
    }
    //OBL2 INV
    for(int i = 1; i < (puzzle.GetLength(0) * 2) - 2; i++)
    {
        riga = i < puzzle.GetLength(0) ? puzzle.GetLength(0) - 1 : (puzzle.GetLength(0) * 2) - i - 2;
        colonna = i < puzzle.GetLength(0) ? puzzle.GetLength(0) - i - 1 : 0;
        bloccoR = riga;
        bloccoC = colonna;
        for(int j = 0; j < Math.Max(bloccoR,bloccoC)-Math.Min(bloccoR, bloccoC) + 1; j++)
        {
            if (parola[j - errore] == puzzle[riga, colonna])
            {
                giuste++;
            }
            else
            {
                giuste = 0;
                errore = j + 1;
            }
            if (giuste == parola.Length)
            {
                for (int k = giuste - 1; k >= 0; k--)
                {
                    colori[riga + k, colonna - k] = 'r';
                }
                return true;
            }
            riga--;
            colonna++;
        }
        errore = giuste = 0;
    }
    return false;
}
//MAIN
Random rnd = new Random();
string vocali = "aeiou", consonanti = "bcdfghlmnpqrstvz";
string usate = "";
string decisione = "";
int punteggio = 0, lun = 10;
char[,] puzzle = new char[lun, lun];
char[,] colori = new char[lun, lun];
string[] paroleDaIndovinare=RiempiVocabolario(puzzle, rnd, vocali, consonanti);
while (true)
{
    scriviPuzzle(puzzle, colori);
    Console.WriteLine("Dammi una parola");
    string parola = Console.ReadLine();
    if (inserimento(puzzle, parola.ToLower(), ref usate,paroleDaIndovinare, colori))
    {
        Console.WriteLine("Parola trovata!");
        punteggio += parola.Length;
    }
    else
    {
        Console.WriteLine("Parola non trovata");
    }
    Console.WriteLine($"Il tuo punteggio è {punteggio}");
}