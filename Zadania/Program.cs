using Zadania;

Console.WriteLine("=== SYMULACJA SYSTEMU KONTENEROWEGO ===\n");

        // Tworzenie statków
        var statek1 = new Statek("Posejdon", 25, 5, 60_000); // max 5 kontenerów, 60 ton
        var statek2 = new Statek("Neptun", 20, 3, 40_000);

        // Tworzenie kontenerów
        var kontenerC = new KontenerC(0, 240, 2000, 600, "", 10000, "bananas", 12);
        var kontenerG = new KontenerG(0, 240, 2500, 600, "", 8000, 5.5);
        var kontenerL = new KontenerL(0, 240, 1800, 600, "", 9000, true);

        //Załadownie kontenerów ładunkiem
        try
        {
            kontenerC.LoadPayload(5000); // OK
            kontenerG.LoadPayload(7000); // OK
            kontenerL.LoadPayload(4000); // OK (niebezpieczny, 50% z 9000 = 4500)
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        //Dodaj kontenery do statku
        statek1.AddKontener(kontenerC);
        statek1.AddKontener(kontenerG);
        statek1.AddKontener(kontenerL);

        //Wypisz info o statku
        Console.WriteLine("\n--- Informacje o statku Posejdon ---");
        statek1.StatekInfo();

        // Tworzymy nowy kontener i go ładujemy
        var kontenerL2 = new KontenerL(0, 220, 1900, 600, "", 8000, false);
        kontenerL2.LoadPayload(6000); // OK, bo nie niebezpieczny – 90%

        // Dodajemy do drugiego statku
        statek2.AddKontener(kontenerL2);

        Console.WriteLine("\n--- Informacje o statku Neptun ---");
        statek2.StatekInfo();

        // Przenosimy kontener z Posejdona do Neptuna
        Statek.MoveKontener(kontenerG, statek1, statek2);

        Console.WriteLine("\n--- Po przeniesieniu kontenera ---");
        statek1.StatekInfo();
        statek2.StatekInfo();

        //Test przekroczenia limitu
        try
        {
            var kontenerZaDuzy = new KontenerC(0, 240, 30000, 600, "", 40000, "fish", 5);
            kontenerZaDuzy.LoadPayload(15000);
            statek2.AddKontener(kontenerZaDuzy);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        Console.WriteLine("\n=== KONIEC TESTU ===");