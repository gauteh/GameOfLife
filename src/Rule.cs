using System;
using System.Collections.Generic;

namespace GameOfLife
{

    // Regelmotor
    // - Tar i mot ein tabell og reknar ut den nye tabellen
    public class Rule
    {

        public Rule ()
        {
        }

        public static int[,] CopyCells (int [,] cells) {
            int [,] copy = new int[Table.HEIGHT, Table.WIDTH];
            for (int i = 0; i < Table.HEIGHT; i++)
                for (int j = 0; j < Table.WIDTH; j++)
                    copy[i,j] = cells[i,j];

            return copy;
        }

        public void ApplyRule (Table table)
        {
            Console.WriteLine("[Rule] - ConwayRule");

            // A og B er kordinatene i et grid.
            int A = 0; // A, rad. 0,0 - 0, 1 = a, 0 - a, 1
            int B = 0; // B, kolonne. 0,0 - 0 , 1 = 0, b - 0, b+1
            int kol = Table.WIDTH-1;
            int rad = Table.HEIGHT-1;

            // Lag ein kopi av tabellen som ikkje foranrar seg
            int [,] cells = CopyCells (table.Cells);

            int nabo = 0;

            for (; A <= rad;A++ )
            {
            // forløkke skal gå igjennom alle radene.
                B = 0;
                for (; B <= kol; B++)
                {
                    
                // forløkke skal gå igjennom alle kolonnene.

                    // Kode skal sjekke alle cellene rundt en celle med kord. A,B.
                    // Og telle opp hvor mange celler det er noe i.
                    nabo = 0;
                    if (!((A+1) > rad || (A-1) < 0 || (B+1) > kol || (B-1) < 0))
                    {
                        
                        if (cells[A - 1, B - 1] != 0)
                            nabo++;
                        if (cells[A - 1, B] != 0)
                            nabo++;
                        if (cells[A - 1, B + 1] != 0)
                            nabo++;
                        if (cells[A, B - 1] != 0)
                            nabo++;
                        if (cells[A, B + 1] != 0) // hopper jo over A,B.
                            nabo++;
                        if (cells[A + 1, B - 1] != 0)
                            nabo++;
                        if (cells[A + 1, B] != 0)
                            nabo++;
                        if (cells[A + 1, B + 1] != 0)
                            nabo++;
                         
                    } // slutt if\else
                    

                    // Hvis det er noe i A,B så skal cellen dø om det er 0,1,4-8 celler rundt.
                    // og leve om det er 2,3.
                    // Hvis det er tom celle skal det bli ny celle ved at det er 3 naboer.
                    
                    if (cells[A, B] != 0) // lever celle i A,B.
                    {
                        if (nabo == 2 || nabo == 3) // leve
                            table.SetCell (A, B, 1);
                        else                        // dø
                            table.SetCell (A, B, 0);
                    }
                    else
                    {
                        if (nabo == 3)
                            table.SetCell (A, B, 1);
                    }
                    
                    // klar for ny runde...

                }
            }

        }

        public void TrondRule (Table table)
        {
            Console.WriteLine("[Rule] - TrondRule");

            // A og B er kordinatene i et grid.
            int A = 0; // A, rad. 
            int B = 0; // B, kolonne. 
            int kol = Table.WIDTH - 1;
            int rad = Table.HEIGHT - 1;

            int nabo = 0;

            // Lag ein kopi av tabellen som ikkje foranrar seg
            int [,] cells = CopyCells (table.Cells);

            for (; A <= rad; A++)
            {
                // forløkke skal gå igjennom alle radene.
                B = 0;
                for (; B <= kol; B++)
                {                    
                    // forløkke skal gå igjennom alle kolonnene.

                    // Kode skal sjekke alle cellene rundt en celle med kord. A,B.
                    // Og telle opp hvor mange celler det er noe i.
                    nabo = 0;
                    if (!((A + 1) > rad || (A - 1) < 0 || (B + 1) > kol || (B - 1) < 0))
                    {

                        if (cells[A - 1, B - 1] != 0)
                            nabo++;
                        if (cells[A - 1, B] != 0)
                            nabo++;
                        if (cells[A - 1, B + 1] != 0)
                            nabo++;
                        if (cells[A, B - 1] != 0)
                            nabo++;
                        if (cells[A, B + 1] != 0) // hopper jo over A,B.
                            nabo++;
                        if (cells[A + 1, B - 1] != 0)
                            nabo++;
                        if (cells[A + 1, B] != 0)
                            nabo++;
                        if (cells[A + 1, B + 1] != 0)
                            nabo++;

                    } // slutt if\else


                    // Hvis det er noe i A,B så skal cellen dø om det er 0,1,4-8 celler rundt.
                    // og leve om det er 2,3.
                    // Hvis det er tom celle skal det bli ny celle ved at det er 3 naboer.

                        
                    if (cells[A, B] != 0) // lever celle i A,B.
                    {
                        if (nabo == 2 || nabo == 3) // leve
                            table.SetCell (A, B, 1);
                        else                        // dø
                            table.SetCell (A, B, 0);
                    }
                    else
                    {
                        if (nabo == 3)
                            table.SetCell (A, B, 1);
                    }
                    

                    // klar for ny runde...

                }
            }

        }


    }
}

// vim: set noai sw=4 tw=4 ts=4:
