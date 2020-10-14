using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace Controllers{

    /* Modelo para generacion automatica de controllers
    dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem 
    -dc TodoContext -outDir Controllers*/

    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase{
        private readonly SchoolContext _context;

         public StudentController(SchoolContext context)
        {
        _context = context;
        }


         [HttpGet("getStudentList")]
        public async Task<ActionResult<List<UserEntity>>> GetAll(){

            var listUsers = await getListUsers();
            if(listUsers.Count < 0){
                return NotFound();
            }else{
                return listUsers;
            }
        }


        private async Task<List<UserEntity>> getListUsers(){
            var listUsers = new List<UserEntity>(){
                new UserEntity(){Id = 1, Name = "Amelie", Username = "Amelie", Password = "AArnham"},
                new UserEntity(){Id = 2, Name = "Alastair Jr.", Username = "Alastair", Password = "AHolybridge"},
                new UserEntity(){Id = 3, Name = "Allegra", Username = "Allegra", Password = "AHolybridge"},
                new UserEntity(){Id = 4, Name = "Hugh ", Username = "Hugh", Password = "HHolybridge"},
                new UserEntity(){Id = 5, Name = "Alastair Sr.", Username = "Alastair1", Password = "AHolybridge"}
            };

            return listUsers;

        }

        //Cambiar las listas harcodeadas por esto
            [HttpPost]
            public async Task<ActionResult<UserEntity>> PostNewUser(UserEntity userEntity)
            {
                _context.UserItems.Add(userEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PostNewUser), new { id = userEntity.Id }, userEntity);
            }
    }
}