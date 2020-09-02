

let gulp = require('gulp');
let gnf = require('gulp-npm-files');

let concat = require('gulp-concat');

// gulp.task('default', defaultTask)

// function defaultTask(done) {
//     console.log('default Task in Gulp');
//     // place code for your default task here
//     done();
// }

gulp.task('copynpm', function (done) {
    gulp.src(gnf(), { base: './' }).pipe(gulp.dest('./wwwroot'));
    done();
})
