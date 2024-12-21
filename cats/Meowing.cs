
static class Meowing{
    public static void gomeow(IMeowable[] meowables){
        foreach(var i in meowables){
            i.Meow();
        }
    }
}