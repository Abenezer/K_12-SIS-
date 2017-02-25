﻿
define(['kendo'],
    function (kendo) {
        var router = new kendo.Router(),
            layout = new kendo.Layout("<div id='content'></div>");

        layout.render($("#app"));

        router.route("/", function () {
            require(['text!/home/index'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/home/index", function () {
            require(['text!/home/index'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/home/about", function () {
            require(['text!/home/about'], function (view) {
                loadView(null, view);
            });
        });

        router.route("/application/", function () {
            require(['text!/application/index'], function (view) {
                loadView(null, view);
            });
        });
        

            router.route("/application/applicationForm", function () {
                require(['text!/application/applicationForm'], function (view) {
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