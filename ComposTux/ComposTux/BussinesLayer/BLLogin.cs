using ComposTux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ComposTux.Entities;
using ComposTux.Models;

namespace ComposTux.BussinesLayer
{
    public class BLLogin
    {
        public async Task<BaseResult<User>> DoLogin(string userName,string password)
        {
            try
            {
                BaseResult<User> userResult = new BaseResult<User>();
                User user = new User();
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelUser(userName, password).FirstOrDefault();
                    if(response != null)
                    {
                        user.IdUser = response.IdUser;
                        user.LastNameUser = response.LastNameUser;
                        user.Latitud = response.Latitud;
                        user.Longitud = response.Longitud;
                        user.NameUser = response.NameUser;
                        user.PasswordUser = response.PasswordUser;
                        user.Privacity = response.Privacity;
                        user.UserActive = response.UserActive;
                        user.UserName = response.UserName;
                        user.UserType = response.UserType;
                        user.Email = response.Email;
                        userResult.Result = user;
                        userResult.Message = "";
                        userResult.Count = 1;
                    }
                    else
                    {
                        userResult.Result = null;
                        userResult.Message = "Usuario no encontrado";
                        userResult.Count = 0;
                    }
                }
                return userResult;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }
        public async Task<bool> InsertUser(UserViewModel user)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spInserUser(user.playerId,user.pushToken, user.UserName, user.LastNameUser, user.NameUser, user.Email, user.PasswordUser, user.UserType, user.Privacity, user.Latitud, user.Longitud);
                    if (response == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateUser(UserViewModel user)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spUpdUser(user.IdUser, user.UserName, user.LastNameUser, user.NameUser, user.Email, user.PasswordUser, user.UserType, user.Privacity, user.Latitud, user.Longitud);
                    if (response == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}