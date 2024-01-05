namespace BOL;
public class Student{
    public int id;
    public string name;
    public string contact;
    public Student(){
        id=0;
        name=null;
        contact=null;
    }
    public Student(int i,string nm,string con){
        id=i;
        name=nm;
        contact=con;
    }
    public Student(string nm,string con){
        name=nm;
        contact=con;
    }
}