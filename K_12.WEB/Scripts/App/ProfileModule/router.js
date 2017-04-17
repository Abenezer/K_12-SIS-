
define(['kendo_mvc'],
    function (kendo) {
        var router = new kendo.Router(),
            layout = new kendo.Layout("<div id='content'></div>");

        layout.render($("#app"));

        router.route("/", function () {
            require(['text!/Profile/main'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/class/:section_id/:subject_id", function (section_id,subject_id) {
            require(['text!/Teacher/Classes?section_id='+section_id+"&&subject_id="+subject_id], function (view) {
                loadView(null, view);
            });
        });


        router.route("/student/:id", function (student_id) {
            require(['text!/Parent/Student/'+student_id], function (view) {
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