/// <binding />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp"),
    sass = require("gulp-sass"),
    cleanCss = require("gulp-clean-css");

var paths = {
    webroot: "./wwwroot/app/"
};
 
paths.css = paths.webroot + "assets/css/**/*.css";
paths.sass = paths.webroot + "assets/sass/**/*.scss";
paths.minCss = paths.webroot + "assets/css/";

gulp.task("sass", function () {
    return gulp.src(paths.sass)
            .pipe(sass())
            .pipe(cleanCss())
            .pipe(gulp.dest(paths.minCss));
});

gulp.task('watch', function () {
    return gulp.watch(paths.sass, ['sass']);
});