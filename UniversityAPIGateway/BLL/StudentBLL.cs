using System.Data;
using System.Data.SqlClient;
using UniversityAPIGateway.DBLayer;
using UniversityAPIGateway.Models;

namespace UniversityAPIGateway.BLL
{
    public class StudentBLL
    {
        DBContext dBContext = new DBContext();


        public List<Student> GetAllStudent()
        {
            

            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection("server=. ; Database =UniversityManagementSystem; Trusted_Connection=True;Integrated security =SSPI;"))
            {
                SqlCommand cmd = new SqlCommand("select*from Student;", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Student student = new Student()
                    {
                        studentID = Convert.ToInt32(rdr["studentID"]),
                        Name = Convert.ToString(rdr["Name"]),
                        Standing = Convert.ToString(rdr["Standing"]),
                        GPA = Convert.ToDouble(rdr["GPA"]),
                        Address = Convert.ToString(rdr["Address"]),
                        Major = Convert.ToString(rdr["Major"]),
                        BirthDate = Convert.ToString(rdr["BirthDate"])


                    };

                    students.Add(student);

                }

                return students;
            }
        }

        public async Task<string> AddStudent(Student student)
        {

 
        

            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection("server=. ; Database =UniversityManagementSystem; Trusted_Connection=True;Integrated security =SSPI;"))
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("AddStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramStudentID = new SqlParameter();
                    paramStudentID.ParameterName = "@StudentID";
                    paramStudentID.Value = student.studentID;
                    cmd.Parameters.Add(paramStudentID);

                    SqlParameter paramName = new SqlParameter();
                    paramName.ParameterName = "@Name";
                    paramName.Value = student.Name;
                    cmd.Parameters.Add(paramName);

                    SqlParameter paramStanding = new SqlParameter();
                    paramStanding.ParameterName = "@Standing";
                    paramStanding.Value = student.Standing;
                    cmd.Parameters.Add(paramStanding);

                    SqlParameter paramGPA = new SqlParameter();
                    paramGPA.ParameterName = "@GPA";
                    paramGPA.Value = student.GPA;
                    cmd.Parameters.Add(paramGPA);

                    SqlParameter paramAddress = new SqlParameter();
                    paramAddress.ParameterName = "@Address";
                    paramAddress.Value = student.Address;
                    cmd.Parameters.Add(paramAddress);

                    SqlParameter paramMajor = new SqlParameter();
                    paramMajor.ParameterName = "@Major";
                    paramMajor.Value = student.Major;
                    cmd.Parameters.Add(paramMajor);

                    SqlParameter paramBirthDate = new SqlParameter();
                    paramBirthDate.ParameterName = "@BirthDate";
                    paramBirthDate.Value = student.BirthDate;
                    cmd.Parameters.Add(paramBirthDate);


                  string error =  validateStudent(paramStudentID,paramName,paramStanding,paramMajor,paramGPA,paramBirthDate);
                  return error;
                  
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return "Success";

                }catch(SqlException e )
                {
                    throw e;
                }

            }




        }


        public string validateStudent(SqlParameter paramStudentID, SqlParameter paramName, SqlParameter paramStanding, SqlParameter paramMajor, SqlParameter paramGPA, SqlParameter paramBirthDate )
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(paramStudentID); // 0 
            sqlParameters.Add(paramName);
            sqlParameters.Add(paramStanding);
            sqlParameters.Add(paramMajor);
            sqlParameters.Add(paramBirthDate);
            sqlParameters.Add(paramGPA);

            string error = string.Empty;


            foreach(var item in sqlParameters)
            {
                if (item.Value.ToString() == "")
                {
                    error = item.Value.ToString() + "Cannot be empty";
                    return error;
                }
            }

            return error;

        }

    }
}
