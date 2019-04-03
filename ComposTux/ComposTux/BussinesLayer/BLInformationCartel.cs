using ComposTux.Entities;
using ComposTux.Helpers;
using ComposTux.Models;
using ComposTux.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ComposTux.BussinesLayer
{
    public class BLInformationCartel
    {
        public async Task<BaseResult<List<InformationCartel>>>Select(Guid IdUser)
        {
            BaseResult<List<InformationCartel>> baseresult = new BaseResult<List<InformationCartel>>();
            List<InformationCartel> list = new List<InformationCartel>();
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelInformationCartel(IdUser).ToList();
                    if(response.Count>0)
                    {
                        foreach(var item in response)
                        {
                            InformationCartel info = new InformationCartel();
                            info.Active = item.Active;
                            info.CartelDescription = item.CartelDescription;
                            info.DateCreated = item.DateCreated;
                            info.IdInformationCartel = item.IdInformationCartel;
                            info.IdUser = item.IdUser;
                            info.UrlImage = item.UrlImage;
                            list.Add(info);
                        }
                        baseresult.Count = response.Count;
                        baseresult.Message = "";
                        baseresult.Result = list;
                    }
                    else
                    {
                        baseresult.Count = 0;
                        baseresult.Message = "No hay datos";
                        baseresult.Result = null;
                    }
                }
                return baseresult;
            }
            catch(Exception ex)
            {
                baseresult.Count = 0;
                baseresult.Message = "No hay datos";
                baseresult.Result = null;
                return baseresult;
            }
        }

        public async Task<BaseResult<List<InformationCartel>>> SelectAll()
        {
            BaseResult<List<InformationCartel>> baseresult = new BaseResult<List<InformationCartel>>();
            List<InformationCartel> list = new List<InformationCartel>();
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spSelAllInformationCartel().ToList();
                    if (response.Count > 0)
                    {
                        foreach (var item in response)
                        {
                            InformationCartel info = new InformationCartel();
                            info.Active = item.Active;
                            info.CartelDescription = item.CartelDescription;
                            info.DateCreated = item.DateCreated;
                            info.IdInformationCartel = item.IdInformationCartel;
                            info.IdUser = item.IdUser;
                            info.UrlImage = item.UrlImage;
                            list.Add(info);
                        }
                        baseresult.Count = response.Count;
                        baseresult.Message = "";
                        baseresult.Result = list;
                    }
                    else
                    {
                        baseresult.Count = 0;
                        baseresult.Message = "No hay datos";
                        baseresult.Result = null;
                    }
                }
                return baseresult;
            }
            catch (Exception ex)
            {
                baseresult.Count = 0;
                baseresult.Message = "No hay datos";
                baseresult.Result = null;
                return baseresult;
            }
        }

        public async Task<bool>Insert(InformationCartelViewModel info)
        {
            try
            {
                if (info.ImageFile == null)
                {
                    return false;
                }
                info.UrlImage = UploadImage.ImagePath(info.ImageFile);
                using (var db = new ProyectosEntities())
                {
                    var response = db.spInsInformationCartel(info.IdUser, info.UrlImage, info.CartelDescription);
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

        public async Task<bool>Update(InformationCartel info)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spUpdInformationCartel(info.IdInformationCartel, info.UrlImage, info.CartelDescription);
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

        public  async Task<bool> Delete(Guid IdInformation)
        {
            try
            {
                using (var db = new ProyectosEntities())
                {
                    var response = db.spDelInformationCartel(IdInformation);
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