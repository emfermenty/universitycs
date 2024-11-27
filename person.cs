using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class Person
{
    private string Lastname{ get; set; }
    private string Firstname{ get; set; }
    private DateTime Birth{ get; set; }
    
    public Person(string lastnamed, string firstnamed, DateTime birthd)
    {
        Lastname = lastnamed;
        Firstname = firstnamed;
        Birth = birthd;
    }
    public Person(){

    }
    /*public string GetLastname(){
        return Lastname;
    }
    public string GetFirstname(){
        return Firstname;
    }
    public DateTime GetBirth(){
        return Birth;
    }*/
}