namespace Zadania;

public class KontenerG : Kontener, IHazardNotifier
{
    public double Pressure { get; set; }
    private int counter = 1;

    public KontenerG(int payload, int height, int deadWeight, int depth, string serialNumber, int maxpayload, double pressure) : base(payload, height, deadWeight, depth, serialNumber, maxpayload)
    {
        Pressure = pressure;
        SerialNumber = $"KON-G-{counter++}";
    }


    public override void FlushPayload()
    {
        Payload = (int)(Payload * 0.05); 

    }

    public override void LoadPayload(int mass)
    {
        if (mass + Payload > MaxPayLoad)
        {
            NotifyHazard("Za duży ładunek dla kontenera gazowego", SerialNumber);
            throw new OverfillException("Przekroczono maksymalny ładunek dla gazu!");
        }
        
        base.LoadPayload(mass);
    }


    public void NotifyHazard(string message, string containerSerialNumber)
    {
        Console.WriteLine($"[HAZARD] {message} | Kontener: {SerialNumber}");
    }  
}