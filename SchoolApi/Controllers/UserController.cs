using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace Controllers{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase{

        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> GetAll(){

            var listUsers = await getListUsers();
            if(listUsers.Count < 0){
                return NotFound();
            }else{
                return listUsers;
            }
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserEntity>> GetUser(UserModel userModel){
            var listUsers = await getListUsers();
             if(listUsers.Count < 0){
                return NotFound();
            }else{
                var userEntity = listUsers.FirstOrDefault(
                    u => u.Username == userModel.Username && u.Password == userModel.Password
                );
                if(userEntity == null){
                    return NotFound();
                }else{
                    return userEntity;
                }
            }
            
        }

        [HttpPost("newUser")]
        public async Task<ActionResult<List<UserEntity>>> CreateNewUser(UserEntity userEntity){
            var listUsers = await getListUsers();
             listUsers.Add(new UserEntity{
                Id = listUsers.Count + 1, 
                Name = userEntity.Name,
                Username = userEntity.Username,
                Password = userEntity.Password
             });

             return listUsers;
        }

        [HttpPut("editUser")]
        public async Task<ActionResult<List<UserEntity>>> PutEditUser(UserEntity userEntity){
            var listUsers = await getListUsers();

            var userUpdate = listUsers.Find(u => u.Id == userEntity.Id);
            if(userUpdate == null){
                return NotFound();
            }else{
                listUsers.First(u => u.Id == userUpdate.Id).Name = userEntity.Name;
                listUsers.First(u => u.Id == userUpdate.Id).Username = userEntity.Username;
                listUsers.First(u => u.Id == userUpdate.Id).Password = userEntity.Password;

            }
                return listUsers;
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult<List<UserEntity>>> deleteUser(int id){
            var listUsers = await getListUsers();
            var userDelete = listUsers.Find(u => u.Id == id);
            if(userDelete == null){
                return NotFound();
            }else{
                listUsers.Remove(userDelete);
            }
                return listUsers;


        }



        private async Task<List<UserEntity>> getListUsers(){
            var listUsers = new List<UserEntity>(){
                new UserEntity(){Id = 1, Name = "Arnham Holybridge, Amelie", Username = "Amy", Password = "TokenizedPasword"},
                new UserEntity(){Id = 2, Name = "Holybridge, Alastair Jr.", Username = "Dada", Password = "AnotherPassword"},
                new UserEntity(){Id = 3, Name = "Holybridge, Allegra", Username = "Myself", Password = "AnotherPassword022"},
                new UserEntity(){Id = 4, Name = "Holybridge, Hugh ", Username = "Uncle", Password = "AnotherPassword023"},
                new UserEntity(){Id = 5, Name = "Holybridge, Alastair Sr.", Username = "Grampa", Password = "AnotherPassword090"},


            };

            return listUsers;

        }


        public class UserModel{
            public String Username {set;get;}

            public String Password {set;get;}
        }
    }
}