using AdminRealState.Models;
using AdminRealState.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;
using AdminRealState.ExtraClass;

namespace AdminPanel.Models
{
    [Table("tblProject")]
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public Nullable<System.DateTime> Possession { get; set; }
        public long Pricing { get; set; }
        public float AverageRating { get; set; }
        [Required(ErrorMessage = "Please Upload ProfilePicture")]
        public string ProfilePicture { get; set; }
        public string CoverPicture { get; set; }
        [RegularExpression(@"(a-zA-Z0-9\s_\\.\-:])+(.png |.jpg |.gif)$",ErrorMessage = "Incorrect Image format")]
        public HttpPostedFileBase ProfilePictureDetail { get; set; }
        [RegularExpression(@"(a-zA-Z0-9\s_\\.\-:])+(.png |.jpg |.gif)$", ErrorMessage = "Incorrect Image format")]
        public HttpPostedFileBase CoverPictureDetail { get; set; }
        public List<Amenity> Amenities { get; set; }
        public List<ApartmentBuildQuality> ApartmentBuildQualities { get; set; }
        public List<BuilderProfile> BuilderProfiles { get; set; }
        public List<ConstructionQualityParameter> ConstructionQualityParameters { get; set; }
        public List<Images> Images { get; set; }
        [RegularExpression(@"(a-zA-Z0-9\s_\\.\-:])+(.png |.jpg |.gif)$", ErrorMessage = "Incorrect Image format")]
        public List<HttpPostedFileBase> ProjectImagesDetails { get; set; }
        public IntroductoryVideo IntroductoryVideos { get; set; }
        [RegularExpression(@"^.*\.(avi|AVI|wmv|WMV|flv|FLV|mpg|MPG|mp4|MP4)$", ErrorMessage = "Incorrect Video format")]
        public HttpPostedFileBase IntroDuctoryVideosDetails { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<LegalClarity> LegalClarities { get; set; }
        public List<Livability> Livabilities { get; set; }
        public Location Locations { get; set; }
        public List<ProjectInformation> ProjectInformations { get; set; }
        public List<ChooseImageToBeDeleted> ImageToBeDeleted { get; set; }

        ProjectRepository objProjectRepository = new ProjectRepository();
        public bool CreateNewProject(Project objProject, out int isProjectId)
        {

            bool status = objProjectRepository.CreateNewProperty(objProject, out isProjectId);
            if (status == true)
            {

                return true;
            }
            isProjectId = 0;
            return false;
        }
        public Project CheckProjectIdIsPresent(int? projectId)
        {
            Project objProject = objProjectRepository.CheckProjectIdIsPresent(projectId);
            return objProject;
        }
        public bool DeleteProjectByProjectId(int projectId)
        {
            bool isDeleted = objProjectRepository.DeleteProjectByProjectId(projectId);
            return isDeleted;
        }

        public List<Project> GetAllProject()
        {
            List<Project> ListOfAllProject =objProjectRepository.GetAllData();
            return ListOfAllProject;
        }
        public bool GetProjectById(int projectId, ref Project objProject)
        {
            bool isRetrieved = objProjectRepository.GetProjectById(projectId, ref objProject);
            return isRetrieved;
        }
        public bool EditProject(Project objProject)
        {
            bool isEdited = objProjectRepository.EditProject(objProject);
            return isEdited;
        }

        
    }
}