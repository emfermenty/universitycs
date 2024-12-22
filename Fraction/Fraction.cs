
class Fraction : IClonable, IDouble{
    private int _numerator;
    public int Numerator{
        get{
            return _numerator;
        }
        private set {
            _numerator = value;
        }
    }
    private int _denominator;
    public int Denominator{
        get{
            return _denominator;
        }
        private set {
            _denominator = value;
        }
    }
    private double? cashed;
    public Fraction(int numerator, int Denominator){
        if (Denominator < 0){
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
        int nok = NOK(numerator, Denominator);
        this._numerator = numerator / nok;
        this._denominator = Denominator / nok;
        cashed = 0;
    }
    public double GetValue(){
        double value = (double)Numerator / Denominator;
        cashed = value;
        return value;
    }
    public void setNumerator(int numerator)
    {
        Numerator = numerator;
        cashed = null;
    }

    public void setDenominator(int denominator)
    {
        Denominator = denominator;
        cashed = null; 
    }
    public Fraction Clone(){
        return new Fraction(Numerator, Denominator);
    }
    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
    public static Fraction operator +(Fraction first, Fraction second){
        int numerator;
        int denominator;
        if(first.Denominator == second.Denominator){
            denominator = first.Denominator;
            numerator = first.Numerator + second.Numerator;
        } else {
            denominator = first.Denominator * second.Denominator;
            numerator = (first.Numerator*second.Denominator) + (second.Numerator * first.Denominator);
        }
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator -(Fraction first, Fraction second){
        int numerator;
        int denominator;
        
        if(first.Denominator == second.Denominator){
            denominator = first.Denominator;
            numerator = first.Numerator - second.Numerator;
        } else {
            denominator = first.Denominator * second.Denominator;
            numerator = (first.Numerator*second.Denominator) - (second.Numerator * first.Denominator);
        }
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator *(Fraction first, Fraction second){
        int numerator = first.Numerator * second.Numerator;
        int denominator = first.Denominator * second.Denominator;
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator /(Fraction first, Fraction second){
        int numerator = first.Numerator * second.Denominator;
        int denominator = first.Denominator * second.Numerator;
        return new Fraction(numerator, denominator);
    }
    public static Fraction operator +(Fraction f1, int num)
    {
        Fraction f2 = new Fraction(num, 1);
        return f1 + f2;
    }

    public static Fraction operator -(Fraction f1, int num)
    {
        Fraction f2 = new Fraction(num, 1);
        return f1 - f2;
    }

    public static Fraction operator *(Fraction f1, int num)
    {
        Fraction f2 = new Fraction(num, 1);
        return f1 * f2;
    }

    public static Fraction operator /(Fraction f1, int num)
    {
        Fraction f2 = new Fraction(num, 1);
        return f1 / f2;
    }
    public override bool Equals(object? obj)
    {
        if(obj is Fraction frac && obj != null){
           return Numerator == frac.Numerator && Denominator == frac.Denominator;
        }
        return false;
    }

    private static int NOK(int Numerator, int Denominator){
        int count = 0;
        int b = Denominator;
        int a = Numerator;
        if(Denominator > Numerator){
            while(b != 0){
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        } else if (Denominator < Numerator){
            while(a != 0){
                int temp = a;
                a = b % a;
                b = temp;
        }
        Denominator = Denominator / b;
        Numerator = Numerator / b;
        return Math.Abs(b);
        }
        return 1;
}
}