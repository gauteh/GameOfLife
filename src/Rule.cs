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

        public void ApplyRule (ref List<int[,]> tables)
        {
            // Forslag til regelfunksjon frå Trond
            Console.WriteLine("[Rule] - ApplyRule");

            // Test, fyller dei tre første rutene
            /*
            tables[1][0, 0] = 1;
            tables[1][0, 1] = 1;
            tables[1][0, 2] = 1;
            */

            // Har bytta ut alle tabOrg med tables[0] og alle tabNy med tables[1]
            // tables er ein referanse til tabellane

            // A og B er kordinatene i et grid.
            int A = 0; // A, rad. 0,0 - 0, 1 = a, 0 - a, 1
            int B = 0; // B, kolonne. 0,0 - 0 , 1 = 0, b - 0, b+1

            int nabo = 0;

            for (; A <= 30;A++ )
            {
                // forløkke skal gå igjennom alle radene.
                for (; B <= 30; B++)
                {
                    // forløkke skal gå igjennom alle kolonnene.

                    // Kode skal sjekke alle cellene rundt en celle med kord. A,B.
                    // Og telle opp hvor mange celler det er noe i.
                    if (!((A+1) > 30 || (A-1) < 0 || (B+1) > 30 || (B-1) < 0))
                    {
                        if (tables[0][A - 1, B - 1] != 0)
                            nabo++;
                        if (tables[0][A - 1, B] != 0)
                            nabo++;
                        if (tables[0][A - 1, B + 1] != 0)
                            nabo++;
                        if (tables[0][A, B - 1] != 0)
                            nabo++;
                        if (tables[0][A, B + 1] != 0) // hopper jo over A,B.
                            nabo++;
                        if (tables[0][A + 1, B - 1] != 0)
                            nabo++;
                        if (tables[0][A + 1, B] != 0)
                            nabo++;
                        if (tables[0][A + 1, B + 1] != 0)
                            nabo++;
                    } // slutt if\else


                    // Hvis det er noe i A,B så skal cellen dø om det er 0,1,4-8 celler rundt.
                    // og leve om det er 2,3.
                    // Hvis det er tom celle skal det bli ny celle ved at det er 3 naboer.

                    if (tables[0][A, B] != 0) // lever celle i A,B.
                    {
                        if (nabo == 2 || nabo == 3) // leve
                            tables[1][A, B] = 1;
                        else                        // dø
                            tables[1][A, B] = 0;
                    }
                    else
                    {
                        if (nabo == 3)
                            tables[1][A, B] = 1;
                    }

                    nabo = 0;

                    // klar for ny runde...

                }
            }

        }
    }
}

// vim: set noai sw=4 tw=4 ts=4:
