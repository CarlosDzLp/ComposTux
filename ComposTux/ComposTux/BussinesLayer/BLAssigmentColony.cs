using ComposTux.Entities;
using ComposTux.Models;
using ComposTux.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ComposTux.BussinesLayer
{
    public class BLAssigmentColony
    {
        public async Task<BaseResult<AssigmentColony>>Select(Guid idUser)
        {
            BaseResult<AssigmentColony> basresult = new BaseResult<AssigmentColony>();
            try
            {              
                AssigmentColony colony = new AssigmentColony();
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelAssigmentColony(idUser).FirstOrDefault();
                    if(response!=null)
                    {
                        colony.Active = response.Active;
                        colony.DateCreated = response.DateCreated;
                        colony.IdAssigmentColony = response.IdAssigmentColony;
                        colony.IdColony = response.IdColony;
                        colony.IdUser = response.IdUser;
                        basresult.Count = 1;
                        basresult.Message = "";
                        basresult.Result = colony;
                    }
                    else
                    {
                        basresult.Count = 0;
                        basresult.Message = "No hay datos";
                        basresult.Result = null;
                    }
                }
                return basresult;
            }
            catch(Exception ex)
            {
                basresult.Count = 0;
                basresult.Message = "No hay datos";
                basresult.Result = null;
                return basresult;
            }
        }

        public async Task<BaseResult<List<Colony>>> SelectColony()
        {
            BaseResult<List<Colony>> basresult = new BaseResult<List<Colony>>();
            try
            {
                List<Colony> listcolony = new List<Colony>();
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelAllColony().ToList();
                    if (response.Count > 0)
                    {
                        foreach(var item in response)
                        {
                            Colony col = new Colony();
                            col.Active = item.Active;
                            col.ColonyAddress = item.ColonyAddress;
                            col.ColonyName = item.ColonyName;
                            col.DateCreated = item.DateCreated;
                            col.IdColony = item.IdColony;
                            col.IdProject = item.IdProject;
                            listcolony.Add(col);
                        }
                    }
                    else
                    {
                        basresult.Count = 0;
                        basresult.Message = "No hay datos";
                        basresult.Result = null;
                    }
                }
                return basresult;
            }
            catch (Exception ex)
            {
                basresult.Count = 0;
                basresult.Message = "No hay datos";
                basresult.Result = null;
                return basresult;
            }
        }

        public async Task<bool> Insert(AssigmentColony Assigment)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spInsAssigmentColony(Assigment.IdColony, Assigment.IdUser);
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
                return false;
            }
        }

        public async Task<bool> Update(AssigmentColony Assigment)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spUpdAssigmentColony(Assigment.IdAssigmentColony, Assigment.IdColony, Assigment.IdUser);
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
                return false;
            }
        }

        public async Task<bool>Delete(Guid IdAssigment)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spDelAssigmentColony(IdAssigment);
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