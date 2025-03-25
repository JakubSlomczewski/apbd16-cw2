namespace Zadania;

public class KontenerC : Kontener
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    private static int counter = 1;
    public KontenerC(int payload, int height, int deadWeight, int depth, string serialNumber, int maxpayload, string productType, double temperature) : base(payload, height, deadWeight, depth, serialNumber, maxpayload)
    {
        ProductType = productType;
        Temperature = temperature;
        SerialNumber = $"KON-C-{counter++}";
    }


    public override void LoadPayload(int mass)
    {
        if(Temperature > ProductRequiredTemperature(ProductType))
            throw new Exception($"Temperature {Temperature} is out of range");
        
        base.LoadPayload(mass);
    }


    private double ProductRequiredTemperature(string productType)
    {
        return productType.ToLower() switch
        {
            "Bananas" => 13.3,
            "Chocolate" => 18,
            "Fish" => 2,
            "Meat" => -15,
            "IceCream" => -18,
            "FrozenPizza" => -30,
            "Cheese" => 7.2,
            "Sausages" => 5,
            "Butter" => 20.5,
            "Eggs" => 19,
        };
    }
    
}