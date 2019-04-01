using ComposTux.Entities;
using ComposTux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ComposTux.BussinesLayer
{
    public class BLAssingment
    {
        public async Task<AssignUserCompany> SelectAssignUserCompany(Guid IdUser)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelAssignUserCompany(IdUser).FirstOrDefault();
                    if (response != null)
                    {
                        AssignUserCompany token = new AssignUserCompany();
                        token.DateCreated = response.DateCreated;
                        token.Datemodified = response.Datemodified;
                        token.IdAssignUserCompany = response.IdAssignUserCompany;
                        token.IdCompany = response.IdCompany;
                        token.IdUser = response.IdUser;
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
        public async Task<bool> InsertAssignUserCompany(AssignUserCompany assignUserCompany)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spInsAssignUserCompany(assignUserCompany.IdCompany, assignUserCompany.IdUser);
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