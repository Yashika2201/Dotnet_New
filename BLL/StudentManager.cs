using BOL;
using DAL;

namespace BLL;
public static class StudentManager{
    public static List<Student> getall(){
        List<Student>slist=DBmanager.getall();
        return slist;
    }
}