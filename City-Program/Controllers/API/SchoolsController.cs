using City_Program.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace City_Program.Controllers.API
{
    public class SchoolsController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-76KPC67;Initial Catalog=TelavivDB;Integrated Security=True;Pooling=False";
        SchoolsDataContext dataContext = new SchoolsDataContext(connectionString);
        // GET: api/Schools
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success!", Citizens = dataContext.Schools.ToList() });
            }
            catch(SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch(Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // GET: api/Schools/5
        public IHttpActionResult GetById(int id)
        {
            try
            {
                return Ok(new { Massage = "Success!", School = dataContext.Schools.First(citizen => citizen.Id == id) });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // POST: api/Schools
        public IHttpActionResult AddSchool([FromBody]School newSchool)
        {
            try
            {
                dataContext.Schools.InsertOnSubmit(newSchool);
                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success! new school added" });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }

        }

        // PUT: api/Schools/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] School editedSchool)
        {
            try
            {
                School expectedSchool = dataContext.Schools.Single(school => school.Id == id);

                expectedSchool.Name = editedSchool.Name;
                expectedSchool.Street = editedSchool.Street;
                expectedSchool.IsPublic = editedSchool.IsPublic;
                expectedSchool.StudentsAmount = editedSchool.StudentsAmount;

                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success! school been edited" });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // DELETE: api/Schools/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.Schools.DeleteOnSubmit(dataContext.Schools.First(school => school.Id == id));
                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success! School deleted" });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch (Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }
    }
}
