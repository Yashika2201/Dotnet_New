using BOL;
using MySql.Data.MySqlClient;

namespace DAL;
public static class DBmanager{
    public static string constring="host=localhost;port=3306;user=root;password=Yashu@2201;database=dotnet";
    public static List<Student> getall(){
        List<Student>slist=new List<Student>();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=constring;
        string query="select * from Student";
        MySqlCommand cmd=new MySqlCommand(query,con);
        try{
            con.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){
                int id=int.Parse(reader["id"].ToString());
                string name=reader["name"].ToString();
                string contact=reader["contact"].ToString();
                Student s=new Student{
                    id=id,
                    name=name,
                    contact=contact,
                };
                slist.Add(s);

            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
        return slist;
    }
    public static void Insert(Student s){
        Console.WriteLine(s.id);
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=constring;
        string query="insert into Student values(@id,@name,@contact)";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.Parameters.AddWithValue("@id",s.id);
        cmd.Parameters.AddWithValue("@name",s.name);
        cmd.Parameters.AddWithValue("@contact",s.contact);
        try{
            con.Open();
            cmd.ExecuteNonQuery();
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
        }
         public static void Edit(Student s){
        Console.WriteLine(s.id);
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=constring;
        string query="update Student set id=@id,name=@name,contact=@contact where id=@id";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.Parameters.AddWithValue("@id",s.id);
        cmd.Parameters.AddWithValue("@name",s.name);
        cmd.Parameters.AddWithValue("@contact",s.contact);
        try{
            con.Open();
            cmd.ExecuteNonQuery();
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
    }
    public static void Delete(int id){
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=constring;
        string query="delete from Student where id=@id";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.Parameters.AddWithValue("@id",id);
        try{
            con.Open();
            cmd.ExecuteNonQuery();
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }

    }

    public static Student Details(int id){
        Student s = new();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=constring;
        string query="Select * from Student where id = @id";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.Parameters.AddWithValue("@id",id);
        try{
            con.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read()){
                int id1=int.Parse(reader["id"].ToString());
                string name=reader["name"].ToString();
                string contact=reader["contact"].ToString();
                s=new(id1, name, contact);}
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
        return s;
    }

}