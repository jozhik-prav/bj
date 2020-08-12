using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulletJournal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : ControllerBase
    {
        /// <summary>
        /// База данных
        /// </summary>
        BulletJournalContext db;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="context"></param>
        public WishController(BulletJournalContext context)
        {
            db = context;
        }

        /// <summary>
        /// Получение всех желаний
        /// </summary>
        /// <returns>Список желаний</returns>
        [HttpGet]
        public IEnumerable<Wish> GetAll()
        {
            return db.Wishes.ToList();
        }

        /// <summary>
        /// Получение желания по Id
        /// </summary>
        /// <param name="id">Идентификатор желания</param>
        /// <returns>Желание</returns>
        [HttpGet("{id}", Name = "GetWish")]
        public IActionResult GetById(Guid id)
        {
            var wish = db.Wishes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (wish == null)
            {
                return NotFound();
            }
            return new ObjectResult(wish);
        }

        /// <summary>
        /// Создание желания
        /// </summary>
        /// <param name="wish">Желание</param>
        /// <returns>Новое желание</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Wish wish)
        {
            if (wish == null)
            {
                return NotFound();
            }
            var newWish = new Wish { Name = wish.Name, Description = wish.Description, Category = wish.Category, Priority = wish.Priority, IsComplete = wish.IsComplete};
            db.Wishes.Add(newWish);
            db.SaveChanges();
            return Ok(newWish);
        }

        /// <summary>
        /// Замена желания
        /// </summary>
        /// <param name="id">Идентификатор желания</param>
        /// <param name="wish">Желание</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Wish wish)
        {
            if (wish == null || wish.Id != id)
            {
                return BadRequest();
            }

            if (db.Wishes.Any(x => x.Id == id))
            {
                return NotFound();
            }
            db.Entry(wish).State = EntityState.Modified;
            db.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// Обновление желания
        /// </summary>
        /// <param name="patchDoc">JsonPatch с изменениями</param>
        /// <param name="id">Идентификатор желания</param>
        /// <returns>Обновленое желание</returns>
        [HttpPatch("{id}")]
        public IActionResult Update(JsonPatchDocument<Wish> patchDoc, Guid id)
        {
            if (patchDoc != null)
            {
                var wish = db.Wishes.FirstOrDefault(x => x.Id == id);

                patchDoc.ApplyTo(wish, ModelState);

                db.Wishes.Update(wish);

                db.SaveChanges();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(wish);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Удаление желания
        /// </summary>
        /// <param name="id">Идентификатор желания</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var wish = db.Wishes.FirstOrDefault(x => x.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            db.Wishes.Remove(wish);
            db.SaveChanges();
            return new NoContentResult();
        }
    }
}
