using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThucTapXamarin.Excercise.Exercise_2.Models;

namespace ThucTapXamarin.Excercise.Exercise_2.Services
{
    public class StudentServies
    {
        //private static readonly int MinSearchLength = 5;
        //private const string Url = "http://api.hkids.edu.vn/api/v1/Notification/All?ClassId=8145646c-4cdc-4a0e-9fe0-7ca9d4c63af0&SchoolId=4bba3fd1-ce85-44de-918c-d6cbf9fb8852";
        //private HttpClient _client = new HttpClient();

        //public async Task<IEnumerable<StudentStatus>> FindStudentByStatus(string searchedStatus, List<StudentStatus> students)
        //{
        //    if (searchedStatus.Length < MinSearchLength)
        //        return Enumerable.Empty<StudentStatus>();
        //    return students.Where(x => x.Status.Contains(searchedStatus));
        //    //var content = await _client.GetStringAsync(Url);
        //}

        //public async IEnumerable<StudentStatus> GetStudents()
        //{
        //    var content = await _client.GetStringAsync(Url);
        //    var students = JsonConvert.DeserializeObject<List<StudentStatus>>(content);
        //    List<StudentStatus> listStudents;
        //    listStudents = new List<StudentStatus>(students);
        //    return listStudents;
        //}
    }
}
