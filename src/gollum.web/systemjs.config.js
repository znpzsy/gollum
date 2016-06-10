﻿(function (global) {
    // map tells the System loader where to look for things
    var map = {
        'app': 'app', // 'dist',
        'rxjs': 'node_modules/rxjs',
        '@angular': 'node_modules/@angular',
        'angular2-jwt': 'node_modules/angular2-jwt/angular2-jwt.js',
    };
    // packages tells the System loader how to load when no filename and/or no extension
    var packages = {
        'app': { main: 'bootstrapper.js', defaultExtension: 'js' },
        "angular2-jwt": { defaultExtension: 'js' },
        'rxjs': { defaultExtension: 'js' },
    };
    var packageNames = [
      '@angular/common',
      '@angular/compiler',
      '@angular/core',
      '@angular/http',
      '@angular/platform-browser',
      '@angular/platform-browser-dynamic',
      '@angular/router',
      '@angular/router-deprecated',
      '@angular/testing',
      '@angular/upgrade',
    ];
    // add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
    packageNames.forEach(function (pkgName) {
        packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
    });
    var config = {
        map: map,
        packages: packages
    }
    System.config(config);
})(this);
