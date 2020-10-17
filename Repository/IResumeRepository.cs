using ResumeAPI.Models;
using ResumeAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI.Repository
{
  public interface IResumeRepository
    {
        #region user Info
        Task<List<UserInfo>> GetAllUserInfo();
        Task<int> AddInfo(UserInfo userInfo);
        Task UpdateInfo(UserInfo userInfo);
        Task<int> DeleteInfo(int? infoID);


        #endregion

        #region Resume View
        Task<List<ResumeViewModel>> GetAllUserResumes();
        Task<List<ResumeViewModel>> GetStats(int? infoID);
        #endregion
        
        #region experience
        Task<int> addExperience(UserExperience experience);
        Task updateExperience(UserExperience experience);
        Task<int> deleteExperience(int? infoID);
        #endregion
        #region Other
        Task<int> AddOther(UserOther other);
        Task UpdateOther(UserOther other);
        Task<int> DeleteOther(int? infoID);
        #endregion


        //Task updateEducation(UserEducation education);

        //I want to Delete the education of this user
        // public async Task<int> deleteEducation(int? infoID);












        //
    }
}
