using Newtonsoft.Json;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace IPT.Lab5.server
{
    /// <summary>
    /// Summary description for Student
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Student : System.Web.Services.WebService
    {
        public static List<StudentModel> students = new List<StudentModel>();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string GetStudents()
        {
            string str = JsonConvert.SerializeObject(students);
            return str;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void AddStudent()
        {
            string studentStr = HttpContext.Current.Request.Params["request"];
            StudentModel studentObj = JsonConvert.DeserializeObject<StudentModel>(studentStr);
            students.Add(studentObj);
        }

        public class StudentModel
        {
            public string name { get; set; }
            public string seatNo { get; set; }
            public int age { get; set; }
        }
    }
}
