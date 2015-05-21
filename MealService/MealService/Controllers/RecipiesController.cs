using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MealService.Domain.Entities;
using MealService.Models;

namespace MealService.Controllers
{
    public class RecipiesController : ApiController
    {
        private MealServiceContext db = new MealServiceContext();

        // GET: api/Recipies
        public IQueryable<RecipieDTO> GetRecipies()
        {
            var recipies = from r in db.Recipies
                select new RecipieDTO()
                {
                    Id = r.Id,
                    RecipieName = r.RecipieName,
                    ChefName = r.Chef.Name
                };

            return recipies;
        }

        // GET: api/Recipies/5
        [ResponseType(typeof(RecipieDetailDTO))]
        public async Task<IHttpActionResult> GetRecipie(int id)
        {
            var recipie = await db.Recipies.Include(r => r.Chef).Select(r =>
              new RecipieDetailDTO()
              {
                  Id = r.Id,
                  RecipieName= r.RecipieName,
                  ChefName = r.Chef.Name,
                  Description = r.Description,
                  PreparationTime = r.PreparationTime,
                  Serves = r.Serves,
                  OriginCountry = r.OriginCountry
              }).SingleOrDefaultAsync(r => r.Id == id);
           
            if (recipie == null)
            {
                return NotFound();
            }

            return Ok(recipie);
        }

        // PUT: api/Recipies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipie(int id, Recipie recipie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipie.Id)
            {
                return BadRequest();
            }

            db.Entry(recipie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipies
        [ResponseType(typeof(Recipie))]
        public async Task<IHttpActionResult> PostRecipie(Recipie recipie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Recipies.Add(recipie);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            db.Entry(recipie).Reference(x => x.Chef).Load();

            var dto = new RecipieDTO()
            {
                Id = recipie.Id,
                RecipieName = recipie.RecipieName,
                ChefName = recipie.Chef.Name
            };


            return CreatedAtRoute("DefaultApi", new { id = recipie.Id }, dto);
        }

        // DELETE: api/Recipies/5
        [ResponseType(typeof(Recipie))]
        public async Task<IHttpActionResult> DeleteRecipie(int id)
        {
            Recipie recipie = await db.Recipies.FindAsync(id);
            if (recipie == null)
            {
                return NotFound();
            }

            db.Recipies.Remove(recipie);
            await db.SaveChangesAsync();

            return Ok(recipie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipieExists(int id)
        {
            return db.Recipies.Count(e => e.Id == id) > 0;
        }
    }
}