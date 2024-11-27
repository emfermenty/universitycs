public class extendslogic : logic{
    private bool _k{get; set;}
    private bool _z{get; set;}
    public extendslogic(bool x, bool y, bool k, bool z)
        : base(x, y) 
    {
        this._k = k;
        this._z = z;
    }
    public bool con(){
        return _k && _z;
    }

    public bool diz(){
        return _k || _z;
    }
    public bool formula(){ // (x->y) && (k || z)
        bool prom1 = implication();
        bool prom2 = _k || _z;
        return prom1 && prom2;
    }
    public override string ToString()
    {
        return $"Первое поле {_x}, второе поле {_y}, третье поле {_k}, четвертое поле {_z}";
    }
}
