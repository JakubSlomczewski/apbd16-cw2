namespace Zadania;

public class KontenerC : Kontener
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    private static int _counter = 1;
    public KontenerC(int payload, int height, int deadWeight, int depth, string serialNumber, int maxpayload, string productType, double temperature) : base(payload, height, deadWeight, depth, serialNumber, maxpayload)
    {
        ProductType = productType;
        Temperature = temperature;
        SerialNumber = $"KON-C-{_counter++}";
    }


    public override void LoadPayload(int mass)
    {
        if(Temperature > ProductRequiredTemperature(ProductType))
            throw new Exception($"Temperature {Temperature} is out of range");
        
        base.LoadPayload(mass);
    }


    private double ProductRequiredTemperature(string productType)
    {
        productType = productType.ToLower();
        
        return productType.ToLower() switch
        {
            "bananas" => 13.3,
            "chocolate" => 18,
            "fish" => 2,
            "meat" => -15,
            "iceCream" => -18,
            "frozenPizza" => -30,
            "cheese" => 7.2,
            "sausages" => 5,
            "butter" => 20.5,
            "eggs" => 19,
            _ => throw new Exception($"Unknown product type: {productType}")
        };
    }
    
}