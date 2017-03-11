define(['kendo'],
  function (kendo) {
      var applicantModel = kendo.data.Model.define({
          id: "ID",
          fields: {
              ID: { type: "int", editable: false, nullable: false },
              FName: { title: "First Name", type: "string" },
              LName: { title: "LastName", type: "string" },
              
          }
      });
      return applicantModel;
  });