
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