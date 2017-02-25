require.config({
    paths: {
        // Packages
        'jquery': '/scripts/jquery-1.10.2.min',
        'kendo': '/scripts/kendo/2015.3.1111/kendo.web.min',
        'text': '/scripts/text',
        'router': '/scripts/app/router'
    },
    shim: {
        'kendo': ['jquery']
    },
    priority: ['text', 'router', 'app'],
    jquery: '1.10.2',
    waitSeconds: 30
});
require([
  'app'
], function (app) {
    app.initialize();
});