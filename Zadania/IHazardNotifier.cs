namespace Zadania;

public interface IHazardNotifier
{
    void NotifyHazard(string message, string containerSerialNumber);
}