//VOID
using System;
using System.IO;
string[] RiempiVocabolario(char[,] puzzle, Random rnd, string vocali, string consonanti)
{
    string percorso = @"../../../../paroleItaliane.txt";
    int r, c, Nparole=rnd.Next(4,11), verso;
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
                    if (parola.Length <= puzzle.GetLength(0) - r - 1)
                    {
                        for (int i = r; i < parola.Length + r; i++)
                        {
                            if (puzzle[i, i] != '\0' && puzzle[i, i] != parola[i - r])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, r] = parola[i];
                                r++;
                            }
                        }
                    }
                    else
                    {
                        scrivi = false;
                    }
                    break;
                //OBL INV
                case 6:
                    if (parola.Length <= r + 1)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r - i, r - i] != '\0' && puzzle[r - i, r - i] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, r] = parola[i];
                                r--;
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
                    if (parola.Length <= puzzle.GetLength(0) - r)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r+i,puzzle.GetLength(0)-r-i-1] != '\0' && puzzle[r + i, puzzle.GetLength(0) - r - i - 1] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for (int i = 0; i < parola.Length; i++)
                            {
                                puzzle[r, puzzle.GetLength(0) - r - 1] = parola[i];
                                r++;
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
                    if(parola.Length <= r + 1)
                    {
                        for (int i = 0; i < parola.Length; i++)
                        {
                            if (puzzle[r - i, puzzle.GetLength(0) - 1 - r + i] != '\0' && puzzle[r - i, puzzle.GetLength(0) - 1 - r + i] != parola[i])
                            {
                                scrivi = false;
                                break;
                            }
                        }
                        if (scrivi)
                        {
                            for(int i=0; i < parola.Length; i++)
                            {
                                puzzle[r,puzzle.GetLength(0)-r-1]=parola[i];
                                r--;
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
            scriviPuzzle(puzzle, new char[puzzle.GetLength(0), puzzle.GetLength(1)]);
            foreach (string p in usate)
            {
                Console.WriteLine(p);
            }
        }
        if (!scrivi)
        {
            scrivi = true;
            k--;
        }
    }
    //CONTROLLO GLI SPAZI BIANCHI
    riempiPuzzle(vocali, consonanti, puzzle, rnd);
    return usate;
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
    int giuste = 0, errore = 0;
    //CONTROLLO PAROLA
    if (parola.Length > puzzle.GetLength(0) || parola.Length < 2 || usate.Contains(parola))
    {
        Console.WriteLine("La parola è di lunghezza sbagliata o è gia stata usata");
        return false;
    }
    usate += parola;
    for(int i = 0; i < paroleDaIndovinare.Length; i++)
    {
        if (parola == paroleDaIndovinare[i])
        {
            break;
        }
        else if (i == paroleDaIndovinare.Length-1)
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
                for (int k = j - parola.Length + 1; k <= j; k++)
                {
                    colori[i, k] = 'r';
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
                return true;
            }
        }
        errore = giuste = 0;
    }
    //CONTROLLO PAROLA OBL
    //OBLP
    for (int i = 0; i < puzzle.GetLength(0); i++)
    {
        if (parola[i - errore] == puzzle[i, i])
        {
            giuste++;
        }
        else
        {
            giuste = 0;
            errore = i + 1;
        }
        if (giuste == parola.Length)
        {
            return true;
        }
    }
    errore = giuste = 0;
    //OBLIQUA PRINCIPALE INV
    for (int i = puzzle.GetLength(0) - 1; i >= 0; i--)
    {
        if (parola[puzzle.GetLength(0) - 1 - i - errore] == puzzle[i, i])
        {
            giuste++;
        }
        else
        {
            giuste = 0;
            errore = puzzle.GetLength(0) - i;
        }
        if (giuste == parola.Length)
        {
            return true;
        }
    }
    errore = giuste = 0;
    //OBL1
    for (int i = 2; i < puzzle.GetLength(0); i++)
    {
        int c = puzzle.GetLength(0) - i, r = 0;
        if (parola.Length <= i)
        {
            for (int j = 0; j < i; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
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
                    return true;
                }
                c++;
                r++;
            }
            errore = giuste = 0;
        }
    }
    //OBL1 INV
    for (int i = 2; i < puzzle.GetLength(0); i++)
    {
        int c = puzzle.GetLength(0) - 1, r = i - 1;
        if (parola.Length <= i)
        {
            for (int j = 0; j < i; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
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
                    return true;
                }
                c--;
                r--;
            }
            errore = giuste = 0;
        }
    }
    //OBL2
    for (int i = 1; i < puzzle.GetLength(0) - 1; i++)
    {
        int c = 0, r = i;
        if (parola.Length <= puzzle.GetLength(0) - i)
        {
            for (int j = 0; j < puzzle.GetLength(0) - i; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
                {
                    giuste++;
                }
                else
                {
                    errore = j + 1;
                    giuste = 0;
                }
                if (giuste == parola.Length)
                {
                    return true;
                }
                r++;
                c++;
            }
            giuste = errore = 0;
        }
    }
    //OBL2 INV
    for (int i = 1; i < puzzle.GetLength(0) - 1; i++)
    {
        int c = puzzle.GetLength(0) - i - 1, r = puzzle.GetLength(0) - 1;
        if (parola.Length <= puzzle.GetLength(0) - i)
        {
            for (int j = 0; j < puzzle.GetLength(0) - i; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
                {
                    giuste++;
                }
                else
                {
                    errore = j + 1;
                    giuste = 0;
                }
                if (giuste == parola.Length)
                {
                    return true;
                }
                r--;
                c--;
            }
            giuste = errore = 0;
        }
    }
    //CONTROLLO PAROLA OBL2
    //OBLP
    for (int i = puzzle.GetLength(0) - 1; i >= 0; i--)
    {
        if (parola[puzzle.GetLength(0) - 1 - i - errore] == puzzle[puzzle.GetLength(0) - i - 1, i])
        {
            giuste++;
        }
        else
        {
            giuste = 0;
            errore = puzzle.GetLength(0) - i;
        }
        if (giuste == parola.Length)
        {
            return true;
        }
    }
    giuste = errore = 0;
    //OBLP INV
    for (int i = puzzle.GetLength(0) - 1; i >= 0; i--)
    {
        if (parola[puzzle.GetLength(0) - 1 - i - errore] == puzzle[i, puzzle.GetLength(0) - i - 1])
        {
            giuste++;
        }
        else
        {
            giuste = 0;
            errore = puzzle.GetLength(0) - i;
        }
        if (giuste == parola.Length)
        {
            return true;
        }
    }
    giuste = errore = 0;
    //OBL1
    for (int i = 0; i < puzzle.GetLength(0) - 1; i++)
    {
        int r = 0, c = i + 1;
        if (parola.Length <= i + 2)
        {
            for (int j = 0; j < i + 2; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
                {
                    giuste++;
                }
                else
                {
                    errore = j + 1;
                    giuste = 0;
                }
                if (giuste == parola.Length)
                {
                    return true;
                }
                r++;
                c--;
            }
            errore = giuste = 0;
        }
    }
    //OBL1 INV
    for (int i = 0; i < puzzle.GetLength(0) - 1; i++)
    {
        int r = i + 1, c = 0;
        if (parola.Length <= i + 2)
        {
            for (int j = 0; j < i + 2; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
                {
                    giuste++;
                }
                else
                {
                    errore = j + 1;
                    giuste = 0;
                }
                if (giuste == parola.Length)
                {
                    return true;
                }
                r--;
                c++;
            }
            errore = giuste = 0;
        }
    }
    //OBL2
    for (int i = 2; i < puzzle.GetLength(0); i++)
    {
        int c = puzzle.GetLength(0) - 1, r = puzzle.GetLength(0) - i;
        if (parola.Length <= i)
        {
            for (int j = 0; j < i; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
                {
                    giuste++;
                }
                else
                {
                    errore = j + 1;
                    giuste = 0;
                }
                if (giuste == parola.Length)
                {
                    return true;
                }
                c--;
                r++;
            }
            errore = giuste = 0;
        }
    }
    //OBL2 INV
    for (int i = 2; i < puzzle.GetLength(0); i++)
    {
        int c = i - 1, r = puzzle.GetLength(0) - 1;
        if (parola.Length <= puzzle.GetLength(0) + 1 - i)
        {
            for (int j = 0; j < puzzle.GetLength(0) + 1 - i; j++)
            {
                if (parola[j - errore] == puzzle[r, c])
                {
                    giuste++;
                }
                else
                {
                    errore = j + 1;
                    giuste = 0;
                }
                if (giuste == parola.Length)
                {
                    return true;
                }
                c++;
                r--;
            }
            errore = giuste = 0;
        }
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