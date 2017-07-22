/// <binding BeforeBuild='less' />
"use strict";

var gulp = require("gulp"),
  fs = require("fs"),
  less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('Styles/*.less')
      .pipe(less())
      .pipe(gulp.dest('wwwroot/css'));
});
gulp.task('watch', function () {
    gulp.watch('Styles/*.less', ['less']);

})