
using System;

namespace GameOfLife
{

	// Regelmotor
	// - Tar i mot ein tabell og reknar ut den nye tabellen
	public class Rule
	{

		public Rule ()
		{
		}
		
		public void ApplyRule (Table table) 
		{
			// Forslag til regelfunksjon frå Trond
			
			
            int[,] tabOrg = new int[30, 30];
            int[,] tabNy = new int[30, 30];

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
                    if ((A+1) > 30 || (A-1) < 0 || (B+1) > 30 || (B-1) < 0)
                        nabo == nabo;
                    else
                    {
                        if (tabOrg[A - 1, B - 1])
                            nabo++;
                        if (tabOrg[A - 1, B])
                            nabo++;
                        if (tabOrg[A - 1, B + 1])
                            nabo++;
                        if (tabOrg[A, B - 1])
                            nabo++;
                        if (tabOrg[A, B + 1]) // hopper jo over A,B. 
                            nabo++;
                        if (tabOrg[A + 1, B - 1])
                            nabo++;
                        if (tabOrg[A + 1, B])
                            nabo++;
                        if (tabOrg[A + 1, B + 1])
                            nabo++;
                    } // slutt if\else


                    // Hvis det er noe i A,B så skal cellen dø om det er 0,1,4-8 celler rundt. 
                    // og leve om det er 2,3.
                    // Hvis det er tom celle skal det bli ny celle ved at det er 3 naboer.

                    if (tabOrg(A, B)) // lever celle i A,B.
                    {
                        if (nabo == 2 || nabo == 3) // leve
                            tabNy(A, B) = 1;
                        else                        // dø
                            tabNy(A, B) = 0;
                    }
                    else
                    {
                        if (nabo == 3)
                            tabNy(A, B) = 1;
                    }

                    nabo = 0;

                    // klar for ny runde...


                }
            }
		}
	}
}
