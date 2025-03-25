namespace Zadania;

public class Kontener
{
    public int Payload { get; set; }
    public int Height { get; set; }
    public int DeadWeight { get; set; }
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public int MaxPayLoad { get; set; }


    
    public Kontener(int payload, int height, int deadWeight, int depth, string serialNumber, int maxpayload)
    {
        
        Height = height;
        DeadWeight = deadWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxPayLoad = maxpayload;
        Payload = 0;

        
    }
    
    
    public virtual void FlushPayload()
    {
        Payload = 0;
    }

    public virtual void LoadPayload(int mass)
    {
        if (mass + Payload > MaxPayLoad)
        {
            throw new OverfillException($"Payload is too big {SerialNumber}");
        }else
        {
            Payload = Payload + mass;
        }
    }

    public override string ToString()
    {
        return $"Kontener {SerialNumber} - Waga: {DeadWeight}, Ładunek: {Payload}/{MaxPayLoad}";
    }
    
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message) { }
    }
}
