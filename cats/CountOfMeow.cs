using System;

class CountOfMeow : IMeowable{
    private IMeowable meowable;
    public int MeowCount {get; set;} = 0;
    public CountOfMeow(IMeowable meowable){
        this.meowable = meowable;
    }
    public void Meow(){
        MeowCount++;
        meowable.Meow();
    }
    public void Meow(int times)
    {
        if (meowable is Cat cat)
        {
            cat.Meow(times);
            MeowCount += times;
        }
        else
        {
            meowable.Meow();
            MeowCount++;
        }
    }
}