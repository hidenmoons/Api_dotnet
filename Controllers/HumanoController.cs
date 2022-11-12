using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Dotnet.Models;
using Microsoft.EntityFrameworkCore;


namespace Api_Dotnetutamiento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        private readonly db_humanosContext dbHumanosContext;
        private static readonly string[] nombres = new[]
       {
        "Juan", "Antonio", "Joan", "MANUEL", "DAVID", "JOAQUIN", "MIGUEL", "PILAR", "ALFONSO", "MARIO"
    };
        public HumanoController(db_humanosContext dbHumanosContext)
        {
            this.dbHumanosContext = dbHumanosContext;
        }
       
        [HttpGet]
        [Route("List")]
        public IEnumerable<Humano> GetList() 
        {
            Random random = new Random();
            var humano = new List<Humano>()
            {
                new Humano(){Id = 1, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="female", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
                new Humano(){Id = 2, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="male", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
                new Humano(){Id = 3, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="female", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
                new Humano(){Id = 4, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="male", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
                new Humano(){Id = 5, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="female", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
                new Humano(){Id = 6, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="female", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
                new Humano(){Id = 7, Nombre =nombres[random.Next(nombres.Length)].ToUpper(), Sexo="male", Peso=random.Next(40,200),Altura=random.Next(150,220),Edad=random.Next(18,102)},
            };

            return humano.ToArray();
        }
        [HttpGet]
        public async Task<IActionResult> GetHumanos()
        {
            return Ok(await dbHumanosContext.Humanos.ToListAsync());

        }
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> GetHumanById([FromRoute] int Id)
        {
            var Humano = await dbHumanosContext.Humanos.FindAsync(Id);
            if (Humano == null)
            {
                return NotFound();
            }

            return Ok(Humano);

        }
        [HttpPost]
        public async Task<IActionResult> AddHuman(AddHuman AddHuman)
        {
            var humano = new Humano()
            {

                Nombre = AddHuman.Nombre,
                Sexo = AddHuman.Sexo,
                Edad = AddHuman.Edad,
                Altura = AddHuman.Altura,
                Peso = AddHuman.Peso
            };
            await dbHumanosContext.Humanos.AddAsync(humano);
            await dbHumanosContext.SaveChangesAsync();

            return Ok(humano);
        }
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult> UpdateHuman([FromRoute]int Id,UpdateHuman UpdateHuman)
        {
            var humano = await dbHumanosContext.Humanos.FindAsync(Id);

            if (humano == null)
            {
                return NotFound();
            }

            humano.Nombre = UpdateHuman.Nombre;
            humano.Edad = UpdateHuman.Edad;
            humano.Sexo = UpdateHuman.Sexo;
            humano.Altura = UpdateHuman.Altura;
            humano.Peso = UpdateHuman.Peso;
            await dbHumanosContext.SaveChangesAsync();
            return Ok(humano);
           
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteHuman([FromRoute]int Id)
        {
            var humano = await dbHumanosContext.Humanos.FindAsync(Id);
            if(humano == null)
            {
                return NotFound("El id" +" "+ Id+" " + "no existe");
            }
            dbHumanosContext.Remove(humano);
            await dbHumanosContext.SaveChangesAsync();
            return Ok("Se elemino el humano" +" " + humano.Nombre);
            
        }
    }
}
