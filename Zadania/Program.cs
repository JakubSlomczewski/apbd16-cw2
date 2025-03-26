using Zadania;

Console.WriteLine("=== SYMULACJA SYSTEMU KONTENEROWEGO ===\n");

        
        var statek1 = new Statek("Posejdon", 25, 5, 60_000); 
        var statek2 = new Statek("Neptun", 20, 3, 40_000);


        var kontenerC = new KontenerC(0, 240, 2000, 600, "", 10000, "Bananas", 12);
        var kontenerG = new KontenerG(0, 240, 2500, 600, "", 8000, 5.5);
        var kontenerL = new KontenerL(0, 240, 1800, 600, "", 9000, true);

        
        try
        {
            kontenerC.LoadPayload(5000); 
            kontenerG.LoadPayload(7000); 
            kontenerL.LoadPayload(4000); 
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

  
        statek1.AddKontener(kontenerC);
        statek1.AddKontener(kontenerG);
        statek1.AddKontener(kontenerL);

       
        Console.WriteLine("\n--- Informacje o statku Posejdon ---");
        statek1.StatekInfo();

        
        var kontenerL2 = new KontenerL(0, 220, 1900, 600, "", 8000, false);
        kontenerL2.LoadPayload(6000); 

        
        statek2.AddKontener(kontenerL2);

        Console.WriteLine("\n--- Informacje o statku Neptun ---");
        statek2.StatekInfo();

        
        Statek.MoveKontener(kontenerG, statek1, statek2);

        Console.WriteLine("\n--- Po przeniesieniu kontenera ---");
        statek1.StatekInfo();
        statek2.StatekInfo();

        var kontenerZaDuzy = new KontenerC(0, 240, 30_000, 600, "", 40_000, "Fish", 5);
        kontenerZaDuzy.LoadPayload(15_000);

        statek2.AddKontener(kontenerZaDuzy);

        Console.WriteLine("\n=== KONIEC TESTU ===");