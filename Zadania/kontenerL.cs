namespace Zadania;

public class KontenerL : Kontener, IHazardNotifier
{
    public bool IsHazardous { get; set; }
    private static int _counter = 1;

    public KontenerL(int payload, int height, int deadWeight, int depth, string serialNumber, int maxpayload, bool isHazardous) : base(payload, height, deadWeight, depth, serialNumber, maxpayload)
    {
        IsHazardous = isHazardous;
        SerialNumber = $"KON-L-{_counter++}";
    }


    public override void LoadPayload(int mass)
    {
        if (IsHazardous)
        {
            if (mass + Payload > MaxPayLoad/2)
            {
                NotifyHazard("Próba załadunku przekraczająca bezpieczny limit 50%", SerialNumber);
                throw new OverfillException($"Payload is too big {SerialNumber}");
            }else
            {
                if (mass + Payload > (int)(MaxPayLoad * 0.09))
                {
                    NotifyHazard("Próba załadunku przekraczająca bezpieczny limit 90%", SerialNumber);
                    throw new OverfillException($"Przekroczono dopuszczalny limit ładunku!");
                }
            }
        }
        base.LoadPayload(mass);
    }
    
    
    public void NotifyHazard(string message, string containerSerialNumber)
    {
        Console.WriteLine($"[HAZARD] {message} | Kontener: {containerSerialNumber}");
    }
}