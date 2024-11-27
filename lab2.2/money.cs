class money{
    private uint _rubles{get; set;}
    private byte _kopeks{get; set;}
    public money(uint rubles, byte kopeks){
        if(kopeks >= 100) {
            while(kopeks >= 100){
                kopeks -=100;
                rubles++;
            }
        }
        this._rubles = rubles;
        this._kopeks = kopeks;
    }
    public money(uint rubles){
        this._rubles = rubles;
        this._kopeks = 0;
    }
    public money(byte kopeks){
        uint rubles = 0;
        if(kopeks >= 100) {
            while(kopeks >= 100){
                kopeks -=100;
                rubles++;
            }
        }
        this._rubles = rubles;
        this._kopeks = kopeks;
    }
    public money answer(uint kop){
        int total = (int)(_rubles * 100 + _kopeks);
        total -= (int)kop;
        if(total < 0)
            total = 0;
        uint rub = (uint)(total / 100);
        byte kope = (byte)(total % 100);
        return new money(rub, kope);
    }
    public override string ToString()
    {
        return $"Рублей {_rubles} копеек {_kopeks}";
    }
}