using ComposTux.Entities;
using ComposTux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ComposTux.BussinesLayer
{
    public class BLToken
    {
        public async Task<bool>UpdateToken(Token token)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spUpdToken(token.IdUser, token.PlayerId, token.PushToken);
                    if(response == -1)
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
        public async Task<Token> SelectToken(Guid IdUser)
        {
            try
            {              
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelToken(IdUser).FirstOrDefault();
                    if (response != null)
                    {
                        Token token = new Token();
                        token.IdToken = response.IdToken;
                        token.IdUser = response.IdUser;
                        token.PlayerId = response.PlayerId;
                        token.PushToken = response.PushToken;
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}