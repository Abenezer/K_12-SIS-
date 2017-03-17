using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using K_12.Entity;
using K_12.BLL.Service;

namespace K_12.WEB
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container
               .RegisterType<K_12Entities, K_12Entities>(new PerRequestLifetimeManager())
               .RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager())
               .RegisterType<IAddressRepository, AddressRepository>()
               .RegisterType<IContactRepository, ContactRepository>()
               .RegisterType<IApplicantRepository, ApplicantRepository>()
                  .RegisterType<IDocumentRepository, DocumentRepository>()
                     .RegisterType<IPhonebookRepository, PhonebookRepository>()
                         .RegisterType<IGradeInfoRepository, GradeInfoRepository>()
                         .RegisterType<IParentRepository, ParentRepository>()
                         .RegisterType<IStudentRepository, StudentRepository>()



               //.RegisterType<IRepositoryAsync<Product>, Repository<Product>>()
               .RegisterType<IAddressService, AddressService>()
               .RegisterType<IContactService, ContactService>()
                .RegisterType<IApplicantService, ApplicantService>()
                .RegisterType<IDocumentService, DocumentService>()
                .RegisterType<IPhonebookService, PhonebookService>()
                  .RegisterType<IGradeInfoService, GradeInfoService>()

                  .RegisterType<IStudentService, StudentService>()
                   .RegisterType<IParentService, ParentService>()
                     .RegisterType<IAdmissionService, AdmissionService>()




               ;


            //.RegisterType<ICustomerService, CustomerService>()
            //.RegisterType<INorthwindStoredProcedures, NorthwindContext>(new PerRequestLifetimeManager())
            //.RegisterType<IStoredProcedureService, StoredProcedureService>();
        }
        
    }
}
