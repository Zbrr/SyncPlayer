/// <binding />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp"),
    less = require("gulp-less"),
    cleanCss = require("gulp-clean-css");

var paths = {
    webroot: "./wwwroot/app/"
};
 
paths.css = paths.webroot + "assets/css/**/*.css";
paths.less = paths.webroot + "assets/less/**/*.less";
paths.minCss = paths.webroot + "assets/css/";

gulp.task("less", function () {
    return gulp.src(paths.less)
            .pipe(less())
            .pipe(cleanCss())
            .pipe(gulp.dest(paths.minCss));
});