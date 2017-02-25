


//module.exports = {
//    //context: path.join(__dirname, 'Scripts'),
//    modulesDirectories: ['Scripts'],
//    entry: './Scripts/app/main.js',

  
//    resolve: {
//        alias: {
//            'jquery': '/scripts/jquery-1.10.2.min',
//            'kendo': '/scripts/kendo/2017.1.118/kendo.web.min',
//            'text': '/scripts/text',
//            'router': '/scripts/app/router'
//        }           
//    },



//    output: {
//        path: path.join(__dirname, 'Built'),
//        filename: '[name].bundle.js'
//    }
//};

var path = require('path');
module.exports = {
    resolve: {
        extensions: ['', '.js', '.min.js'],
        root: [
            path.resolve('.'),
            path.resolve('./scripts/kendo/2017.1.118/') // the path to the minified scripts
        ]
    },
        

    //},
    entry: './scripts/app/main',
    output: {
        filename: 'built/bundle.js'
    }
}