﻿



using System.Web.Http;
using System.Web.Http.OData.Builder;


namespace K_12.WEB
{
    public static class ODataConfig
    {


        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Entity.Address>("Address");
            builder.EntitySet<Entity.Contact>("Contact");
            builder.EntitySet<Entity.PhoneBook>("PhoneBook");
            builder.EntitySet<Entity.Document>("Document");
            builder.EntitySet<Entity.Applicant>("Application");
            builder.EntitySet<Entity.Grade_Info>("GradeInfo");

            //builder.EntitySet<Entities.Models.Customer>(typeof(Entities.Models.Customer).Name);
            //builder.EntitySet<Entities.Models.Order>(typeof(Entities.Models.Order).Name);

            //var orderDetailBuilder = builder.EntitySet<Entities.Models.OrderDetail>(typeof(Entities.Models.OrderDetail).Name);
            //orderDetailBuilder.EntityType.HasKey(x => x.ProductID);

            //var customerDemographicBuilder = builder.EntitySet<Entities.Models.CustomerDemographic>(typeof(Entities.Models.CustomerDemographic).Name);
            //customerDemographicBuilder.EntityType.HasKey(x => x.CustomerDesc);

            //var productBuilder = builder.EntitySet<Entities.Models.Product>(typeof(Entities.Models.Product).Name);
            //productBuilder.EntityType.HasKey(t => t.ProductID);

            //builder.EntitySet<Entities.Models.Category>(typeof(Entities.Models.Category).Name);
            //builder.EntitySet<Entities.Models.Supplier>(typeof(Entities.Models.Supplier).Name);

            //builder.EntitySet<Entities.Models.Employee>(typeof(Entities.Models.Employee).Name);
            //builder.EntitySet<Entities.Models.Shipper>(typeof(Entities.Models.Shipper).Name);


            //  config.Routes.MapODataRoute("odata", "odata", model);



            //config.MapODataServiceRoute(
            //routeName: "odata",
            //routePrefix: "odata",
            //model: builder.GetEdmModel());

            //config.AddODataQueryFilter();

            var model = builder.GetEdmModel();
            config.Routes.MapODataRoute("odata", "odata", model);

            config.EnableQuerySupport();
            config.MapHttpAttributeRoutes();
            


        }

    }

    }
