class money
{
    private uint _rubles { get; set; }
    private byte _kopeks { get; set; }
    public money(uint rubles, byte kopeks)
    {
        if (kopeks >= 100)
        {
            while (kopeks >= 100)
            {
                kopeks -= 100;
                rubles++;
            }
        }
        this._rubles = rubles;
        this._kopeks = kopeks;
    }
    public money(uint rubles)
    {
        this._rubles = rubles;
        this._kopeks = 0;
    }
    public money(){
        this._rubles = 0;
        this._kopeks = 0;
    }
    public money(byte kopeks)
    {
        uint rubles = 0;
        if (kopeks >= 100)
        {
            while (kopeks >= 100)
            {
                kopeks -= 100;
                rubles++;
            }
        }
        this._rubles = rubles;
        this._kopeks = kopeks;
    }
    // унарное вычитание 1
    public static money operator --(money money)
    {
        if (money._kopeks == 0)
        {
            if (money._rubles == 0)
            {
                return money;
            }
            money._rubles -= 1;
            money._kopeks = 99;
        }
        else
        {
            money._kopeks -= 1;
        }
        return money;
    }
    // унарное сложение 1
    public static money operator ++(money money)
    {
        if (money._kopeks == 99)
        {
            money._kopeks = 0;
            money._rubles += 1;
        }
        else money._kopeks += 1;
        return money;
    }
    //явное приведение

    public static explicit operator uint(money money){
        return money._rubles; 
    }

    //неявное
    public static implicit operator bool(money money){
        return money._rubles > 0 || money._kopeks > 0;
    }
    // бинарное вычитание копеек
    public static money operator -(money m, uint kop)
{
    int total = (int)(m._rubles * 100 + m._kopeks);
    total -= (int)kop;
    if (total < 0)
    {
        total = 0;
    }
    uint rub = (uint)(total / 100);
    byte kope = (byte)(total % 100);
    return new money(rub, kope);
}
// бинарное вычитание мани из мани
    public static money operator -(money m1, money m2)
    {
        uint totalkop1 = m1._rubles * 100 + m1._kopeks;
        uint totalkop2 = m2._rubles * 100 + m2._kopeks;
        uint totalrez = totalkop1 >= totalkop2 ? totalkop1 - totalkop2 : 0;
        uint rubl = totalrez / 100;
        byte kopx = (byte)(totalrez % 100);
        return new money(rubl, kopx);
    }

public override string ToString()
{
    return $"Рублей {_rubles} копеек {_kopeks}";
}
}