using System;

public class logic{
    protected bool _x{get; set;}
    protected bool _y{get; set;}
    public logic(bool x, bool y){
        this._x = x;
        this._y = y;
    }
    public logic(logic l){
        this._x = l._x;
        this._y = l._y;
    }
    
    public bool implication(){
        return !_x || _y;
    }
    public override string ToString()
    {
        return $"Первое поле {_x}, второе поле {_y}";
    }
}
