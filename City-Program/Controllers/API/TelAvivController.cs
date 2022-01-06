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
    public class TelAvivController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-76KPC67;Initial Catalog=TelavivDB;Integrated Security=True;Pooling=False";
        TelavivDataContext dataContext = new TelavivDataContext(connectionString);
        // GET: api/TelAviv
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success!", Citizens = dataContext.Citizens.ToList() });
            }
            catch (SqlException ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
            catch(Exception ex)
            {
                return Ok(new { Massage = "Faliure", ex.Message });
            }
        }

        // GET: api/TelAviv/5
        public IHttpActionResult GetById(int id)
        {
            try
            {
                return Ok(new { Massage = "Success!", Citizen = dataContext.Citizens.First(citizen => citizen.Id == id) });
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

        // POST: api/TelAviv
        public IHttpActionResult AddCitizen([FromBody]Citizen newCitizen)
        {
            try
            {
                dataContext.Citizens.InsertOnSubmit(newCitizen);
                dataContext.SubmitChanges();
                return Ok(new { Massage = "Success !New citizen on board!" });
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

        // PUT: api/TelAviv/5
        [HttpPut]
        public IHttpActionResult EditCitizen(int id, [FromBody]Citizen editedCitizen)
        {
            try
            {
                //dataContext.Citizens = from citizen in dataContext.Citizens where citizen.Id == id; 
                //expectedCitizen.FirstName = editedCitizen.FirstName;
                //expectedCitizen.LastName = editedCitizen.LastName;
                //expectedCitizen.BirthDate = editedCitizen.BirthDate;
                //expectedCitizen.Adress = editedCitizen.Adress;
                //expectedCitizen.YearsInCity = editedCitizen.YearsInCity;

                return Ok(new { Massage = "Success! Citizen been edited." });

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

        // DELETE: api/TelAviv/5
        public void Delete(int id)
        {
        }
    }
}
