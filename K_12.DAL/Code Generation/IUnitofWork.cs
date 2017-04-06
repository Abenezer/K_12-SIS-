            using System;

public interface IUnitOfWork : IDisposable
{
    ISchoolRepository Schools { get; }
    IClassRepository Classs { get; }
    IStudentParentRepository student_parents { get; }
    IMedicationRepository Medications { get; }
    IApplicantRepository Applicants { get; }
    ISectionRepository Sections { get; }
    IBaseentityRepository BaseEntitys { get; }
    IApplicationRepository Applications { get; }
    ITeacherRepository Teachers { get; }
    ISubjectRepository Subjects { get; }
    IStaffclaimRepository StaffClaims { get; }
    IPersonRepository Persons { get; }
    IParentRepository Parents { get; }
    IActivityRepository Activitys { get; }
    IRegistrationRepository Registrations { get; }
    IPhonebookRepository PhoneBooks { get; }
    IDocumentRepository Documents { get; }
    IStudentSectionRepository student_sections { get; }
    IStudentMedicationRepository student_medications { get; }
    IAddressRepository Addresss { get; }
    ILanguageRepository Languages { get; }
    IStudentRepository Students { get; }
    IContactRepository Contacts { get; }
    IGradeInfoRepository Grade_Infos { get; }
    void Save();
System.Threading.Tasks.Task<int> SaveAsync();
    
}
