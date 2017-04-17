
define(['kendo_mvc'],
    function (kendo) {
        var router = new kendo.Router(),
            layout = new kendo.Layout("<div id='content'></div>");

        layout.render($("#app"));

        router.route("/", function () {
            require(['text!/home/main'], function (view) {
                loadView(null, view);
            });
        });

       

        router.route("/home/about", function () {
            require(['text!/home/about'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/application", function () {
            require(['text!/application/index'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/application/check", function () {
            require(['text!/application/CheckApplication'], function (view) {
                loadView(null, view);
            });
        });

        //router.route("/application/result/:id", function (id) {
        //    require(['text!/application/ApplicationResult/'+id], function (view) {
        //        loadView(null, view);
        //    });
        //});

        router.route("/admission", function () {
            require(['text!/admission/index'], function (view) {
                loadView(null, view);
            });
        });
        
       

        router.route("/admission/:appID", function (appID) {
            require(['text!/admission/index?appId='+appID], function (view) {
                loadView(null, view);
            });
        });



 router.route("/admin/processApplication", function () {
     require(['text!/admin/processApplication'], function (view) {
                loadView(null, view);
            });
        });
        
 router.route("/admin/ConfigureAdmission", function () {
     require(['text!/admin/ConfigureAdmission'], function (view) {
                loadView(null, view);
            });
        }); 
    router.route("/admin/Sections", function () {
     require(['text!/admin/Sections'], function (view) {
                loadView(null, view);
            });
        });      
    router.route("/Registration/AssignSection", function () {
        require(['text!/Registration/AssignSection'], function (view) {
                loadView(null, view);
            });
        });      
    router.route("/Staff/Claim", function () {
        require(['text!/Staff/Claim'], function (view) {
                loadView(null, view);
            });
    });

            router.route("/Staff/Register", function () {
        require(['text!/Staff/Register/20'], function (view) {
                loadView(null, view);
            });
        });   
            router.route("/Admin/StaffClaims", function () {
                require(['text!/Admin/StaffClaims'], function (view) {
                loadView(null, view);
            });
        });   
            router.route("/Admin/Classes", function () {
                require(['text!/Admin/Classes'], function (view) {
                loadView(null, view);
            });
        });
        var loadView = function (viewModel, view, delegate) {
            var kendoView = new kendo.View(view, { model: viewModel });
            kendo.fx($("#content")).slideInRight().reverse().then(function () {
                layout.showIn("#content", kendoView);

                if (delegate != undefined)
                    delegate();

                kendo.fx($("#content")).slideInRight().play();
            });
        };

        return router;
    });