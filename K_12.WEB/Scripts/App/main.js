require.config({
    
    paths: {
        // Packages
        'jquery': '/scripts/jquery-1.10.2.min',
        'kendo': '/scripts/kendo/2015.3.1111/kendo.all.min',
        'kendo_mvc': '/scripts/kendo/2015.3.1111/kendo.aspnetmvc.min',
        'text': '/scripts/text',
        'router': '/scripts/app/router',
        'profRouter': '/scripts/app/ProfileModule/router',
        'domain': '/scripts/app/domain'
    },
    shim: {
       
        'kendo_mvc' : ['kendo'],
         'kendo': ['jquery']
        
    },
    priority: ['text', 'router', 'app','profApp'],
    jquery: '1.10.2',
    waitSeconds: 30
});
