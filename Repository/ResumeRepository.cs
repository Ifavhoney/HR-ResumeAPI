using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResumeAPI.Models;
using ResumeAPI.ViewModel;

namespace ResumeAPI.Repository
{
    public class ResumeRepository : IResumeRepository
    {

        ResumeContext db;
        public ResumeRepository(ResumeContext _db)
        {
            db = _db;
        }
        #region UserInfo
        public async Task<List<UserInfo>> GetAllUserInfo()
        {
            if (db != null)
            {
            
                return await db.UserInfo.ToListAsync();
            }
            return null;
        }


        public async Task<int> AddInfo(UserInfo userInfo)
        {
            int result = 0;
            if (db != null)
            {
                await db.AddAsync(userInfo);
                await db.SaveChangesAsync();
                return result = userInfo.Id;

            }
            return result;
        }


        public async Task UpdateInfo(UserInfo userInfo)
        {
            if (db != null)
            {
                db.UserInfo.Update(userInfo);
                await db.SaveChangesAsync();
            }
        }


        public async Task<int> DeleteInfo(int? infoID)
        {
            int result = 0;
            if (db != null)
            {
                //find ID
                var user = await db.UserInfo.FirstOrDefaultAsync(x => x.Id == infoID);
                if (user != null)
                {
                    db.UserInfo.Remove(user);
                    result = await db.SaveChangesAsync();

                }
                return result;
            }
            return result;
        }

        #endregion

        #region Resumes
        public async Task<List<ResumeViewModel>> GetAllUserResumes()
        {
            if (db != null)
            {
                List<ExperienceViewModel> myList = await (
                                                          from e in db.UserExperience

                                                          where e.Fk_Info_Id == e.Fk_Info_Id
                                                          select new ExperienceViewModel
                                                          {
                                                              JobTitle = e.JobTitle,
                                                              Duties = e.Duties,
                                                              MonthsSpent = e.MonthsSpent,
                                                              CurrentlyEmployed = e.CurrentlyEmployed,
                                                              Fk_Info_Id = e.Fk_Info_Id


                                                          }).ToListAsync();

               
                List<EducationViewModel> myEducationList =
                    await (   from ed in db.UserEducation
                           where ed.Fk_Info_Id == ed.Fk_Info_Id
                           select new EducationViewModel
                           {
                               School = ed.School,
                               Major = ed.Major,
                               DegreeType = ed.DegreeType,
                               Gpa = ed.Gpa,
                               Fk_Info_Id = ed.Fk_Info_Id



                           }).ToListAsync();

              List<OtherViewModel> myOtherList =
             await (
                    from o in db.UserOther
                    where o.Fk_Info_Id == o.Fk_Info_Id
                    select new OtherViewModel
                    {
                        Skills = o.Skills,
                        Bilingual = o.Bilingual,
                        Certification = o.Certification,
                        Fk_Info_Id = o.Fk_Info_Id


                    }).ToListAsync();


             List<UserInfoViewModel> myPersonalList  =
          await (from i in db.UserInfo
                 where i.Id == i.Id

                 select new UserInfoViewModel
                 {
                     Fullname = i.Fullname,
                     Address = i.Address,
                     Email = i.Email,
                     FieldOfExpertise = i.FieldOfExpertise,
                     Fk_Info_Id = i.Id



                 }).ToListAsync();
                                                                      
              return await (from i in db.UserInfo
                            from ed in db.UserEducation
                            where i.Id == ed.Fk_Info_Id
            
            
                            select new ResumeViewModel
                            {
                                Personal = myPersonalList,
                                // Fullname = i.Fullname,
                                // Address =  i.Address,
                                // Email = i.Email,
                                // FieldOfExpertise = i.FieldOfExpertise,
                                Education = myEducationList,
            
                                Experience = myList,
                                //    Duties = e.Duties,
                                //    MonthsSpent = e.MonthsSpent,
                                //    CurrentlyEmployed = e.CurrentlyEmployed,
            
                                Other = myOtherList,
                                //   Skills = o.Skills,
                                //   Bilingual = o.Bilingual,
                                //   Certification = o.Certification,
                            }).ToListAsync();
            }
            return null;
        }

         public async Task<List<ResumeViewModel>> GetStats(int? infoID)
         {
             if (db != null)
             {
                List<ExperienceViewModel> myList = await (from e in db.UserExperience
                              where e.Fk_Info_Id == infoID
                              select new ExperienceViewModel
                              {
                               // Fullname = i.Fullname,
                                  JobTitle = e.JobTitle,
                                  Duties = e.Duties,
                                  MonthsSpent = e.MonthsSpent,
                                  CurrentlyEmployed = e.CurrentlyEmployed,
                                  Fk_Info_Id = infoID

                              }).ToListAsync();
                
               

                List<EducationViewModel> myEducationList =
                    await (from ed in db.UserEducation
                           where ed.Fk_Info_Id == infoID
                           select new EducationViewModel
                           {
                               School = ed.School,
                               Major = ed.Major,
                               DegreeType = ed.DegreeType,
                               Gpa = ed.Gpa,
                               Fk_Info_Id = ed.Fk_Info_Id
                           }).ToListAsync();

                List<OtherViewModel> myOtherList =
               await (from o in db.UserOther
                      where o.Fk_Info_Id == infoID
                      select new OtherViewModel
                      {
                          Skills = o.Skills,
                          Bilingual = o.Bilingual,
                          Certification = o.Certification,
                          Fk_Info_Id = o.Fk_Info_Id

                      }).ToListAsync();

                List<UserInfoViewModel> myPersonalList =
         await (from i in db.UserInfo
                where i.Id == infoID

                select new UserInfoViewModel
                {
                    Fullname = i.Fullname,
                    Address = i.Address,
                    Email = i.Email,
                    FieldOfExpertise = i.FieldOfExpertise,
                    Fk_Info_Id = i.Id



                }).ToListAsync();

                return await (from ed in db.UserEducation
                              where ed.Fk_Info_Id == infoID
                              
                              select new ResumeViewModel
                              {
                                 Personal = myPersonalList,
                                 
                                  Education = myEducationList,

                                  Experience = myList,
                                  //    Duties = e.Duties,
                                  //    MonthsSpent = e.MonthsSpent,
                                  //    CurrentlyEmployed = e.CurrentlyEmployed,

                                  Other = myOtherList,
                                  //   Skills = o.Skills,
                                  //   Bilingual = o.Bilingual,
                                  //   Certification = o.Certification,
                              }).ToListAsync();
            }


        
            return null;
          }

        #endregion
        #region add,update,delete experience
        //ADDS SINGLE EXPERIENCE
        public async Task<int> addExperience(UserExperience experience)
        {
            int result = 0;
            if (db != null && experience.Fk_Info_Id != null)
            {
              await  db.AddAsync(experience);
               await db.SaveChangesAsync();
                return result = experience.Id;
                                                                      
            }
            return result;
        }


        public async Task updateExperience(UserExperience experience)
        {
            if (db != null && experience.Fk_Info_Id != null)
            {
               db.UserExperience.Update(experience);
               await db.SaveChangesAsync();
            }
        }


        //DELETES SINGLE EXPERIENCE
        public async Task<int> deleteExperience(int? infoID)
        {
            int result = 0;
           if (db != null)
            {
                //find ID
                var experience = await db.UserExperience.FirstOrDefaultAsync(x => x.Id == infoID);
                if (experience != null)
                {
                    db.UserExperience.Remove(experience);
                    result = await db.SaveChangesAsync();
               
                }
                return result; 
            }
            return result;
        }

        #endregion

        #region other
        public async Task<int> AddOther(UserOther other)
           {           
                int result = 0;
                if (db != null && other.Fk_Info_Id != null)
                {
                    await db.AddAsync(other);
                    await db.SaveChangesAsync();
                    return result = other.Id;

                }
            return result;

        }

        public async Task UpdateOther(UserOther other)
        {
            if (db != null && other.Fk_Info_Id != null)
            {
                db.UserOther.Update(other);
                await db.SaveChangesAsync();
            }
        }


        //DELETES SINGLE OTHER
        public async Task<int> DeleteOther(int? infoID)
        {
            int result = 0;
            if (db != null)
            {
                //find ID
                var other = await db.UserOther.FirstOrDefaultAsync(x => x.Id == infoID);
                if (other != null)
                {
                    db.UserOther.Remove(other);
                    result = await db.SaveChangesAsync();

                }
                return result;
            }
            return result;
        }
#endregion 



        //
        //    public Task deleteEducation(int? infoID)
        //    {
        //        throw new NotImplementedException();
        //    }
        //
        //    public Task<List<ResumeViewModel>> getAll()
        //    {
        //        throw new NotImplementedException();
        //    }
        //
        //
        //
        //    public Task<List<ResumeViewModel>> getUserEducation(int? infoID)
        //    {
        //        throw new NotImplementedException();
        //    }
        //
        //   
        //
        //
        //
        //    public Task<List<ResumeViewModel>> getUserOther(int? infoID)
        //    {
        //        throw new NotImplementedException();
        //    }
        //
        //    public Task updateEducation(UserEducation education)
        //    {
        //        throw new NotImplementedException();
        //    }
        //

    }
}
