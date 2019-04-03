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
        public async Task<BaseResult<User>>GetUser(string UserName,string Password)
        {
            try
            {
                BaseResult<User> result = new BaseResult<User>();
                User user = new User();
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelUser(UserName, Password).FirstOrDefault();
                    if (response != null)
                    {
                        user.IdUser = response.IdUser;
                        user.LastNameUser=response.LastNameUser;
                        user.Latitud=response.Latitud;
                        user.Longitud=response.Longitud;
                        user.NameUser=response.NameUser;
                        user.PasswordUser=response.PasswordUser;
                        user.Privacity=response.Privacity;
                        user.UserActive=response.UserActive;
                        user.UserName=response.UserName;
                        user.UserType=response.UserType;
                        user.Email = response.Email;

                        result.Count = 1;
                        result.Message = "";
                        result.Result = user;
                    }
                    else
                    {
                        result.Count = 0;
                        result.Message = "Usuario no encontrado";
                        result.Result = null;
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<bool>InsertUser(UserViewModel user)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spInsUser(user.NameUser, user.LastNameUser, user.UserName, user.Email, user.PasswordUser, user.Latitud, user.Longitud, user.playerId, user.pushToken);
                    if(response==-1)
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
                return false;
            }
        }

        public async Task<bool>Update(User user)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spUpdUser(user.IdUser, user.NameUser, user.LastNameUser, user.UserName, user.Email, user.PasswordUser, user.Latitud, user.Longitud);
                    if(response==-1)
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
                return false;
            }
        }

        public async Task<bool> DeleteUser(Guid IdUser)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spDelUser(IdUser);
                    if(response==-1)
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
                return false;
            }
        }
    }
}