namespace Zadania;

public class Statek
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public int MaxNumberOfContainters { get; set; }
    public int MaximumWeightOfContainters { get; set; }
    public List<Kontener> Kontenery { get; set; }

    public Statek(string name, int speed, int numberOfContainters, int maximumWeightOfContainters)
    {
        Name = name;
        Speed = speed;
        MaxNumberOfContainters = numberOfContainters;
        MaximumWeightOfContainters = maximumWeightOfContainters;
        Kontenery = new List<Kontener>();
    }

    public void AddKontener(Kontener kontener)
    {
        double currentWeight = Kontenery.Sum(k => k.DeadWeight + k.Payload);
        double weightAfterAddingContainer = kontener.Payload + kontener.DeadWeight + currentWeight;

        if (MaximumWeightOfContainters < weightAfterAddingContainer / 1000)
        {
            Console.WriteLine("Nie można dodać kontenera – przekroczono limit wagowy");
            
        }else if (MaxNumberOfContainters < Kontenery.Count)
        {
            Console.WriteLine("Nie można dodać kontenera – przekroczono limit liczby kontenerów.");
        }
        else
        {
          Kontenery.Add(kontener);  
          Console.WriteLine("Dodano Kontener "+ kontener.SerialNumber + " do statku "+ Name);
        }
    }

    public void RemoveKontener(Kontener kontener)
    {
        Kontenery.Remove(kontener);
        Console.WriteLine("Usunięto kontener "+ kontener.SerialNumber + " ze statku "+ Name);
    }


    public static void MoveKontener(Kontener kontener, Statek z, Statek doStatku)
    {
        doStatku.AddKontener(kontener);
        z.RemoveKontener(kontener);
        Console.WriteLine("Przeniesiono kontener ze statku "+ z.Name +" do statku "+ doStatku.Name);
    }


    public void StatekInfo()
    {
        Console.WriteLine($"Statek: {Name}");
        Console.WriteLine($"Prędkość maksymalna: {Speed} węzłów");
        Console.WriteLine($"Kontenery ({Kontenery.Count}/{MaxNumberOfContainters}):");
        foreach (var k in Kontenery)
        {
            Console.WriteLine($"  {k}");
        }

        double lacznaWaga = Kontenery.Sum(k => k.DeadWeight + k.Payload) / 1000;
        Console.WriteLine($"Aktualna łączna waga: {lacznaWaga} ton (max: {MaximumWeightOfContainters} ton)");
    }
    
    
    
}