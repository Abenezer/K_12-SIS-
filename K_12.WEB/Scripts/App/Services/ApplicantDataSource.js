define(['kendo'],
  function (kendo) {
        var crudServiceBaseUrl = "/odata/Application";

        return new kendo.data.DataSource({
            type: "odata",
            transport: {
                read: {
                    async: false,
                    url: crudServiceBaseUrl,
                    dataType: "json"
                },
                update: {
                    url: function (data) {
                        return crudServiceBaseUrl + "(" + data.ID + ")";
                    },
                    type: "put",
                    dataType: "json"
                },
                destroy: {
                    url: function (data) {
                        return crudServiceBaseUrl + "(" + data.ID + ")";
                    },
                    dataType: "json"
                }
            },
            batch: false,
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true,
            pageSize: 10,
            schema: {
                data: function (data) { return data.value; },
                total: function (data) { return data["odata.count"]; },
                model: customerModel
            },
            error: function (e) {
                alert(e.xhr.responseText);
            }
        });
    });