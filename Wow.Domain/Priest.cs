using Wow.SharedKernel;

namespace Wow.Domain;

public class Priest
{
    private Priest(string name, double mana)
    {
        Name = name;
        Mana = mana;
    }

    public static Priest CreatePriest(string name, double mana)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("Name should not be null!");
        }
        return new Priest(name, mana);
    }

    public string Name { get; private set; }
    public double Mana { get; private set; }

    public double CastResurrection(double mana)
    {
        if (mana> Mana)
        {
            throw new BusinessRuleViolationException("Char should have more mana than then resurrection mana cost!");
        }
        Mana = Mana - mana;
        return Mana;
    }
}