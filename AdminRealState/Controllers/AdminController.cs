using AdminPanel.Models;
using AdminRealState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdminRealState.Controllers
{
    public class AdminController : Controller
    {
        #region Object for all classes declared.
        Project objProject = new Project();
        Amenity objAmenity = new Amenity();
        ApartmentBuildQuality objApartmentBuildQuality = new ApartmentBuildQuality();
        BuilderProfile objBuilderProfile = new BuilderProfile();
        ConstructionQualityParameter objConstructionQualityParameter = new ConstructionQualityParameter();
        Images objImages = new Images();
        IntroductoryVideo objIntroductoryVideo = new IntroductoryVideo();
        Inventory objInventory = new Inventory();
        LegalClarity objLegalClarity = new LegalClarity();
        Livability objLivability = new Livability();
        Location objLocation = new Location();
        ProjectInformation objProjectInformation = new ProjectInformation();
        RecentlyViewed objRecentlyViewed = new RecentlyViewed();
        Review objReview = new Review();
        UpdatedVideo objUpdateVideo = new UpdatedVideo();
        FollowProject objFollowProject = new FollowProject();
        MasterAmenity objMasterAmenity = new MasterAmenity();
        MasterApartmentBuildQuality objMasterApartmentBuildQuality = new MasterApartmentBuildQuality();
        MasterConstructionQualityParameter objMasterConstructionQualityParameter = new MasterConstructionQualityParameter();
        MasterInventory objMasterInventory = new MasterInventory();
        MasterBuilderProfile objMasterBuilderProfile = new MasterBuilderProfile();
        MasterLegalClarity objMasterLegalClarity = new MasterLegalClarity();
        MasterLivability objMasterLivability = new MasterLivability();
        MasterProjectInformation objMasterProjectInformation = new MasterProjectInformation();
        MasterReview objMasterReview = new MasterReview();
        City objCity = new City();
        User objUser = new User();
        #endregion

        //GET: Admin/CreateNewProject
        [HttpGet]
        public ActionResult CreateNewProject()
        {
            ViewBag.dataMasterAmenity = objMasterAmenity.GetAllData();
            ViewBag.dataMasterApartmentBuildQuality = objMasterApartmentBuildQuality.GetAllData();
            ViewBag.dataMasterConstructionQualityParameter = objMasterConstructionQualityParameter.GetAllData();
            ViewBag.dataMasterInventory = objMasterInventory.GetAllData();
            ViewBag.dataMasterLegalClarity = objMasterLegalClarity.GetAllData();
            ViewBag.dataMasterLivability = objMasterLivability.GetAllData();
            ViewBag.dataMasterProjectInformation = objMasterProjectInformation.GetAllData();
            ViewBag.dataMasterBuilderProfile = objMasterBuilderProfile.GetAllData();
            ViewBag.dataCity = objCity.GetAllData();
            return View();
        }

        // POST: Admin/CreateNewProject
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateNewProject(Project objProject)
        {
            if (objProject.Name != null)
            {
                if (!ModelState.IsValid)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
                }
                int id;
                bool projectIsFilled = objProject.CreateNewProject(objProject, out id);
                objProject.Id = id;
                bool amenityIsFilled = objAmenity.FillAmenity(objProject);
                bool apartmentBuildQualityIsFilled = objApartmentBuildQuality.FillApartmentBuildQuality(objProject);
                bool builderProfileIsFilled = objBuilderProfile.FillBuilderProfile(objProject);
                bool constructionQualityParameterIsFilled = objConstructionQualityParameter.FillConstructionQualityParameter(objProject);
                bool imagesIsFilled = objImages.FillImages(objProject);
                bool introductoryVideoIsFilled = objIntroductoryVideo.FillIntroductoryVideo(objProject);
                bool inventoryIsFilled = objInventory.FillInventory(objProject);
                bool legalClarityIsFilled = objLegalClarity.FillLegalClarity(objProject);
                bool livabilityIsFilled = objLivability.FillLivability(objProject);
                bool locationIsFilled = objLocation.FillLocation(objProject);
                bool projectInformationIsFilled = objProjectInformation.FillProjectInformation(objProject);
                bool projectIsCreated = (projectIsFilled && amenityIsFilled && apartmentBuildQualityIsFilled
                                         && builderProfileIsFilled && constructionQualityParameterIsFilled
                                         && imagesIsFilled && introductoryVideoIsFilled && inventoryIsFilled
                                         && legalClarityIsFilled && livabilityIsFilled && locationIsFilled
                                         && projectInformationIsFilled);
                if (projectIsCreated)
                    return RedirectToAction("ViewAllProject");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");

        }

        // GET: /Admin/DeleteProjectById/projectId
        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteProjectById(int? id)


        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int? projectId = id;
            Project objProject = new Project();
            objProject = objProject.CheckProjectIdIsPresent(id);
            if (objProject != null)
            {
                return View(objProject);
            }
            return HttpNotFound();
        }

        // POST: /Admin/DeleteProjectById/projectId
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteProjectById(int id)
        {
            int projectId = id;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Model State");
                return View();
            }
            bool projectIsDeleted = objProject.DeleteProjectByProjectId(projectId);
            return RedirectToAction("ViewAllProject");
        }
        [HttpGet, ActionName("ViewProject")]
        public ActionResult RetrieveProjectByProjectId(int id)

        {
            int projectId = id;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Model State");
                return View();
            }
            ViewBag.dataMasterAmenity = objMasterAmenity.GetAllData();
            ViewBag.dataMasterApartmentBuildQuality = objMasterApartmentBuildQuality.GetAllData();
            ViewBag.dataMasterConstructionQualityParameter = objMasterConstructionQualityParameter.GetAllData();
            ViewBag.dataMasterInventory = objMasterInventory.GetAllData();
            ViewBag.dataMasterLegalClarity = objMasterLegalClarity.GetAllData();
            ViewBag.dataMasterLivability = objMasterLivability.GetAllData();
            ViewBag.dataMasterProjectInformation = objMasterProjectInformation.GetAllData();
            ViewBag.dataCity = objCity.GetAllData();
            ViewBag.dataMasterBuilderProfile = objMasterBuilderProfile.GetAllData();

            bool isRetrievedProject = objProject.GetProjectById(projectId, ref objProject);
            bool isRetrievedLocation = objLocation.GetLocationByProjectId(projectId, ref objProject);
            bool isRetrievedImage = objImages.GetImageByProjectId(projectId, ref objProject);
            bool isRetrievedBuilderProfile = objBuilderProfile.GetBuilderProfileByProjectId(projectId, ref objProject);
            bool isRetrievedAmenity = objAmenity.GetAmenityByProjectId(projectId, ref objProject);
            bool isRetrievedApartmentBuildQuality = objApartmentBuildQuality.GetApartmentbuildQualityByProjectId(projectId, ref objProject);
            bool isRetrievedConstructionQualityParameter = objConstructionQualityParameter.GetConstructionQualityParameterByProjectId(projectId, ref objProject);
            bool isRetrievedIntroductoryVideo = objIntroductoryVideo.GetIntroductoryVideoByProjectId(projectId, ref objProject);
            bool isRetrievedInventory = objInventory.GetInventoryByProjectId(projectId, ref objProject);
            bool isRetrievedLegalClarity = objLegalClarity.GetLegalClarityByProjectId(projectId, ref objProject);
            bool isRetrievedLivability = objLivability.GetLivabilityByProjectId(projectId, ref objProject);
            bool isRetrievedProjectInformation = objProjectInformation.GetProjectInformationByProjectId(projectId, ref objProject);
            return View(objProject);

        }
        [HttpGet, ActionName("EditProject")]
        public ActionResult EditProjectByProjectId(int id)
        {

            int projectId = id;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Model State");
                return View();
            }

            ViewBag.dataMasterAmenity = objMasterAmenity.GetAllData();
            ViewBag.dataMasterApartmentBuildQuality = objMasterApartmentBuildQuality.GetAllData();
            ViewBag.dataMasterConstructionQualityParameter = objMasterConstructionQualityParameter.GetAllData();
            ViewBag.dataMasterInventory = objMasterInventory.GetAllData();
            ViewBag.dataMasterLegalClarity = objMasterLegalClarity.GetAllData();
            ViewBag.dataMasterLivability = objMasterLivability.GetAllData();
            ViewBag.dataMasterProjectInformation = objMasterProjectInformation.GetAllData();
            ViewBag.dataCity = objCity.GetAllData();
            ViewBag.dataMasterBuilderProfile = objMasterBuilderProfile.GetAllData();

            bool isRetrievedProject = objProject.GetProjectById(projectId, ref objProject);
            bool isRetrievedLocation = objLocation.GetLocationByProjectId(projectId, ref objProject);
            bool isRetrievedImage = objImages.GetImageByProjectId(projectId, ref objProject);
            bool isRetrievedBuilderProfile = objBuilderProfile.GetBuilderProfileByProjectId(projectId, ref objProject);
            bool isRetrievedAmenity = objAmenity.GetAmenityByProjectId(projectId, ref objProject);
            bool isRetrievedApartmentBuildQuality = objApartmentBuildQuality.GetApartmentbuildQualityByProjectId(projectId, ref objProject);
            bool isRetrievedConstructionQualityParameter = objConstructionQualityParameter.GetConstructionQualityParameterByProjectId(projectId, ref objProject);
            bool isRetrievedIntroductoryVideo = objIntroductoryVideo.GetIntroductoryVideoByProjectId(projectId, ref objProject);
            bool isRetrievedInventory = objInventory.GetInventoryByProjectId(projectId, ref objProject);
            bool isRetrievedLegalClarity = objLegalClarity.GetLegalClarityByProjectId(projectId, ref objProject);
            bool isRetrievedLivability = objLivability.GetLivabilityByProjectId(projectId, ref objProject);
            bool isRetrievedProjectInformation = objProjectInformation.GetProjectInformationByProjectId(projectId, ref objProject);
            return View(objProject);

        }
        [HttpPost, ActionName("EditProject")]
        public ActionResult EditProjectByProjectId(Project objProject)
        {
            bool amenityIsEdited = objAmenity.EditAmenity(objProject);
            bool apartmentBuildQualityIsEdited = objApartmentBuildQuality.EditApartmentBuildQuality(objProject);
            bool builderProfileIsEdited = objBuilderProfile.EditBuilderProfile(objProject);
            bool constructionQualityParameterIsEdited = objConstructionQualityParameter.EditConstructionQualityParameter(objProject);
            bool imagesIsEdited = objImages.EditImages(objProject);
            bool introductoryVideoIsEdited = objIntroductoryVideo.EditIntroductoryVideo(objProject);
            bool inventoryIsEdited = objInventory.EditInventory(objProject);
            bool legalClarityIsEdited = objLegalClarity.EditLegalClarity(objProject);
            bool livabilityIsEdited = objLivability.EditLivability(objProject);
            bool locationIsEdited = objLocation.EditLocation(objProject);
            bool projectInformation = objProjectInformation.EditProjectInformation(objProject);
            bool projectIsEdited = objProject.EditProject(objProject);
            return RedirectToAction("ViewProject/" + objProject.Id);
        }
        [HttpGet, ActionName("ViewAllProject")]
        public ActionResult ViewAllProject()
        {
            //  List<Project> ListOfAllProject = objProject.GetAllProject();
            return View(objProject.GetAllProject());

        }
        [HttpGet, ActionName("ManageAmenity")]
        public ActionResult ManageMasterAmenity(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterAmenity.GetAllData());
        }
        [HttpPost, ActionName("ManageAmenity")]
        public ActionResult ManageMasterAmenity(MasterAmenity objMasterAmenity)
        {
            bool isAdded = objMasterAmenity.AddNewMasterAmenity(objMasterAmenity);
            return View(objMasterAmenity.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterAmenity")]
        public ActionResult DeleteMasterAmenity(int? id)
        {
            bool isDeleted = objMasterAmenity.DeleteMasterAmenityById((int)id);
            return RedirectToAction("ManageAmenity");
        }
        [HttpGet, ActionName("ManageApartmentBuildQuality")]
        public ActionResult ManageMasterApartmentBuildQuality(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterApartmentBuildQuality.GetAllData());
        }
        [HttpPost, ActionName("ManageApartmentBuildQuality")]
        public ActionResult ManageMasterApartmentBuildQuality(MasterApartmentBuildQuality objMasterApartmentBuildQuality)
        {
            bool isAdded = objMasterApartmentBuildQuality.AddNewMasterApartmentBuildQuality(objMasterApartmentBuildQuality);
            return View(objMasterApartmentBuildQuality.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterApartmentBuildQuality")]
        public ActionResult DeleteMasterApartmentBuildQuality(int? id)
        {
            bool isDeleted = objMasterApartmentBuildQuality.DeleteMasterApartmentBuildQualityById((int)id);
            return RedirectToAction("ManageApartmentBuildQuality");
        }

        [HttpGet, ActionName("ManageBuilderProfile")]
        public ActionResult ManageMasterBuilderProfile(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterBuilderProfile.GetAllData());
        }
        [HttpPost, ActionName("ManageBuilderProfile")]
        public ActionResult ManageMasterBuilderProfile(MasterBuilderProfile objMasterBuilderProfile)
        {
            bool isAdded = objMasterBuilderProfile.AddNewMasterBuilderProfile(objMasterBuilderProfile);
            return View(objMasterBuilderProfile.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterBuilderProfile")]
        public ActionResult DeleteMasterBuilderProfile(int? id)
        {
            bool isDeleted = objMasterBuilderProfile.DeleteMasterBuilderProfileById((int)id);
            return RedirectToAction("ManageBuilderProfile");
        }
        [HttpGet, ActionName("ManageConstructionQualityParameter")]
        public ActionResult ManageMasterConstructionQualityParameter(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterConstructionQualityParameter.GetAllData());
        }
        [HttpPost, ActionName("ManageConstructionQualityParameter")]
        public ActionResult ManageMasterConstructionQualityParameter(MasterConstructionQualityParameter objMasterConstructionQualityParameter)
        {
            bool isAdded = objMasterConstructionQualityParameter.AddNewMasterConstructionQualityParameter(objMasterConstructionQualityParameter);
            return View(objMasterConstructionQualityParameter.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterConstructionQualityParameter")]
        public ActionResult DeleteMasterConstructionQualityParameter(int? id)
        {
            bool isDeleted = objMasterConstructionQualityParameter.DeleteMasterConstructionQualityParameter((int)id);
            return RedirectToAction("ManageConstructionQualityParameter");
        }

        [HttpGet, ActionName("ManageInventory")]
        public ActionResult ManageMasterInventory(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterInventory.GetAllData());
        }
        [HttpPost, ActionName("ManageInventory")]
        public ActionResult ManageMasterInventory(MasterInventory objMasterInventory)
        {
            bool isAdded = objMasterInventory.AddNewMasterInventory(objMasterInventory);
            return View(objMasterInventory.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterInventory")]
        public ActionResult DeleteMasterInventory(int? id)
        {
            bool isDeleted = objMasterInventory.DeleteMasterInventoryById((int)id);
            return RedirectToAction("ManageInventory");
        }

        [HttpGet, ActionName("ManageLegalClarity")]
        public ActionResult ManageMasterLegalClarity(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterLegalClarity.GetAllData());
        }
        [HttpPost, ActionName("ManageLegalClarity")]
        public ActionResult ManageMasterLegalClarity(MasterLegalClarity objMasterLegalClarity)
        {
            bool isAdded = objMasterLegalClarity.AddNewMasterLegalClarity(objMasterLegalClarity);
            return View(objMasterLegalClarity.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterLegalClarity")]
        public ActionResult DeleteMasterLegalClarity(int? id)
        {
            bool isDeleted = objMasterLegalClarity.DeleteMasterLegalClarityById((int)id);
            return RedirectToAction("ManageLegalClarity");
        }

        [HttpGet, ActionName("ManageLivability")]
        public ActionResult ManageMasterLivability(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterLivability.GetAllData());
        }
        [HttpPost, ActionName("ManageLivability")]
        public ActionResult ManageMasterLivability(MasterLivability objMasterLivability)
        {
            bool isAdded = objMasterLivability.AddNewMasterLivability(objMasterLivability);
            return View(objMasterLivability.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterLivability")]
        public ActionResult DeleteMasterLivability(int? id)
        {
            bool isDeleted = objMasterLivability.DeleteMasterLivabilityById((int)id);
            return RedirectToAction("ManageLivability");
        }

        [HttpGet, ActionName("ManageProjectInformation")]
        public ActionResult ManageMasterProjectInformation(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterProjectInformation.GetAllData());
        }
        [HttpPost, ActionName("ManageProjectInformation")]
        public ActionResult ManageMasterProjectInformation(MasterProjectInformation objMasterProjectInformation)
        {
            bool isAdded = objMasterProjectInformation.AddNewMasterProjectInformation(objMasterProjectInformation);
            return View(objMasterProjectInformation.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterProjectInformation")]
        public ActionResult DeleteMasterProjectInformation(int? id)
        {
            bool isDeleted = objMasterProjectInformation.DeleteMasterProjectInformationById((int)id);
            return RedirectToAction("ManageProjectInformation");
        }

        [HttpGet, ActionName("ManageReview")]
        public ActionResult ManageMasterReview(int? id)
        {
            ViewBag.dataId = id;
            return View(objMasterReview.GetAllData());
        }
        [HttpPost, ActionName("ManageReview")]
        public ActionResult ManageMasterReview(MasterReview objMasterReview)
        {
            bool isAdded = objMasterReview.AddNewMasterReview(objMasterReview);
            return View(objMasterReview.GetAllData());
        }
        [HttpGet, ActionName("DeleteMasterReview")]
        public ActionResult DeleteMasterReview(int? id)
        {
            bool isDeleted = objMasterReview.DeleteMasterReviewById((int)id);
            return RedirectToAction("ManageReview");
        }
        [HttpGet, ActionName("DeleteUser")]
        public ActionResult DeleteUserByUserId(int? id)
        {
            if (id != null)
               objUser = objUser.GetUserByUserId((int)id);
            if (objUser != null)
                return View(objUser);
            return View();
        }
        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteUserByUserId(int id)
        {
            bool isDeleted = objUser.DeleteUserByUserId(id);
            if (isDeleted)
                return RedirectToAction("ViewAllUser");
            return View();
        }
        [HttpGet, ActionName("ViewAllReview")]
        public ActionResult ViewAllReview()
        {
            List<Review> reviewData = objReview.GetReviewDataForViewAllReview();
            return View(reviewData);
        }
        public ActionResult DeleteReview(int id)
        {
            bool isDeleted = objReview.DeleteReviewById(id);
            return RedirectToAction("ViewAllReview");
        }
    }
}
