using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjSessionCollege.Controllers;
using prjSessionCollege.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using prjSessionCollege.JSON;
using prjSessionCollege.Objects;


namespace prjSessionCollege.Models
{
    public class HomeViewModel
    {
        private static HomeViewModel instance = null;

        public string account = "";

        public static HomeViewModel getInstance()
        {
            if (HomeViewModel.instance == null)
            {
                HomeViewModel.instance = new HomeViewModel();
            }

            return HomeViewModel.instance;
        }

        public List<Person> dataPersons = new List<Person>();
        public List<Semester> dataSemesters = new List<Semester>();
        public List<Department> dataDepartments = new List<Department>();
        public List<CourseSemester> dataCourseSemester = new List<CourseSemester>();
        public List<CourseSemesterStudent> dataCourseSemesterStudent = new List<CourseSemesterStudent>();

        public string errorMessage = "";


        //////////////////////////////////////// GET METHODES  ////////////////////////////////////////

        public async Task AccountValidate(string Utilisateur, string Password)
        {

            try
            {
                this.account = "";
                this.errorMessage = "";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    string method = "AccountValidate";

                    string parameters = $"{{\"parameters\":[\"{Utilisateur}\",\"{Password}\"]}}";

                    HttpResponseMessage response = await client.GetAsync("College?method=" + method + "&parameters=" + parameters);

                    if (response.IsSuccessStatusCode)
                    {

                        
                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSON responseJSON = JsonSerializer.Deserialize<ResponseJSON>(cleanResponse);

                        if (responseJSON.status == "success")
                        {
                            await CourseSemesterGetAll();
                            account = Utilisateur;
                        }
                        else
                        {
                            //mauvais username ou password
                            errorMessage = "Les Informations Entrées ne sont pas Valides - Vérifiez votre nom d'Utilisateur et Entrez votre Mot de Passe à nouveau.";
                        }

                        // Success
                    }
                    else
                    {
                        //erreur(s) avec l'API
                        errorMessage = "Resultat échec avec API";
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }

        }

        public async Task CourseSemesterGetAll()
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //GET Method
                    string method = "CourseSemesterGetAll";
                    string parameters = "{\"parameters\":\"[]\"}"; //aucun parametre

                    HttpResponseMessage response = await client.GetAsync("College?method=" + method + "&parameters=" + parameters);

                    if (response.IsSuccessStatusCode)
                    {

                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSONCourseSemesters responseJSON = JsonSerializer.Deserialize<ResponseJSONCourseSemesters>(cleanResponse);

                        this.dataCourseSemester = responseJSON.data;

                        // Success
                    }
                    else
                    {
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }
        }

        public async Task CoursSemesterStudentGetAll(int CourseSemesterId)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //GET Method
                    string method = "CourseSemesterStudentGetAll";
                    string parameters = $"{{\"parmeters\":[\"{CourseSemesterId}\"]\"}}"; //aucun parametre

                    HttpResponseMessage response = await client.GetAsync("College?method=" + method + "&parameters=" + parameters);

                    if (response.IsSuccessStatusCode)
                    {

                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSONSemester responseJSON = JsonSerializer.Deserialize<ResponseJSONSemester>(cleanResponse);

                        this.dataCourseSemesterStudent = responseJSON.data;

                        // Success
                    }
                    else
                    {
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }
        }

        public async Task PersonGetAll (string role)
        {

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //GET Method
                    string method = "PersonGetAll";
                    string parameters = $"{{\"parameters\":[\"{role}\"]}}"; //"Teacher" ou "Student"

                    HttpResponseMessage response = await client.GetAsync("College?method=" + method + "&parameters=" + parameters);

                    if (response.IsSuccessStatusCode)
                    {

                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSONPerson responseJSON = JsonSerializer.Deserialize<ResponseJSONPerson>(cleanResponse);

                        dataPersons = responseJSON.data;

                        // Success
                    }
                    else
                    {
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }

        }

        /* public List<CourseSemester> DataCourseSemesters
         {
             get
             {
                 return this.dataCourseSemesters.OrderBy(cs => cs.LastName).ToList();
             }
         }*/


        //////////////////////////////////////// POST METHODES  ////////////////////////////////////////

        public async Task CourseSemesterStudentInsert(int CourseSemesterId, int StudentId)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //POST Method
                    string method = "CourseSemesterStudentInsert";
                    string parameters = "{\"parameters\":[\"" + CourseSemesterId + "\",\"" + StudentId + "\"}";

                    HttpResponseMessage response = await client.PostAsync("College?method=" + method + "&parameters=" + parameters, new StringContent(""));

                    if (response.IsSuccessStatusCode)
                    {

                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSONCourseSemesters responseJSON = JsonSerializer.Deserialize<ResponseJSONCourseSemesters>(cleanResponse);

                        this.dataCourseSemester = responseJSON.data;

                        // Success
                    }
                    else
                    {
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }
        }


        //////////////////////////////////////// PATCH METHODES  ////////////////////////////////////////

        public async Task CourseSemesterUpdateTeacher(int CourseSemesterId, int TeacherId)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //POST Method
                    string method = "CourseSemesterUpdateTeacher";
                    string parameters = "{\"parameters\":[\"" + CourseSemesterId + "\",\"" + TeacherId + "\"}";

                    HttpResponseMessage response = await client.PatchAsync("College?method=" + method + "&parameters=" + parameters, new StringContent(""));

                    if (response.IsSuccessStatusCode)
                    {

                        string responseSTR = await response.Content.ReadAsStringAsync();
                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSONCourseSemesters responseJSON = JsonSerializer.Deserialize<ResponseJSONCourseSemesters>(cleanResponse);

                        this.dataCourseSemester = responseJSON.data;

                        // Success
                    }
                    else
                    {
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }
        }

        public async Task CourseSemesterStudentUpdateGrade(int CourseSemesterId, int StudentId, decimal Grade)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //POST Method
                    string method = "CourseSemesterStudentUpdateGrade";
                    string parameters = "{\"parameters\":[\"" + CourseSemesterId + "\",\"" + StudentId + "\",\"" + Grade + "\"}";

                    HttpResponseMessage response = await client.PatchAsync("College?method=" + method + "&parameters=" + parameters, new StringContent(""));

                    if (response.IsSuccessStatusCode)
                    {

                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSONCourseSemesters responseJSON = JsonSerializer.Deserialize<ResponseJSONCourseSemesters>(cleanResponse);

                        this.dataCourseSemester = responseJSON.data;

                        // Success
                    }
                    else
                    {
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }
        }

        //////////////////////////////////////// PUT METHODES  ////////////////////////////////////////

        public async Task UpdatePerson(string FirstName, string LastName, string Phone, string Email, string Role)
        {

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    string method = "PersonUpdateInfo";

                    string parameters = "{\"parameters\":[\"" + FirstName + "\",\"" + LastName + "\",\"" + Phone + "\",\"" + Email + "\",\"" + DateTime.Now + "\",\"" + Role + "\"]}";

                    HttpResponseMessage response = await client.PutAsync("College?method=" + method + "&parameters=" + parameters, new StringContent(""));

                    if (response.IsSuccessStatusCode)
                    {


                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSON responseJSON = JsonSerializer.Deserialize<ResponseJSON>(cleanResponse);

                        if (responseJSON.status == "success")
                        {
                            int y = 0;
                        }
                        else
                        {
                            int z = 0;
                        }

                        // Success
                    }
                    else
                    {
                        int x = 0;
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }

        }


        //////////////////////////////////////// DELETE METHODES  ////////////////////////////////////////

        public async Task CourseSemesterStudentDelete( int CourseSemesterId, int PersonId)
        {

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7218");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    string method = "CourseSemesterStudentDelete";

                    string parameters = "{\"parameters\":[\"" + CourseSemesterId + "\",\"" + PersonId + "\"]}";

                    HttpResponseMessage response = await client.DeleteAsync("College?method=" + method + "&parameters=" + parameters);

                    if (response.IsSuccessStatusCode)
                    {


                        string responseSTR = await response.Content.ReadAsStringAsync();

                        string cleanResponse = "";
                        cleanResponse = responseSTR.Replace(@"\", "");
                        cleanResponse = cleanResponse.Substring(1, cleanResponse.Length - 2);

                        ResponseJSON responseJSON = JsonSerializer.Deserialize<ResponseJSON>(cleanResponse);

                        if (responseJSON.status == "success")
                        {
                            int y = 0;
                        }
                        else
                        {
                            int z = 0;
                        }

                        // Success
                    }
                    else
                    {
                        int x = 0;
                        // Message a l'utilisateur
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Try/Catch Error");
            }

        }



        public string ErrorMessage
        {
            get { return this.errorMessage; }
        }
    }
}